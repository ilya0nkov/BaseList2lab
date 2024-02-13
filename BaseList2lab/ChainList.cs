using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseList2lab
{
    public class ChainList : BaseList
    {
        public int value;
        public ChainList next;

        public ChainList(int value = 0, ChainList next = null)
        {
            this.value = value;
            this.next = next;
        }

        public override BaseList Reverse()
        {
            if (Head == null || Head.next == null)
            {
                return this;
            }
            ChainList newHead = RealReverse(Head, Head.next);
            Head.next = null;
            Head = newHead;
            return this;

        }

        private ChainList RealReverse(ChainList point1, ChainList point2)
        {
            if (point2 == null)
            {
                return point1;
            }
            else
            {
                ChainList newHead = RealReverse(point2, point2.next);
                point2.next = point1;
                return newHead;
            }
        }

        private ChainList Head { get; set; }

        public override void Add(int value)
        {
            if (Head == null)
            {
                Head = new ChainList(value);
                count++;
            }
            else
            {
                ChainList current = Head;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new ChainList(value);
                count++;
            }
        }

        public override void Clear()
        {
            Head = null;
            count = 0;
        }

        public override void Delete(int position)
        {
            int i = 0;
            ChainList current = Head;
            ChainList last = null;
            if (position == 0 && Head != null)
            {
                Head = Head.next;
            }
            if (position < count & count != 0)
            {
                while (true)
                {
                    if (i == position)
                    {
                        last.next = current.next;
                        count--;
                        break;
                    }
                    i++;
                    last = current;
                    current = current.next;
                }
            }
            else
            {
                return;
            }
        }

        public override void Insert(int position, int value)
        {
            ChainList newNode = new ChainList(value);
            ChainList current = Head;
            ChainList last = null;
            int i = 0;
            if (position == 0)
            {
                newNode.next = Head;
                Head = newNode;
                count++;
                return;
            }

            if (position < count)
            {
                while (true)
                {
                    if (i == position)
                    {
                        last.next = newNode;
                        newNode.next = current;
                        count++;
                        break;
                    }
                    i++;
                    last = current;
                    current = current.next;
                }
            }
            else
            {
                return;
            }
        }

        public override void Print()
        {
            ChainList current = Head;
            while (current != null)
            {
                Console.WriteLine(current.value);
                current = current.next;
            }
        }

        public override BaseList Clone()
        {
            ChainList chainList = new ChainList();
            chainList.Assign(this);
            return chainList;
        }

        private ChainList LastNode(int index)
        {
            ChainList current = Head;

            if (index >= count)
            {
                return null;
            }

            for (int i = 0; i < index; i++)
            {
                current = current.next;
            }
            return current;
        }

        public override int this[int index]
        {
            get
            {
                return LastNode(index).value;
            }

            set
            {
                LastNode(index).value = value;
            }
        }


        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            ChainList current;
            int temp;

            for (int i = 0; i < count; i++)
            {
                current = Head;

                while (current != null & current.next != null)
                {
                    if (current.value > current.next.value)
                    {
                        temp = current.value;
                        current.value = current.next.value;
                        current.next.value = temp;
                    }
                    current = current.next;
                }
            }
        }
    }
}
