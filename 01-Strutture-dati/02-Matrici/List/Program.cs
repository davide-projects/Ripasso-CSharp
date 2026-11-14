using System.Runtime.CompilerServices;

Console.WriteLine("Programma To do list dinamica!");

List<string> toDoList = new List<string>();
List <bool> isCompletedList = new List<bool>();

MenuOption choice;
do
{
    PrintMenu();
    choice = (MenuOption)ReadIntRange("Scelta: ", (int)MenuOption.Add, (int)MenuOption.Exit);
    MenuChoice(choice, toDoList, isCompletedList);
}
while (choice != MenuOption.Exit);




void AddActivity(List<string> activities, List<bool> isCompleted, string newActivity)
{
    activities.Add(newActivity);
    isCompleted.Add(false);
}

void PrintActivities(List<string> activities, List<bool> isCompleted)
{
    if (activities.Count == 0)
    {
        Console.WriteLine("Nessuna Attività in lista");
    }
    else
    {
        for (int i = 0; i < activities.Count; i++)
        {
            string status = isCompleted[i] ? "[X]" : "[ ]";
            Console.WriteLine($"{i + 1}. {activities[i]} {status}");
        }
    }
}

bool TryRemoveActivity(List<string> activities, List<bool> isCompleted, int index)
{
    if (index < 0 || index >= activities.Count)
    {
        return false;
    }
    activities.RemoveAt(index);
    isCompleted.RemoveAt(index);
    return true;
}

bool TryCompleteActivity(List<bool> isCompleted, int index)
{
    if (index < 0 || index >= isCompleted.Count || isCompleted[index] == true)
        {
        return false;
        }
    isCompleted[index] = true;
    return true;
}

void PrintMenu()
{
    Console.WriteLine();
    Console.WriteLine("--- Menu To-Do List ---");
    Console.WriteLine($"" +
        $"{(int)MenuOption.Add}. Aggiungi attività\n" +
        $"{(int)MenuOption.List}. Lista Attività\n" +
        $"{(int)MenuOption.Remove}. Rimuovi Attività\n" +
        $"{(int)MenuOption.Complete}. Segna come completata\n" +
        $"{(int)MenuOption.Exit}  Esci" +
        "");
}

void MenuChoice(MenuOption choice, List<string> activities, List<bool> isCompletedList)
{
    switch (choice)
    {
        case MenuOption.Add:
            string newActivity = ReadInput("Nuova attività: ");
            AddActivity(activities, isCompletedList, newActivity);
            Console.WriteLine("Attività aggiunta.");
            break;

        case MenuOption.List:
            PrintActivities(activities, isCompletedList);
            break;

        case MenuOption.Remove:
            if (activities.Count == 0)
            {
                Console.WriteLine("Lista vuota.");
            }
            else
            {
                PrintActivities(activities, isCompletedList);
                int itemNumber = ReadIntRange("Numero di attività da rimuovere: ", 1, activities.Count);
                if (TryRemoveActivity(activities, isCompletedList, itemNumber - 1))
                {
                    Console.WriteLine("Rimozione confermata.");
                }
                else
                {
                    Console.WriteLine("Attività inesistente.");
                }
            }
            break;

        case MenuOption.Complete:
            if (activities.Count == 0)
            {
                Console.WriteLine("Lista vuota.");
            }
            else
            {
                PrintActivities(activities, isCompletedList);
                int itemNumber = ReadIntRange("Numero di attività da completare: ", 1, activities.Count);
                if (TryCompleteActivity(isCompletedList, itemNumber - 1))
                {
                    Console.WriteLine("Attività completata.");
                }
                else
                {
                    Console.WriteLine("Attività già completata o non valida.");
                }
            }
            break;

        case MenuOption.Exit:
            Console.WriteLine("Uscita programma\nArrivederci!");
            break;
    }
}


int ReadIntRange(string prompt, int min, int max)
    {
        int value;
        do
        {
            string input = ReadInput(prompt);
            if (int.TryParse(input, out value) && value >= min && value <= max)
            {
                return value;
            }
            else
            {
                Console.WriteLine($"Errore: l'input il numero deve essere tra {min} e {max}. Riprova!");
            }
        }
        while (true);
    }

string ReadInput(string prompt)
{
        do
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Errore: l'input non può essere vuoto. Riprova.");
            }
            else
            {
                return input;
            }
        }
        while (true);
}

enum MenuOption
{
    Add = 1,
    List = 2,
    Remove = 3,
    Complete = 4,
    Exit = 5
}