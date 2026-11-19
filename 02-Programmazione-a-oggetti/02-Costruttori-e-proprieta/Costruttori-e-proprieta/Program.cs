using Costruttori_e_proprieta;

Console.WriteLine("Scheda Dipendente");

List<Employee> employees = new List<Employee>();
bool anotherEmployee;

do
{
    string name = ReadInput("Inserisci un nome: ");
    string surname = ReadInput("Inserisci un cognome: ");
    string role = ReadInput("Inserisci un ruolo: ");
    bool hasOptionalData = ReadInput("Vuoi inserire dipartimento e salario? (S/N): ")
        .Equals("S", StringComparison.OrdinalIgnoreCase);

    try
    {
        if (hasOptionalData)
        {
            string department = ReadInput("Inserisci un dipartimento:");
            decimal salary = ReadPositiveDecimal("Inserisci un Salario: ", 0m);
            Employee employee = new Employee(name, surname, role, department, salary);
            employees.Add(employee);
        }
        else
        {

            Employee employee = new Employee(name, surname, role);
            employees.Add(employee);
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"Errore nella creazione del Dipendente: {ex.Message}");
    }

    anotherEmployee = ReadInput("Vuoi inserire un altro dipendente: (S/N)")
        .Equals("S", StringComparison.OrdinalIgnoreCase);
}
while (anotherEmployee);

PrintEmployees(employees);

try
{
    new Employee("", "Rossi", "Developer");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test 1 OK (bloccato): {ex.Message}");
}

try
{
    new Employee("Mario", "Rossi", "Developer", "   ", 1500m);
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Test 2 OK (bloccato): {ex.Message}");
}

try
{
    new Employee("Mario", "Rossi", "Developer", "IT", -500m);
}
catch (ArgumentOutOfRangeException ex)
{
    Console.WriteLine($"Test 3 OK (bloccato): {ex.Message}");
}


void PrintEmployees(List<Employee> employees)
{
    if (employees.Count == 0)
    {
        Console.WriteLine("Nessun dipendente registrato");
        return;
    }
    foreach (Employee employee in employees)
    {
        Console.WriteLine(employee.GetSummary());
        Console.WriteLine();
    }
}


decimal ReadPositiveDecimal(string prompt, decimal minValue)
{
    decimal value;
    do
    {
        string input = ReadInput(prompt);
        if (decimal.TryParse(input, out value) && value > minValue)
        {
            return value;
        }
        else
        {
            Console.WriteLine($"Errore: Il numero deve essere maggiore di {minValue}. Riprova!");
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