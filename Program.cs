internal class Program
{
    static void Main(string[] args)
    {
        Task1();
        Task2();
        Task3();
        FindPrimeInRange();
    }

    static double GetDoubleInput(string inputMessage)
    {
        double value;
        bool isTrue;

        do
        {
            Console.WriteLine(inputMessage);
            string userInput = Console.ReadLine();
            isTrue = double.TryParse(userInput, out value);

            if (!isTrue)
            {
                Console.WriteLine("Invalid input. Please enter a valid decimal number.");
            }
        } while (!isTrue);

        return value;
    }

    static double GetPositiveDoubleInput(string inputMessage)
    {
        double value;
        bool isTrue;

        do
        {
            value = GetDoubleInput(inputMessage);
            isTrue = value > 0;

            if (!isTrue)
            {
                Console.WriteLine("Please enter a positive decimal number.");
            }
        } while (!isTrue);

        return value;
    }

    static void Task1()
    {
        Console.WriteLine("Task 1:");
        double low_number = GetDoubleInput("Enter a low number:");
        double high_number = GetDoubleInput("Enter a high number:");
        Console.WriteLine($"The difference between {high_number} and {low_number} is {high_number - low_number}");
    }

    static void Task2()
    {
        Console.WriteLine("Task 2:");

        double low_number;
        double high_number;

        do
        {
            low_number = GetPositiveDoubleInput("Enter a low number: ");
            if (low_number <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive low number.");
            }
        } while (low_number <= 0);

        do
        {
            high_number = GetPositiveDoubleInput("Enter a high number: ");
            if (high_number <= low_number)
            {
                Console.WriteLine("Invalid input. Please enter a high number greater than the low number.");
            }
        } while (high_number <= low_number);

        Console.WriteLine($"Low Number: {low_number}");
        Console.WriteLine($"High Number: {high_number}");
    }

    static void Task3()
    {
        Console.WriteLine("Task 3:");
        double low_number;
        double high_number;

        do
        {
            low_number = GetPositiveDoubleInput("Enter a low number: ");
            if (low_number <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive low number.");
            }
        } while (low_number <= 0);

        do
        {
            high_number = GetPositiveDoubleInput("Enter a high number: ");
            if (high_number <= low_number)
            {
                Console.WriteLine("Invalid input. Please enter a high number greater than the low number.");
            }
        } while (high_number <= low_number);

        List<double> numbers = new List<double>();

        double increment = 0.1;
        for (double i = high_number; i >= low_number; i -= increment)
        {
            double roundedNumber = Math.Round(i, 1);
            numbers.Add(roundedNumber);
        }

        string folderPath = @"C:\TextFile";
        string fileName = "test.txt";
        string filePath = Path.Combine(folderPath, fileName);

        WriteNumbersToFile(numbers, filePath);
    }

    static void WriteNumbersToFile(List<double> numbers, string filePath)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            foreach (double number in numbers)
            {
                writer.WriteLine(number);
            }
        }
    }

    static bool PrimeChecker(double number)
    {
        if (number <= 1)
        {
            return false;
        }
        else
        {
            for (double i = 2; i <= number / 2; i++)
            {
                if (number % i == 0)
                {
                    return false;

                }
            }
        }
        return true;
    }
    static void FindPrimeInRange()
    { 
        double low_number = GetDoubleInput("Enter a low number: ");
        double high_number = GetDoubleInput("Enter a high number: ");
        for (double num = low_number; num <= high_number; num++)
        {
            if (PrimeChecker((num)))
                { Console.WriteLine($"{num} is a prime number");
            }
        }
    }
}