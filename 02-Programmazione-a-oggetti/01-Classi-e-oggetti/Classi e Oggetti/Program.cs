using Classi_e_Oggetti;

Console.WriteLine("Programma Libri!");
List<Book> bookList = new List<Book>();
int currentYear = DateTime.Now.Year;
bool anotherBook;

do
{
    string titleInput = ReadInput("Inserisci un titolo: ");
    string authorInput = ReadInput("Inserisci un autore: ");
    int publicationYearInput = ReadIntRange("Inserisci l'anno di pubblicazione: ", 1, currentYear);

    try
    {
        Book book = new Book(titleInput, authorInput, publicationYearInput);
        bookList.Add(book);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Errore nella creazione del libro: {ex.Message}");
    }

    anotherBook = ReadInput("Vuoi aggiungere un altro libro (S/N): ").Equals("S", StringComparison.OrdinalIgnoreCase);
}
while (anotherBook);

PrintBooks(bookList);

int referenceYear = ReadIntRange("Inserisci un anno di riferimento per il filtro: ", 1, currentYear);
PrintBooksPublishedBefore(bookList, referenceYear);

try
{
    new Book("", "Orwell", 1949);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test caso: Titolo non valido riuscito: {ex.Message}");
}

try
{
    new Book("1984", " ", 1949);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test caso: Autore non valido riuscito: {ex.Message}");
}

try
{
    new Book("1984", "Orwell", currentYear + 5);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Test caso: Anno di pubblicazione non valido riuscito: {ex.Message}");
}

void PrintBooks(List<Book> books)
{
    if (books.Count == 0)
    {
        Console.WriteLine("Nessun Libro in catalogo");
        return;
    }

    Console.WriteLine("\n--- Elenco Libri ---");
    foreach (var book in books)
    {
        Console.WriteLine(book.GetDescription());
        Console.WriteLine();
    }
}

void PrintBooksPublishedBefore(List<Book> books, int targetYear)
{
    int count = 0;
    foreach (var book in books)
    {
        if (book.IsPublishedBefore(targetYear))
        {
            Console.WriteLine($"Libro: {book.Title} ({book.PublicationYear}) - pubblicato prima del {targetYear}");
            count++;
        }
    }

    if (count == 0)
    {
        Console.WriteLine($"Nessun Libro è stato pubblicato prima dell'anno {targetYear}");
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
            Console.WriteLine($"Errore: Il numero deve essere tra {min} e {max}. Riprova!");
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
            return input.Trim();
        }
    }
    while (true);
}