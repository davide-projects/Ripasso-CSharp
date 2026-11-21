using Incapsulamento;

Console.WriteLine("Conto Bancario");

string accountNumber = ReadInput("Inserisci un conto corrente: ");
bool hasInitialBalance = ReadInput("Vuoi inserire un saldo iniziale? (S/N)")
    .Equals("S", StringComparison.OrdinalIgnoreCase);
BankAccount account;

if (hasInitialBalance)
{
    decimal initialBalance = ReadDecimal("Inserisci il saldo iniziale: ");
    account = new BankAccount(accountNumber, initialBalance);
}
else
{
    account = new BankAccount(accountNumber);
}

MenuOption selectedOption;

do
{
    selectedOption = ReadMenuOption("Scegli un'operazione: ");

    switch (selectedOption)
    {
        case MenuOption.Deposit:
            decimal depositAmount = ReadDecimal("Quanto vuoi depositare? ");
            var depositResult = account.Deposit(depositAmount);
            Console.WriteLine(depositResult.Message);
            break;

        case MenuOption.Withdraw:
            decimal withdrawAmount = ReadDecimal("Quanto vuoi prelevare? ");
            var withdrawResult = account.Withdraw(withdrawAmount);
            Console.WriteLine(withdrawResult.Message);
            break;

        case MenuOption.Summary:
            Console.WriteLine(account.GetSummary());
            break;

        case MenuOption.Transactions:
            PrintTransactions(account.Transactions);
            break;

        case MenuOption.Exit:
            Console.WriteLine("Uscita programma\nArriverci!");
            break;
    }
}
while (selectedOption != MenuOption.Exit);

Console.WriteLine("\n--- TEST CASI NON VALIDI ---");

try
{
    new BankAccount("");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test 1 OK (bloccato): {ex.Message}");
}

try
{
    new BankAccount("IT001", -100m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test 2 OK (bloccato): {ex.Message}");
}

var invalidDeposit = account.Deposit(-50m);
if (!invalidDeposit.Success)
{
    Console.WriteLine($"Test 3 OK (bloccato): {invalidDeposit.Message}");
}

var invalidWithdraw = account.Withdraw(account.Balance + 500m);
if (!invalidWithdraw.Success)
{
    Console.WriteLine($"Test 4 OK (bloccato): {invalidWithdraw.Message}");
}

MenuOption ReadMenuOption(string prompt)
{
    Console.WriteLine("\n--- MENU OPERAZIONI ---");
    Console.WriteLine("1. Deposita");
    Console.WriteLine("2. Preleva");
    Console.WriteLine("3. Riepilogo conto");
    Console.WriteLine("4. Storico operazioni");
    Console.WriteLine("0. Esci");

    do
    {
        string input = ReadInput(prompt);
        if (int.TryParse(input, out int value) && Enum.IsDefined(typeof(MenuOption), value))
        {
            return (MenuOption)value;
        }

        Console.WriteLine("Errore: scegli un'opzione valida dal menu.");
    }
    while (true);
}


void PrintTransactions(IReadOnlyList<string> transactions)
{
    if (transactions.Count == 0)
    {
        Console.WriteLine("Nessuna transazione registrata");
        return;
    }
    Console.WriteLine("\n--- RIEPILOGO OPERAZIONI ---");
    foreach (string transaction in transactions)
    {
        Console.WriteLine(transaction);
    }
    Console.WriteLine($"SALDO: {account.Balance:F2}");
}

decimal ReadDecimal(string prompt)
{
    decimal value;
    do
    {
        string input = ReadInput(prompt);
        if (decimal.TryParse(input, out value) && value > 0)
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Errore: Il numero deve essere maggiore di 0. Riprova!");
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

enum MenuOption
{
    Exit = 0,
    Deposit = 1,
    Withdraw = 2,
    Summary = 3,
    Transactions = 4
}