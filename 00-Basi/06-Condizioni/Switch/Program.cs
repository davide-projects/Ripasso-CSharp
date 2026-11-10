Console.WriteLine("Gestione studenti!");

//<summary>
// Gestisce le operazioni di gestione degli studenti
// soluzione moderna con switch expression
//</summary>

//string nullable
//per eliminare il warning CS8600:
//questo warning indica che si sta tentando di assegnare un valore null a una variabile di tipo non nullable.
//Per risolvere questo warning, è possibile dichiarare la variabile come nullable utilizzando il simbolo "?" dopo il tipo della variabile.
//In questo modo, la variabile può contenere sia valori null che valori non null.
//si può usare il nullable reference type
string? input;
const int MIN_INPUT = 1;
const int MAX_INPUT = 4;

do
{
    Console.WriteLine("Opzioni di scelta:");
    Console.WriteLine("1. Aggiungi studente");
    Console.WriteLine("2. Visualizza studenti");
    Console.WriteLine("3. Elimina studente");
    Console.WriteLine("4. Esci");
    input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Errore: L'input non può essere vuoto");
    }
    else if (!int.TryParse(input, out int choice))
    {
        Console.WriteLine($"Errore formato: l'input deve essere un numero intero");
    }
    else if (choice < MIN_INPUT || choice > MAX_INPUT)
    {
        Console.WriteLine($"Errore di intervallo: l'input deve essere un numero compreso tra {MIN_INPUT} e {MAX_INPUT}");
    }
    else
    {
        string option = input switch
            {
        "1" => "Studente aggiunto\n",
        "2" => "Visualizzazione studenti\n",
        "3" => "Studente eliminato\n",
        "4" => "Uscita\n",
        _ => "Opzione non valida\n"
    };
        Console.Write(option);     
    }
}
while (input != "4");