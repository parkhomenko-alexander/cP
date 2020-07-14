using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cP;

namespace repClass
{
    public struct infoToReport
    {
        public infoToReport(string field1, string field2, string field3, string field4)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3 ?? null;
            this.field4 = field4 ?? null;
        }


        public static bool operator >=(infoToReport i1, infoToReport i2)
        {
            int resCompFl1 = i1.field1.CompareTo(i2.field1);

            if (resCompFl1 == 0 || resCompFl1 == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator <=(infoToReport i1, infoToReport i2)
        {
            int resCompFl1 = i1.field1.CompareTo(i2.field1);

            if (resCompFl1 == 0 || resCompFl1 == -1)
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
        public string field4 { get; set; }
    }

   public class reportClass
    {
        public reportClass()
        {
            this.arraySize = 1;
            this.array = new infoToReport[arraySize];
        }

        public string pushArray(string field1, string field2, string field3, string field4)
        {
            infoToReport record = new infoToReport(field1, field2, field3, field4);

            if (arraySize == 1)
            {
                array[arraySize - 1] = record;
                arraySize++;
                Array.Resize(ref array, arraySize);
                return "Запись успешно добавлена";
            }
            else
            {
                int i = 0;
                while (record <= array[i])
                {
                    i++;
                }
                arraySize++;
                Array.Resize(ref array, arraySize);
                for(int j = arraySize - 2; j > i; j--)
                {
                    array[j] = array[j - 1];
                }
                array[i] = record;
                return "Запись успешно добавлена";
            }
        }

        public infoToReport[] array;
        public int arraySize;
    }
}
