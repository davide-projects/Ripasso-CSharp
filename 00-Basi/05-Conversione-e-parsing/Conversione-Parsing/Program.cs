Console.WriteLine("Programma conversione!");


decimal priceInput = leggiDecimalPositivo("Inserisci il prezzo: ");
int quantityInput = leggiIntPositivo("Inserisci la quantità: ");
decimal total = calcoloTotale(priceInput, quantityInput);


string leggiInput (string prompt)
{
    do
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Errore: L'input Non deve essere vuoto!");
        }
        else
        {
            return input;
        }
    }
    while (true);
}

int leggiIntPositivo(string prompt)
{
    do
    {
        string input = leggiInput(prompt);
        int quantity = 0;
        bool quantityConverted = int.TryParse(input, out quantity);
        if (quantityConverted && quantity > 0)
        {
            return quantity;
        }
        else
        {
            Console.WriteLine("Errore: L'input deve essere un numero intero positivo!");
        }
    }
    while (true);
}

decimal leggiDecimalPositivo(string prompt)
{
    do
    {
        string input = leggiInput(prompt);
        decimal price = 0;
        bool priceConverted = decimal.TryParse(input, out price);
        if (priceConverted && price > 0)
        {
            return price;
        }
        else
        {
            Console.WriteLine("Errore: L'input deve essere un numero decimale positivo!");
        }
    }
    while (true);
}

decimal calcoloTotale(decimal price, int quantity)
{
    decimal total = price * quantity;
    Console.WriteLine($"Il totale è: {total:C}");
    return total;
}