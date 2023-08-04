/*
* FILE : Program.cs
* PROJECT : ParallelProcessig
* PROGRAMMER : Alex Palmer
* FIRST VERSION : 2021-11-11
* DESCRIPTION :
* Testing Parallel Processing
*/
using System;
using System.Threading.Tasks;

namespace Parallel_Processing
{
    /*
    * NAME : Program
    * PURPOSE : The Program Calss to text the Parrallel processing functions
    */
    class Program
    {
        
        
        static void Main(string[] args)
        {
            string spass = "";
            string stime = "";
            bool validpassword = false;
            bool validTime = false;
            //check if there is a password arg
            if (args.Length < 1)
            {

                //keep asking until a valid password
                while (validpassword == false)
                {
                    Console.WriteLine("Please enter a password");
                    spass = Console.ReadLine();
                    if (spass.Length >= 6 && spass.Length <= 18 && float.TryParse(spass, out float var) == true)
                    {
                        validpassword = true;
                    }
                }
            }
            else
            {
                spass = args[0];
                if (spass.Length >= 6 && spass.Length <= 18 && float.TryParse(spass, out float var) == true)
                {
                    validpassword = true;
                }
                while (validpassword == false)
                {
                    Console.WriteLine("Please enter a password");
                    spass = Console.ReadLine();
                    if (spass.Length >= 6 && spass.Length <= 18 && float.TryParse(spass, out float va2) == true)
                    {
                        validpassword = true;
                    }
                }
            }
            //check if the time is valid
            if (args.Length < 2)
            {

                while (validTime == false)
                {
                    Console.WriteLine("Please enter a time limit (in Milliseconds)");
                    stime = Console.ReadLine();
                    if (int.TryParse(stime, out int var) == true)
                    {
                        validTime = true;
                    }
                }
            }
            else
            {
                stime = args[1];
                if (int.TryParse(stime, out int var) == true)
                {
                    validTime = true;
                }
                while (validTime == false)
                {
                    Console.WriteLine("Please enter a time limit (in Milliseconds)");
                    stime = Console.ReadLine();
                    if (int.TryParse(stime, out int var2) == true)
                    {
                        validTime = true;
                    }
                }
            }
            //start the timer
            DateTime StartTime = DateTime.Now;
            //start the function
            passwordchecker(spass, int.Parse(stime), StartTime);
            //calculate the time it took to complete and write it down
            TimeSpan time = DateTime.Now - StartTime;
            Console.WriteLine("The time took to finish function, Sequential " + time.TotalMilliseconds.ToString() + " Milliseconds");
            //repeated working the function in Parallel
            StartTime = DateTime.Now;
            Parallel.Invoke(() => passwordchecker(spass, int.Parse(stime), StartTime));
            time = DateTime.Now - StartTime;
            Console.WriteLine("The time took to finish function, Parallel " + time.TotalMilliseconds.ToString() + " Miliseconds");
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
        /*
    * NAME : passwordchecker
    * PURPOSE : 
    * To find the password in the regelated time limit
    */
        static void passwordchecker(string password, int time, DateTime start)
        {
            int counter = 0;
            while(password != counter.ToString("000000"))
            {
                counter++;
                TimeSpan check = DateTime.Now - start;
                if((int)check.TotalMilliseconds == time)
                {
                    Console.WriteLine("Times up!!! Failed to find Password with number of attempts " + counter.ToString());
                    return;
                }

            }
            Console.WriteLine("Found password " + counter.ToString("000000") + " with number of attempts " + counter.ToString());
            return;
        }
    }
}
