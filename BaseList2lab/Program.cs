using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseList2lab
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseList doubleList = new DoubleLinkedList();
            BaseList array = new MyArrayList();
            BaseList chain = new ChainList();

            Random rnd = new Random();
            /*
            for (int i = 0; i < 10; i++)
            {
                int rand = rnd.Next(1000);
                
                doubleList.Add(rand);
                
                //array.Add(rand);
                chain.Add(rand);
                //chain.Add(i);

            }
            */
            for(int i = 0; i < 1000; i++)
            {
                int rand = rnd.Next(4);
                int rand2 = rnd.Next(1000);
                int ii = rnd.Next(1000);
                switch (rand)
                {
                    case 1:
                        doubleList.Add(rand2);
                        chain.Add(rand2);
                        break;
                    case 2:
                        doubleList.Delete(i);
                        chain.Delete(i);
                        break;
                    case 3:
                        doubleList.Insert(ii, i);
                        chain.Insert(ii, i);
                        break;
                    case 4:
                        doubleList.Clear();
                        chain.Clear();
                        break;
                }
            }
            
            doubleList.Print();
            Console.WriteLine("----");
            chain.Print();

            //bool answer = array.IsEqual(chain);
            //array.Print();
            bool answer = (doubleList.IsEqual(chain));
            Console.WriteLine(answer);
            //Console.WriteLine(array.IsEqual(chain));
            //chain.Print();
            /*
            Console.WriteLine(array.IsEqual(doubleList));
            //doubleList.Print();
            Console.WriteLine(chain.IsEqual(doubleList));
            Console.WriteLine(chain.IsEqual(array));
            Console.WriteLine(doubleList.IsEqual(array));
            Console.WriteLine(doubleList.IsEqual(chain));
            Console.WriteLine(doubleList.Count);
            Console.WriteLine(array.Count);
            Console.WriteLine(chain.Count);

            */
            //chain.Clear();
            //chain.Insert(2, 100);
            //chain.Print();
            //Console.WriteLine("---");
            //chain.Reverse();
            //chain.Print();
            //Console.WriteLine("---");
            //doubleList.Insert(1, 100);
            //doubleList.Print();

            //doubleList.Insert(8, 99999);

            //doubleList.Sort();
            //doubleList.Print();


            Console.ReadKey();
        }
    }
}
