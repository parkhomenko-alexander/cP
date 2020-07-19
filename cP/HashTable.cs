using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cP;
using bynTree;
using pMap;
using avlTree;
using HashTable;
using repClass;

namespace HashTable
{
    public struct info
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
            if ((1071 < field2[0] && field2[0] < 1104 || field2[0] == 1105) && (1071 < field3[0] && field3[0] < 1104 || field3[0] == 1105))
            {
                foreach (char letter in field2)
                {
                    if (1072 > letter || letter > 1105 || letter == 1104 || 1 > field2.Length || field2.Length > 30)
                    {
                        return 1;
                    }
                }

                foreach (char letter in field3)
                {
                    if (1072 > letter || letter > 1105 || letter == 1104 || 1 > field2.Length || field2.Length > 30)
                    {
                        return 2;
                    }
                }
            }
            else if ((48 > field2[0] || field2[0] > 57) || (48 > field3[0] || field3[0] > 57))
                return 9;
            else
            {
                foreach (char letter in field2)
                {
                    if (48 > letter || letter > 57)
                    {
                        return 5;
                    }
                }

                foreach (char letter in field3)
                {
                    if (48 > letter || letter > 57)
                    {
                        return 6;
                    }
                }

                if (Convert.ToInt32(field2) < 0 || Convert.ToInt32(field2) > 100)
                {
                    return 7;
                }

                if (Convert.ToInt32(field3) < 0 || Convert.ToInt32(field3) > 100)
                {
                    return 8;
                }
            }

            if (5 > field1.Length || field1.Length > 100)
                return 4;
            int j = 0, k = 0;
            for (int i = 0; i < field1.Length; i++)
            {
                if (j == 0 && field1[i] != 1025 && (1040 > field1[i] || field1[i] > 1071))
                {
                    return 3;
                }

                if (j == 1 && field1[i] != 32 && (1072 > field1[i] || field1[i] > 1105 || field1[i] == 1104))
                {
                    return 4;
                }
                else if (field1[i] == 32)
                {
                    j = 0;
                    k++;
                    if (k > 2)
                        return 4;
                }
                else if (j == 0)
                    j = 1;
            }
            if (k < 2)
                return 4;
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
                case 5:
                    {
                        return "В записи стажа использованы не только цифры";
                    }
                case 6:
                    {
                        return "В записи коэффициента использованы не только цифры";
                    }
                case 7:
                    {
                        return "Некорректное значение стажа";
                    }
                case 8:
                    {
                        return "Некорректное значение коэффициента";
                    }
                case 9:
                    {
                        return "Некорректные данные";
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

            if (resCompFl1 == 0)
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

            if (resCompFl1 != 0)
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

    public class Node
    {
        public Node(string data1, string data2, string data3)
        {
            Data1 = data1;
            Data2 = data2;
            Data3 = data3;
        }
        public string Data1 { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public Node Next { get; set; }
    }
    public class LinkedList// односвязный список
    {
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
        public LinkedList()
        {
            this.head = new Node(null, null, null);
        }
        // добавление элемента
        public void Add(info record)
        {
            Node node = new Node(record.field1, record.field2, record.field3);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
        // удаление элемента
        public bool Remove(string data1)
        {
            Node current = head;
            Node previous = null;

            while (current != null)
            {
                if (current.Data1.Equals(data1))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        // содержит ли список элемент
        public Tuple<Node, int> Contains(string data1)
        {
            Node zero = new Node(null, null, null);
            int count = 0;
            Node current = head;
            if(current == null)
            {
                return Tuple.Create(zero, count);
            }

            while (current.Data1 != zero.Data1)
            {
                count++;
                if (current.Data1.Equals(data1))
                    return Tuple.Create(current, count);
                if (current.Next != null)
                current = current.Next;
                else return Tuple.Create(zero, count);
            }
            return Tuple.Create(zero, count);
        }
    }

    public class hashTable
    {
        public hashTable()
        {
            this.arraySize = 1;
            this.array = new info[arraySize];
            this.arrayRootSize = 16;
            this.arrayRoot = new LinkedList[arrayRootSize];
            for (int i = 0; i < arrayRootSize;i++)
            {
                arrayRoot[i] = new LinkedList();
            }            
        }

        public string pushBackArray(string field1, string field2, string field3)
        {
            info record = new info(field1, field2, field3);

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
                if (refRecordToRemove != -1)
                {
                    this.swapRecords(ref this.array, refRecordToRemove);
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

        public int getHash(string field1)
        {
            int hashAdress = hFunction(field1);
            return hashAdress;
        }
        public void addHashTable(info record)
        {
            int hashAdress = hFunction(record.field1);
            this.arrayRoot[hashAdress].Add(record);
        }
        public void removeFromHashTable(string field1)
        {
            int hashAdress = hFunction(field1);
            this.arrayRoot[hashAdress].Remove(field1);
        }
        public void initHashTableFromArray()
        {
            for (int i = 0; i < arraySize - 1; i++)
            {
                addHashTable(array[i]);
            }
        }
        public Tuple<int, string, string, string, int, string> findInHashTable(string field1)
        {
            int hashAdress = hFunction(field1);
            Tuple<Node, int> findRecord = this.arrayRoot[hashAdress].Contains(field1);
            if (this.arraySize == 1)
            {
                return Tuple.Create(hashAdress, findRecord.Item1.Data1, findRecord.Item1.Data2, findRecord.Item1.Data3, -2, "Справочник не содержит записей");//Запись не найдена
            }
            else if (findRecord.Item1.Data1 == null)
            {
                return Tuple.Create(hashAdress, findRecord.Item1.Data1, findRecord.Item1.Data2, findRecord.Item1.Data3, -1, "Запись не содержится в справочнике");//Список пуст
            }
            else
            {
                return Tuple.Create(hashAdress, findRecord.Item1.Data1, findRecord.Item1.Data2, findRecord.Item1.Data3, findRecord.Item2, "Запись найдена");//Запись найдена
            }
        }

        public int hFunction(string key)//Хэш-функция метод умножения
        {
            double result = 0;
            double size = arrayRootSize;
            foreach (char letter in key)
            {
                result += letter;
            }
            result = (result * 0.6180339887) % 1;
            result = result * size;
            return Convert.ToInt32(result);
        }
        public void getReport(reportClass rC, hashTable eM)
        {
            for (int i = 0; i < this.arraySize - 1; i++)
            {
                Tuple<int, string, string, string, int, string> finded = eM.findInHashTable(this.array[i].field1);
                rC.pushArray(this.array[i].field1, this.array[i].field2, finded.Item3, null);
            }
        }

        public void getReport(reportClass rC, payMap pM)
        {
            for (int i = 0; i < this.arraySize - 1; i++)
            {
                Tuple<int, pMap.info, int, string> finded = pM.findInHashTable(this.array[i].field2);
                rC.pushArray(this.array[i].field1, finded.Item2.field1, null, null);
            }
        }

        public void getReport(reportClass rC, hashTable eM, payMap pM)
        {
            for (int i = 0; i < this.arraySize - 1; i++)
            {
                Tuple<int, string, string, string, int, string> findedFromEmployee = eM.findInHashTable(this.array[i].field1);
                Tuple<int, pMap.info, int, string> findedFromPay = pM.findInHashTable(this.array[i].field2);
                rC.pushArray(array[i].field1, array[i].field3,
                            findedFromEmployee.Item3, findedFromPay.Item2.field1);
            }
        }

        public info[] array;
        public LinkedList[] arrayRoot;
        public int arrayRootSize { get; set; }
        public int arraySize { get; set; }
    }
}

