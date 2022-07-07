using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Application.ViewModels.UploadArquivosViewModel
{
    public class ReadsStraem
    {
        public byte[] ReadStraem(IFormFile formFile)
        {
            if (formFile == null) return null;

            using (var stream = new MemoryStream())
            {
                formFile?.CopyTo(stream);
                   var byteArray = stream.ToArray();
                   return byteArray;
               // return stream;
            }
        }
    }
}
