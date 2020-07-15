using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pMap
{
    public struct info
    {

        public info(string field1, string field2, string field3)
        {
            this.field1 = field1;
            this.field2 = field2;
            this.field3 = field3;
        }

        //1-длина профессии, 2-[n] == не строчная кирилица, 
        // 3 - в записи стажа не толко цифры, 4 - в записи коефа  5- зп меньше мрот, 6 - кеф > 100
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
            int resCompFl2 = i1.field2.CompareTo(i2.field2);

            if (resCompFl2 == 0)
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
    public class payMap
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

        public int getEmptyHashAddress(string field2)
        {
            int hashAdreeLevel1 = hFunction1(field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == null || this.arrayForReport[hashAdreeLevel1].field2 == "deleted")
            {
                return hashAdreeLevel1;
            }
            else
            {
                int hashAdressLevel2 = this.hFunction2(field2);
                for (int i = 1; i < arrayForReportSize; i++)
                {
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

        public int getHashToRecord(string field2)
        {
            int hashAdreeLevel1 = hFunction1(field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == field2)
            {
                return hashAdreeLevel1;
            }
            else
            {
                int hashAdressLevel2 = this.hFunction2(field2);
                for (int i = 1; i < arrayForReportSize; i++)
                {
                    int insertionAdress = (hashAdreeLevel1 + i * hashAdressLevel2) % arrayForReportSize;
                    if (this.arrayForReport[insertionAdress].field2 == field2)
                    {
                        return insertionAdress;
                    }
                    if(this.arrayForReport[insertionAdress].field2 == "deleted")
                    {
                        continue;
                    }
                   if(this.arrayForReport[insertionAdress].field2 == null)
                   {
                        return -1;
                   }
                }
            }
            return -1;
        }

        public void addInArrayForReport(info record)
        {
            int hashAdreeLevel1 = hFunction1(record.field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == null || this.arrayForReport[hashAdreeLevel1].field2 == "deleted")
            {
                this.arrayForReport[hashAdreeLevel1] = record;
                this.recorded++;

                this.recordedCoef = recorded / arrayForReportSize;

                return;
            }
            else
            {
                int hasAdreeLevel2 = this.hFunction2(record.field2);
                for (int i = 1; i < arrayForReportSize; i++)
                {
                   int insertionAdress = (hashAdreeLevel1 + i * hasAdreeLevel2) % arrayForReportSize;
                   if (this.arrayForReport[insertionAdress].field2 == null || this.arrayForReport[insertionAdress].field2 == "deleted")
                   {
                        this.arrayForReport[insertionAdress] = record;
                        this.recorded++;

                        this.recordedCoef = recorded / arrayForReportSize;

                        return;
                   }
                   else
                   {
                        continue;
                   }
                }
            }
        }
        public void removeFromHashTable(info record)
        {
            int hashAdreeLevel1 = this.hFunction1(record.field2);
            if (this.arrayForReport[hashAdreeLevel1].field2 == record.field2)
            {
                this.arrayForReport[hashAdreeLevel1].field1 = "deleted";
                this.arrayForReport[hashAdreeLevel1].field2 = "deleted";
                this.arrayForReport[hashAdreeLevel1].field3 = "deleted";
                this.recorded--;
                this.recordedCoef = this.recorded / this.arrayForReportSize;
            }
            else
            {
                int hasAdreeLevel2 = this.hFunction2(record.field2);
                for (int i = 1; i < arrayForReportSize; i++)
                {
                    int insertionAdress = (hashAdreeLevel1 + i * hasAdreeLevel2) % arrayForReportSize;
                    if (this.arrayForReport[insertionAdress].field2 == record.field2)
                    {
                        this.arrayForReport[insertionAdress].field1 = "deleted";
                        this.arrayForReport[insertionAdress].field2 = "deleted";
                        this.arrayForReport[insertionAdress].field3 = "deleted";
                        this.recorded--;
                        this.recordedCoef = this.recorded / this.arrayForReportSize;
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }

        public void initHashTableFromArray()
        {
            for (int i = 0; i < arraySize - 1; i++)
            {
                this.addInArrayForReport(array[i]);
            }

        }

        /// <summary>
        /// Поиск по всем трём полям
        /// </summary>
        public Tuple<int, info, int> findInHashTable(info record)
        {
            int comparisonCounter = 1;
            if (recorded == 0)
            {
                info returnRec = new info();
                return Tuple.Create(-1, returnRec, -1);
            }
            else
            {   
                int hashAdreeLevel1 = hFunction1(record.field2);
                if (this.arrayForReport[hashAdreeLevel1].field2 == record.field2)
                {
                    comparisonCounter++;
                    return Tuple.Create(hashAdreeLevel1, this.arrayForReport[hashAdreeLevel1], comparisonCounter);
                }
                else
                {
                    int hasAdreeLevel2 = this.hFunction2(record.field2);
                    for (int i = 1; i < arrayForReportSize; i++)
                    {
                        comparisonCounter++;
                        int insertionAdress = (hashAdreeLevel1 + i * hasAdreeLevel2) % arrayForReportSize;
                        if (this.arrayForReport[insertionAdress].field2 == record.field2)
                        {
                            return Tuple.Create(insertionAdress, this.arrayForReport[insertionAdress], comparisonCounter);
                        }
                        else
                        {   if(this.arrayForReport[insertionAdress].field2 == "deleted")
                            {
                                continue;
                            }
                            else 
                            {
                                return Tuple.Create(-2, this.arrayForReport[insertionAdress], -2);
                            }
                        }
                    }
                }

            }
            return Tuple.Create(-2, new info(), comparisonCounter);
        }
        
        /// <summary>
        /// Поиск по должности
        /// </summary>
        public Tuple<int, info, int, string> findInHashTable(string post)
        {
            int comparisonCounter = 1;
            if (recorded == 0)
            {
                info returnRec = new info();
                return Tuple.Create(-1, returnRec, -1, "Справочник не содержит записей");
            }
            else
            {
                int hashAdreeLevel1 = hFunction1(post);
                if (this.arrayForReport[hashAdreeLevel1].field2 == post)
                {
                    return Tuple.Create(hashAdreeLevel1, this.arrayForReport[hashAdreeLevel1], comparisonCounter, "Запись найдена");
                }
                else
                {
                    int hasAdreeLevel2 = this.hFunction2(post);
                    for (int i = 1; i < arrayForReportSize; i++)
                    {
                        comparisonCounter++;
                        int insertionAdress = (hashAdreeLevel1 + i * hasAdreeLevel2) % arrayForReportSize;
                        if (this.arrayForReport[insertionAdress].field2 == post)
                        {
                            return Tuple.Create(insertionAdress, this.arrayForReport[insertionAdress], comparisonCounter, "Запись найдена");
                        }
                        else
                        {
                            if (this.arrayForReport[insertionAdress].field2 == null)
                            {
                                return Tuple.Create(-2, this.arrayForReport[insertionAdress], -2, "Запись не содержится в справочнике");
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }

            }
            return Tuple.Create(-2, new info(), comparisonCounter, "");
        }

        public Tuple<int, info, string> findInHashTableHandler(Tuple<int, info, int> returnedRecord)
        {
            if(returnedRecord.Item3 == -1)
            {
                return Tuple.Create(-1, returnedRecord.Item2, "Справочник не содержит записей");
            }
            else if (returnedRecord.Item3 == -2)
            {
                return Tuple.Create(-2, returnedRecord.Item2, "Запись не содержится в справочнике");
            }
            else
            {
                return Tuple.Create(returnedRecord.Item1, returnedRecord.Item2, "Запись найдена за  " + returnedRecord.Item3.ToString() + " сравнений");
            }
        }
        public string checkForUpReHashing()
        {
            if (this.recordedCoef < 0.75)
            {
                return null;
            }
            else
            {   this.arrayForReportSize *= 2;
                Array.Resize(ref this.arrayForReport, 0);
                Array.Resize(ref this.arrayForReport, this.arrayForReportSize);
                for(int i = 0; i < this.arraySize - 1; i++)
                {
                    addInArrayForReport(this.array[i]);
                }


                return "Уровень заполнения хеш-таблицы 75% - произошло рехеширование";
            }
        }

        public string checkForDownReHashing()
        {
            if (this.recordedCoef < 0.25)
            {
                return null;
            }
            else
            {
                this.arrayForReportSize /= 2;
                Array.Resize(ref this.arrayForReport, 0);
                Array.Resize(ref this.arrayForReport, this.arrayForReportSize);
                for (int i = 0; i < this.arraySize - 1; i++)
                {
                    addInArrayForReport(this.array[i]);
                }
                return "Уровень заполнения хеш-таблицы менее 25% - произошло рехеширование";
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

            //result *= key[0];
            result += 23;

            if(result % 2 == 0)
            {
                return result + 1;
            }
            else
            {
                return result;
            }
        }
         
        public info[] array;
        public info[] arrayForReport;
        public double recordedCoef { get; set; }
        public double recorded { get; set; }
        public int arrayForReportSize { get; set; }
        public int arraySize { get; set; }
    }
}
