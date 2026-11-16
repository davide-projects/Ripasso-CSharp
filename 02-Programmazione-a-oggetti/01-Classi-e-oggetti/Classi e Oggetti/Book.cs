namespace Classi_e_Oggetti
{
    public class Book
    {
        public string Title { get; } = string.Empty;
        public string Author { get; } = string.Empty;
        public int PublicationYear { get; }

        public Book(string title, string author, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Titolo richiesto", nameof(title));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Autore richiesto", nameof(author));
            }

            int currentYear = DateTime.Now.Year;
            if (publicationYear <= 0 || publicationYear > currentYear)
            {
                throw new ArgumentOutOfRangeException(nameof(publicationYear), $"L'anno accettato è compreso tra 1 e {currentYear}");
            }

            Title = title.Trim();
            Author = author.Trim();
            PublicationYear = publicationYear;
        }


        public string GetDescription()
        {
            return $"Titolo: {Title}" +
                $"\nAutore: {Author}" +
                $"\nAnno di pubblicazione: {PublicationYear}";
        }

        public bool IsPublishedBefore(int targetYear)
        {
            if (PublicationYear < targetYear) return true; else return false;
        }
    }
}
