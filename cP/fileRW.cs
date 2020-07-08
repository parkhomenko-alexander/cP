using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fileRWSpace
{
    class fileRW
    {   
        public StreamReader reader;

        //проверка наличия файла в директории
        public bool checkDirectory(string path)
        {
            if (File.Exists(path) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //подключение ридера к файлу
        public StreamReader openReader(string path)
        {
            if (checkDirectory(path) == true)
            {
                reader = new StreamReader(path);
                return reader;
            }
            else
            {
                return reader = null;
            }
        }

        //парсер строк
        public string[] readerPars(string tmp)
        {
            string[] words = tmp.Split(' ');
            return words;
        }

        //отключение ридера
        public StreamReader closeReader()
        {
            if (reader != null)
            {
                reader.Close();
            }
            return reader = null;
        }
    }
}
