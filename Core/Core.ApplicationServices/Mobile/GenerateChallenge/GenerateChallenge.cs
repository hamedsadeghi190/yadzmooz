using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Entities.Mongo.Enums;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class GenerateChallenge : IGenerateChallenge
    {
        private readonly IUnitOfWork unit;

        private readonly IJwtHandler jwtHandler;

        public GenerateChallenge
            (
            IUnitOfWork unit

, IJwtHandler jwtHandler)
        {
            this.unit = unit;

            this.jwtHandler = jwtHandler;
        }


        public void Execute(Words words)
        {


            var challenges = new List<Challenge>();




            challenges.Add(CreateDragAndDrop(words));
            challenges.Add(CreateCompleteTheWord(words));
            challenges.Add(CreateTrueOrFalse(words));
            challenges.Add(CreateSecoundCompleteTheWord(words));
            challenges.Add(CreateThirdCompleteTheWord(words));




            if (words.Word.Length < 9)
            {
                challenges.Add(CreatePatern(words));

            }
            challenges.Add(CreateParing(words));


            if (challenges.Count > 0)
            {


                unit.Challenges.InsertMany(challenges);



                //foreach (var item in challenges)
                //{
                //    unit.Challenges.Insert(item);
                //    unit.SubCategories.AddChallengeToSubCategory(item.Id, item.SubCategoryId);
                //}


            }

            challenges = new List<Challenge>();


        }


        public static string RandomString(int length, int languageUtc)
        {


            var chars = "";

            if (languageUtc == LanguageUtc.Latin.ToInt())
            {
                chars = "abcdefghijklmnopqrstuvwxyz";
            }
            else if (languageUtc == LanguageUtc.Arabic.ToInt())
            {
                chars = "يوهنملكقفغعظطضصشسزرذدخحجثتبا";
            }else if(languageUtc == LanguageUtc.Persian.ToInt())
            {
                chars = "ابپتثجچحخدذرزژسشصضطظعغفقکگلمنوهیي";
            }
            else
            {
                chars = "abcdefghijklmnopqrstuvwxyz";
            }


            




            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[new Random().Next(s.Length)]).ToArray());
        }




        public Challenge CreateDragAndDrop(Words word)
        {
            int countOfOptions = ((new Random().Next(1,11) % 2) == 0) ? 4 : 2;


            var otherOptions = unit.Words.FindBySubCateoryId(word.SubCategoryId);

            var options = new List<ChallengeOptions>();

            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,
                
            };

            options.Add(correct);

            for (int i = 0; i < countOfOptions-1; i++)
            {
                options.Add(DtoBuilder.CreateChallengeOptionsByWord(otherOptions[new Random().Next(otherOptions.Count - 1)]));
            }

        
            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateDragAndDropTitle,
                Type = ChallangeType.DragAndDrop.ToInt()

            };
        }


      

        public static Challenge CreateCompleteTheWord(Words word)
        {


            List<string> words = word.Word.Select(c => c.ToString()).ToList(); 


            //var words = ChunksUpto(word.Word, word.Word.Length <= 4  ?  new Random().Next(word.Word.Length) : 2  ).ToList();




            var options = new List<ChallengeOptions>();



            for (int i = 0; i < words.Count; i++)
            {
                options.Add(new ChallengeOptions
                {
                    Word = words[i],
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Index = i + 1
                });
            }

            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,
            };


            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateCompleteTheWordFirstTitle,
                Type = ChallangeType.CompleteTheWordFirst.ToInt()

            };
        }
        public  Challenge CreateTrueOrFalse(Words word)

        {
            int countOfOptions = ((new Random().Next(1, 11) % 2) == 0) ? 2 : 1;
            var options = new List<ChallengeOptions>();
            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,

            };
            if (countOfOptions == 2)
            {
                options.Add(correct);
                var otherOptions = unit.Words.FindBySubCateoryId(word.SubCategoryId);
                options.Add(DtoBuilder.CreateChallengeOptionsByWord(otherOptions[new Random().Next(otherOptions.Count - 1)]));
            }else
            {
                options.Add(correct);
            }




            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateTrueOrFalseTitle,
                Type = ChallangeType.TrueOrFalse.ToInt()

            };
        }
        public static Challenge CreateSecoundCompleteTheWord(Words word)

        {



            int countOfOptions = ((new Random().Next(4, 7) % 2) == 0) ? 2 : 1;

            var options = new List<ChallengeOptions>();


            for (int i = 0; i < countOfOptions; i++)
            {
                var letter = RandomString(1, word.LanguageUtc);

                options.Add(new ChallengeOptions
                {
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Word = letter
                });
               
            }

            var wor = word.Word.ToList();

            foreach (var item in wor)
            {
                options.Add(new ChallengeOptions
                {
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Word = item.ToString()
                });
            }



            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,

            };

            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateSecoundCompleteTheWord,
                Type = ChallangeType.CompleteTheWordSecound.ToInt()

            };
        }
        public static Challenge CreateThirdCompleteTheWord(Words word)

        {

            int countOfOptions = ((new Random().Next(4, 7) % 2) == 0) ? 2 : 1;

            var options = new List<ChallengeOptions>();


            var wor = word.Word.ToList();

            for (int i = 0; i < wor.Count; i++)
            {
                options.Add(new ChallengeOptions
                {
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Word = wor[i].ToString(),
                    Index = i + 1,
                    IsCorrecr = true,
                    
                });


                for (int j = 0; j < 5; j++)
                {
                    options.Add(new ChallengeOptions
                    {
                        Id = Guid.NewGuid(),
                        Image = null,
                        PairId = null,
                        Voice = null,
                        Word = RandomString(1,word.LanguageUtc),
                        Index = i + 1,
                        IsCorrecr = false

                    });
                }
            }



            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,

            };

            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateSecoundCompleteTheWord,
                Type = ChallangeType.CompleteTheWordThird.ToInt()

            };
        }
        public static Challenge CreatePatern(Words word)

        {

            int countOfOptions = 9 - word.Word.Length;



            var options = new List<ChallengeOptions>();


            for (int i = 0; i < countOfOptions; i++)
            {
                var letter = RandomString(1,word.LanguageUtc);

                options.Add(new ChallengeOptions
                {
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Word = letter,
                    IsCorrecr = false
                });

            }

            var wor = word.Word.ToList();

            foreach (var item in wor)
            {
                options.Add(new ChallengeOptions
                {
                    Id = Guid.NewGuid(),
                    Image = null,
                    PairId = null,
                    Voice = null,
                    Word = item.ToString(),
                    IsCorrecr = true
                });
            }



            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,

            };

            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreatePatern,
                Type = ChallangeType.Pattern.ToInt()

            };
        }

        public  Challenge CreateParing(Words word)

        {



            int countOfOptions = ((new Random().Next(4,11)));

            var otherOptions = unit.Words.FindBySubCateoryId(word.SubCategoryId);

            var options = new List<ChallengeOptions>();

            var correct = new ChallengeOptions
            {
                Id = Guid.NewGuid(),
                Image = word.ImageFile,
                Voice = word.VoiceFile,
                Word = word.Word,

            };

            for (int i = 0; i < countOfOptions; i++)
            {
                options.Add(DtoBuilder.CreateChallengeOptionsByWord(otherOptions[new Random().Next(otherOptions.Count - 1)]));

            }


            return new Challenge
            {
                Word = word.Word,
                CorrectAnswer = correct,
                CreatedAt = Agent.Now,
                Id = Guid.NewGuid(),
                Meanings = word.Meaning,
                Options = options,
                SubCategoryId = word.SubCategoryId,
                Title = Messages.CreateParingTitle,
                Type = ChallangeType.Pairing.ToInt()

            };
        }
    }
}
