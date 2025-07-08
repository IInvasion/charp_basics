//
// class MainReturnValTest
// {
//     static int Main()
//     {
//         //...
//         return 1;
//     }
// }

//
// class Program
// {
//     static int Main(string[] args)
//     {
//         return ConsoleWork();
//     }

//     private static int ConsoleWork()
//     {
//         return 0;
//     }
// }

//
// public class Functions
// {
//     public static long Factorial(int n)
//     {
//         // Test for invalid input.
//         if ((n < 0) || (n > 20))
//         {
//             return -1;
//         }

//         // Calculate the factorial iteratively rather than recursively.
//         long tempResult = 1;
//         for (int i = 1; i <= n; i++)
//         {
//             tempResult *= i;
//         }
//         return tempResult;
//     }
// }

// class MainClass
// {
//     static int Main(string[] args)
//     {
//         if (args.Length == 0)
//         {
//             Console.WriteLine("Please enter a numeric argument.");
//             Console.WriteLine("Usage: Factorial <num>");
//             return 1;
//         }

//         int num;
//         bool test = int.TryParse(args[0], out num);
//         if (!test)
//         {
//             Console.WriteLine("Please enter a numeric argument.");
//             Console.WriteLine("Usage: Factorial <num>");
//             return 1;
//         }

//         long result = Functions.Factorial(num);

//         if (result == -1)
//             Console.WriteLine("Input must be >= 0 and <= 20.");
//         else
//             Console.WriteLine($"The Factorial of {num} is {result}.");

//         return 0;
//     }
// }

//
// using System.Text;

// StringBuilder builder = new();
// builder.AppendLine("The following arguments are passed:");

// foreach (var arg in args)
// {
//     builder.AppendLine($"Argument={arg}");
// }

// Console.WriteLine(builder.ToString());

// return 0;

//
// MyClass.TestMethod();
// MyNamespace.MyClass.MyMethod();

// public class MyClass
// {
//     public static void TestMethod()
//     {
//         Console.WriteLine("Hello World!");
//     }
// }

// namespace MyNamespace
// {
//     class MyClass
//     {
//         public static void MyMethod()
//         {
//             Console.WriteLine("Hello World from MyNamespace.MyClass.MyMethod!");
//         }
//     }
// }

// args
// if (args.Length > 0)
// {
//     foreach (var arg in args)
//     {
//         Console.WriteLine($"Argument={arg}");
//     }
// }
// else
// {
//     Console.WriteLine("No arguments");
// }

// await
// Console.Write("Hello ");
// await Task.Delay(5000);
// Console.WriteLine("World!");

//
string? s = Console.ReadLine();

int returnValue = int.Parse(s ?? "-1");
return returnValue;