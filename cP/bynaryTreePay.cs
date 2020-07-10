using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.CodeDom;
using fileRWSpace;
using System.Collections.Specialized;
using System.Globalization;

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
            payRate = "12130";
            coefficient = "0.2";
        }

        //конструктор с параметрами
        public payInfo(string s, string pR, string c)
        {
               post = s;
               payRate = pR;
               coefficient = c;
        }
        
        //финализатор
        ~payInfo()
        {
            post = null;
            payRate = null;
            coefficient = null;
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
       
        public void initInfo(string[] data)
        {
            this.post = data[0];
            this.payRate = data[1];
            this.coefficient = data[2];
        }

        //поля класса
        public string post { get; set; }
        public string payRate { get; set; }
        public string coefficient { get; set; }
    }

    class bynaryTreeNode
    {
        public bynaryTreeNode()
        {
            info = new payInfo();
            left = null;
            right = null;
            
        }

        double getKey()
        {
            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberGroupSeparator = ".";

            return Convert.ToDouble(this.info.payRate, provider);
        }

        public bool compareTwoNodes(bynaryTreeNode secondNode)
        {
            return this.getKey() >= secondNode.getKey();

        }
        
        public bool equNode(bynaryTreeNode secondNode)
        {
            return this.getKey() == secondNode.getKey() && this.info.post == secondNode.info.post;
        }

        public void initNode(payInfo data)
        {
            this.info = data;
        }
        public payInfo info { get; set; }
        public bynaryTreeNode left { get; set; }
        public bynaryTreeNode right {get; set; }
    }

    class bynaryTreePay
    {

        public bool isEmpty()
        {
            if (root == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addNode(bynaryTreeNode node)
        {
            bynaryTreeNode current;
            if (isEmpty() == true)
            {
                root = node;

                return;
            }

            current = root;
            bynaryTreeNode parentForCurrent = new bynaryTreeNode();
            while (current != null)
            {
                parentForCurrent = current;
                if (node.compareTwoNodes(current) == true)
                {
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }
            }
            if (node.compareTwoNodes(parentForCurrent) == true)
            {
                parentForCurrent.right = node;
            }
            else
            {
                parentForCurrent.left = node;
            }
            return;
        }

        public bynaryTreeNode findNode(bynaryTreeNode node)
        {
            bynaryTreeNode current = root;
            while (current != null && !node.equNode(current))
            {
                if (node.compareTwoNodes(current) == true)
                {
                    current = current.right;
                }
                else
                {
                    current = current.left;
                }

            }
            if(current == null)
            {
                return null;
            }
            else
            {
                return current;
            }
        }

        public void initTreeFromFile(fileRW reader)
        {
        }

        private bynaryTreeNode root;
    }
}
