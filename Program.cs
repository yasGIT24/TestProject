// See https://aka.ms/new-console-template for more information

using System.Text;

string option = "";
do
{
    Console.WriteLine("Enter the string to encode");
    string str = Console.ReadLine();
    if (str != null) Console.WriteLine(Convert.ToBase64String(Encoding.UTF8.GetBytes(str)));
    Console.WriteLine("Do you want to encode more strings? (y/n)");
    option = Console.ReadLine();
}
while (option.ToLower() == "y");