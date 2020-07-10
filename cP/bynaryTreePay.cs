using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.CodeDom;
using System.Collections.Specialized;
using System.Globalization;
using System.Drawing.Drawing2D;

namespace cP
{   
    struct info
    {   
        public info(string field1, string field2, string field3)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
        }

        //1-не целая зп, 2 - [0] != !A, 3-[n] == /.!, 4 - кеф > 100, 5 - кеф > 100
        //6 < MROT
        public int validator(string field1, string field2, string field3)
        {   
            int i = 0;
            foreach (char letter in field2)
            {   if (i == 0)
                {
                    i++;
                    continue;
                }
                if (1072 > letter || letter > 1103)
                {   
                    return 3;
                }
            }

            if (1040 > field2[0] || field2[0] > 1071)
            {
                return 2;
            }

            foreach (char letter in field1)
            {
                if (48 > letter || letter > 57)
                {
                    return 1;
                }
            }
            if (field3.Length > 3)
            {
                return 4;
            }
            foreach (char letter in field3)
            {
                if (48 > letter || letter > 57)
                {
                    return 5;
                }
            }
            if (Convert.ToInt32(field1) < 12130)
            {
                return 6;
            }
            return 0;
        }
        public string errorHandler(int number)
        {
            switch (number)
            {
                case 0:
                    {
                        return "";
                    }
                case 1:
                    {
                        return "Данные о з\\п некорректны";
                    }
                case 2:
                    {
                        return "Нарушение регистра в записи профессии";
                    }
                case 3:
                    {
                        return "Профессия записана не на кирилице";
                    }
                case 4:
                    {
                        return "Коэффциент определён на [0 .. 100]";
                    }
                case 5:
                    {
                        return "Коэффициент определён на [0 .. 100]";
                    }
                case 6:
                    {
                        return "З\\п не может быть меньше МРОТ";
                    }
                default:
                    {
                        return "Запись успешно добалена";
                    }
            }
        }

        public static bool operator ==(info i1, info i2)
        {
            int resCompFl1 = i1.field1.CompareTo(i2.field1);
            int resCompFl2 = i1.field2.CompareTo(i2.field2);
            int resCompFl3 = i1.field3.CompareTo(i2.field3);

            if (resCompFl1 == 0 && resCompFl2 == 0 && resCompFl3 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(info i1, info i2)
        {
            int resCompFl1 = i1.field1.CompareTo(i2.field1);
            int resCompFl2 = i1.field2.CompareTo(i2.field2);
            int resCompFl3 = i1.field3.CompareTo(i2.field3);

            if (resCompFl1 != 0 || resCompFl2 != 0 || resCompFl3 != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }

    }

    class node
    {
        public node()
        {
            field1 = null;
            field2 = null;
            field3 = null;
            parent = null;
            left = null;
            right = null;
        }
        public node(string field1, string field2, string field3)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
            this.parent = null;
            this.left = null;
            this.right = null;
        }

        public static bool operator ==(node n1, node n2)
        {
            if (n1.field2.CompareTo(n2.field2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(node n1, node n2)
        {
            if (n1.field2.CompareTo(n2.field2) == 1 || n1.field2.CompareTo(n2.field2) == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator >=(node n1, node n2)
        {
            if (n1.field2.CompareTo(n2.field2) == 1 || n1.field2.CompareTo(n2.field2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(node n1, node n2)
        {
            if (n1.field2.CompareTo(n2.field2) == -1 || n1.field2.CompareTo(n2.field2) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string field1 { get; set; }
        public string field2 { get; set; }
        public string field3 { get; set; }
        public node parent { get; set; }
        public node left { get; set; }
        public node right { get; set; }
    }

    class bynaryTree
    {
        public bynaryTree()
        {
            root = null;
            arraySize = 1;
            array = new info[arraySize];
        }

        //всегда успешно
        public string pushBackArray(string field1, string field2, string field3)
        {
            info record = new info(field2, field1, field3);

            if (arraySize == 1)
            {
                array[arraySize-1] = record;
                arraySize++;
                Array.Resize(ref array, arraySize);
                return "Запись успешно добавлена";
            }
            else 
            {
                array[arraySize - 1] = record;
                arraySize++;
                Array.Resize(ref array, arraySize);
                return "Запись успешно добавлена";
            }
        }

        public string eraseFromArray(string field2, string field1, string field3)
        {
            info record = new info(field2, field1, field3);

            if(arraySize == 0)
            {
                return "Удаление невозможно справочник пуст";
            }
            else
            {   
                int refRecordToRemove = this.findInArray(record);
                int i = 0; 
                if (refRecordToRemove != -1)
                {
                    this.swapRecords(ref this.array, i);
                    arraySize--;
                    Array.Resize(ref this.array, arraySize);
                    return "Запись успешно удалена";
                }
                else
                {
                    return "Удаление невозможно запись не содержится в справочнике";
                }

            }
        }
        public void swapRecords(ref info[] ar, int refRecordToRemove)
        {
            array[refRecordToRemove]= array[arraySize - 2];
            array[arraySize - 2] = array[arraySize - 1];
           
            return;
        }
        
        //-1 - dont find
        public int findInArray(info record)
        {
            int i = 0;
            foreach (info rec in array)
            {   
                if (i == arraySize - 1)
                {
                    i = -1;
                    break;
                }
                if (rec == record)
                {
                    break;
                }
                i++;
            }
            return i;
        }

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

        public void addNode(node n)
        {
            if (this.isEmpty() == true)
            {
                root = n;
                return;
            }
            else
            {
                node parent = new node();
                node current = new node();
                current = root;

                while(current != null)
                {
                    if (current <= n)
                    {
                        parent = current;
                        current = current.right;
                    }
                    else
                    {
                        parent = current;
                        current = current.left;
                    }
                }

                if (parent <= n)
                {
                    n.parent = parent;
                    parent.right = n;
                }
                else
                {
                    n.parent = parent;
                    parent.left = n;
                }
            }
        }
        public void initTreeFromePayArray(ref info[] array)
        {
            int i = 0;
            while (i != arraySize - 2)
            {
                node newNode = new node(array[i].field1, array[i].field2, array[i].field3);
                this.addNode(newNode);
            }
        }

        public node root;
        public info[] array;
        public int arraySize;
    }

}
