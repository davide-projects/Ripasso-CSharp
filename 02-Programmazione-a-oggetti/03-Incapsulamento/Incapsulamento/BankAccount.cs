namespace Incapsulamento
{
    public class BankAccount
    {
        public string AccountNumber { get; } = string.Empty;
        public decimal Balance { get; private set; }
        private readonly List<string> _transactions = new();
        public IReadOnlyList<string> Transactions => _transactions.AsReadOnly();

        public BankAccount(string accountNumber, decimal initialBalance = 0m)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException("Numero di conto richiesto", nameof(accountNumber));
            }
            if (initialBalance < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(initialBalance), "Il saldo iniziale non può essere negativo");
            }
            AccountNumber = accountNumber.Trim();
            Balance = initialBalance;

            if (initialBalance > 0)
            {
                RecordTransaction("Deposito iniziale", initialBalance);
            }
        }

        public (bool Success, string Message) Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                return (false, "Errore: l'importo del deposito deve essere maggiore di 0.");
            }
            Balance += amount;
            RecordTransaction("Deposito", amount);
            return (true, BuildConfirmationMessage(amount));
        }

        public (bool Success, string Message) Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                return (false, "Errore: l'importo del prelievo deve essere maggiore di 0.");
            }

            if (amount > Balance)
            {
                return (false, "Errore: Saldo Insufficiente");
            }
            Balance -= amount;
            RecordTransaction("Prelievo", amount);
            return (true, BuildConfirmationMessage(amount));
        }

        public string GetSummary()
        {
            return $" --- RIEPILOGO CONTO ---\n" +
                $"Conto: {AccountNumber}\n" +
                $"Saldo: {Balance:F2} €";
        }

        private void RecordTransaction(string type, decimal amount)
        {
            _transactions.Add($"{type}: {amount:F2} €");
        }

        private string BuildConfirmationMessage(decimal amount)
        {
            return $"Transazione eseguita\n" +
                $"Importo: {amount:F2}\n" +
                $"Saldo: {Balance:F2}";
        }
    }
}