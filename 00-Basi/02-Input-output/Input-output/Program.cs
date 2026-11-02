using System.Runtime.CompilerServices;

Console.WriteLine("Programma Anagrafico!");

/// in caso l'utente non inserisca nulla
/// viene assegnato un valore di default
string name = LeggiInput("Inserisci il tuo nome:", "nome non inserito");

string surname = LeggiInput("Inserisci il tuo cognome:", "cognome non inserito");

string city = LeggiInput("Inserisci la tua città:", "città non inserita");

///Metodo moderno per andare a capo
string anagraficInfUser = $"""
    Nome: {name}
    Cognome: {surname}
    Città: {city}
    """;

Console.WriteLine("\nInformazioni anagrafiche inserite:");
Console.WriteLine(anagraficInfUser);


string LeggiInput(string messaggio, string defaultValue)
{
    Console.Write(messaggio + " ");
    string? input = Console.ReadLine()?.Trim().ToUpper();

    // Se l'input è nullo o vuoto (o contiene solo spazi), restituisce il valore di default
    return string.IsNullOrWhiteSpace(input) ? defaultValue : input;
}