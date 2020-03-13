using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex_Navita_1
{
    public class Program
    {

        static void Main(string[] args)
        {

            //while (true)
            //{
                long N = 0;
                string recived = "";

                long maxfamily = 0;

                while (true)
                {
                    Console.WriteLine("entre com Numero");
                    N = long.Parse(Console.ReadLine());

                    if (N > 0)
                    {
                        break;
                    }

                    Console.WriteLine("O numero deve ser prositivo, entre com Numero");
                }

                recived = N.ToString();


                maxfamily = Convert.ToInt64(returnBrothers(recived));



                if (maxfamily > 100000000)
                {
                    Console.WriteLine(" seu numero é -1");
                }
                else
                {

                    Console.WriteLine("Seu numero maximo é " + maxfamily);
                }


                Console.ReadKey();
            //}
        }

        public static string returnBrothers(string recived)
        {

            List<long> brothers = new List<long>();
            //var ar = recived.Split();
            List<numberP> numberPs = new List<numberP>();

            long control = 1;
            long control2 = recived.Length;
            int p = 0;

            string m = "";

            while (recived.Length > 0)
            {
                numberP numberP = new numberP();
                numberP.numero = Convert.ToInt32(recived.Substring(0, 1));
                numberP.p = p;
                numberPs.Add(numberP);
                p++;
                recived = recived.Remove(0, 1);

            }



            while (control <= control2)
            {
                int number = numberPs.Max(t => t.numero);
                numberP numberP = numberPs.FirstOrDefault(a => a.numero == number);
                m = string.Concat(m, numberP.numero.ToString());

                numberPs.RemoveAll(c => c.p == numberP.p);


                control++;
            }

            return m;

        }
    }
}
