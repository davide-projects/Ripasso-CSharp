Console.WriteLine("Calcolatrice!");

const int MIN_CHOICE = 1;
const int MAX_OPERATION = 4;
const int EXIT_OPTION = 5;
int choice = 0;

do
{
    Console.WriteLine("\n--- MENU ---");
    Console.WriteLine("1. Somma");
    Console.WriteLine("2. Sottrazione");
    Console.WriteLine("3. Moltiplicazione");
    Console.WriteLine("4. Divisione");
    Console.WriteLine("5. Esci");

    string rawChoice = ReadInput("Seleziona un'operazione: ");
    if (!int.TryParse(rawChoice, out choice))
    {
        Console.WriteLine("Errore: Inserisci un numero intero valido per la scelta.");
        continue;
    }
    if (choice >= MIN_CHOICE && choice <= MAX_OPERATION)
    {
        double num1 = ReadDoubleInput("Inserisci il primo numero: ");
        double num2 = ReadDoubleInput("Inserisci il secondo numero: ");

        switch (choice)
        {
            case 1:
                Console.WriteLine($"\nRisultato: {num1} + {num2} = {Sum(num1, num2)}");
                break;
            case 2:
                Console.WriteLine($"\nRisultato: {num1} - {num2} = {Subtract(num1, num2)}");
                break;
            case 3:
                Console.WriteLine($"\nRisultato: {num1} * {num2} = {Multiply(num1, num2)}");
                break;
            case 4:
                if (num2 == 0)
                {
                    Console.WriteLine("\nErrore: Divisione per zero non consentita!");
                }
                else
                {
                    Console.WriteLine($"\nRisultato: {num1} / {num2} = {Divide(num1, num2):F2}");
                }
                break;
        }
    }
    else if (choice == EXIT_OPTION)
    {
        Console.WriteLine("Uscita dal programma. Arrivederci!");
    }
    else
    {
        Console.WriteLine($"Opzione non valida. Inserisci un numero da {MIN_CHOICE} a {EXIT_OPTION}.");
    }
}
while (choice != EXIT_OPTION);




double Sum(double number1, double number2) => number1 + number2;
double Subtract(double number1, double number2) => number1 - number2;
double Multiply(double number1, double number2) => number1 * number2;
double Divide(double number1, double number2) => number1 / number2;

    



string ReadInput(string prompt)
{
    do
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Errore: L'input non può essere vuoto. Riprova!");
        }
        else
        {
            return input;
        }
    } while (true);
}

double ReadDoubleInput(string prompt)
{
    do
    {
        string input = ReadInput(prompt);
        if (double.TryParse(input, out double result))
        {
            return result;
        }
        else
                {
            Console.WriteLine("Errore: Inserisci un numero reale!");
        }
    }
        while (true);
}
