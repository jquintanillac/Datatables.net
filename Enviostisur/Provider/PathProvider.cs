using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System.IO;
using Enviostisur.Data.Datasql;

namespace Enviostisur.Provider
{
    public class PathProvider
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PathProvider(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string MapPath(string fileName)
        {
            string uniquefilename = "";
            string filename1 = "";
            uniquefilename = Guid.NewGuid().ToString() + "_" + fileName;            
            filename1 = $"{_webHostEnvironment.WebRootPath}\\Antepuerto\\{uniquefilename}";
            string path = Path.Combine(_webHostEnvironment.WebRootPath, filename1);

            return path;
        }
    }
}
