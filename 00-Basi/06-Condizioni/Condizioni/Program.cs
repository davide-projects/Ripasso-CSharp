

Console.WriteLine("Programma di valutazione studenti!");

const int MIN_RANGE = 0;

const int MIN_VOTE_VAL = 60;
const int MAX_VOTE_VAL = 100;

const int MIN_FREQUENCY_VAL = 75;
const int MAX_FREQUENCY_VAL = 100;

const int VOTE_TO_EXTRA_POINTS = 90;
const int FREQUENCY_TO_EXTRA_POINTS = 90;

const int EXTRA_POINTS_TO_VOTE = 3;
const int EXTRA_POINTS_TO_FREQUENCY = 2;

Console.WriteLine($"Voto per punti extra: {VOTE_TO_EXTRA_POINTS}");
Console.WriteLine($"Frequenza per punti extra: {FREQUENCY_TO_EXTRA_POINTS}");
int studentVote = leggiIntInIntervallo("Inserisci il voto dello studente (da 0 a 100): ", MIN_RANGE, MAX_VOTE_VAL);
int studentFrequency = leggiIntInIntervallo("Inserisci la frequenza dello studente (da 0 a 100): ", MIN_RANGE, MAX_FREQUENCY_VAL);
int studentValutationResult = valutaStudente(studentVote, studentFrequency);



//Funzioni
string leggiInputVuoto(string prompt)
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

int leggiIntInIntervallo(string prompt, int min, int max)
{
    int value;
    do
    {
        string input = leggiInputVuoto(prompt);
        if (int.TryParse(input, out value) && value >= min && value <= max)
        {
            return value;
        }
        Console.WriteLine($"Inserisci un numero tra {min} e {max}.");
    } while (true);
}

int valutaStudente(int vote, int frequency)
{
    int finalVote = vote;
    if (vote >= VOTE_TO_EXTRA_POINTS) finalVote += EXTRA_POINTS_TO_VOTE;

    if (frequency >= FREQUENCY_TO_EXTRA_POINTS) finalVote += EXTRA_POINTS_TO_FREQUENCY;

    if (finalVote > MAX_VOTE_VAL) finalVote = MAX_VOTE_VAL;

    if (vote < MIN_VOTE_VAL || frequency < MIN_FREQUENCY_VAL)
    {
        Console.WriteLine($"Lo studente è bocciato. \nVoto: {vote}\nFrequenza: {frequency}");
        return finalVote;
    }
    if (finalVote == MAX_VOTE_VAL) Console.WriteLine($"Lo studente è promosso CON LODE\nPunti extra per voto: {EXTRA_POINTS_TO_VOTE}\nPunti extra per frequenza: {EXTRA_POINTS_TO_FREQUENCY}\nVoto finale: {finalVote}!");
    else if (finalVote >= VOTE_TO_EXTRA_POINTS) Console.WriteLine($"\nPunti extra per voto: {EXTRA_POINTS_TO_VOTE}\nPunti extra per frequenza: {EXTRA_POINTS_TO_FREQUENCY}\nLo studente è promosso CON MERITO con voto finale {finalVote}!");

    else Console.WriteLine($"Lo studente è promosso!\nVoto finale: {finalVote}!");
    return finalVote;
}