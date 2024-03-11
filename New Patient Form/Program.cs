/*
 * Author: Emily Cornelius
 * Course: Comp-003A
 * Purpose: Final Project Health App
 */
using System.Net;
using System.Reflection.Metadata.Ecma335;

namespace New_Patient_Form
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Getting Patient's Basic Information before the questionnaire
            Console.WriteLine("\nWelcome! As a new patient, we will need to collect some basic health information.");

            string BasicInfo = SectionSeparator("Basic Information ");

            string firstName = Validate("\nEnter your First Name: ");
            string lastName = Validate("Enter your Last Name: ");
            int yourage = BirthYear();
            string yourgender = GenderString(InputGender());

            // Asking the patient questions about their general health
            string HealthInfo = SectionSeparator("Health Questions ");
            List<string> Health = new List<string>();
            List<string> Questions = new List<string>()
            {   "\nDo you have any current symptoms?",
                "On a scale of 0-10, how much pain are you experiencing?",
                "What current medications are you taking?",
                "What bloodwork have you completed?",
                "Any family history of heart disease? Yes or no",
                "On average, how many hours a week do you exercise?",
                "What type of imaging have you completed before your appointment?",
                "Who is your primary care provider?",
                "What doctor referred you to this clinic?"

            };

            Console.WriteLine("\nDo you have any current symptoms?");
            string symptoms = Console.ReadLine();
            Health.Add(symptoms);

            Console.WriteLine("On a scale of 0-10, how much pain are you experiencing?");

           
            int pain1;
            do
            {
                string pain = Console.ReadLine();
                pain1 = Convert.ToInt32(pain);
                Health.Add(pain);
                if (pain1 <= 0 && pain1 >= 10)
                {
                    Console.WriteLine("Please only enter number 0-10");
                }
            } while (pain1 <= 0 && pain1 >= 10);

            Console.WriteLine("What current medications are you taking?");
            string medications = Console.ReadLine();
            Health.Add(medications);

            Console.WriteLine("What bloodwork have you completed?");
            string bloodwork = Console.ReadLine();
            Health.Add(bloodwork);

            Console.WriteLine("Any family history of heart disease? Yes or no");
            string heartdisease = Console.ReadLine();
            Health.Add(heartdisease);
                
            Console.WriteLine("On average, how many hours a week do you exercise?");
            string exercise = Console.ReadLine();
            Health.Add(exercise);

            Console.WriteLine("What type of imaging have you completed before your appointment?");
            string imaging = Console.ReadLine();
            Health.Add(imaging);


            // Questions about insurance to also add to the string 
            string Insurance = SectionSeparator("Insurance Questions ");
            
            Console.WriteLine("Who is your primary care provider?");
            string provider = Console.ReadLine();
            Health.Add(provider);

            Console.WriteLine("What doctor referred you to this clinic?");
            string referral = Console.ReadLine();
            Health.Add(referral);

            Console.WriteLine($"\nFirst Name: {firstName}");
            Console.WriteLine($"Last Name: {lastName}");
            Console.WriteLine($"You are {yourage} years old");
            Console.WriteLine($"Gender: {yourgender}");

            for (int i = 0; i<Questions.Count(); i++)
            {
                Console.WriteLine($"{Questions[i]}: {Health[i]}\n");
            }



        }

        

        /// <summary>
        /// Method to Validate that the input was not null, empty, and did not contain special characters
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static string Validate(string prompt)
        {
            string answer;
            do
            {
                Console.WriteLine(prompt);
                answer = Console.ReadLine();
            } while (string.IsNullOrEmpty(answer) || NumbersandSpecialCharacters(answer));
            return answer;
        }

        /// <summary>
        /// Method to Add a title before each section
        /// </summary>
        /// <param name="section"></param>
        /// <returns></returns>
        static string SectionSeparator(string section)
        {
            Console.WriteLine("\n*************************");
            Console.WriteLine($"{section}Section");
            Console.WriteLine("*************************");
            return section;
        }

        /// <summary>
        /// Method to check user's input for any special characters or numbers
        /// </summary>
        /// <param name="prompt"></param>
        /// <returns></returns>
        static bool NumbersandSpecialCharacters(string prompt)
        {
            foreach (char b in prompt)
            {
                if (!char.IsLetter(b))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Calculate User's Age
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        static int BirthYear()
        {
            int birthYear;
            int age;
            do
            {
                Console.WriteLine("What year were you born?");
                string inputYear = Console.ReadLine();
                birthYear = Convert.ToInt32(inputYear);
                int currentYear = DateTime.Now.Year;
                age = currentYear - birthYear;

                if (birthYear < 1900 || birthYear > DateTime.Now.Year)
                {
                    Console.WriteLine("Please enter a valid birth year.");
                }

            } while (birthYear < 1900 || birthYear > DateTime.Now.Year);
            return age;

        }

        /// <summary>
        /// Receive a letter input for Gender
        /// </summary>
        /// <returns></returns>
        static char InputGender()
        {
            char genderinput;
            do
            {
                Console.WriteLine("What is your Gender? Enter M/F/O:");
                genderinput = Convert.ToChar(Console.ReadLine());
                if (genderinput != 'M' && genderinput != 'F' && genderinput != 'O')
                {
                    Console.WriteLine("Please only enter M/F/O");
                }

            } while (genderinput != 'M' && genderinput != 'F' && genderinput != 'O');
            return genderinput;

        }

        /// <summary>
        /// Method to Convert the character of the gender to the word 
        /// </summary>
        /// <param name="gender"></param>
        /// <returns></returns>
        static string GenderString(char gender)
        {
            if (gender == 'M')
            {
                return "Male";
            }
            else if (gender == 'F')
            {
                return "Female";
            }
            else
            {
                return "Other";
            }
        }
     }
 }
