using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace DealorNoDeal
{
    class Program
    {
        // Struct that contains imported student information
        public struct PlayerInfo
        {
            public string firstName;
            public string lastName;
            public string interest;
        }

        // Contains imported information for finalists info
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

            // Main menu switch case
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

        // Sorting method for creating 
        public static void NameFinder(PlayerInfo[] contestant)
        {
            // Variable declarations 
            PlayerInfo temp;
            StreamReader sr = new StreamReader(@"DealOrNoDeal.txt");
            //----------------------

            // Reads Deal or No Deal text file for student information and assigns them to a variable
            for (int i = 0; i < contestant.Length; i++)
            {
                contestant[i].firstName = sr.ReadLine();
                contestant[i].lastName = sr.ReadLine();
                contestant[i].interest = sr.ReadLine();
            }

            // Bubble sort for sorting students into alphabetacale order sorting from last name
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

            // Prints out finalist information with formating
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

        // Method for updateing player interest feilds
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

            // Writes updated interest information back onto the deal or no deal text
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

        // Method for creating the finalist array
        public static void FinalistSort(PlayerInfo[] contestant, Finalists[] finalist)
        {
            // Variable declarations 
            int[] numList = new int[10];
            int arraySize = 21;
            NumGen(ref numList, arraySize);
            //----------------------
            
            
            // Displays finalist information 
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

        // Method for creating array of non duplicate random numbers 
        public static void NumGen(ref int[] numList, int arraySize)
        {
            // Variable declarations 
            Random rand = new Random();
            int num;
            //----------------------

            for (int i = 0; i < numList.Length; i++)
            {
                num = rand.Next(0, arraySize);
                for (int j = 0; j < i; j++)
                {
                    while (num == numList[j])
                    {
                        num = rand.Next(0, arraySize);
                        j = 0;
                    }
                }
                numList[i] = num;            }
        }

        // Method for providing cases with money values 
        public static void CaseSort(double?[] cases, double?[] moneyPosition)
        {
            // Variable declarations 
            double[] money = new double[26];
            int[] numList = new int[26];
            int arraySize = 26;
            //----------------------

            // Calls NumGen array for array of random numbers
            NumGen(ref numList, arraySize);

            // Money value array
            money[0] = 0.50;
            money[1] = 1;
            money[2] = 2;
            money[3] = 5;
            money[4] = 10;
            money[5] = 20;
            money[6] = 50;
            money[7] = 100;
            money[8] = 150;
            money[9] = 200;
            money[10] = 250;
            money[11] = 500;
            money[12] = 750;
            money[13] = 1000;
            money[14] = 2000;
            money[15] = 3000;
            money[16] = 4000;
            money[17] = 5000;
            money[18] = 15000;
            money[19] = 20000;
            money[20] = 30000;
            money[21] = 50000;
            money[22] = 75000;
            money[23] = 100000;
            money[24] = 200000;
            money[25] = 1000000;


            // Assigns cases with their money values
            for(int i = 0; i < numList.Length;i++)
            {
                cases[i] = money[numList[i]];
            }
        }
        // Method for creating the bankers offer
        public static double? OfferMaker(double?[] cases, int turns)
        {
            double? sum = 0;
            int entrys = 0;

            for(int i = 0; i < cases.Length; i++)
            {
                if (cases[i] > 0)
                {
                    sum += cases[i];
                    entrys++;

                }
            }
            sum = sum / entrys;
            sum = sum * turns;
            sum = sum / 10;
            return sum;
           
        }

        public static void GameStart(Finalists[] finalist)
        {
            // Variable declarations 
            Random rand = new Random();
            double?[] cases = new double?[26];
            double?[] moneyPosition = new double?[26];
            int num;
            //----------------------
            //Temp
            int pick;
            int[] openedCase = new int[26];
            double? playerCase;
            int call = 7;
            int counter = 0;
            int turns = 0;
            string choice = " ";
            double? offer = 0;
            //----------------------
            CaseSort(cases, moneyPosition);


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
            pick--;
            playerCase = cases[pick];
            cases[pick] = null;
            do
            {
                Console.WriteLine("Now pick a case to open");
                pick = Convert.ToInt32(Console.ReadLine());
                pick--;
                if(cases[pick] == null)
                {
                    
                    while(cases[pick] == null)
                    {
                        Console.WriteLine("You already picked this case try another one!");
                        pick = Convert.ToInt32(Console.ReadLine());
                    }
                }
                Console.Clear();
                Console.WriteLine($"Case {pick + 1} had ${cases[pick]} inside!");
                cases[pick] = null;
                turns++;
                counter++;

               




                if (counter == call)
                {
                    offer = OfferMaker(cases, turns);
                    Console.WriteLine($"The banker is offering you ${offer}. Deal or No Deal?");
                    choice = Console.ReadLine().ToUpper();
                    counter = 0;
                    call--;
                }
            } while (turns <= cases.Length - 1  && choice != "DEAL");
            {
             
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
        public static void Display(double?[] cases)
        {
            string[] moneyDisplay = new string[26];

            moneyDisplay[0] = "0.50";
            moneyDisplay[1] = "1";
            moneyDisplay[2] = "2";
            moneyDisplay[3] = "5";
            moneyDisplay[4] = "10";
            moneyDisplay[5] = "20";
            moneyDisplay[6] = "50";
            moneyDisplay[7] = "100";
            moneyDisplay[8] = "150";
            moneyDisplay[9] = "200";
            moneyDisplay[10] = "250";
            moneyDisplay[11] = "500";
            moneyDisplay[12] = "750";
            moneyDisplay[13] = "1000";
            moneyDisplay[14] = "2000";
            moneyDisplay[15] = "3000";
            moneyDisplay[16] = "4000";
            moneyDisplay[17] = "5000";
            moneyDisplay[18] = "15000";
            moneyDisplay[19] = "20000";
            moneyDisplay[20] = "30000";
            moneyDisplay[21] = "50000";
            moneyDisplay[22] = "75000";
            moneyDisplay[23] = "100000";
            moneyDisplay[24] = "200000";
            moneyDisplay[25] = "1000000";



            for (int i = 0; i < moneyDisplay.Length; i++)
            {
             
                
            }

            int? pos = null;
            Console.Write("-----------------------------------------");
            Console.WriteLine();
            Console.Write("|".PadRight(40));
            Console.WriteLine("");
            Console.Write("|".PadRight(40));
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            Console.Write("|".PadRight(40));
            Console.Write("|".PadRight(40));
            Console.WriteLine();
            Console.WriteLine("-----------------------------------------");
            
            Console.ReadKey();
        }
    }
}
