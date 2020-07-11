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

        //1-не целая зп, 2 - [0] != !A, 3-[n] == /.!, 4 - кеф > 100, 5 - кеф > 100
        //6 < MROT
        public int validator(string field1, string field2, string field3)
        {
            int i = 0;
            foreach (char letter in field2)
            {
                if (i == 0)
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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");

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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");

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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");

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
            n1 ??= new node("", "", "");
            n2 ??= new node("", "", "");

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
            current.left = nodeWithLeftSon.left;
            nodeWithLeftSon.left.parent = current;
            nodeWithLeftSon.parent = null;
            nodeWithLeftSon.left = null;

            return;
        }
        public void removeNodeWithRightSon(node nodeWithRightSon)
        {
            node current = nodeWithRightSon.parent;
            current.right = nodeWithRightSon.right;
            nodeWithRightSon.right.parent = current;
            nodeWithRightSon.parent = null;
            nodeWithRightSon.right = null;

            return;
        }
        public void removeNodeWithTwoSons(node nodeWithTwoSons)
        {
            this.transplantTwoNodes(nodeWithTwoSons);

            return;
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
        public void transplantTwoNodes(node nodeForTransplant)
        {
            Tuple<node, int> tmp = this.findNode(nodeForTransplant);
            node maxInLeftSubTree = this.findMaxInLeftSubTree(tmp.Item1);

            if (root == tmp.Item1)
            {
                root = maxInLeftSubTree;

                maxInLeftSubTree.left = tmp.Item1.left;
                maxInLeftSubTree.right = tmp.Item1.right;
                maxInLeftSubTree.parent.right = null;
                maxInLeftSubTree.parent= null;

                tmp.Item1.left.parent = maxInLeftSubTree;
                tmp.Item1.right.parent = maxInLeftSubTree;

                tmp.Item1.left = null;
                tmp.Item1.right = null;

                return;
            }
            else if(tmp.Item1.left == maxInLeftSubTree)
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

        public node root;
        public info[] array;
        public int arraySize;
    }

}
