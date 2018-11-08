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
        public struct Cases
        {
            public bool playerCase;
            public int caseNumber;
            public int caseValue;
            public bool opened;
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
            for (int i = 0; i < contestant.Length - 1; i++)
            {
                for (int pos = 0; pos < contestant.Length - 1; pos++)
                {
                    if (contestant[pos + 1].lastName.CompareTo(contestant[pos].lastName) < 0)
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
            for (int i = 0; i < contestant.Length; i++)
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

            for (int i = 0; i < contestant.Length; i++)
            {
                if (input == contestant[i].firstName)
                {
                    Console.WriteLine($"You are updateing {contestant[i].firstName} {contestant[i].lastName}s interest feild");
                    Console.WriteLine();
                    Console.Write($"Their current interest is set to {contestant[i].interest}. What would you like to change it to?");
                    input = Console.ReadLine();
                    contestant[i].interest = input;
                }
            }

            // Writes updated interest information back onto the deal or no deal text
            for (int i = 0; i < contestant.Length; i++)
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
                numList[i] = num; }
        }

        // Method for providing cases with money values 
        public static void CaseSort(Cases[] cases, int[] moneyPosition)
        {
            // Variable declarations 
            int[] money = new int[26];
            int[] numList = new int[26];
            int arraySize = 26;
            int caseNum = 1;
            //----------------------

            // Calls NumGen array for array of random numbers
            NumGen(ref numList, arraySize);

            // Money value array
            money[0] = 1;
            money[1] = 2;
            money[2] = 5;
            money[3] = 10;
            money[4] = 20;
            money[5] = 50;
            money[6] = 100;
            money[7] = 150;
            money[8] = 200;
            money[9] = 250;
            money[10] = 300;
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
            for (int i = 0; i < numList.Length; i++)
            {
                cases[i].caseNumber = caseNum;
                cases[i].caseValue = money[numList[i]];
                caseNum++;
            }
        }
        // Method for creating the bankers offer
        public static int OfferMaker(Cases[] cases, int turns)
        {
            int sum = 0;
            int entrys = 0;

            for (int i = 0; i < cases.Length; i++)
            {
                if (cases[i].opened == false)
                {
                    sum += cases[i].caseValue;
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
            Cases[] cases = new Cases[26];
            int[] moneyPosition = new int[26];
            int num;
            //----------------------
            //Temp
            int pick;
            int playerCaseNumber;
            int call = 6;
            int counter = 0;
            int turns = 0;
            string choice = " ";
            int offer = 0;
            int temp = 0;
            string swap = " ";
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
            cases[pick].playerCase = true;
            playerCaseNumber = pick;

            while (turns < 24)
            {
                Console.Clear();
                Display(cases);
                Console.WriteLine("Now pick a case to open");
                Console.WriteLine(turns);

                pick = Convert.ToInt32(Console.ReadLine());
                pick--;
                if (cases[pick].opened == true || cases[pick].playerCase == true)
                {
                    
                    while (cases[pick].opened == true || cases[pick].playerCase == true)
                    {
                        Console.WriteLine("You already picked this case try another one!");
                        pick = Convert.ToInt32(Console.ReadLine());
                        pick--;
                    }
                }
                Console.Clear();

                Display(cases);
                Console.WriteLine($"Case {pick + 1} had ${cases[pick].caseValue} inside!");
                
                cases[pick].opened = true;
                turns++;
                counter++;
                if (counter == call)
                {
                    offer = OfferMaker(cases, turns);
                    Console.WriteLine($"The banker is offering you ${offer}. Deal or No Deal?");
                    choice = Console.ReadLine().ToUpper();
                    counter = 0;
                    if (call > 2)
                    {
                        call--;
                    }
                    
                }
            } 
            {
                Console.Clear();
                Display(cases);
                if (choice == "DEAL")
                {
                    Console.WriteLine($"Congratulations you win {offer}. You had {cases[playerCaseNumber].caseValue} inside your case");
                    
                }
                if (turns == 24)
                {
                    for (int i = 0; i < cases.Length; i++)
                    {
                        if (cases[i].opened == false && cases[i].playerCase == false)
                        {
                            Console.WriteLine($"Do you want to keep case {playerCaseNumber + 1} or swap for case {cases[i].caseNumber}");
                            temp = i;
                        }
                    }
                    choice = Console.ReadLine().ToUpper();
                    if (choice.Contains("KEEP"))
                    {
                        Console.WriteLine($"Your case contains {cases[playerCaseNumber].caseValue}");
                    }
                    else if(choice.Contains("SWAP"))
                    {
                        Console.WriteLine($"Case {temp} contains {cases[temp].caseValue}");
                    }

                }
            }

            Console.WriteLine("Would you like to play again?");
            choice =Console.ReadLine().ToUpper();
            if(choice == "NO")
            {
                Console.WriteLine("Bye!");
                Environment.Exit(0);
            }



        }
        public static void Display(Cases[] cases)
        {
            int count = 0;
            string[] money = new string[26];
            Cases[] sortedCases = new Cases[26];
            Array.Copy(cases, sortedCases,26);
            money[0] = "1";
            money[1] = "2";
            money[2] = "5";
            money[3] = "10";
            money[4] = "20";
            money[5] = "50";
            money[6] = "100";
            money[7] = "150";
            money[8] = "200";
            money[9] = "250";
            money[10] = "300";
            money[11] = "500";
            money[12] = "750";
            money[13] = "1000";
            money[14] = "2000";
            money[15] = "3000";
            money[16] = "4000";
            money[17] = "5000";
            money[18] = "15000";
            money[19] = "20000";
            money[20] = "30000";
            money[21] = "50000";
            money[22] = "75000";
            money[23] = "100000";
            money[24] = "200000";
            money[25] = "1000000";

            int n = sortedCases.Length;
            for (int i = 1; i < n; ++i)
            {
                Cases key = sortedCases[i];
                int j = i - 1;

                while (j >= 0 && sortedCases[j].caseValue > key.caseValue)
                {
                    sortedCases[j + 1] = sortedCases[j];
                    j = j - 1;
                }
                sortedCases[j + 1] = key;
            }

            while (count < money.Length / 2)
            {
                if (sortedCases[count].opened == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                Console.Write(money[count] + "\t\t");
                if (sortedCases[count + (money.Length / 2) - 1].opened == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                
                Console.Write(money[count + (money.Length / 2) -1]+"\n");
                count++;
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("Avalible cases");
            Console.WriteLine();
            for (int i = 0; i < cases.Length; i++)
            {
                
                if (cases[i].opened == false && cases[i].playerCase == false)
                {
                    Console.Write($"{cases[i].caseNumber}  ");
                    
                    
                }
            }
            Console.WriteLine();

        }
    }
}
