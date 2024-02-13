using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseList2lab
{
    public class MyArrayList : BaseList
    {

        private static int[] data = null;

        private static void Expand()
        {
           
            if (data == null)
            {
                data = new int[1];
                return;
            }
            /*
            if (count < data.Length)
            {
                return;
            }
            */
            int[] temp = new int[data.Length];

            for (int i = 0; i < data.Length; i++)
            {
                temp[i] = data[i];
            }
            data = new int[data.Length * 2];
            for (int i = 0; i < temp.Length; i++)
            {
                data[i] = temp[i];
            }
            temp = null;
        }

        public override void Add(int a)
        {
            Expand();
            data[count] = a;
            count++;
        }

        public override void Delete(int position)
        {
            Expand();
            if (position < count)
            {
                for (int i = position; i < count; i++)
                {
                    data[i] = data[i + 1];
                }
                count--;
            }
        }

        public override void Insert(int position, int a)
        {
            Expand();
            if (position < count)
            {
                count++;
                for (int i = count - 1; i > position; i--)
                {
                    data[i] = data[i - 1];
                }
                data[position] = a;
            }
        }

        public override void Clear()
        {
            data = null;
            count = 0;
        }

        public override int this[int index]
        {
            get
            {
                if (index >= count) return 0;
                return data[index];
            }
            set
            {
                if (index >= count) Expand();
                data[index] = value;
            }
        }

        public override void Print()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(data[i]);
            }
        }

        public override BaseList Clone()
        {
            MyArrayList arrayList = new MyArrayList();
            arrayList.Assign(this);
            return arrayList;
        }
        public override BaseList Reverse()
        {
            throw new NotImplementedException();
        }
    }
}
