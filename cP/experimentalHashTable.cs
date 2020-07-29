using System;
using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace expHashTable
{
    class experimetalHashTable
    {
        public experimetalHashTable(int mapSize)
        {   
            this.mapSize = mapSize;
            this.map = new Tuple<string, int>[mapSize];
            this.arraySize = 1;
            this.array = new string[arraySize];
        }
        public string pushBackArray(string field1)
        {
            array[arraySize - 1] = field1;
            arraySize++;
            Array.Resize(ref array, arraySize);
            return "Запись успешно добавлена";
        }

        public Tuple<int, string, int> calcHashAndInsertion(string key, int index, DataGridView dgw)
        {
            int firstAdress = func1(key);
            int offsetFromFirst = funс2(key);
            int cc = 0;

            for (int i = 0; i < mapSize; i++)
            {
                int insertionAdress = (firstAdress + i * offsetFromFirst) % mapSize;
                if (map[insertionAdress] != null)
                {
                    cc++;
                    collisionCounter++;
                    continue;
                }
                else
                {
                    map[insertionAdress] = Tuple.Create(key, index);
                    recorded++;
                    recordedCoef = recorded / mapSize;
                    dgw.Rows.Add(insertionAdress, key);
                    if (recordedCoef > 0.75)
                    {
                        recorded = 0;
                        recordedCoef = 0;
                        collisionCounter = 0;
                        return Tuple.Create(cc, rehasing(dgw), insertionAdress);
                    }
                    return Tuple.Create(cc, "", insertionAdress);
                }
            }
            return Tuple.Create(0, "", 0);
        }
        public Tuple<int, string, int> calcHashAndInsertion(string key, int index)
        {
            int firstAdress = func1(key);
            int offsetFromFirst = funс2(key);
            int cc = 0;

            for (int i = 0; i < mapSize; i++)
            {
                int insertionAdress = (firstAdress + i * offsetFromFirst) % mapSize;
                if(map[insertionAdress] != null)
                {
                    cc++;
                    collisionCounter++;
                    continue;
                }
                else
                {
                    map[insertionAdress] = Tuple.Create(key, index);
                    recorded++;
                    recordedCoef = recorded/mapSize;
                    return Tuple.Create(cc, "", insertionAdress);
                }
            }
            return Tuple.Create(0, "", 0);
        }

        public Tuple<int,int> calcHash(string key)
        {
            int firstAdress = func1(key);
            int offsetFromFirst = funс2(key);
            int collisionСounter = 1;

            for (int i = 0; i < mapSize; i++)
            {
                int insertionAdress = (firstAdress + i * offsetFromFirst) % mapSize;
                if (map[insertionAdress] == null)
                {
                    return Tuple.Create(-1, -1);
                }
                if (map[insertionAdress].Item1 != key)
                { 
                    collisionСounter++;
                    continue;
                }
                else
                {
                    return Tuple.Create(insertionAdress, collisionСounter);
                }
            }
            return Tuple.Create(0, collisionСounter);
        }
        public string rehasing(DataGridView dgw)
        {
            mapSize *= 2;
            recorded = 0;
            recordedCoef = 0;
            dgw.Rows.Clear();
            Array.Resize(ref map, 0);
            Array.Resize(ref map, mapSize);
            for (int i = 0; i < arraySize - 1; i++)
            {
                Tuple<int, string, int> x = calcHashAndInsertion(array[i], i, dgw);
            }
            return "да";
        }

        public Tuple<int, string, int> calcHashAndInsertion_1(string key, int index)
        {
            int firstAdress = func1_1(key);
            int offsetFromFirst = funс2_1(key);
            int cc = 0;

            for (int i = 0; i < mapSize; i++)
            {
                int insertionAdress = (firstAdress + i * offsetFromFirst) % mapSize;
                if (map[insertionAdress] != null)
                {
                    cc++;
                    collisionCounter++;
                    continue;
                }
                else
                {
                    map[insertionAdress] = Tuple.Create(key, index);
                    recorded++;
                    recordedCoef = recorded / mapSize;
                    return Tuple.Create(cc, "", insertionAdress);
                }
            }
            return Tuple.Create(0, "", 0);
        }
        public Tuple<int, int> calcHash_1(string key)
        {
            int firstAdress = func1_1(key);
            int offsetFromFirst = funс2_1(key);
            int collisionСounter = 0;

            for (int i = 0; i < mapSize; i++)
            {
                int insertionAdress = (firstAdress + i * offsetFromFirst) % mapSize;
                if (map[insertionAdress].Item1 != key)
                {
                    collisionСounter++;
                    continue;
                }
                else
                {
                    return Tuple.Create(insertionAdress, collisionСounter);
                }
            }
            return Tuple.Create(0, collisionСounter);
        }

        public int func1(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }

            return result % mapSize;
        }
        public int funс2(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }

            if (result % 2 == 0)
            {
                return result+1;
            }
            else
            {
                return result;
            }
        }
        public int func1_1(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }
            result >>= 2;
            return result % mapSize;
        }
        public int funс2_1(string key)
        {
            int result = 0;

            foreach (char letter in key)
            {
                result += letter;
            }
            result >>= 3;
            if (result % 2 == 0)
            {
                return result + 1;
            }
            else
            {
                return result;
            }
        }

        public string[] array;
        public Tuple<string, int>[] map;
        public double recorded;
        public double recordedCoef;
        public int mapSize;
        public int arraySize;
        public int collisionCounter;
    }
}
