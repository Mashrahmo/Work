�using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int n = 800000; // number of random numbers to generate
        double[,] numbers;
        Stopwatch timer = new Stopwatch();

        numbers = GenRandomNumbers(n);

        // Measure addition of ints
        timer.Start();
        AddIntegers(numbers, n);
        timer.Stop();
        Console.WriteLine("Addition of ints");
        Console.WriteLine("Elapsed time = " + timer.ElapsedMilliseconds + " ms " + timer.ElapsedTicks + " ticks\n");

        // Measure multiplication of ints
        timer.Restart();
        MultiplyIntegers(numbers, n);
        timer.Stop();
        Console.WriteLine("Multiplication of ints");
        Console.WriteLine("Elapsed time = " + timer.ElapsedMilliseconds + " ms " + timer.ElapsedTicks + " ticks\n");

        // Experiment-1 Measure direct multiplication of doubles
        timer.Restart();
        SquareDoublesDirectly(numbers, n);
        timer.Stop();
        Console.WriteLine("Direct multiplication of doubles (squared)");
        Console.WriteLine("Elapsed time = " + timer.ElapsedMilliseconds + " ms " + timer.ElapsedTicks + " ticks\n");

        // Measure using Math.Pow for doubles
        timer.Restart();
        SquareDoublesWithMathPow(numbers, n);
        timer.Stop();
        Console.WriteLine("Using Math.Pow for doubles (squared)");
        Console.WriteLine("Elapsed time = " + timer.ElapsedMilliseconds + " ms " + timer.ElapsedTicks + " ticks\n");

        // Measure using Math.Sqrt for doubles
        timer.Restart();
        SquareRootDoublesWithMathSqrt(numbers, n);
        timer.Stop();
        Console.WriteLine("Using Math.Sqrt for doubles (square root)");
        Console.WriteLine("Elapsed time = " + timer.ElapsedMilliseconds + " ms " + timer.ElapsedTicks + " ticks\n");
    }

    // Experiment-2 Function that adds integers in the supplied 2D array
    static void AddIntegers(double[,] nums, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            nums[i, 2] = (int)nums[i, 0] + (int)nums[i, 1];
        }
    }

    // Expriment-3 Function that multiplies integers in the supplied 2D array
    static void MultiplyIntegers(double[,] nums, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            nums[i, 2] = (int)nums[i, 0] * (int)nums[i, 1];
        }
    }

    // Expriment-4 Function that squares doubles via direct multiplication
    static void SquareDoublesDirectly(double[,] nums, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            nums[i, 2] = nums[i, 0] * nums[i, 0];
        }
    }

    // Expriment-5 Function that squares doubles using Math.Pow
    static void SquareDoublesWithMathPow(double[,] nums, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            nums[i, 2] = Math.Pow(nums[i, 0], 2);
        }
    }

    // Function that computes the square root of doubles using Math.Sqrt
    static void SquareRootDoublesWithMathSqrt(double[,] nums, int count)
    {
        for (int i = 0; i < count; ++i)
        {
            nums[i, 2] = Math.Sqrt(nums[i, 0]);
        }
    }

    // Function to generate an array of random numbers
    static double[,] GenRandomNumbers(int count)
    {
        Random rand = new Random(); // instantiate random number generator
        double[,] num = new double[count, 3]; // make array

        for (int i = 0; i < count; ++i)
        {
            num[i, 0] = 10000.0 * rand.NextDouble(); // fill in elements of array
            num[i, 1] = 10000.0 * rand.NextDouble();
        }

        return num; // returns a reference to the array
    }
}

