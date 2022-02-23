using System;

namespace ConsoleApp10
{
    class Program
    {

        static int score(int[]numb)
        {
            int count = 0;
            for(int i=0;i<numb.Length;i++)
            {
                if(numb[i]%2==0)
                {
                    count++;
                }else
                {
                    count = count + 3;
                }
                if(numb[i]==8)
                {
                    count = count + 5;
                }
            }
            return count;
        }
        static void Main(string[] args)
        {
            int[] example1 = new int[] { 1,2,3,4,5};
            var loox =score(example1);
            Console.WriteLine("example1 =>{ 1,2,3,4,5} => " + loox);

            int[] example2 = new int[] { 15, 25, 35 };
            loox = score(example2);
            Console.WriteLine("example2 =>{ 15, 25, 35 } => " + loox);

            int[] example3 = new int[] { 8,8 };
            loox = score(example3);
            Console.WriteLine("example3 =>{ 8,8 } => " + loox);

            Console.ReadLine();
        }
    }
}
