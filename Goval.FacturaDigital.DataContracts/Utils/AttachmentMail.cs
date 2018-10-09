using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goval.FacturaDigital.DataContracts.Utils
{
    public class AttachmentMail
    {
        public String FileName { get; set; }
        public Stream FileData { get; set; }
    }
}
