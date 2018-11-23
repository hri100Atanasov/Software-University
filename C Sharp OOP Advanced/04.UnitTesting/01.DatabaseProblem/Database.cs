using System;
using System.Collections.Generic;

namespace _01.DatabaseProblem
{
    public class Database
    {
        private int?[] integersDatabase;
        private int index;


        public Database(params int?[] data)
        {
            if (data.Length > 16)
            {
                throw new InvalidOperationException("Size of the array should be 16!");
            }
            integersDatabase = new int?[16];
            index = data.Length;
            Array.Copy(data, integersDatabase, index);
        }

        public void Add(int? element)
        {
            if (index > 15)
            {
                throw new InvalidOperationException("Database is full!");
            }
            integersDatabase[index++] = element;
        }

        public void Remove()
        {
            if (index == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            var tempArr = new List<int?>(integersDatabase);
            tempArr.RemoveAt(--index);
            integersDatabase = tempArr.ToArray();
        }

        public int?[] Fetch()
        {
            return integersDatabase;
        }
    }
}
