namespace Costruttori_e_proprieta
{
    public class Employee
    {
        public string FirstName { get; } = string.Empty;
        public string LastName { get; } = string.Empty;
        public string Role { get; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
        public string? Department { get; }
        public decimal? Salary { get; }

        public Employee(string firstName, string lastName, string role)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("Nome richiesto", nameof(firstName));
            }

            else if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Cognome richiesto", nameof(lastName));
            }

            else if (string.IsNullOrWhiteSpace(role))
            {
                throw new ArgumentException("Ruolo richiesto", nameof(role));

            }

            FirstName = firstName.Trim();
            LastName = lastName.Trim();
            Role = role.Trim();
        }

        public Employee(string firstName, string lastName, string role, string? department, decimal? salary)
            : this(firstName, lastName, role)
        {
            if (department != null && string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException("Il dipartimento non può essere vuoto", nameof(department));
            }

            if (salary.HasValue && salary <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(salary), "il salario deve essere superiore a 0");
            }

            Department = department?.Trim();
            Salary = salary;
        }

        public string GetSummary()
        {
            return $"Scheda Dipendente:\n" +
                $"Dati Anagrafici: {FullName}\n" +
                $"Ruolo: {Role}\n" +
                $"Dipartimento {Department ?? "Non assegnato"}\n" +
                $"Salario: {(Salary.HasValue ? $"{Salary:F2} €" : "Non assegnato")}";
        }
    }
}
