// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
// Set the directory you want to read from
//string sourceDirectory = @"C:\Users\yasmin.shahul.hameed\source\repos\GenWizard3.0\GenWizardAgent\2010-GenwizardAgent.DataAccess\Models";

//// Set the path to save the output text file
//string outputFilePath = @"C:\Users\yasmin.shahul.hameed\Desktop\My Work\Files From Directory\2010-GenwizardAgent.DataAccess-Models.txt";

//try
//{
//    // Get all file names in the directory
//    string[] files = Directory.GetFiles(sourceDirectory);
//    string[] fileNames = Directory.GetFiles(sourceDirectory)
//                              .Select(Path.GetFileName)
//                              .ToArray();


//    // Write file names to the text file
//    File.WriteAllLines(outputFilePath, fileNames);

//    Console.WriteLine("File names written successfully to " + outputFilePath);
//}
//catch (Exception ex)
//{
//    Console.WriteLine("An error occurred: " + ex.Message);
//}


//string key = "mykey";
//string val1 = "CR Title";
//string val2 = "CR Desc";

//string result = $"@key:{key} @value:Title as '\\''<{val1}>'\\'' Description as '\\''<{val2}>'\\''";

//Console.WriteLine(result);


//Reference check
Employee emp = new Employee()
{
    Id = 1,
    Name = "Yasmin Begam",
    FirstName = "Yasmin",
    LastName = "Begam",
    Title = "title",
    Description = "description",
    Hobbies = {"Reading", "Writing","Carrom"}
};

Employee emp2 = emp;
Employee emp3 = new Employee()
{
    Id = 2,
    Name = "name",
    FirstName = "fname",
    LastName = "lname",
    Title = "title",
};
emp3.Hobbies = emp.Hobbies;
Console.WriteLine("Employee 3 details "+ emp3.Hobbies[0] +"," + emp3.Hobbies[1]);
emp2.Hobbies.Clear();
Console.WriteLine("Employee 2 details "+ emp2.Hobbies.Count());
Console.WriteLine("Employee details " + emp.Hobbies.Count());
Console.WriteLine("Employee 3 details " + emp3.Hobbies[0] + "," + emp3.Hobbies[1]);
public class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Title { get; set; }
    public List<string?> Hobbies { get; set; } = new List<string?>();
}

