using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(Fibo(8));

            //Console.WriteLine(Power(5));

            //Foobar();

            //var arr = new int[] { 1, 2, 3, 1 };
            //var test = arr.GroupBy(x => x);

            //Console.WriteLine(HasDuplicates(new int[] { 1, 2, 3, 1 }));
            //Console.WriteLine(HasDuplicates(new int[] { 1, 2, 3, 4 }));

            Console.WriteLine(Reverse(new char[] { 'h', 'e', 'l', 'l', 'o' }));
        }

        public static bool HasDuplicates(int[] array) => array.GroupBy(x => x).Any(x => x.Count() > 1);

        public static char[] Reverse(char[] array) => array.Reverse().ToArray();

        public static int Fibo(int n)
        {
            if (n < 1) throw new Exception("Value less than 1");
            if (n < 3) return 1;
            return Fibo(n - 1) + Fibo(n - 2);
        }

        public static int Power(int n)
        {
            var result = 0;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static void Foobar()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 4 == 0)
                {
                    Console.WriteLine("Foo");
                    continue;
                }

                if (i % 7 == 0)
                {
                    Console.WriteLine("Bar");
                    continue;
                }

                if (i % 4 == 0 && i % 7 == 0)
                {
                    Console.WriteLine("FooBar");
                    continue;
                }

                Console.WriteLine(i);
            }
        }
    }
}

