using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Services
{
    public interface IFileService
    {
        public  abstract void CopyFile(string file);
        public abstract void DeleteFile(string file);
        public abstract string GetFilePath(string file);

    }
}
