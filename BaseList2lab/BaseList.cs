using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseList2lab
{
    public abstract class BaseList
    {
        protected int count = 0;

        public int Count { get { return count; } }

        public abstract void Add(int data);

        public abstract void Delete(int data);

        public abstract void Insert(int position, int data);

        public abstract int this[int i] { get; set; }

        public abstract void Clear();

        public abstract void Print();

        public abstract BaseList Clone();

        public abstract BaseList Reverse();

        public int Length { get { return count; } }

        public void Assign(BaseList sourceList)
        {
            Clear();
            for (int i = 0; i < sourceList.Count; i++)
            {
                Add(sourceList[i]);
            }
        }

        public void AssignTo(BaseList destList)
        {
            destList.Assign(this);
        }
        
        public virtual void Sort()
        {
            int temp;
            for (int i = 0; i < Count; i++)
            {
                int element = i;

                for (int j = i + 1; j < Count; j++)
                {
                    if (this[j] < this[element])
                    {
                        element = j;
                    }
                }

                temp = this[i];
                this[i] = this[element];
                this[element] = temp;
            }
        }

        public bool IsEqual(BaseList array)
        {
            if (this.count != array.count)
            {
                return false;
            }
            for (int i = 0; i < this.count; i++)
            {
                //Console.WriteLine(this[i]);
                //Console.WriteLine(array[i]);
                if (this[i] != (array[i]))
                {
                    return false;
                }
            }
            return true;
        }       
    }
}
