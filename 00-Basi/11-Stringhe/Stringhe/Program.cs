//Soluzione Ottimale
Console.WriteLine("Programma Stringhe!");

string sentence = ReadInput("Inserisci una frase da analizzare: ");
string wordToSearch = ReadInput("Inserisci la parola da cercare: ").Trim();

AnalyzeText(sentence, wordToSearch);


void AnalyzeText(string text, string targetWord)
{
    string cleanedText = text.Trim();
    string[] words = ExtractWords(cleanedText);
    bool isFound = ContainsWord(words, targetWord);
    string reversedText = ReverseText(cleanedText);

    Console.WriteLine("\n--- Riepilogo Analisi ---");
    Console.WriteLine($"Lunghezza frase (spazi inclusi): {cleanedText.Length} caratteri");
    Console.WriteLine($"Numero di parole: {words.Length}");
    Console.WriteLine($"Frase in maiuscolo: {cleanedText.ToUpper()}");
    Console.WriteLine($"La parola \"{targetWord.ToUpper()}\" {(isFound ? "è" : "NON è")} presente nella frase.");
    Console.WriteLine($"Frase invertita: {reversedText}");
}

string[] ExtractWords(string text) =>
    text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

bool ContainsWord(string[] words, string targetWord)
{
    foreach (string word in words)
    {
        if (word.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
        {
            return true;
        }
    }
    return false;
}

string ReverseText(string text)
{
    string reversed = string.Empty;
    for (int i = text.Length - 1; i >= 0; i--)
    {
        reversed += text[i];
    }
    return reversed;
}


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


/*Prima Soluzione
 Console.WriteLine("Programma Stringhe!");

string sentence = ReadInput("Inserisci una frase da analizzare: ");
string wordToSearch = ReadInput("Inserisci la parola da cercare: ").Trim();

AnalyzeText(sentence, wordToSearch);

void AnalyzeText(string text, string targetWord)
{
    string cleanedText = text.Trim();
    string[] words = cleanedText.Split(' ', StringSplitOptions.RemoveEmptyEntries);

    int charCount = cleanedText.Length;
    int wordCount = words.Length;
    string textToUpper = cleanedText.ToUpper();

    Console.WriteLine("\n--- Riepilogo Analisi ---");
    Console.WriteLine($"Lunghezza frase (spazi inclusi): {charCount} caratteri");
    Console.WriteLine($"Numero di parole: {wordCount}");
    Console.WriteLine($"Frase in maiuscolo: {textToUpper}");

    bool isFound = false;
    foreach (string word in words)
    {
        if (word.Equals(targetWord, StringComparison.OrdinalIgnoreCase))
        {
            isFound = true;
            break;
        }
    }

    if (!isFound)
    {
        Console.WriteLine($"La parola \"{targetWord.ToUpper()}\" NON è presente nella frase.");
    }
    else
    {
        Console.WriteLine($"La parola \"{targetWord.ToUpper()}\" è presente nella frase.");
    }

    string reversedText = string.Empty;
    for (int i = cleanedText.Length - 1; i >= 0; i--)
    {
        reversedText += cleanedText[i];
    }
    Console.WriteLine($"Frase invertita: {reversedText}");
}

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
*/