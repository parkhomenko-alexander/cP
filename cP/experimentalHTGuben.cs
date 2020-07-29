using System;
using System.Windows.Forms;

namespace guben
{
    public class Node
    {
        public Node(string data1)
        {
            Data1 = data1;
        }
        public string Data1 { get; set; }
        public Node Next { get; set; }
    }
    public class LinkedList// односвязный список
    {
        Node head; // головной/первый элемент
        Node tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке
        public LinkedList()
        {
            this.head = new Node(null);
        }
        // добавление элемента
        public void Add(string record)
        {
            Node node = new Node(record);
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
            Node zero = new Node(null);
            int count = 0;
            Node current = head;
            if (current == null)
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

    public class experimentalHTGuben
    {
        public experimentalHTGuben(int size)
        {
            arraySize = 1;
            array = new string[arraySize];
            this.arrayRootSize = size;
            this.arrayRoot = new LinkedList[arrayRootSize];
            for (int i = 0; i < arrayRootSize; i++)
            {
                arrayRoot[i] = new LinkedList();
            }
            constanta = 0.6180339887;
        }
        public string pushBackArray(string field1)
        {
            array[arraySize - 1] = field1;
            arraySize++;
            Array.Resize(ref array, arraySize);
            return "Запись успешно добавлена";
        }
        public int getHash(string field1)
        {
            int hashAdress = hFunction(field1);
            return hashAdress;
        }
        public void addHashTable(string record, DataGridView dgw)
        {
            int hashAdress = hFunction(record);
            this.arrayRoot[hashAdress].Add(record);
            dgw.Rows.Add(hashAdress, record);
        }
        public void removeFromHashTable(string field1)
        {
            int hashAdress = hFunction(field1);
            this.arrayRoot[hashAdress].Remove(field1);
        }
        public void rehashing(DataGridView dgw, int k)
        {
            arrayRootSize *= 2;
            Array.Resize(ref arrayRoot, 0);
            Array.Resize(ref arrayRoot, arrayRootSize);
            dgw.Rows.Clear();
            for (int i = 0; i < arrayRootSize; i++)
            {
                arrayRoot[i] = new LinkedList();
            }
            for (int i = 0; i < k; i++)
            {
                int hashAdress = hFunction(array[i]);
                this.arrayRoot[hashAdress].Add(array[i]);
                dgw.Rows.Add(hashAdress, array[i]);

            }
        }
        
        public int findInHashTable(string field1)
        {
            int hashAdress = hFunction(field1);
            Tuple<Node, int> finded = arrayRoot[hashAdress].Contains(field1);
            return finded.Item2;

        }

        public int hFunction(string key)//Хэш-функция метод умножения
        {
            double result = 0;
            double size = arrayRootSize - 1;
            foreach (char letter in key)
            {
                result += letter;
            }
            result = (result * constanta) % 1;
            result = result * size;
            return Convert.ToInt32(result);
        }

        public int validator(string s)
        {
            if (s[0] < 1040 || s[0] > 1071)
            {
                MessageBox.Show("Должность должна начинаться с заглавной буквы", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return 1;
            }

            for (int k = 0; k < s.Length; k++)
            {
                if (s[k] == 32 && s[k+1] == 32)
                {
                    MessageBox.Show("Некорректно записана должность", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
            }

            int i = 0;
            foreach (char letter in s)
            {
                if (i == 0)
                {
                    i++;
                    continue;
                }
                if (letter != 32 && (letter < 1072 || letter > 1103))
                {
                    MessageBox.Show("Некорректно записана должность", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return 1;
                }
            }

            return 0;
        }

        public LinkedList[] arrayRoot;
        public int arrayRootSize { get; set; }
        public string[] array;
        public int arraySize;
        public double constanta;
    } 
}
