using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File_Logic
{
    public class FileLogic
    {
        private readonly string path;

        public FileLogic(string _systemPath)
        {
            path = _systemPath;
        }

        public string SetFile(string _base64String, string _fileName)
        {
            if (Directory.Exists(path))
            {
                string fileName = path + _fileName;
                File.WriteAllBytes(fileName, Convert.FromBase64String(_base64String));
                return fileName;
            }
            return "directory not found";
        }

        public string GetFile( string FileName)
        {
            string filePath = path + FileName;
            if (File.Exists(filePath)){
                return filePath;
            }
            return "";
        }
    }
}
