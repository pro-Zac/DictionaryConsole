using System;
using System.Collections.Generic;
using System.IO;

class RowData
{
    public string Column1 { get; set; }
    public decimal Column2 { get; set; }
    public string Column3 { get; set; }
    public string Column4 { get; set; }

    public RowData(string col1, decimal col2, string col3, string col4)
    {
        Column1 = col1;
        Column2 = col2;
        Column3 = col3; 
        Column4 = col4;
    }

    public override string ToString()
    {
        return $"{Column1}\t{Column2}\t{Column3}\t{Column4}\t\t\t\t";
    }
}

class DictionaryInput
{
    static void Main()
    {
        List<RowData> rows = new List<RowData>();
        string previousColumn1Value = "";
        decimal previousColumn2Value = 0;
        string previousColumn3Value = "";
        string previousColumn4Value = "";

        while (true)
        {
            Console.WriteLine("\nAdd New Row (**UwU**)");

            Console.Write($"Enter value for Column 1 (string) [defult: {previousColumn1Value}]: ");
            string column1Input = Console.ReadLine();
            string newColumn1Value = string.IsNullOrEmpty(column1Input) ? previousColumn1Value : column1Input;

            Console.Write($"Enter value for Column 2 (decimal) [default: {previousColumn2Value}]: ");
            string column2Input = Console.ReadLine();
            decimal newColumn2Value = string.IsNullOrEmpty(column2Input) ? previousColumn2Value : decimal.Parse(column2Input);

            Console.Write($"Enter value for Column 3 (string) [default: {previousColumn3Value}]: ");
            string column3Input = Console.ReadLine();
            string newColumn3Value = string.IsNullOrEmpty(column3Input) ? previousColumn3Value : column3Input;

            Console.Write($"Enter value for Column 4 (string) [default: {previousColumn4Value}]: ");
            string column4Input = Console.ReadLine();
            string newColumn4Value = string.IsNullOrEmpty(column4Input) ? previousColumn4Value : column4Input;

            RowData newRow = new RowData(newColumn1Value, newColumn2Value, newColumn3Value, newColumn4Value);
            rows.Add(newRow);

            previousColumn1Value = newColumn1Value;
            previousColumn2Value = newColumn2Value; 
            previousColumn3Value = newColumn3Value; 
            previousColumn4Value = newColumn4Value;

            Console.WriteLine("\nNewly added row: ");
            Console.WriteLine(newRow);

            Console.WriteLine("\nAdd another row? (y/n): ");
            if (Console.ReadLine().ToLower() != "y") break;

        }

        string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string filePath = Path.Combine(documentsPath, "DictionaryOutput.txt");
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Column1\tColumn2\tColumn3\tColumn4\t\t\t\t");
            foreach (var row in rows)
            {
                writer.WriteLine(row);
            }
        }

        Console.WriteLine($"\nData has been saved to {filePath}");
        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
    }
}