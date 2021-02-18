using System;

namespace stream_022
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Captain What is your todays Journal");
            string input = "";
            Captain_Jornal jornal = new Captain_Jornal();
            while (!input.Contains("stop"))
            {
                input = Console.ReadLine();
                if (input.Contains("start"))
                    while (!input.Contains("stop"))
                    {
                        jornal.Save(input);
                        input = Console.ReadLine();

                    }

            }
            jornal.endLine();
        }
    }
}
