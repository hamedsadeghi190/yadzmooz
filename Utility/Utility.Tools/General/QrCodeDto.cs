using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace Utility.Tools.General
{
    public class QrCodeDto
    {
        public string Id { get; set; }
        public Bitmap QrCodeImage { get; set; }
    }
}
