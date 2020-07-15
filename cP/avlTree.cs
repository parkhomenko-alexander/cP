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
    public class Nodetree
    {
        public string vacancy;
        public string FIO;
        public string unit;
        public Nodetree left;
        public Nodetree right;
        public Nodetree(string vacancy, string FIO, string unit)
        {
            this.vacancy = vacancy;
            this.FIO = FIO;
            this.unit = unit;
        }
        public static bool operator >(Nodetree c1, Nodetree c2)
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
        public static bool operator <(Nodetree c1, Nodetree c2)
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

    public class AVL
    {
        public Nodetree root;

        public void Add(string vacancy, string FIO, string unit)
        {
            Nodetree newItem = new Nodetree(vacancy, FIO, unit);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = RecursiveInsert(root, newItem);
            }
        }
        private Nodetree RecursiveInsert(Nodetree current, Nodetree n)
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
        private Nodetree balance_tree(Nodetree current)
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
        private Nodetree Delete(Nodetree current, string vacancy, string FIO, string unit)
        {
            Nodetree target = new Nodetree(vacancy, FIO, unit);
            Nodetree parent;
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

        public Nodetree Find(string vacancy)
        {
            Nodetree search = Find(vacancy, root);
            if (search.vacancy == vacancy)//исправить
            {
                return search;
            }
            else
            {
                Nodetree target = new Nodetree(null, null, null);
                return target;
            }
        }
        private Nodetree Find(string vacancy, Nodetree current)
        {
            Nodetree target = new Nodetree(vacancy, null, null);
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

        public void getReport(Nodetree current, reportClass rC, payMap pM)
        {
            if (current != null)
            {
                getReport(current.left, rC, pM);
                Tuple<int, pMap.info, int, string> finded = pM.findInHashTable(current.vacancy);
                rC.pushArray(current.FIO, finded.Item2.field1, null, null);
                getReport(current.right, rC, pM);
            }
        }
        private int max(int l, int r)
        {
            return l > r ? l : r;
        }
        private int getHeight(Nodetree current)
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
        private int balance_factor(Nodetree current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }
        private Nodetree RotateRR(Nodetree parent)
        {
            Nodetree pivot = parent.right;
            parent.right = pivot.left;
            pivot.left = parent;
            return pivot;
        }
        private Nodetree RotateLL(Nodetree parent)
        {
            Nodetree pivot = parent.left;
            parent.left = pivot.right;
            pivot.right = parent;
            return pivot;
        }
        private Nodetree RotateLR(Nodetree parent)
        {
            Nodetree pivot = parent.left;
            parent.left = RotateRR(pivot);
            return RotateLL(parent);
        }
        private Nodetree RotateRL(Nodetree parent)
        {
            Nodetree pivot = parent.right;
            parent.right = RotateLL(pivot);
            return RotateRR(parent);
        }

    }
}
