// static async Task WaitAndApologizeAsync()
// {
//     await Task.Delay(2000);

//     Console.WriteLine("Sorry for the delay...\n");
// }

// await WaitAndApologizeAsync();

// Console.WriteLine("-----------------------------------");

// Task waitAndApologizeTask = WaitAndApologizeAsync();

// string output =
//     $"Today is {DateTime.Now:D}\n" +
//     $"The current time is {DateTime.Now.TimeOfDay:t}\n" +
//     "The current temperature is 76 degrees.\n";

// await waitAndApologizeTask;
// Console.WriteLine(output);

// string message =
//     $"Today is {DateTime.Today:D}\n" +
//     "Today's hours of leisure: " +
//     $"{await GetLeisureHoursAsync()}";

// Console.WriteLine(message);

// static async Task<int> GetLeisureHoursAsync()
// {
//     // DayOfWeek today = await Task.FromResult(DateTime.Now.DayOfWeek);
//     DayOfWeek today = DateTime.Now.DayOfWeek;

//     int leisureHours =
//         today is DayOfWeek.Saturday || today is DayOfWeek.Sunday
//         ? 16 : 5;

//     return leisureHours;
// }
// Example output:
//    Today is Wednesday, May 24, 2017
//    Today's hours of leisure: 5

public class NaiveButton
{
    public event EventHandler? Clicked;

    public void Click()
    {
        Console.WriteLine("Somebody has clicked a button. Let's raise the event...");
        Clicked?.Invoke(this, EventArgs.Empty);
        Console.WriteLine("All listeners are notified.");
    }
}

public class AsyncVoidExample
{
    static readonly TaskCompletionSource<bool> s_tcs = new TaskCompletionSource<bool>();

    public static async Task Main(string[] args)
    {
        await MultipleEventHandlersAsync();
    }

    public static async Task MultipleEventHandlersAsync()
    {
        Task<bool> secondHandlerFinished = s_tcs.Task;

        var button = new NaiveButton();

        button.Clicked += OnButtonClicked1;
        button.Clicked += OnButtonClicked2Async;
        button.Clicked += OnButtonClicked3;

        Console.WriteLine("Before button.Click() is called...");
        button.Click();
        Console.WriteLine("After button.Click() is called...");

        await secondHandlerFinished;
    }

    private static void OnButtonClicked1(object? sender, EventArgs e)
    {
        Console.WriteLine("   Handler 1 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 1 is done.");
    }

    private static async void OnButtonClicked2Async(object? sender, EventArgs e)
    {
        Console.WriteLine("   Handler 2 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 2 is about to go async...");
        await Task.Delay(500);
        Console.WriteLine("   Handler 2 is done.");
        s_tcs.SetResult(true);
    }

    private static void OnButtonClicked3(object? sender, EventArgs e)
    {
        Console.WriteLine("   Handler 3 is starting...");
        Task.Delay(100).Wait();
        Console.WriteLine("   Handler 3 is done.");
    }
}
// Example output:
//
// Before button.Click() is called...
// Somebody has clicked a button. Let's raise the event...
//    Handler 1 is starting...
//    Handler 1 is done.
//    Handler 2 is starting...
//    Handler 2 is about to go async...
//    Handler 3 is starting...
//    Handler 3 is done.
// All listeners are notified.
// After button.Click() is called...
//    Handler 2 is done.