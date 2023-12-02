string folderPath = @"C:\Users\robin\OneDrive\Desktop";
string fileName = "shoppingList.txt";
string filePath = Path.Combine(folderPath, fileName);
List<string> myshoppingList = GetItemsFromUser();

if (File.Exists(filePath))
{
    myshoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myshoppingList);
}
else
{
    File.Create(filePath).Close();
    Console.WriteLine($"File {fileName} has been created.");
    myshoppingList = GetItemsFromUser();
    File.WriteAllLines(filePath, myshoppingList);
}



static List<string> GetItemsFromUser()
{
    List<string> userlist = new List<string>();

    while (true)
    {
        Console.WriteLine("Add an item (add)/ Exit (exit):");
        string userChoice = Console.ReadLine();

        if (userChoice == "add")
        {
            Console.WriteLine("Enter an item:");
            string userItem = Console.ReadLine();
            userlist.Add(userItem);
        }
        else
        {
            Console.WriteLine("Bye!");
            break;
        }
    }
    return userlist;
}

static void ShowItemsFromList(List<string> someList)
{
    Console.Clear();

    int listLenght = someList.Count();
    Console.WriteLine($"You have added {listLenght} items to your shopping list:");

    int i = 1;
    foreach (string item in someList)
    {

        Console.WriteLine($"{i}. {item}");
        i++;
    }
}
