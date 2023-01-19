using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Enviostisur.Provider;

namespace Enviostisur.Helpers
{
    public class HelpersUpload
    {


        public HelpersUpload()
        {
            
        }

        public async Task<String> UploadFilesAsync(IFormFile formFile, string path)
        {
            try
            {                           
                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    await formFile.CopyToAsync(stream);
                }
                return path;
            }
            catch (Exception ex)
            {

                throw ex;
            }
         
           
        }

    }
}
