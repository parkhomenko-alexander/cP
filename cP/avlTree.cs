using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cP;
using bynTree;
using pMap;
using avlTree;
using HashTable;
using repClass;

namespace avlTree
{
    struct info
    {
        public info(string field1, string field2, string field3)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
        }

        //1 - Неверно записана должность, 2 - Неверно записано подразделение, 3 - ФИО должно начинаться с заглавной буквы
        //4 - Неверно записано ФИО
        public int validator(string field1, string field2, string field3)
        {
            foreach (char letter in field2)
            {
                if ((1072 > letter || letter > 1105 || letter == 1104) && (1 > field2.Length || field2.Length > 30))
                {
                    return 1;
                }
            }

            foreach (char letter in field3)
            {
                if ((1072 > letter || letter > 1105 || letter == 1104) && (1 > field3.Length || field3.Length > 30))
                {
                    return 2;
                }
            }

            int j = 0, k = 0;
            for (int i = 0; i < field1.Length; i++)
            {
                if (j == 0 && (1040 > field1[i] || field1[i] > 1071 || field1[i] != 1025))
                {
                    return 3;
                }
                else j = 1;

                if (j == 1 && (1072 > field1[i] || field1[i] > 1105 || field1[i] == 1104) && (5 > field1.Length || field1.Length > 152))
                {
                    return 4;
                }
                else if (field1[i] == 20)
                {
                    j = 0;
                    k++;
                    if (k > 2)
                        return 4;
                }
                if (k < 2)
                    return 4;
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
                        return "Неверно записано подразделение";
                    }
                case 3:
                    {
                        return "ФИО должно начинаться с заглавной буквы";
                    }
                case 4:
                    {
                        return "Неверно записано ФИО";
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

    class Node
    {
        public string vacancy;
        public string FIO;
        public string unit;
        public Node left;
        public Node right;
        public Node(string vacancy, string FIO, string unit)
        {
            this.vacancy = vacancy;
            this.FIO = FIO;
            this.unit = unit;
        }
        public static bool operator >(Node c1, Node c2)
        {
            if (String.Compare(c1.vacancy, c2.vacancy) > 0)
                return true;
            else if (String.Compare(c1.vacancy, c2.vacancy) < 0)
                return false;
            else if (String.Compare(c1.FIO, c2.FIO) > 0)
                return true;
            else if (String.Compare(c1.FIO, c2.FIO) < 0)
                return false;
            else return false;
        }
        public static bool operator <(Node c1, Node c2)
        {
            if (String.Compare(c1.vacancy, c2.vacancy) > 0)
                return false;
            else if (String.Compare(c1.vacancy, c2.vacancy) < 0)
                return true;
            else if (String.Compare(c1.FIO, c2.FIO) > 0)
                return false;
            else if (String.Compare(c1.FIO, c2.FIO) < 0)
                return true;
            else return false;
        }
    }

    class AVL
    {
        Node root;
        public info[] array;
        public int arraySize { get; set; }
        public AVL()
        {
            arraySize = 1;
            array = new info[arraySize];
        }

        public void Add(string vacancy, string FIO, string unit)
        {
            Node newItem = new Node(vacancy, FIO, unit);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n < current)
            {
                current.left = RecursiveInsert(current.left, n);
                current = balance_tree(current);
            }
            else if (n > current)
            {
                current.right = RecursiveInsert(current.right, n);
                current = balance_tree(current);
            }
            return current;
        }
        private Node balance_tree(Node current)
        {
            int b_factor = balance_factor(current);
            if (b_factor > 1)
            {
                if (balance_factor(current.left) > 0)
                {
                    current = RotateLL(current);
                }
                else
                {
                    current = RotateLR(current);
                }
            }
            else if (b_factor < -1)
            {
                if (balance_factor(current.right) > 0)
                {
                    current = RotateRL(current);
                }
                else
                {
                    current = RotateRR(current);
                }
            }
            return current;
        }
        public void Delete(string vacancy, string FIO, string unit)
        {//and here
            root = Delete(root, vacancy, FIO, unit);
        }
        private Node Delete(Node current, string vacancy, string FIO, string unit)
        {
            Node target = new Node(vacancy, FIO, unit);
            Node parent;
            if (current == null)
            {
                return null;
            }
            else
            {
                //left subtree
                if (target < current)
                {
                    current.left = Delete(current.left, vacancy, FIO, unit);
                    if (balance_factor(current) == -2)//here
                    {
                        if (balance_factor(current.right) <= 0)
                        {
                            current = RotateRR(current);
                        }
                        else
                        {
                            current = RotateRL(current);
                        }
                    }
                }
                //right subtree
                else if (target > current)
                {
                    current.right = Delete(current.right, vacancy, FIO, unit);
                    if (balance_factor(current) == 2)
                    {
                        if (balance_factor(current.left) >= 0)
                        {
                            current = RotateLL(current);
                        }
                        else
                        {
                            current = RotateLR(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }
                        current.vacancy = parent.vacancy;
                        current.FIO = parent.FIO;
                        current.unit = parent.unit;
                        current.right = Delete(current.right, parent.vacancy, parent.FIO, parent.unit);
                        if (balance_factor(current) == 2)//rebalancing
                        {
                            if (balance_factor(current.left) >= 0)
                            {
                                current = RotateLL(current);
                            }
                            else { current = RotateLR(current); }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }
            return current;
        }

        public Node Find(string vacancy)
        {
            Node search = Find(vacancy, root);
            if (search.vacancy == vacancy)//исправить
            {
                return search;
            }
            else
            {
                Node target = new Node(null, null, null);
                return target;
            }
        }
        private Node Find(string vacancy, Node current)
        {
            Node target = new Node(vacancy, null, null);
            if (target < current)
            {
                if (vacancy == current.vacancy)
                {
                    return current;
                }
                else if (current.left != null)
                    return Find(vacancy, current.left);
                else return current;
            }
            else
            {
                if (vacancy == current.vacancy)
                {
                    return current;
                }
                else if (current.right != null)
                    return Find(vacancy, current.right);
                else return current;
            }

        }
        public void clear()
        {
            root = null;
        }

        public void InOrderDisplayTree(Node current, reportClass rC, payMap pM)
        {
            if (current != null)
            {
                InOrderDisplayTree(current.left, rC, pM);
                Tuple<int, pMap.info, int, string> finded = pM.findInHashTable(current.vacancy);
                rC.pushArray(finded.Item2.field2, finded.Item2.field1, current.unit, null);
                InOrderDisplayTree(current.right, rC, pM);
            }
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private Node RotateRR(Node parent)
        {
            Node pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Node RotateLL(Node parent)
        {
            Node pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Node RotateLR(Node parent)
        {
            Node pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Node RotateRL(Node parent)
        {
            Node pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

        public string pushBackArray(string field1, string field2, string field3)
        {
            info record = new info(field2, field1, field3);

            if (arraySize == 1)
            {
                array[arraySize - 1] = record;
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

            if (arraySize == 0)
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
            array[refRecordToRemove] = array[arraySize - 2];
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
    }
}
