using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Services
{
    public class FileServiceProxy : IFileService
    {
        private FileService _fileService;
        public bool IsAuthorized { get; set;}
        public FileServiceProxy()
        {
            _fileService = FileService.Instance;
        }
        public void CopyFile(string file)
        {
            if(IsAuthorized)
            {
                _fileService.CopyFile(file);
            }
            else throw new Exception("Unahuthorized opperation");
        }
        public void DeleteFile(string file)
        {
            if (IsAuthorized)
            {
                _fileService.DeleteFile(GetFilePath(file));
            }
            else throw new Exception("Unahuthorized opperation");
        }

        public string GetFilePath(string file)
        {
            return _fileService.GetFilePath(file);
        }

    }
}
