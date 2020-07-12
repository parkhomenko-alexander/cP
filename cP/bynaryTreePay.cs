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
using System.Text.RegularExpressions;
using System.Threading;
using cP;

namespace bynTree
{
    struct info
    {
        public info(string field1, string field2, string field3)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
        }

        //1-длина профессии, 2-[n] == не строчная кирилица, 
        // 3 - в записи стажа не толко цифры, 4 - в записи коефа  5- стаж > 100 или меньше 0, 6 - кеф > 100
        //0 - все нормально
        public int validator(string field1, string field2, string field3)
        {
            if(field2.Length < 1 || field2.Length > 30)
            {
                return 1;
            }

            foreach (char letter in field2)
            {
                if (1072 > letter || letter > 1103)
                {
                    return 2;
                }
            }

            foreach (char letter in field1)
            {
                if (48 > letter || letter > 57)
                {
                    return 3;
                }
            }

            foreach (char letter in field3)
            {
                if (48 > letter || letter > 57)
                {
                    return 4;
                }
            }

            if (Convert.ToInt32(field1) < 12130)
            {
                return 5;
            }

            if (Convert.ToInt32(field3) < 0 || Convert.ToInt32(field3) > 100)
            {
                return 6;
            }


            return 0;
        }
        public string errorHandler(int number)
        {
            switch (number)
            {
                case 1:
                    {
                        return "Неверно записана должность";
                    }
                case 2:
                    {
                        return "Неверна записана должность";
                    }
                case 3:
                    {
                        return "В записи стажа использованы не только цифры";
                    }
                case 4:
                    {
                        return "В записи коеффициента использованы не только цифры";
                    }
                case 5:
                    {
                        return "Некорректное значение стажа";
                    }
                case 6:
                    {
                        return "Некорректное значение коеффициента";
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

            if (resCompFl1 == 0 && resCompFl2 == 0)
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

            if (resCompFl1 != 0 || resCompFl2 != 0)
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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");
            string strN1 = n1.field2 + n1.field1;
            string strN2 = n2.field2 + n2.field1;
            if (strN1.CompareTo(strN2) == 0)
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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");
            string strN1 = n1.field2 + n1.field1 + n1.field3;
            string strN2 = n2.field2 + n2.field1 + n2.field3;
            if (strN1.CompareTo(strN2) == 1 || strN1.CompareTo(strN2) == -1)
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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");
            string strN1 = n1.field2;
            string strN2 = n2.field2;
            if (strN1.CompareTo(strN2) == 1)
            {
                return true;
            }
            if (strN1.CompareTo(strN2) == 0)
            {
                if (Convert.ToInt32(n1.field1) > Convert.ToInt32(n2.field1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(node n1, node n2)
        {
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");
            string strN1 = n1.field2;
            string strN2 = n2.field2;
            if (strN1.CompareTo(strN2) == -1)
            {
                return true;
            }
            if (strN1.CompareTo(strN2) == 0)
            {
                if (Convert.ToInt32(n1.field1) < Convert.ToInt32(n2.field1))
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
            while (i != arraySize - 1)
            {
                node newNode = new node(array[i].field1, array[i].field2, array[i].field3);
                this.addNode(newNode);
                i++;
            }
        }

        //empty tree, dont find
        public Tuple<node, int> findNode(node nodeForFind)
        {
            if (this.isEmpty() == true)
            {
                node finedNode = new node(null, null, null);
                return Tuple.Create(finedNode, -1);
            }
            else
            {
                node current = root;
                int counter = 1;
                while(current != null && current != nodeForFind)
                {
                    if(current <= nodeForFind)
                    {
                        current = current.right;
                    }
                    else
                    {
                        current = current.left;
                    }
                    counter++;
                }

                if (current == null)
                {
                    node finedNode = new node(null, null, null);
                    return Tuple.Create(finedNode, 0);
                }
                else
                {
                    return Tuple.Create(current, counter);
                }
            }
        }
        public Tuple<string, string> findHandler(Tuple<node, int> finedNode)
        {
            if (finedNode.Item2 == -1)
            {
                return Tuple.Create("Список пуст - запись не найдена", ""); 
            }
            else if(finedNode.Item2 == -2)
            {
                return Tuple.Create("Запись не содержится в справочнике", "");
            }
            else
            {   
                return Tuple.Create("Запись содержится в справочнике", "число сравнений - " + finedNode.Item2.ToString());
            }
        }

        public string removeNode(Tuple<node, int> nodeForRemove)
        {
            if (nodeForRemove.Item2 > 0)
            {
                if (nodeForRemove.Item1.left == null && nodeForRemove.Item1.right == null)
                {
                    this.removeLeaf(nodeForRemove.Item1);
                    return "Запись успешно удалена";
                }
                else if(nodeForRemove.Item1.left != null && nodeForRemove.Item1.right == null)
                {
                    this.removeNodeWithLeftSon(nodeForRemove.Item1);
                    return "Запись успешно удалена";
                }
                else if(nodeForRemove.Item1.left == null && nodeForRemove.Item1.right != null)
                {
                    this.removeNodeWithRightSon(nodeForRemove.Item1);
                    return "Запись успешно удалена";
                }
                else
                {
                    this.removeNodeWithTwoSons(nodeForRemove.Item1);
                    return "Запись успешно удалена";
                }
            }
            else 
            {
                return this.findHandler(nodeForRemove).Item1;
            }
        }
        public void removeLeaf(node leaf)
        {
            node current = this.findNode(leaf).Item1.parent;
            if (current.left == leaf)
            {
                current.left = null;
                return;
            }
            else
            {
                current.right = null;
                return;
            
            }
        }
        public void removeNodeWithLeftSon(node nodeWithLeftSon)
        {
            node current = nodeWithLeftSon.parent;
            if (current.left == nodeWithLeftSon)
            {
                current.left = nodeWithLeftSon.left;
            }
            else
            {
                current.right = nodeWithLeftSon.left;
            }
            nodeWithLeftSon.left.parent = current;
            nodeWithLeftSon.parent = null;
            nodeWithLeftSon.left = null;

            return;
        }
        public void removeNodeWithRightSon(node nodeWithRightSon)
        {
            node current = nodeWithRightSon.parent;
            if(current.left == nodeWithRightSon)
            {
                current.left = nodeWithRightSon.right;
            }
            else
            {
                current.right = nodeWithRightSon.right;
            }
            nodeWithRightSon.right.parent = current;
            nodeWithRightSon.parent = null;
            nodeWithRightSon.right = null;

            return;
        }
        public void removeNodeWithTwoSons(node nodeForTransplant)
        {
            Tuple<node, int> tmp = this.findNode(nodeForTransplant);
            node maxInLeftSubTree = this.findMaxInLeftSubTree(tmp.Item1);

            if (root == tmp.Item1)
            {
                root = maxInLeftSubTree;

                maxInLeftSubTree.left = tmp.Item1.left;
                maxInLeftSubTree.right = tmp.Item1.right;
                maxInLeftSubTree.parent.right = null;
                maxInLeftSubTree.parent = null;

                tmp.Item1.left.parent = maxInLeftSubTree;
                tmp.Item1.right.parent = maxInLeftSubTree;

                tmp.Item1.left = null;
                tmp.Item1.right = null;

                return;
            }
            else if (tmp.Item1.left == maxInLeftSubTree)
            {
                maxInLeftSubTree.parent = tmp.Item1.parent;
                tmp.Item1.parent.left = maxInLeftSubTree;

                tmp.Item1.parent = null;
                tmp.Item1.left = null;

                maxInLeftSubTree.right = tmp.Item1.right;
                tmp.Item1.right.parent = maxInLeftSubTree;
                tmp.Item1.right = null;

                return;
            }
            else
            {
                maxInLeftSubTree.left = tmp.Item1.left;
                maxInLeftSubTree.right = tmp.Item1.right;

                tmp.Item1.left.parent = maxInLeftSubTree;
                tmp.Item1.right.parent = maxInLeftSubTree;

                tmp.Item1.left = null;
                tmp.Item1.right = null;

                maxInLeftSubTree.parent = tmp.Item1.parent;
                if (tmp.Item1.parent.left == tmp.Item1)
                {
                    tmp.Item1.parent.left = maxInLeftSubTree;
                }
                else
                {
                    tmp.Item1.parent.right = maxInLeftSubTree;
                }

                return;
            }


        }

        public node findMaxInLeftSubTree(node subRoot)
        {
            node current = subRoot;
            current = current.left;
            while(current.right != null) 
            {
                current = current.right;
            }

            return current;
        }
       
        //public node symmetricTraversal(node root)
        //{
        //    findPayInfo fpi = new findPayInfo();
        //    fpi.Show();
        //    return ;
        //} 

        public node root;
        public info[] array;
        public int arraySize;
    }

}
