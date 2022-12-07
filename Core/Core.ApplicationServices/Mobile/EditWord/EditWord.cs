using Core.Entities.Dto;
using Core.Entities.Functions;
using Core.Entities.GlobalSettings;
using Core.Entities.Mongo;
using Core.Entities.Mongo.Dto;
using Core.Mongo.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Utility.Tools.Auth;
using Utility.Tools.General;

namespace Core.ApplicationServices
{
    public class EditWord : IEditWord
    {
        private readonly IUnitOfWork unit;
        private readonly IJwtHandler jwtHandler;

        public EditWord
            (
            IUnitOfWork unit
, IJwtHandler jwtHandler)
        {
            this.unit = unit;
            this.jwtHandler = jwtHandler;
        }


        public EditWordResultDto Execute(EditWordDto dto)
        {

            var cat = unit.Words.GetById(dto.Id);
            cat.SubCategoryId = dto.SubCategoryId;
            cat.CategoryId = dto.CategoryId;
            cat.Meaning = dto.Meaning;

            cat.Word = dto.Word;
            cat.VoiceFile = dto.VoiceFile;
            cat.ImageFile = dto.ImageFile;


            unit.Words.Replace(cat);


            return new EditWordResultDto 
            {
                Code  = 0,
                IsSuccess = true,
                Message = Messages.OK
                 
            };
        }
    }
}
