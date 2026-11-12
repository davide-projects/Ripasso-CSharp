Console.WriteLine("Programma statistiche voti");


const int MIN_STUDENTS = 0;
const int MAX_STUDENTS = 10;
const double MIN_GRADE = 0.0;
const double PASSING_GRADE = 6.0;
const double MAX_GRADE = 10.0;

int studentCount = ReadIntRange($"Inserisci il numero degli studenti (da {MIN_STUDENTS} a {MAX_STUDENTS}): ", MIN_STUDENTS, MAX_STUDENTS);
double[] grades = ReadGrades(studentCount);
PrintClassSummary(grades);






int ReadIntRange(string prompt, int min, int max)
{
    int value;
    do
    {
        string input = ReadInput(prompt);
        if (int.TryParse(input, out value) && value >= min && value <= max)
        {
            return value;
        }
        Console.WriteLine($"Inserisci un numero tra {min} e {max}.");
    }
        while (true);
}

double ReadDoubleRange(string prompt, double min, double max)
{
    double value;
    do
    {
        string input = ReadInput(prompt);
        if (double.TryParse(input, out value) && value >= min && value <= max)
        {
            return value;
        }
        Console.WriteLine($"Inserisci un numero tra {min} e {max}.");
    }
    while (true);
}


double[] ReadGrades(int size)
{
    double[] grades = new double[size];
    for (int i = 0; i < grades.Length; i++)
        {
        grades[i] = ReadDoubleRange($"Inserisci il voto dello studente {i + 1}: ", MIN_GRADE, MAX_GRADE);

    }
    return grades;
}


double CalculateAverage(double[] grades)
{
    if (grades.Length == 0)
    {
        return 0.0;
    }

    double sum = 0.0;
    foreach (double grade in grades)
    {
        sum += grade;
    }
    double average = sum / grades.Length;
    return average;
}

double FindMaxGrade(double[] grades)
{
    if (grades.Length == 0)
    {
        return 0.0;
    }

    double maxGrade = grades[0];
    foreach (double grade in grades)
    {
        if (grade > maxGrade)
        {
            maxGrade = grade;
        }
    }
    return maxGrade;
}

int CountFailingGrades(double[] grades, double passingGrade)
{
    int failingCount = 0;
    foreach (double grade in grades)
    {
        if (grade < passingGrade)
        {
            failingCount++;
        }
    }
    return failingCount;
}


void PrintClassSummary(double[] grades)
{
    if (grades.Length == 0)
    {
        Console.WriteLine("Nessun Voto Inserito!");
        return;
    }
    double average = CalculateAverage(grades);
    double maxGrade = FindMaxGrade(grades);
    int failingCount = CountFailingGrades(grades, PASSING_GRADE);

    Console.WriteLine("\n--- Riepilogo Voti ---");
    Console.WriteLine($"Media Voti: {average:F2}");
    Console.WriteLine($"Voto migliore: {maxGrade}");
    Console.WriteLine($"Numero di insufficienze: {failingCount}");

    PrintGradesAboveAverage(grades, average);
}

void PrintGradesAboveAverage(double[] grades, double average)
{
    Console.WriteLine("\n--- Voti sopra la media ---");
    bool hasGradesAboveAverage = false;

    for (int i = 0; i < grades.Length; i++)
        {
        if (grades[i] > average)
        {
            hasGradesAboveAverage = true;
            Console.WriteLine($"Studente {i + 1}: {grades[i]}");
        }
    }
    if (!hasGradesAboveAverage)
        {
        Console.WriteLine("Nessun voto sopra la Media");
        }
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
            return input;
        }
    }
    while (true);
}
