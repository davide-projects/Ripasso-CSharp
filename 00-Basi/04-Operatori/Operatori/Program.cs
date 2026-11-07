Console.WriteLine("Calcolatore di consumo!");


double km = leggiDoublePositivo("Inserisci il numero di chilometri percorsi: ");
double liters = leggiDoublePositivo("Inserisci il numero di litri di carburante consumati: ");

double consume = km / liters;
double avgConsume = consume / 100;
Console.WriteLine($"Il consumo medio è di {consume:N2} km/l.");
Console.WriteLine($"Il consumo medio è di {avgConsume:N2} l/100km.");

string consumeAuto = calcoloConsumo(consume);
Console.WriteLine($"Il consumo dell'auto è: {consumeAuto}");


//switch modern expression method
string calcoloConsumo(double consume) => consume switch
{
    < 5 => "Alto",
    < 10 => "Medio",
    < 15 => "Basso",
    _ => "Eccellente"
};

string leggiInput (string prompt)
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

double leggiDoublePositivo (string prompt)
{
    do
    {
        string input = leggiInput(prompt);
        if (double.TryParse(input, out double result) && result > 0)
        {
            return result;
        }

        else
        {
            Console.WriteLine("Errore: l'input deve essere un numero positivo. Riprova.");
        }
    }
    while (true);
}
