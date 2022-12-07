using System;
using System.Collections.Generic;
using System.Drawing;

namespace Core.Entities.Mongo.Dto
{
    public class QrCodeDto
    {
        public Guid Id{ get; set; }
        public Bitmap QrCodeImage{ get; set; }
    }
}
