Console.WriteLine("Programma prenotazione cinema!");


const int MENU_EXIT = 0;
const int MENU_BOOK = 1;
const int MENU_CANCEL = 2;
const int ROWS_SEATS = 15;
const int COLUMNS_SEATS = 15;

bool[,] seats = new bool[ROWS_SEATS, COLUMNS_SEATS];
int choice = 0;

do
{
    PrintSeatingMap(seats);
    Console.WriteLine("Menù prenotazione posti al cinema: ");
    Console.WriteLine($"{MENU_BOOK}. Prenota");
    Console.WriteLine($"{MENU_CANCEL}. Annulla");
    Console.WriteLine($"{MENU_EXIT}. Esci");

    choice = ReadIntRange("Scelta: ", MENU_EXIT, MENU_CANCEL);

    switch(choice)
    {
        case MENU_BOOK:
            if (CountAvailableSeats(seats) == 0)
            {
                Console.WriteLine("Sala Piena!");
            }
            else
            {
                int row = ReadIntRange("Riga: ", 1, ROWS_SEATS);
                int col = ReadIntRange("Colonna: ", 1, COLUMNS_SEATS);
            if (TryBookSeat(seats, row - 1, col - 1))
                {
                    Console.WriteLine($"Posto {row} , {col} prenotato");
                }
                else
                {
                    Console.WriteLine("Posto già occupato!");                
                }
            }
            break;
        case MENU_CANCEL:
            if (CountAvailableSeats(seats) == ROWS_SEATS * COLUMNS_SEATS)
            {
                Console.WriteLine("Non ci sono prenotazioni da annullare!");
                break;
            }
            else
            {
                int row = ReadIntRange("Riga: ", 1, ROWS_SEATS);
                int col = ReadIntRange("Colonna: ", 1, COLUMNS_SEATS);
                if (TryCancelBooking(seats, row - 1, col - 1))
                {
                    Console.WriteLine($"Prenotazione al posto {row} , {col} annullata");
                }
                else
                {
                    Console.WriteLine("Il posto era già libero!");
                }
            }
            break;
        case MENU_EXIT:
            Console.WriteLine("Uscita Programma!");
            break;
        default:
            Console.WriteLine("Input Non valido");
            break;
    }


}
while (choice != MENU_EXIT);








int CountAvailableSeats(bool[,] seats)
{
    int availableCount = 0;
    for (int row = 0; row < seats.GetLength(0); row++)
    {
        for (int col = 0; col < seats.GetLength(1); col++)
        {
            if (!seats[row,col])
            {
                availableCount++;
            }
        }
    }
    return availableCount;
}


bool TryBookSeat(bool[,] seats, int row, int col)
{
    if (seats[row, col] == true)
    {
        return false;
    }
    else
    {
        seats[row, col] = true;
        return true;
    }
}

bool TryCancelBooking(bool[,] seats, int row, int col)
{
    if (!seats[row,col])
    {
        return false;
    }
    else
    {
        seats[row, col] = false;
        return true;
    }
}

void PrintSeatingMap(bool[,] seats)
{
    Console.Write("   ");
    for (int col = 0; col < seats.GetLength(1); col++)
    {
        Console.Write($"{col + 1,2} ");
    }
    Console.WriteLine();

    for (int row = 0; row < seats.GetLength(0); row++)
    {
        Console.Write($"{row + 1,2} ");
        for (int col = 0; col < seats.GetLength(1); col++)
        {
            if (seats[row, col])
            {
                Console.Write("[X]");
            }
            else
            {
                Console.Write("[ ]");
            }
        }
        Console.WriteLine();
    }

    int availableSeats = CountAvailableSeats(seats);
    Console.WriteLine($"\nPosti liberi: {availableSeats}");
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