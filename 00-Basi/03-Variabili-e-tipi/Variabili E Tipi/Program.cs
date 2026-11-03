using System.Runtime.CompilerServices;

Console.WriteLine("Negozio (variabili e tipi)");

    string productName = leggiInput("Inserisci il nome del prodotto: ");
    int quantity = leggiIntero("Inserisci la quantità: ");
    decimal singlePrice = leggiDecimale("Inserisci il prezzo unitario: ");

    Console.WriteLine(calcolaTotale(productName, quantity, singlePrice));


///Funzioni

string calcolaTotale(string productName, int quantity, decimal singlePrice)
{
    decimal totalPrice = quantity * singlePrice;
    return $"Il totale del prodotto '{productName.ToUpper()}' è: € {totalPrice:N2}";
}

string leggiInput(string prompt)
{
    do
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
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

int leggiIntero(string message)
{
    do
    {
        string input = leggiInput(message);
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("Errore: l'input deve essere un numero intero. Riprova.");
        }
    }
    while (true);
}

decimal leggiDecimale(string message)
{
    do
    {
        string input = leggiInput(message);
        if (decimal.TryParse(input, out decimal result))
        {
            return result;
        }
        else
        {
            Console.WriteLine("Errore: l'input deve essere un numero decimale. Riprova.");
        }
    }
    while (true);
}