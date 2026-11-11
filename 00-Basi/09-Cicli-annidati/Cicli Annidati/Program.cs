Console.WriteLine("Programma tavola pitagorica!");

const int MIN_ROWS = 1;
const int MAX_ROWS = 20;
const int EXIT_OPTION = 3;


int choice = 0;


do
{
    Console.WriteLine("\nSeleziona un'opzione:");
    Console.WriteLine("1. Genera Tavola Pitagorica completa");
    Console.WriteLine("2. Genera la tabellina di un singolo numero");
    Console.WriteLine("3. Esci");
    string rawChoice = ReadInput("Scelta: ");

    if (!int.TryParse(rawChoice, out choice))
    {
        Console.WriteLine($"Errore: inserisci numero intero valido ({MIN_ROWS}-{MAX_ROWS})");
        continue;
    }
    else
    {
        switch (choice)
        {
            case 1:
                int rows = ReadRowsInput($"Inserisci la dimensione della tavola ({MIN_ROWS}-{MAX_ROWS}): ");
                PrintPitagoricTable(rows);
                break;
            case 2:
                int number = ReadRowsInput($"Inserisci il numero di cui vuoi la tabellina ({MIN_ROWS}-{MAX_ROWS}): ");
                PrintSingleTable(number);
                break;
            case 3:
                Console.WriteLine("Uscita dal programma. Arrivederci!");
                break;
            default:
                Console.WriteLine("Opzione non valida!");
                break;
        }
    } 
} while (choice != EXIT_OPTION);



string ReadInput(string prompt)
{
    do
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Errore: Input Vuoto. Riprova!");
            }
        else
        {
            return input;
        }
    }
        while (true);
}

int ReadRowsInput(string prompt)
{
    do
        {
        string input = ReadInput(prompt);
        if (int.TryParse(input, out int result) && result >= MIN_ROWS && result <= MAX_ROWS)
        {
                    return result;
                }
        else
                {
                    Console.WriteLine($"Errore: Input non valido. Inserisci un numero compreso tra {MIN_ROWS} e {MAX_ROWS}!");
        }
    }
        while (true);
}

void PrintPitagoricTable(int rows)
{
    for (int r = 1; r <= rows; r++)
        {
        for (int c = 1; c <= rows; c++)
                {
            Console.Write($"{r * c, 4}");
                }
            Console.WriteLine();
        }
}


void PrintSingleTable(int number)
{
    int maxCalcole = 10;
    Console.WriteLine($">Tabellina del {number}");
    for (int i = 1; i <= maxCalcole; i++)
        {
        Console.WriteLine($"{number} x {i} = {number * i, 3}");
    }
}