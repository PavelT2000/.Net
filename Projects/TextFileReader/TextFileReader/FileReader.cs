using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextFileReader
{
    internal class FileReader
    {
        public FileReader()
        {
        }

        public string ReadFile(string path)
        {
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            else
            {
                throw new Exception($"Файл по пути:{path} не найден");
            }

        }
    }
}
