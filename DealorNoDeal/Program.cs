using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DealorNoDeal
{
    class Program
    {
        public struct PlayerInfo
        {
            public string firstName;
            public string lastName;
            public string interest;
        }
        public struct Finalists
        {
            public string firstName;
            public string lastName;
            public string interest;
        }
        static void Main(string[] args)
        {
            // Variable declarations 
            int input = 0;
            PlayerInfo[] contestant = new PlayerInfo[21];
            Finalists[] finalist = new Finalists[10];
            //----------------------


            while (input != 5)
            {
                Console.Write("1".PadRight(10));
                Console.Write("Load Player List".PadRight(10));
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("2".PadRight(10));
                Console.Write("Update Interest Feild".PadRight(10));
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("3".PadRight(10));
                Console.Write("Generate 10 finalists".PadRight(10));
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("4".PadRight(10));
                Console.Write("Pick contestant".PadRight(10));
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("5".PadRight(10));
                Console.Write("Exit".PadRight(10));
                Console.WriteLine();
                Console.WriteLine();
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        NameFinder(contestant);
                        break;

                    case 2:
                        Console.Clear();
                        FeildUpdate(contestant);
                        break;

                    case 3:
                        Console.Clear();
                        FinalistSort(contestant, finalist);
                        break;

                    case 4:
                        Console.Clear();
                        GameStart(finalist);
                        break;

                    case 5:

                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
        }
        public static void NameFinder(PlayerInfo[] contestant)
        {
            // Variable declarations 
            PlayerInfo temp;
            StreamReader sr = new StreamReader(@"DealOrNoDeal.txt");
            //----------------------

            for (int i = 0; i < contestant.Length; i++)
            {
                contestant[i].firstName = sr.ReadLine();
                contestant[i].lastName = sr.ReadLine();
                contestant[i].interest = sr.ReadLine();
            }
            for(int i = 0; i < contestant.Length - 1; i++)
            {
                for(int pos = 0; pos < contestant.Length - 1; pos++)
                {
                    if(contestant[pos + 1].lastName.CompareTo(contestant[pos].lastName)< 0)
                    {
                        temp = contestant[pos + 1];
                        contestant[pos + 1] = contestant[pos];
                        contestant[pos] = temp;
                    }
                }
            }
            Console.Write("First Name".PadRight(20));
            Console.Write("Last Name".PadRight(20));
            Console.Write("Interest".PadRight(20));
            Console.WriteLine();
            for(int i = 0; i < contestant.Length; i++)
            {
                Console.WriteLine();
                Console.Write(contestant[i].firstName.PadRight(20));
                Console.Write(contestant[i].lastName.PadRight(20));
                Console.Write(contestant[i].interest.PadRight(20));
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            sr.Close();
            Console.ReadKey();
            Console.Clear();
        }


        public static void FeildUpdate(PlayerInfo[] contestant)
        {
            // Variable declarations 
            string input;
            StreamWriter sw = new StreamWriter(@"DealOrNoDeal.txt");
            //----------------------

            Console.WriteLine("Who would you like to update?");
            input = Console.ReadLine();
            
            for(int i = 0; i < contestant.Length; i++)
            {
              if(input == contestant[i].firstName)
                {
                    Console.WriteLine($"You are updateing {contestant[i].firstName} {contestant[i].lastName}s interest feild");
                    Console.WriteLine();
                    Console.Write($"Their current interest is set to {contestant[i].interest}. What would you like to change it to?");
                    input = Console.ReadLine();
                    contestant[i].interest = input;
                }
            }
           for(int i = 0; i < contestant.Length; i++)
            {
                sw.WriteLine(contestant[i].firstName);
                sw.WriteLine(contestant[i].lastName);
                sw.WriteLine(contestant[i].interest);
            }
            sw.Close();
            Console.WriteLine("Feild has been updated");
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
            
        }

        public static void FinalistSort(PlayerInfo[] contestant, Finalists[] finalist)
        {
            // Variable declarations 
            int[] numList = new int[10];
            NumGen(ref numList);
            //----------------------

            Console.WriteLine("Your finalists are!");
            Console.WriteLine();
            for (int i = 0; i < finalist.Length; i++)
            {
                finalist[i].firstName = contestant[numList[i]].firstName;
                finalist[i].lastName = contestant[numList[i]].lastName;
                finalist[i].interest = contestant[numList[i]].interest;
                Console.Write(finalist[i].firstName.PadRight(20));
                Console.Write(finalist[i].lastName.PadRight(20));
                Console.Write(finalist[i].interest.PadRight(20));
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to return to the main menu");
            Console.ReadKey();
            Console.Clear();
        }

        public static void NumGen(ref int[] numList)
        {
            // Variable declarations 
            Random rand = new Random();
            int num;
            //----------------------

            for (int i = 0; i < numList.Length; i++)
            {
                num = rand.Next(0, numList.Length);
                for (int j = 0; j < i; j++)
                {
                    while (num == numList[j])
                    {
                        num = rand.Next(0, numList.Length);
                        j = 0;
                    }
                }
                numList[i] = num;
            }
        }
        public static void CaseSort(ref int[] cases)
        {
            // Variable declarations 
            int[] money = new int[26];
            int[] numList = new int[26];
            //----------------------

            NumGen(ref numList);

            money[0] = 1;
            money[1] = 5;
            money[2] = 10;
            money[3] = 15;
            money[4] = 25;
            money[5] = 50;
            money[6] = 75;
            money[7] = 100;
            money[8] = 200;
            money[9] = 300;
            money[10] = 400;
            money[11] = 500;
            money[12] = 750;
            money[13] = 1000;
            money[14] = 5000;
            money[15] = 10000;
            money[16] = 25000;
            money[17] = 50000;
            money[18] = 75000;
            money[19] = 400000;
            money[20] = 200000;
            money[21] = 300000;
            money[22] = 400000;
            money[23] = 500000;
            money[24] = 750000;
            money[25] = 1000000;


            for(int i = 0; i < numList.Length;i++)
            {
                cases[i] = money[numList[i]];
            }
        }

        public static void OfferMaker(int[] cases, int turns, int offer)
        {
            int sum = 0;

            for(int i = 0; i < cases.Length; i++)
            {
                sum += cases[i];
            }
            sum = sum * turns / 10;
            offer = sum;
        }

        public static void GameStart(Finalists[] finalist)
        {
            // Variable declarations 
            Random rand = new Random();
            int[] cases = new int[26];
            int num;
            //----------------------
            //Temp
            int pick;
            int[] openedCase = new int[26];
            int playerCase;
            int call = 7;
            int turns = 0;
            string choice = " ";
            int offer = 0;
            string[] moneyDisplay = new string[26];
            string[] casesDisplay = new string[26];
            
            //----------------------

            CaseSort(ref cases);


            num = rand.Next(0, 10);
            Console.WriteLine("The player tonight is!");
            Console.WriteLine();
            Console.Write(finalist[num].firstName.PadRight(15));
            Console.Write(finalist[num].lastName.PadRight(15));
            Console.Write(finalist[num].interest.PadRight(15));
            Console.WriteLine();
            Console.WriteLine("Press Enter to start");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Pick your case!");
            pick = Convert.ToInt32(Console.ReadLine());
            playerCase = cases[pick];
            cases[pick] = 0;
            while (turns < cases.Length || choice != "NO DEAL")
            {
                for (int i = 0; i < moneyDisplay.Length - 1; i++)
                {
                    Console.WriteLine();
                }

                Console.WriteLine("Now pick a case to open");
                pick = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Case {pick} had ${cases[pick]} inside!");
                turns++;
                if (turns == call)
                {
                    OfferMaker(cases, turns, offer);
                    Console.WriteLine($"The banker is offering you {offer}. Deal or No Deal?");
                    choice = Console.ReadLine().ToUpper();
                    call--;
                }
            }
            if(choice == "DEAL")
            {
                Console.WriteLine($"Congratulations you win {offer}. You had {playerCase} inside your case");
                if(offer < playerCase)
                {
                    Console.WriteLine("Oh well better luck next time");
                }
            }
            if(turns == 26)
            {
                Console.WriteLine($"Your case has {playerCase}");
            }
            Console.ReadKey();


            
        }
    }
}
