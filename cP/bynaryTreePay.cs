using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace bynaryTreePaySpace
{   enum post 
    {
        Директор,
        Экономист, 
        Менеджер,
        Программист, 
        Инженер,
        Уборщица
    }

    class payInfo
    {   
        //конструктор по умолчанию
        payInfo()
        {
            post = "Нет должности";
            payRate = 12130;
            coefficient = 0.2;
        }
        //конструктор с параметрами
        public payInfo(string s, double pR, double c)
        {
               post = s;
               payRate = pR;
               coefficient = c;
        }
        //финализатор
        ~payInfo()
        {
            post = null;
            payRate = 0;
            coefficient = 0;
        }
        
        //поля класса
        public string post { get; set; }
        public double payRate { get; set; }
        public double coefficient { get; set; }
    }

    class bynaryTreeNode
    {
        private payInfo info { get; set; }
        private bynaryTreeNode left { get; set; }
        private bynaryTreeNode rigt { get; set; }
    }

    class bynaryTreePay
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
        public StreamReader getReader(string path)
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
        public StreamReader closeReader(string path)
        {
            if (reader != null)
            {
                reader.Close();
            }
            return reader = null;
        }

        //инициализация дерева из файла
        public void initTreeFromFile(string path)
        {
            
        }


        public bynaryTreeNode root;
        public StreamReader reader;
    }
}
