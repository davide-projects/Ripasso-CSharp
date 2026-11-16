Console.WriteLine("Programma Elenco Prezzi!");

List<decimal> priceList = new List<decimal>();


bool anotherPrice;
do
{
    decimal priceInput = ReadPositivePrice("Inserisci un prezzo: ", 0);
    priceList.Add(priceInput);
    anotherPrice = ReadInput("Vuoi inserire un altro prezzo? (S/N) ").Equals("S", StringComparison.OrdinalIgnoreCase);
}
while (anotherPrice);

SortPrices(priceList);
Console.WriteLine("\n--- I 3 prezzi più bassi ---");
PrintLowestPrices(priceList, 3);

bool searchAgain;
do
{
    decimal targetPrice = ReadPositivePrice("Prezzo da cercare: ", 0m);
    int seqIndex = SequentialSearch(priceList, targetPrice);
    int binIndex = BinarySearchPrice(priceList, targetPrice);
    if (seqIndex >= 0)
    {
        Console.WriteLine("Prezzo Trovato");
        Console.WriteLine($"Posizione (ricerca sequenziale): {seqIndex}");
        Console.WriteLine($"Posizione (ricerca binaria): {binIndex}");
    }
    else
    {
        Console.WriteLine("Prezzo non trovato");
    }
    searchAgain = ReadInput("Vuoi Cercare un altro prezzo? (S/N) ").Equals("S", StringComparison.OrdinalIgnoreCase);
}
while (searchAgain);
Console.WriteLine("Uscita dal programma.");



void PrintLowestPrices(List<decimal> sortedPrices, int count)
{
    if (sortedPrices.Count == 0)
    {
        Console.WriteLine("Nessun prezzo presente in elenco");
        return;
    }
    int lowestPricesToPrint = Math.Min(count, sortedPrices.Count);

    for (int i = 0; i < lowestPricesToPrint; i++)
    {
        Console.WriteLine($"{sortedPrices[i]} €");
    }
}

// Metodo che trova un elemento (in liste o array ordinati)
// confrontandolo con il centro della sua grandezza
// dimezzando i tempi di ricerca
int BinarySearchPrice(List<decimal> sortedPrices, decimal targetPrice)
{
    int index = sortedPrices.BinarySearch(targetPrice);
    if (index >= 0)
    {
        return index;
    }
    else
    {
        return -1;
    }
}

/// Metodo che esamina tutti gli elementi dall'inizio alla fine
/// Scorre fino a N elementi
int SequentialSearch(List<decimal> prices, decimal targetPrice)
{
    for (int i = 0; i < prices.Count; i++)
    {
        if (prices[i] == targetPrice)
        {
            return i;
        }
    }
    return -1;
}

void SortPrices(List<decimal> prices)
{
    prices.Sort();
}

decimal ReadPositivePrice(string prompt, decimal minPrice)
{
    decimal value;
    do
    {
        string input = ReadInput(prompt);
        if (decimal.TryParse(input, out value) && value > minPrice)
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Errore: il prezzo deve essere maggiore di {minPrice}");
        }
    }
    while (true);
}

string ReadInput(string prompt)
{
    do
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Errore: l'input non può essere vuoto. Riprova.");
        }
        else
        {
            return input.Trim();
        }
    }
    while (true);
}