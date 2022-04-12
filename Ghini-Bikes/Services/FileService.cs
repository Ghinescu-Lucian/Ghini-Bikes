﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ghini_Bikes.Services
{
    /*
     * LoggerService
     * 
     * */
    public class FileService : IFileService
    {
        private static FileService _instance;
        private static readonly object padlock = new object();

        private FileService()
        {
            //System.Console.WriteLine("Constructor called");
        }
        /// <summary>
        /// 
        /// </summary>
        public static FileService Instance
        {
            get
            {
                if (_instance == null)
                {
                    //System.Console.WriteLine("Instance called");
                    lock (padlock)
                    {
                        if (_instance == null)
                        {
                            _instance = new FileService();
                        }
                    }
                }
                return _instance;
            }
            private set { }
        }
        private const string directoryPathPhotos = "C:\\Users\\ghine\\Desktop\\Facultate\\Amdaris\\Proiect\\Ghini-Bike\\Ghini-Bikes\\Ghini-Bikes\\Pictures";

        public void CopyFile(string filePathSRC)
        {
            var name = Path.GetFileNameWithoutExtension(filePathSRC) + "_copy";
            var extension = Path.GetExtension(filePathSRC);
            var newFileName = name + extension;
            var newFilePath = Path.Combine(directoryPathPhotos, newFileName);
            try
            {
                File.Copy(filePathSRC, newFilePath);
                Console.WriteLine("Copied successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void DeleteFile(string filePathSRC)
        {
            if (string.IsNullOrEmpty(filePathSRC))
            {
                Console.WriteLine("File path is null");
                return;
            }
            FileInfo fileInfo = new FileInfo(filePathSRC);
            try
            {
                fileInfo.Delete();
                Console.WriteLine("Deleted successfully");
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        // private
        public string GetFilePath(string fileName)
        {
            var dir = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(dir);
            DirectoryInfo baseDirectory = directory.Parent.Parent.Parent;

            string pathDirecotry = Path.Combine(baseDirectory.FullName, "Pictures");
            string filePath = Path.Combine(pathDirecotry, fileName);

            return filePath;
        }

    }
}
