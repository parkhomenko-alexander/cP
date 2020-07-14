using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cP
{
    public class fileRW
    {   

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

        public StreamWriter openWriter(string path)
        {
            if (checkDirectory(path) == true)
            {
                writer = new StreamWriter(path, false);
                return writer;
            }
            else
            {
                return writer = null;
            }
        }

        public StreamWriter closeWriter(string path)
        {
            if (checkDirectory(path) == true)
            {
                if (writer != null)
                {
                    writer.Close();
                }
                return writer = null;
            }
            return writer = null;
        }

        //парсер строк
        public string[] readerPars(string tmp)
        {
            string[] words = tmp.Split(new[] {"; " },  System.StringSplitOptions.None);
            return words;
        }

        //перегруженный для ХТ
        public string[] readerPars(string tmp, int signature)
        {
            string[] words = tmp.Split(new[] { "; " }, System.StringSplitOptions.None);
            Array.Resize(ref words, words.Length + 1);
            words[words.Length - 1] = words[words.Length - 2];
            words[words.Length - 2] = words[words.Length - 3];
            words[words.Length - 3] = words[words.Length - 4];
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

        public StreamReader reader;
        public StreamWriter writer;
    }
}
