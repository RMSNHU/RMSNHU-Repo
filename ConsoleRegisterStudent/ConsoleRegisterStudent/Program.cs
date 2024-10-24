using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRegisterStudent
{
    class Program
    {
        static void Main(string[] args)
        {
            (new Program()).run();
        }


        void run()
        {
            //declare varibables
            int choice;
            int firstChoice = 0, secondChoice = 0, thirdChoice = 0;
            int totalCredit = 0;
            string yesOrNo = "";

            System.Console.WriteLine("Reese McGuffey");

            //main loop, loops until yesOrNo = N
            do
            {
                //output explanation and convert choice to int
                WritePrompt();
                choice = Convert.ToInt32(Console.ReadLine());

                //check to see if what the user inputted is valid, add course if it is
                switch (ValidateChoice(choice, firstChoice, secondChoice, thirdChoice, totalCredit))
                {
                    //if the user inputs an invalid course (ex. 10)
                    case -1:
                        Console.WriteLine("Your entered selection {0} is not a recognized course.", choice);
                        break;
                    //if the user inputs an already inputted course (ex. 2, then 2 again)
                    case -2:
                        Console.WriteLine("You have already registered for this {0} course.", ChoiceToCourse(choice));
                        break;
                    //if the user inputs more than three courses
                    case -3:
                        Console.WriteLine("You can not register for more than 9 credit hours.");
                        break;
                    //if the user inputs a valid course
                    case 0:
                        Console.WriteLine("Registration Confirmed for course {0}.", ChoiceToCourse(choice));
                        //add credit, stop adding if total credit reaches 9
                        if (totalCredit != 9)
                        {
                            totalCredit += 3;
                        }
                        //logic to see which choice the user is on
                        if (firstChoice == 0)
                            firstChoice = choice;
                        else if (secondChoice == 0)
                            secondChoice = choice;
                        else if (thirdChoice == 0)
                            thirdChoice = choice;
                        break;
                }

                //output current registration status
                WriteCurrentRegistration(firstChoice, secondChoice, thirdChoice);

                //ask user if they want to continue, program resumes if Y is entered, program stops if N is entered
                Console.Write("\nDo you want to try again? (Y|N)? : ");
                yesOrNo = (Console.ReadLine()).ToUpper();
            } while (yesOrNo == "Y");

            //goodbye message
            Console.WriteLine("Thank you for registering with us");
        }

        void WritePrompt()
        {
            //explanation message
            Console.WriteLine("Please select a course for which you want to register by typing the number inside []");
            Console.WriteLine("[1]IT 145\n[2]IT 200\n[3]IT 201\n[4]IT 270\n[5]IT 315\n[6]IT 328\n[7]IT 330");
            Console.Write("Enter your choice : ");
        }

        int ValidateChoice(int choice, int firstChoice, int secondChoice, int thirdChoice, int totalCredit)
        {
            //logic for validating user input
            if (choice < 1 || choice > 7)
                return -1;
            else if (choice == firstChoice || choice == secondChoice || choice == thirdChoice)
                return -2;
            else if (totalCredit >= 9)
                return -3;
            return 0;
        }


        void WriteCurrentRegistration(int firstChoice, int secondChoice, int thirdChoice)
        {
            //variable output that updates according to which choice the user is currently on, no output if the user makes an invalid input on the first choice
            if (firstChoice == 0)
                return;
            else if (secondChoice == 0)
                Console.WriteLine("You are currently registered for {0}", ChoiceToCourse(firstChoice));
            else if (thirdChoice == 0)
                Console.WriteLine("You are currently registered for {0}, {1}", ChoiceToCourse(firstChoice), ChoiceToCourse(secondChoice));
            else
                Console.WriteLine("You are currently registered for {0}, {1}, {2}", ChoiceToCourse(firstChoice), ChoiceToCourse(secondChoice), ChoiceToCourse(thirdChoice));
        }

        string ChoiceToCourse(int choice)
        {
            //converting the user's number choice to the corresponding course
            string course = "";
            switch (choice)
            {
                case 1:
                    course = "IT 145";
                    break;
                case 2:
                    course = "IT 200";
                    break;
                case 3:
                    course = "IT 201";
                    break;
                case 4:
                    course = "IT 270";
                    break;
                case 5:
                    course = "IT 315";
                    break;
                case 6:
                    course = "IT 328";
                    break;
                case 7:
                    course = "IT 330";
                    break;
                default:
                    break;
            }
            return course;
        }
    }
}