using  System;
public class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        int randomNumber = random.Next(1, 101);
        int num = 0;
        int atempts = 0;
        while (true)
        {
        try
        {
          Console.WriteLine("Guess a number between 1 and 100:");
          num=Convert.ToInt32(Console.ReadLine());
        if(num==randomNumber)
        {
            Console.WriteLine("Congratulations! You guessed the correct number.");
            Console.WriteLine($"Number of attempts: {atempts}");
            break;
        }
        else if(num<randomNumber)
        {
            Console.WriteLine("The number is too low. Try again.");
        }
        else if(num>randomNumber)
        {
            Console.WriteLine("The number is too high. Try again.");
        }
        atempts++;
        }

          catch (FormatException)
        {
            Console.WriteLine("Please enter a valid integer.");
        }
    }
}
}