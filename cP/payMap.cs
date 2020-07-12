using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMap
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
            if (field2.Length < 1 || field2.Length > 30)
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

            if (Convert.ToInt32(field1) < 0 || Convert.ToInt32(field1) > 100)
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
                        return "В записи з\\п использованы не только цифры";
                    }
                case 4:
                    {
                        return "В записи коеффициента использованы не только цифры";
                    }
                case 5:
                    {
                        return "Размер з\\п не может быть меньше МРОТ";
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
    class payMap
    {
        public payMap()
        {   
            this.arraySize = 1;
            this.array= new info[arraySize];
            this.arrayForReportSize = 16;
            this.arrayForReport = new info[arrayForReportSize];
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

        public int getHash(string field2)
        {
            int hashAdreeLevel1 = hFunction1(field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == null || this.arrayForReport[hashAdreeLevel1].field2 == "deleted")
            {
                return hashAdreeLevel1;
            }
            else
            {
                for (int i = 0; i < arrayForReportSize; i++)
                {
                    int hashAdressLevel2 = this.hFunction2(field2);
                    int insertionAdress = (hashAdreeLevel1 + i * hashAdressLevel2) % arrayForReportSize;
                    if (this.arrayForReport[insertionAdress].field2 == null || this.arrayForReport[insertionAdress].field2 == "deleted")
                    {
                        return insertionAdress;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            return 0;
        }
        public void addInArrayForReport(info record)
        {
            int hashAdreeLevel1 = hFunction1(record.field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == null || this.arrayForReport[hashAdreeLevel1].field2 == "deleted")
            {
                this.arrayForReport[hashAdreeLevel1] = record;
            }
            else
            {
                int hasAdreeLevel2 = this.hFunction2(record.field2);
                for (int i = 0; i < arrayForReportSize; i++)
                {
                   int insertionAdress = (hashAdreeLevel1 + i * hasAdreeLevel2) % arrayForReportSize;
                   if (this.arrayForReport[insertionAdress].field2 == null || this.arrayForReport[insertionAdress].field2 == "deleted")
                   {
                        this.arrayForReport[insertionAdress] = record;
                   }
                   else
                   {
                        continue;
                   }
                }
            }

            this.recorded++;
            this.recordedCoef = recorded / arrayForReportSize * 100;
        }

        public string checkForReHashing()
        {
            if (this.recorded < 0.75)
            {
                return "";
            }
            else
            {   this.arrayForReportSize *= 2;
                Array.Resize(ref this.arrayForReport, 0);
                Array.Resize(ref this.arrayForReport, this.arrayForReportSize);
                foreach (info elem in this.array)
                {
                    addInArrayForReport(elem);
                }

                return "Уровень заполнения хеш-таблицы 75% - произошло рехеширование";
            }
        }

        public int hFunction1(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }

            return result % arrayForReportSize;
        }
        public int hFunction2(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }

            result *= key[0];

            if(result % 2 == 0)
            {
                return result % arrayForReportSize + 1;
            }
            else
            {
                return result % arrayForReportSize;
            }
        }

        // public int hFunction2(int num);
        public info[] array;
        public info[] arrayForReport;
        public double recordedCoef { get; set; }
        public double recorded { get; set; }
        public int arrayForReportSize { get; set; }
        public int arraySize { get; set; }
    }
}
