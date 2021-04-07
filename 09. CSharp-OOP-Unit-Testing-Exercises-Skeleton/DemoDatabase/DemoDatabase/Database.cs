using System;
using System.Collections.Generic;
using System.Text;

namespace DemoDatabase
{
    public class Database
    {
        private const int defaultLength = 16;
        private int[] database;
        private int index;

        public Database(params int[] numbers)
        {
            ValidateCollectionSize(numbers);
            this.index = 0;
            this.database = new int[defaultLength];
            this.DatabaseElements = numbers;
        }
        public int[] DatabaseElements
        {
            get
            {
                List<int> numbers = new List<int>();
                for (int i = 0; i < index; i++)
                {
                    numbers.Add(this.database[i]);
                }
                return numbers.ToArray();
            }
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    this.database[this.index] = value[i];
                    this.index++;
                }
            }
        }
        public void Add(int number)
        {
            if (index >= defaultLength)
            {
                throw new InvalidOperationException("Database is full.");
            }
            this.database[this.index] = number;
            this.index++;
        }
        public void Remove()
        {
            if (this.index == 0)
            {
                throw new InvalidOperationException("Database is empty.");
            }
            this.database[this.index - 1] = default(int);
            this.index--;
        }
        private void ValidateCollectionSize(int[] value)
        {
            if (value.Length > defaultLength || value.Length < 1)
            {
                throw new InvalidOperationException("Invalid collection size.");
            }
        }
    }
}
