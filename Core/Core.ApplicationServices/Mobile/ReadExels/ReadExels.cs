using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class ReadExels : IReadExels
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;
        private readonly IAddChallenge create;
        private readonly IHostingEnvironment hosting;
        //private readonly IWebHostEnvironment _appEnvironment;


        public ReadExels
            (
            IUnitOfWork unit,
            IJwtHandler jwtHandler,
            IHostingEnvironment hosting,
            IAddChallenge create
            //IWebHostEnvironment appEnvironment
            )
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
            this.hosting = hosting;
            this.create = create;
            //_appEnvironment = appEnvironment;
        }


        public DeleteLanguageResultDto Execute()
        {
            //this.unit.Challenges.GetBySubCategory();

            

            string path = Path.Combine(hosting.WebRootPath, "1.txt");
            string newPath = Path.Combine(hosting.WebRootPath, "2.txt");
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
          
            var challenges = unit.Challenges.GetAll();

            foreach (var item in challenges)
            {
                try
                {
                    var id = Guid.NewGuid();
                    if (System.IO.File.Exists(hosting.WebRootPath + $"/{item.Word.Replace('?' , '_')}.mp3"))
                    {

                        foreach (var opt in item.Options)
                        {
                            System.IO.File.Move(hosting.WebRootPath +  $"/{item.Word.Replace('?', '_')}.mp3", hosting.WebRootPath + $"/{id}.mp3");

                            opt.Image = "/Documents/" + id.ToString() + ".mp3";
                        }
                    }

                    unit.Challenges.Replace(item);
                }
                catch (Exception ex)
                {

                }

            }




            //var challange = unit.Challenges.getByWord("And you?");

           











            return new DeleteLanguageResultDto
            {
                Code = 0,
                IsSuccess = true,
                Message = Messages.Success
            };

        }
    }
}
