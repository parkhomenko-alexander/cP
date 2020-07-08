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
        public payInfo()
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

        //проверка данных на корректность 1-сторная буква в [0], 2-некоторая буква не кирилица,
        //3-з/п меньше МРОТ, 4-коэф. меньше 0.2
        public int dataValidator(string post, double payRate, double coefficient)
        {
            if (  192 > post[0] || post[0] > 223)
            {
                return 1;
            }
            else
            {
                foreach(char letter in post)
                {
                    if ( 224 > letter || letter > 255)
                    {
                        return 2;
                    }
                }

                if (payRate < 12130)
                {
                    return 3;
                }

                if (coefficient < 0.2) 
                {
                    return 4;
                }
            }
            return 0;
        }


        //поля класса
        public string post { get; set; }
        public double payRate { get; set; }
        public double coefficient { get; set; }
    }

    class bynaryTreeNode
    {
        bynaryTreeNode()
        {
            info = new payInfo();
            left = null;
            right = null;
            
        }
        private payInfo info { get; set; }
        private bynaryTreeNode left { get; set; }
        private bynaryTreeNode right { get; set; }
    }

    class bynaryTreePay
    {   
        

        //инициализация дерева из файла
        public void initTreeFromFile(string path)
        {
            
        }


        public bynaryTreeNode root;
    }
}
