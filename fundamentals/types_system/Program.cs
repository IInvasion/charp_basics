Console.WriteLine("\n--- Выход за границы массива ---");

// Представь, что у тебя есть коробка с 3 игрушками,
// а ты пытаешься взять 5-ю игрушку
void PlayWithToys()
{
    string[] toys = { "Мишка", "Машинка", "Кукла" };

    try
    {
        Console.WriteLine("Игрушки в коробке:");
        for (int i = 0; i < toys.Length; i++)
        {
            Console.WriteLine($"{i}: {toys[i]}");
        }

        Console.WriteLine("\nПопытка взять игрушку под номером 5...");
        string toy = toys[5]; // Здесь произойдет исключение!
        Console.WriteLine($"Взял игрушку: {toy}");
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine("🚨 Ошибка! Такой игрушки нет в коробке!");
        Console.WriteLine($"В коробке всего {toys.Length} игрушек");
        Console.WriteLine($"Что случилось: {ex.Message}");
    }
}

PlayWithToys();