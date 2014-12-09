using System;
using System.Numerics;

namespace _05_BitArray
{
    class BitArray
    {
        private byte[] bitArray;

        public BitArray(int numberOfBits)
        {
            this.NumberOfBits = numberOfBits;
        }

        public int NumberOfBits
        {
            get { return this.bitArray.Length; }
            private set
            {
                if (value > 100000 || value < 1)
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.bitArray = new byte[value];
            }
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index >= this.NumberOfBits)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));                    
                }
                return this.bitArray[index];
            }
            set
            {
                if (index < 0 || index >= this.NumberOfBits)
                {
                    throw new IndexOutOfRangeException(String.Format("Index {0} is invalid!", index));
                }
                if (value != 1 && value != 0)
                {
                    throw new ArgumentException("The bit value can be either 0 or 1");
                }
                this.bitArray[index] = value;
            }
        }

        public override string ToString()
        {
            BigInteger result = 0;
            for (int i = 0; i < this.NumberOfBits; i++)
            {
                if (this.bitArray[i] == 1)
                {
                    //result += (BigInteger)Math.Pow(2, i);  // doesn't work with really big numbers
                    BigInteger currentNumber = 1;
                    for (int j = 0; j < i; j++)
                    {
                        currentNumber *= 2;
                    }
                    result += currentNumber;
                }
            }
            return result.ToString();
        }
    }
}
