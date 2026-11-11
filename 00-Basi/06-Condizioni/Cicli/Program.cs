Console.WriteLine("Programma valore sentinella!");

const string SENTINEL_VALUE = "q";
int count = 0;
int sum = 0;
int min = int.MaxValue;
int max = int.MinValue;


do
{
    string input = ReadInput($"Inserisci un numero intero (o {SENTINEL_VALUE} per terminare): ");
    if (input.Equals(SENTINEL_VALUE, StringComparison.OrdinalIgnoreCase))
    {
        break;
    }

    if (!int.TryParse(input, out int number))
        {
            Console.WriteLine("Errore: Inserisci un numero intero valido!");
            continue;
        }
    
        if (input == SENTINEL_VALUE)
            {
            break;
        }
        else
            {
                count++;
                sum += number;
                min = Math.Min(min, number);
                max = Math.Max(max, number);
        }
    }
    while (true);
    
    if (count > 0)
    {
        double average = (double)sum / count;
        Console.WriteLine("Statistiche:");
    Console.WriteLine($"Numeri inseriti: {count}");
        Console.WriteLine($" - Conteggio: {count}");
        Console.WriteLine($" - Somma: {sum}");
        Console.WriteLine($" - Media: {average:F2}");
        Console.WriteLine($" - Minimo: {min}");
        Console.WriteLine($" - Massimo: {max}");
    }
    else
    {
        Console.WriteLine("Nessun numero valido inserito!");
    }


// Funzioni
string ReadInput(string prompt)
{
    do
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Errore: L'input è vuoto. Riprova!");
        }
        else
                {
            return input;
        }
    }
    while (true);
}