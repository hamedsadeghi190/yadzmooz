using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Core.Entities.GlobalSettings;
using Core.Mongo.Contracts;
using Core.Entities.Mongo.Enums;
using Core.Entities.Mongo;
using System;

namespace Infrastructure.EndPoint.Controllers
{
    public class DocumentController : SimpleController
    {
        private IUnitOfWork unit;
        private readonly IHostingEnvironment hosting;

        public string HostLocation { get; set; }

        public DocumentController(IUnitOfWork _unit, IHostingEnvironment hosting)
        {
            unit = _unit;
            this.hosting = hosting;
        }
        //[HttpGet]
        //public async Task<IActionResult> GetDocument(Guid Id)
        //{
        //    //var doc = unit.Documents.Get(Id);

        //    //if (doc.DocumentType == DocumentType.Image.ToInt())
        //    //    return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "image/jpeg");
        //    //else if (doc.DocumentType == DocumentType.Video.ToInt())
        //    //    return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "video/mp4");
        //    //else if (doc.DocumentType == DocumentType.Document.ToInt())
        //    //    return PhysicalFile(hosting.WebRootPath + "\\Documents\\" + Path.GetFileName(doc.Location), "application/octet-stream");
        //    return null;
        //}
        //[HttpGet]
        //public async Task<DocumentResultDto> GetDocumentAddress(Guid Id)
        //{
        //    //var doc = unit.Files.Get(Id);
        //    //return new DocumentResultDto { Address = doc.Location};
        //    return null;
        //}


        [HttpPost]
        public ShortFile SendDocument([FromForm]FileTypes type)
        {
            var file = Request.Form.Files[0];
            Guid guid = SaveImage(file,type);
            return new ShortFile { Id = guid , Location = HostLocation,Type = type };
        }
        //[HttpPost]
        //public string SendImages()
        //{
        //    List<ImageDto> Images = new List<ImageDto>();
        //    Request.Form.Files.ToList().ForEach(p =>
        //    {
        //        var guid = SaveImage(p);
        //        Images.Add(new ImageDto { Id = guid,Name = p.Name});
        //    });
        //    return Agent.ToJson( Images );
        //}

        private Guid SaveImage(IFormFile file, FileTypes type)
        {


            string extension = Path.GetExtension(file.FileName);

            Guid guid = Guid.NewGuid();
            string fileName = guid.ToString() + extension;
            var HardLocation = hosting.WebRootPath + "/Documents" + $"/{fileName}";
            HostLocation = AdminSettings.Root + "/Documents" + $"/{fileName}";


            if (file.Length > 0)
            {
                //file = ImageHelper.ChangeImageAsync(file, hosting.WebRootPath + "/watermark.png").Result;
                using (var fileStream = new FileStream(HardLocation, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            Core.Entities.Mongo.File img = new Core.Entities.Mongo.File
            {
                Id = guid,
                Location = HostLocation,
                CreatedAt = DateTime.Now.ToUnix(),
                Type = type
            };
            //unit.Files.Insert(img);
            
            return guid;
        }
    }
}
