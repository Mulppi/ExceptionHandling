namespace ExceptionHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BasicExceptionHandling();
            MultipleExceptionTypes();
            FinalyBlockUsage();
            CustomExceptionClass();
            ExceptionPropagation();
            UsingThrowAndCatch();
        }

        static void BasicExceptionHandling()
        {
            Console.Write("Enter a number: ");
            // TODO:
            try
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine("Input is correct.");

            }
            catch (FormatException fex)
            {
                Console.WriteLine("An error occurred: " + fex);
            }

            // Convert the input to an integer using int.Parse().
            // Use a try-catch block to handle FormatException if the user enters a non-numeric value.
            // Display an error message in case of an exception.
            // Output the input if correct
        }

        static void MultipleExceptionTypes()
        {
            Console.Write("Enter a number: ");
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Include a catch block for OverflowException to handle cases where the number is too large or small for an int.
            // Display appropriate error messages for different exceptions.
            try
            {
                int input = int.Parse(Console.ReadLine());

            }
            catch (OverflowException ofex)
            {
                Console.WriteLine("An error occurred: " + ofex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex); // Handle exceptions of any type
            }
        }

        static void FinalyBlockUsage()
        {
            bool caught = false;
            Console.Write("Enter a number: ");
            try
            {
                int input = int.Parse(Console.ReadLine());
            }
            catch (FormatException fex)
            {
                caught = true;
            }
            finally
            {
                Console.WriteLine("It is " + caught.ToString() + " that an exception was caught.");
            }
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Add a finally block to the program.
            // Use the finally block to display a message whether an exception was caught or not.
        }

        // Class for custom exception type
        class NegativeNumberException : ApplicationException
        {
            public NegativeNumberException(string message) : base(message) { }
        }

        static void CustomExceptionClass()
        {
            Console.Write("Enter a number: ");
            int value = int.Parse(Console.ReadLine());
            try
            {
                if (value < 0)
                {
                    throw new NegativeNumberException("Integer must be positive.");
                }
            } catch (NegativeNumberException e)
            {
                Console.WriteLine(e);
            }
            
            

            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Modify your number input program to throw NegativeNumberException if the user enters a negative number.
            // Handle this exception in a separate catch block and display an appropriate message.
        }

        static void ExceptionPropagation()
        {
            Console.Write("Enter a number: ");
            try
            {
                CheckNumber(Convert.ToInt32(Console.ReadLine()));   
            } catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Exception occurred: " + ex);
            }
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumber that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // In this function, call CheckNumber inside a try block and handle the exception.
        }

        // NOTE: You can implement the CheckNumber here
        static void CheckNumber(int input)
        {
            if (input > 100)
            {
                throw new ArgumentOutOfRangeException("input");
            }
        }

        static string logged = ""; // Static variable to extract the logged exception string from CheckNumberWithLogging()
        static void UsingThrowAndCatch()
        {
            Console.Write("Enter a number: ");
            try
            {
                CheckNumberWithLogging(Convert.ToInt32(Console.ReadLine()));
            } catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(logged);
            }
            
            // TODO:
            // Implement BasicExceptionHandling code with following modification
            // Write a function CheckNumberWithLogging that takes an integer and throws ArgumentOutOfRangeException if the number is greater than 100.
            // Modify the CheckNumberWithLogging function to log the exception message before throwing it.
            // In this function, catch the exception in the main program and display the logged message.
        }

        // NOTE: You can implement the CheckNumberWithLogging here
        static void CheckNumberWithLogging(int input)
        {
            logged = "";
            if (input > 100)
            {
                logged = (new ArgumentOutOfRangeException("input").ToString());
                throw new ArgumentOutOfRangeException("input");
            }
        }
    }
}