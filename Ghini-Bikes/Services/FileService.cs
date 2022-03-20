using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Services
{
    public static class FileService
    {
        private const string directoryPathPhoto = "C:\\Users\\ghine\\Desktop\\Facultate\\Amdaris\\Proiect\\Ghini-Bike\\Ghini-Bikes\\Ghini-Bikes\\Pictures";
        
        public static void CopyPicture(string filePathSRC)
        {
            var name = Path.GetFileNameWithoutExtension(filePathSRC) + "_copy";
            var extension = Path.GetExtension(filePathSRC);
            var newFileName = name + extension;
            var newFilePath = Path.Combine(directoryPathPhoto,newFileName);
            var fileStream = File.Create(newFilePath);
            fileStream.Close();

            byte[] buffer = File.ReadAllBytes(filePathSRC);
            File.WriteAllBytes(newFilePath, buffer);
            
        }
        public static void CopyFile(string filePathSRC)
        {
            var name = Path.GetFileNameWithoutExtension(filePathSRC) + "_copy";
            var extension = Path.GetExtension(filePathSRC);
            var newFileName = name + extension;
            var newFilePath = Path.Combine(directoryPathPhoto, newFileName);


            try
            {
                var sr = new StreamReader(filePathSRC);
                var fileStream = File.Create(newFilePath);
                var sw = new StreamWriter(fileStream);
                var read = true;
                while (read)
                {
                    var line = sr.ReadLine();
                    if (string.IsNullOrEmpty(line))
                        read = false;
                    sw.WriteLine(line);
                }
                sw.Close();
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        
        public static void DeleteFile(string filePathSRC)
        {
            FileInfo fileInfo = new FileInfo(filePathSRC);
            fileInfo.Delete();
          
        }

    }
}
