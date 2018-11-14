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

        // Struct for finalists info
        public struct Finalists
        {
            public string firstName;
            public string lastName;
            public string interest;
        }
        // Struct for important case information
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
            string input;
            int menu = 0;
            PlayerInfo[] contestant = new PlayerInfo[21];
            Finalists[] finalist = new Finalists[10];
            string aLine;
            //----------------------

            // Main menu switch case
            
            while (menu != 5)
            {
                // Reads a ascii art from a text file
                StreamReader sr = new StreamReader(@"Title.txt");
                for (int i = 0; i < 7; i++)
                {
                    aLine = sr.ReadLine();
                    Console.WriteLine(aLine);
                }


                // Formating for the menu switch case
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

                // Reads an input and sends it to the input checking method
                input = Console.ReadLine();
                menu = InputTest(input);

                // Switch case menu for navigating around the programm
                switch (menu)
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
                        Console.WriteLine("Bye!");
                        break;
                    
                    default:
                        Console.WriteLine("Invalid Input");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }

        // Sorting method for creating 
        public static void NameFinder(PlayerInfo[] contestant)
        {
            // Variable declarations 
            PlayerInfo temp;
            string aline = " ";
            
            Console.Clear();

            // Reads another ascii title from a text file and displays it
            StreamReader sr = new StreamReader(@"PlayerList.txt");
            for(int i = 0; i < 7;i++)
            {
                aline = sr.ReadLine();
                Console.WriteLine(aline);
            }


            // Reads Deal or No Deal text file for student information and assigns them to a variable
            sr = new StreamReader(@"DealOrNoDeal.txt");
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

            // Prints finalists to console with name/interest headers 
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
            bool found = false;
            int pos = 0;
            
            //----------------------

            // Accepts an input
            Console.WriteLine("Who would you like to update?");
            input = Console.ReadLine();
            
            // Searches the contestant array to see if input matches any entrys
            for (int i = 0; i < contestant.Length; i++)
            {     
                // If a matching entry there found is set to true 
                if (input == contestant[i].firstName || input == contestant[i].lastName)
                {
                    
                    found = true;
                    pos = i;
                }
                
            }

            // Loops an input untill a matching play is found
            while (found == false)
            {
                Console.WriteLine("Could not find contestatnt please try agin");
                Console.WriteLine("Who would you like to update?");
                input = Console.ReadLine();
                Console.Clear();
                for (int i = 0; i < contestant.Length; i++)
                {
                    if (input == contestant[i].firstName || input == contestant[i].lastName)
                    {

                        found = true;
                        pos = i;
                    }

                }
            }
            // If found is trye allows the user to update the interest feild
            if (found == true)
            {
                // Opens the text file for editiing 
                StreamWriter sw = new StreamWriter(@"DealOrNoDeal.txt");

                // Reminds the user what they are updating
                Console.WriteLine($"You are updateing {contestant[pos].firstName} {contestant[pos].lastName}s interest feild");
                Console.WriteLine();
                Console.Write($"Their current interest is set to {contestant[pos].interest}. What would you like to change it to?");

                // Accepts input
                input = Console.ReadLine();

                // Rewrites the interest feild with a new interest
                contestant[pos].interest = input;

                // Rewrites updated information back to the text file
                for (int i = 0; i < contestant.Length; i++)
                {
                    sw.WriteLine(contestant[i].firstName);
                    sw.WriteLine(contestant[i].lastName);
                    sw.WriteLine(contestant[i].interest);
                }

                //Closes the text file
                sw.Close();

                Console.WriteLine("Feild has been updated");
                Console.WriteLine();
                Console.WriteLine("Press any key to return to the main menu");
                Console.ReadKey();
               
            }
            Console.Clear();

        }

        // Method for creating the finalist array
        public static void FinalistSort(PlayerInfo[] contestant, Finalists[] finalist)
        {
            // Variable declarations 
            int[] numList = new int[10];
            int arraySize = 21;
            NumGen(ref numList, arraySize);
            string aLine = " ";


            // Reads another ascii title from a text folder
            StreamReader sr = new StreamReader(@"Finalist.txt");
            for (int i = 0; i < 7; i++)
            {
                aLine = sr.ReadLine();
                Console.WriteLine(aLine);
            }

            // A loop for displaying all the finalists
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

        // Method for creating array of non duplicate random numbers it recives improtant variables passed from other methods
        public static void NumGen(ref int[] numList, int arraySize)
        {
            // Variable declarations 
            Random rand = new Random();
            int num;

            // This creates an array of unique random numbers
            

            for (int i = 0; i < numList.Length; i++)
            {
                // Creates a random number 
                num = rand.Next(0, arraySize);

                // Allows j to be used for postitioning while checking the array
                for (int j = 0; j < i; j++)
                {
                    // If the generated number is a duplicate create another number and recheck accroos the whole array untill it is unique
                    while (num == numList[j])
                    {
                        num = rand.Next(0, arraySize);
                        j = 0;
                    }
                }
                // Assigns the created numbers to a position in the numlist array
                numList[i] = num; }
        }

        // Method for providing cases with money values 
        public static void CaseSort(Cases[] cases)
        {
            // Variable declarations 
            int[] money = new int[26];
            int[] numList = new int[26];
            int arraySize = 26;
            int caseNum = 1;
            //----------------------

            // Calls NumGen array for array of random numbers and passes the array size and numlist variables
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
            // Runs through the cases array
            for (int i = 0; i < cases.Length; i++)
            {
                // Checks to see if a case has been opened if it is unoppend it can be added to the sum
                if (cases[i].opened == false)
                {
                    sum += cases[i].caseValue;
                    entrys++;

                }
            }
            // The formula for creating the bank offer
            sum = sum / entrys * turns / 10;
            return sum;

        }

        public static void GameStart(Finalists[] finalist)
        {
            // Variable declarations 
            Random rand = new Random();
            Cases[] cases = new Cases[26];
            //int[] moneyPosition = new int[26];
            int num;
            int pick = 0;
            int playerCaseNumber;
            int call = 6;
            int counter = 6;
            int turns = 0;
            string choice = " ";
            int offer = 0;
            int temp = 0;
            string input;

            // Calls the case sorting method and passes the cases array
            CaseSort(cases);

            // Generates a random number to be used to select the player
            num = rand.Next(0, 10);
            Console.WriteLine("The player tonight is!");
            Console.WriteLine();

            // Displays the players name and what they like
            Console.Write(finalist[num].firstName.PadRight(15));
            Console.Write(finalist[num].lastName.PadRight(15));
            Console.Write(finalist[num].interest.PadRight(15));
            Console.WriteLine();
            Console.WriteLine("Press Enter to start");
            Console.ReadKey();
            Console.Clear();

            // Asks the user to pick their case by inputing a number
            Console.WriteLine("Pick a case from 1,26!");
            input = Console.ReadLine();
            // passes the input to a checking method to see it is the correct data type
            pick = InputTest(input);
            pick--;
            // Sets the player case value in the cases struct to true
            cases[pick].playerCase = true;
            playerCaseNumber = pick;

            // Loops case picking input while under set amount of rounds or untill deal is accepted
            while (turns < 24 && choice != "DEAL")
            {
                Console.Clear();
                // Calls the display methods and passes the cases array and player case number
                Display(cases,playerCaseNumber,counter);
                Console.WriteLine("Now pick a case to open");

                // Asks the user for an input
                input = Console.ReadLine();
                // Calls the input testing method and passes the input variable
                pick = InputTest(input);
                pick--;

                // Checks user input to make sure that it is a unique input each time 
                if (cases[pick].opened == true || cases[pick].playerCase == true)
                {
                    
                    while (cases[pick].opened == true || cases[pick].playerCase == true)
                    {
                        Console.WriteLine("You already picked this case try another one!");
                        input = Console.ReadLine();
                        pick = InputTest(input);
                        pick--;
                    }
                }


                Console.Clear();
                Display(cases,playerCaseNumber,counter);

                // Displays chosen case value and increases count towards the bankers call
                Console.WriteLine($"Case {pick + 1} had ${cases[pick].caseValue} inside!");
                Console.ReadKey();
                cases[pick].opened = true;
                turns++;
                counter--;

                // Checks to see weather or not the banker is ready to be called or not
                if (counter == 0)
                {
                    Console.Clear();

                    // Updates the display by calling the Display method and providing updated values
                    Display(cases,playerCaseNumber, counter);

                    // 
                    offer = OfferMaker(cases, turns);
                    Console.WriteLine($"The banker is offering you ${offer}. Deal or No Deal?");
                    choice = Console.ReadLine().ToUpper();
                    counter = 0;

                    // Decreases the amount of turns that need to happen before a bank offer
                    if (call > 2)
                    {
                        call--;
                        counter = call;
                    }
                    
                }
            } 
            {
                Console.Clear();
                Display(cases,playerCaseNumber, counter);

                // End game condition for accecpting the bankers deal
                if (choice == "DEAL")
                {
                    Console.WriteLine($"Congratulations you win {offer}. You had {cases[playerCaseNumber].caseValue} inside your case");
                    
                }


                // Checks to see if the player finished by picking all the avaliable cases 
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

                    // Checks to see if player wants to keep their case or swap it for the remaining case
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

            // Provides an exit for the game
            Console.WriteLine("Would you like to play again?");
            choice =Console.ReadLine().ToUpper();
            if(choice == "NO")
            {
                Console.WriteLine("Bye!");
                Environment.Exit(0);
            }



        }

        // Method for creating the games display
        public static void Display(Cases[] cases, int playerCaseNumber , int counter)
        {
            // Variable declaration
            int count = 0;
            Cases[] sortedCases = new Cases[26];
            Array.Copy(cases, sortedCases,26);
            int n = sortedCases.Length;

            string[] money = new string[26];
            money[0] = "$1";
            money[1] = "$2";
            money[2] = "$5";
            money[3] = "$10";
            money[4] = "$20";
            money[5] = "$50";
            money[6] = "$100";
            money[7] = "$150";
            money[8] = "$200";
            money[9] = "$250";
            money[10] = "$300";
            money[11] = "$500";
            money[12] = "$750";
            money[13] = "$1000";
            money[14] = "$2000";
            money[15] = "$3000";
            money[16] = "$4000";
            money[17] = "$5000";
            money[18] = "$15000";
            money[19] = "$20000";
            money[20] = "$30000";
            money[21] = "$50000";
            money[22] = "$75000";
            money[23] = "$100000";
            money[24] = "$200000";
            money[25] = "$1000000";

           
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

            // Provides the game money board with its color and updates it if the opened value is set to true
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
                if (sortedCases[count + (money.Length / 2)].opened == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                
                Console.Write(money[count + (money.Length / 2)]+"\n");
                count++;
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Avalible cases");
            Console.WriteLine();


            // Displays all currently avalible cases to the player 
            for (int i = 0; i < cases.Length; i++)
            {
                
                if (cases[i].opened == false && cases[i].playerCase == false)
                {
                    Console.Write($@"{cases[i].caseNumber}  ");
                    
                    
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Turns untill next offer {counter}");
            Console.WriteLine($"Your case {playerCaseNumber + 1}");
            Console.WriteLine();

        }

        // Accpepts a passed input and checks to see if it is the correct data type
        public static int InputTest(string input)
        {
            int temp;
            // Attempts to convert a string to an int
            bool success = Int32.TryParse(input, out temp);

            // While the input cannot be converted alert the user that their input is an invalid input
            while(success == false || temp < 0 || temp > 26)
            {
                Console.WriteLine("Invalid input please use avalible numbers");
                input = Console.ReadLine();
                success = Int32.TryParse(input, out temp);
            }
            return temp;
        }
    }
}
