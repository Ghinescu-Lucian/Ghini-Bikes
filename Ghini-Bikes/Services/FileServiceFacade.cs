using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Services
{
    public class FileServiceFacade
    {
        public void CopyFile(string filePath)
        {
            var file = FileService.Instance;
            file.CopyFile(filePath);
        }
        public void DeleteFile(string filename)
        {
            var file = FileService.Instance;
            file.DeleteFile(file.GetFilePath(filename));
        }
    }
}
