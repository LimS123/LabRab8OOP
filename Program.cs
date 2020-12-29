using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LabRab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> S1 = new CollectionType<int>() { c = { 2, 4, 6 } };
                CollectionType<int> S2 = new CollectionType<int>() { c = { 2, 0, 7 } };
                S2.add(S1, S2);
                string writePath = @"C:\text.txt";
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var i in S2.c)
                    {
                        sw.WriteLine(i);
                    }

                }
                using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ошибка вида {ex.Message}");

            }
            finally
            {
                Console.WriteLine("Программа завершена упешно");
            }
            Console.ReadLine();
        }
        public class CollectionA<T>
        {

        }
        public class CollectionB<T> where T : CollectionA<int>
        {

        }
        interface IInterface<T>
        {
            CollectionType<T> add(CollectionType<T> S1, CollectionType<T> S2);
            CollectionType<T> delete(CollectionType<T> S2);
            CollectionType<T> display(CollectionType<T> S2);
        }
        public class CollectionType<T> : IInterface<T>
        {
            public bool Check(int length = 4)
            {
                var counter = 0;
                foreach (var i in c)
                {
                    counter++;
                }
                if (counter == length)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public List<T> c = new List<T> { };
            public CollectionType<T> add(CollectionType<T> S1, CollectionType<T> S2)
            {
                if ((S1.c != null && S1.c.Count > 0) && (S2.c != null && S2.c.Count > 0))
                {
                    S2.c.AddRange(S1.c);
                }
                S2.c = S2.c.Distinct().ToList();
                return S2;
            }
            public CollectionType<T> delete(CollectionType<T> S2)
            {
                if (S2.c != null && S2.c.Count > 0)
                {
                    S2.c.RemoveAt(Count(S2));
                }
                return S2;
            }
            public CollectionType<T> display(CollectionType<T> S2)
            {
                foreach (T i in S2.c)
                {
                    Console.WriteLine(i);
                }
                return S2;
            }
            public static int Count(CollectionType<T> S2)
            {
                int counter = 0;
                foreach (T i in S2.c)
                {
                    counter++;
                }
                return counter;
            }
            public static CollectionType<T> operator +(CollectionType<T> S1, CollectionType<T> S2)
            {
                CollectionType<T> S3 = new CollectionType<T>() { };
                if ((S1.c != null && S1.c.Count > 0) && (S2.c != null && S2.c.Count > 0))
                {

                    S3.c.AddRange(S1.c);
                    S3.c.AddRange(S2.c);
                }
                S3.c = S3.c.Distinct().ToList();
                return S3;
            }
            public static explicit operator int(CollectionType<T> set)
            {
                var x = set.c.Count();
                return x;
            }
            public static bool operator true(CollectionType<T> set)
            {
                return set.Check();
            }
            public static bool operator false(CollectionType<T> set)
            {
                return set.Check();
            }
        }
    }
}
