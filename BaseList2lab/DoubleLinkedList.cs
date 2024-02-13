using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseList2lab
{
    /*
    class DoubleLinkedList
    {
        public DoubleLinkedList(int data)
        {
            Data = data;
        }
        public int Data { get; set; }
        public DoubleLinkedList Previous { get; set; }
        public DoubleLinkedList Next { get; set; }
    }
    */

    /*
    public int value;
    public ChainList next;

    public ChainList(int value = 0, ChainList next = null)
    {
        this.value = value;
        this.next = next;
    }
    */

    public class DoubleLinkedList : BaseList
    {
        public int Data;
        public DoubleLinkedList Next;
        public DoubleLinkedList Previous;

        public DoubleLinkedList(int data = 0, DoubleLinkedList next = null, DoubleLinkedList previous = null)
        {
            this.Data = data;
            this.Next = next;
            this.Previous = previous;
        }

        private DoubleLinkedList Head { get; set; }

        private DoubleLinkedList Tail { get; set; }

        public override void Add(int data)
        {
            DoubleLinkedList DoubleLinkedList = new DoubleLinkedList(data);

            if (Head == null)
                Head = DoubleLinkedList;
            
            else
            {
                Tail.Next = DoubleLinkedList;
                DoubleLinkedList.Previous = Tail;
            }
            Tail = DoubleLinkedList;
            count++;
        }

        public override void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public override void Delete(int position)
        {
            if (Head == null)
            {
                return;
            }
            if (position == 0)
            {
                Head = Head.Next;
            }
            if (position == count - 1)
            {
                Tail = Tail.Previous;
            }

            if (position < count & count != 0)
            {
                if (position / 2 <= count)
                {
                int i = 0;
                DoubleLinkedList current = Head;
                DoubleLinkedList last = null;
                    while (true)
                    {
                        if (i == position)
                        {
                            last.Next = current.Next;
                            count--;
                            break;
                        }
                        i++;
                        last = current;
                        current = current.Next;
                    }
                }
                else
                {
                    int i = count;
                    DoubleLinkedList current = Tail;
                    DoubleLinkedList last = null;
                    while (true)
                    {
                        if (i == position)
                        {
                            last.Previous = current.Previous;
                            count--;
                            break;
                        }
                        i--;
                        last = current;
                        current = current.Previous;
                    }
                }
            }
            else
            {
                return;
            }
        }

        public override void Insert(int position, int data)
        {
            DoubleLinkedList newNode = new DoubleLinkedList(data);
            DoubleLinkedList current;

            if (position == 0)
            {
                newNode.Next = Head;
                Head = newNode;
                count++;
                return;
            }

            if (position == count - 1)
            {
                newNode.Previous = Tail;
                Tail = newNode;
                count++;
                return;
            }

            if (position < count)
            {
                if (position / 2 <= count)
                {
                    current = Head;
                    DoubleLinkedList last = null;
                    int i = 0;
                    while (true && current != null)
                    {
                        if (i == position)
                        {
                            last.Next = newNode;
                            newNode.Next = current;
                            count++;
                            break;
                        }
                        i++;
                        last = current;
                        current = current.Next;
                    }
                }
                else
                {
                    current = Tail;
                    DoubleLinkedList next = null;
                    int i = count - 1;
                    while (true)
                    {
                        if (i == position)
                        {
                            next.Previous = newNode;
                            newNode.Previous = current;
                            count++;
                            break;
                        }
                        i--;
                        next = current;
                        current = current.Previous;
                    }
                }
            }
            else
            {
                return;
            }

        }

        public override void Print()
        {
            DoubleLinkedList current = Head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
        }

        public override BaseList Clone()
        {
            ChainList chainList = new ChainList();
            chainList.Assign(this);
            return chainList;
        }

        private DoubleLinkedList LastNode(int index)
        {
            DoubleLinkedList current = Head;

            if (index >= count)
            {
                return null;
            }
            if (index == 0)
            {
                return Head;
            }
            if (index == count - 1)
            {
                return Tail;
            }
            if (index == 1)
            {
                return Head.Next;
            }
            if (index == count - 2)
            {
                return Tail.Previous;
            }
            if(current == null)
            {
                return current.Previous;
            }
            
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }

        public override int this[int index]
        {
            get
            {
                return LastNode(index).Data;
            }

            set
            {
                LastNode(index).Data = value;
            }
        }


        public override void Sort()
        {
            if (count <= 1)
            {
                return;
            }

            DoubleLinkedList current;
            int temp;

            for (int i = 0; i < count; i++)
            {
                current = Head;

                while (current != null & current.Next != null)
                {
                    if (current.Data > current.Next.Data)
                    {
                        temp = current.Data;
                        current.Data = current.Next.Data;
                        current.Next.Data = temp;
                    }
                    current = current.Next;
                }
            }
        }


        public override BaseList Reverse()
        {
            throw new NotImplementedException();
        }
    }
}