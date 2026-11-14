Console.WriteLine("Rubrica Telefonica!");


const string PREFIX = "+39 ";
const int MAX_PHONE_LENGTH = 10;

Dictionary<string, string> contacts = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

MenuOption choice;

do
{
    PrintMenu();
    choice = (MenuOption)ReadIntRange("Scelta: ",
        (int)MenuOption.Add,
        (int)MenuOption.Exit);
    MenuChoice(choice, contacts);
}
while (choice != MenuOption.Exit);



void MenuChoice(MenuOption choice, Dictionary<string, string> contacts)
{
    switch (choice)
    {
        case MenuOption.Add:
            string name = ReadInput("Nominativo: ");
            string rawPhone = ReadPhoneNumber("Numero di telefono: ", MAX_PHONE_LENGTH);
            if (TryAddContact(contacts, name, rawPhone) == true)
            {
                Console.WriteLine("Contatto Aggiunto");
            }
            else
            {
                Console.WriteLine("Nominativo già presente");
            }
            break;

        case MenuOption.Search:
            if (IsPhoneBookEmpty(contacts) == true)
            {
                break;
            }
            name = ReadInput("Nominativo da cercare: ");
            if (TryFindPhone(contacts, name, out string? foundPhone) == true)
            {
                Console.WriteLine($"Contatto Trovato: {foundPhone}");
            }
            else
            {
                Console.WriteLine("Nessun Contatto trovato");
            }
            break;

        case MenuOption.Update:
            if (IsPhoneBookEmpty(contacts) == true)
            {
                break;
            }
            name = ReadInput("Nominativo da aggiornare: ");
            string newRawPhone = ReadPhoneNumber("Nuovo Numero: ", MAX_PHONE_LENGTH);
            if (TryUpdateContact(contacts, name, newRawPhone) == true)
            {
                Console.WriteLine("Contatto Aggiornato");
            }
            else
            {
                Console.WriteLine("Nominativo non trovato");
            }
            break;

        case MenuOption.Remove:
            if (IsPhoneBookEmpty(contacts) == true)
            {
                break;
            }
            name = ReadInput("Nominativo da rimuovere: ");
            if (TryRemoveContact(contacts, name) == true)
            {
                Console.WriteLine("Nominativo rimosso");
            }
            else
            {
                Console.WriteLine("Nominativo inesistente");
            }
            break;

        case MenuOption.Exit:
            Console.WriteLine("Uscita dal programma");
            break;

    }
}


void PrintMenu()
{
    Console.WriteLine("\n --- Menu ---");
    Console.WriteLine($"" +
        $"{(int)MenuOption.Add}. Aggiungi Contatto\n" +
        $"{(int)MenuOption.Search}. Cerca Contatto\n" +
        $"{(int)MenuOption.Update}. Aggiorna Contatto\n" +
        $"{(int)MenuOption.Remove}. Rimuovi Contatto\n" +
        $"{(int)MenuOption.Exit}. Esci"
        );
}

bool TryAddContact(Dictionary<string, string> contacts, string name, string phone)
{
    return contacts.TryAdd(name, phone);
}

bool TryFindPhone(Dictionary<string, string> contacts, string name, out string? phone)
{
    return contacts.TryGetValue(name, out phone);
}

bool TryUpdateContact(Dictionary<string, string> contacts, string name, string newPhone)
{
    if (!contacts.ContainsKey(name))
    {
        return false;
    }
    else
    {
        contacts[name] = newPhone;
        return true;
    }
}

bool TryRemoveContact(Dictionary<string, string> contacts, string name)
{
    return contacts.Remove(name);
}


bool IsPhoneBookEmpty(Dictionary<string, string> contacts)
{
    if (contacts.Count == 0)
    {
        Console.WriteLine("Rubrica Vuota");
        return true;
    }
    return false;
}

string ReadPhoneNumber(string prompt, int maxLenght)
{
    do
    {
        string input = ReadInput(prompt); 
        if (input.Length == maxLenght && IsValidPhone(input))
        {
            return PREFIX + input;
        }
        if(!IsValidPhone(input))
        {
            Console.WriteLine($"Errore: inserisci ({maxLenght} cifre). Riprova!");
        }
        else
        {
            Console.WriteLine($"Errore: Il numero deve contenere {maxLenght} cifre. Riprova!");
        }
    }
        while (true);
}

bool IsValidPhone(string text)
{
    foreach (var c in text)
    {
        if(!char.IsDigit(c))
        {
            return false;
        }
    }
    return true;
}

int ReadIntRange(string prompt, int min, int max)
{
    int value;
    do
    {
        string? input = ReadInput(prompt);
        if (int.TryParse(input, out value) && value >= min && value <= max)
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Errore: inserisci un numero valido compreso tra {min} e {max}. Riprova.");
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

enum MenuOption
{
    Add = 1,
    Search = 2,
    Update = 3,
    Remove = 4,
    Exit = 5

}