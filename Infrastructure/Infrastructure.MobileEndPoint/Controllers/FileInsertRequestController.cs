using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Core.Entities.GlobalSettings;
using Core.Mongo.Contracts;
using Core.Entities.Mongo.Enums;
using Core.Entities.Mongo;
using System;
using Core.Entities.Dto;
using Core.ApplicationServices;

namespace Infrastructure.EndPoint.Controllers
{
    public class FileInsertRequestController : SimpleController
    {
        private IUnitOfWork unit;
        private readonly IHostingEnvironment hosting;
        private readonly IGetByIdFileRequest getByIdFileRequest;
        private readonly IListFileRequest listFileRequest;
        private readonly IDeleteFileRequest deleteFileRequest;

        public string HostLocation { get; set; }

        public FileInsertRequestController(IUnitOfWork _unit,
            IHostingEnvironment hosting ,
            IGetByIdFileRequest getByIdFileRequest,
            IListFileRequest listFileRequest,
            IDeleteFileRequest deleteFileRequest
            )
        {
        

            unit = _unit;
            this.hosting = hosting;
            this.getByIdFileRequest = getByIdFileRequest;
            this.listFileRequest = listFileRequest;
            this.deleteFileRequest = deleteFileRequest;
        }



        [HttpGet]
        public ActionResult<GetByIdFileRequestResultDto> GetById([FromQuery] GetByIdFileRequestDto dto)
        {
            return getByIdFileRequest.Execute(dto);


        }

        [HttpGet]
        public ActionResult<ListFileRequestResultDto> List([FromQuery] ListFileRequestDto dto)
        {
            return listFileRequest.Execute(dto);
        }


        [HttpDelete]
        public ActionResult<DeleteFileRequestResultDto> Delete([FromQuery] DeleteFileRequestDto dto)
        {
            return deleteFileRequest.Execute(dto);
        }



        [HttpPost]
        public ShortFile SendDocument([FromForm]FileTypes type ,[FromForm] IFormFile file)
        {
            //var file = Request.Form.Files[0];
            Guid guid = SaveImage(file,type);
            return new ShortFile { Id = guid , Location = HostLocation,Type = type };
        }





    

        private Guid SaveImage(IFormFile file, FileTypes type)
        {


            string extension = Path.GetExtension(file.FileName);

            Guid guid = Guid.NewGuid();
            string fileName = guid.ToString() + extension;
            var HardLocation = hosting.WebRootPath + "/File" + $"/{fileName}";
            HostLocation =  "/File" + $"/{fileName}";





            if (file.Length > 0)
            {
                //file = ImageHelper.ChangeImageAsync(file, hosting.WebRootPath + "/watermark.png").Result;
                using (var fileStream = new FileStream(HardLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }





            Core.Entities.Mongo.FileRequest zFile = new Core.Entities.Mongo.FileRequest
            {
                Id = guid,
                Location = HostLocation,
                CreatedAt = DateTime.Now.ToUnix(),
                Type = ((int)type),
                Status = FileRequestStatus.Pending.ToInt(),
                Title = file.FileName

            };


            unit.FileRequest.Insert(zFile);

            return guid;
        }
    }
}
