using Lab2_v2;
using System.Xml.Linq;

var db = new DataSource(); //Produkt-"databas"
Login userLogin = new Login(); //Loggar in en användare
bool loggingIn = true; //Bool för login-loop
bool shoping = false; //Bool när man är inloggad
var keyPress = new ConsoleKeyInfo(); //Switch-navigering

//Programmet körs tills användaren avlsutar
while (true)
{
    while (loggingIn)
    {
        LoginMenu();
    }

    while (shoping)
    {
        StoreMenu();
    }
}

void LoginMenu()
{
    Console.WriteLine("1: Logga in | 2: Registrera ny kund | Q: Stäng program");
    keyPress = Console.ReadKey();
    Console.CursorLeft = 0;

    System.ConsoleKey[] cK = { ConsoleKey.D1, ConsoleKey.D2, ConsoleKey.D3, ConsoleKey.Q };
    if (keyPress.Key != cK[0] & keyPress.Key != cK[1] & keyPress.Key != cK[3])
    {
        Console.Write("\nFel inmatning: ");
        ChangeTextColor("Red");
        Console.WriteLine("\nVänligen välj mellan 1, 2 eller Q för att avsluta.\n");
    }
    else
    {
        switch (keyPress.Key)
        {
            case ConsoleKey.D1:

                ChangeTextColor("Green.Login");
                userLogin.LoginFields();
                if (userLogin.CheckIfUserExists())
                {
                    loggingIn = false;
                    shoping = true;
                }
                break;

            case ConsoleKey.D2:

                ChangeTextColor("Green.Register");
                userLogin.LoginFields(); //Name, Password
                userLogin.userList.Add(new Customer(userLogin.Name, userLogin.Password)); //Spara till lista
                break;

            case ConsoleKey.Q:

                ChangeTextColor("Green.Quit");
                Login.VerifyQuit();
                Console.Clear();
                break;
        }
    }
}
void StoreMenu()
{
    keyPress = Console.ReadKey();
    int productId = 0;
    switch (keyPress.Key)
    {
        case ConsoleKey.D1:
            Console.Clear();
            productId = 1;
            StoreMethod.AddToCart(productId);
            StoreMethod.PrintCart();
            break;
        case ConsoleKey.D2:
            Console.Clear();
            productId = 2;
            StoreMethod.AddToCart(productId);
            StoreMethod.PrintCart();
            break;
        case ConsoleKey.D3:
            Console.Clear();
            productId = 3;
            StoreMethod.AddToCart(productId);
            StoreMethod.PrintCart();
            break;
        case ConsoleKey.D4:
            Console.Clear();
            productId = 1;
            StoreMethod.RemoveFromCart(productId);
            StoreMethod.PrintCart();
            break;
        case ConsoleKey.D5:
            Console.Clear();
            productId = 2;
            StoreMethod.RemoveFromCart(productId);
            StoreMethod.PrintCart();
            break;
        case ConsoleKey.D6:
            Console.Clear();
            productId = 3;
            StoreMethod.RemoveFromCart(productId);
            StoreMethod.PrintCart();
            break;
    }
}
void ChangeTextColor(string color)
{
    switch (color)
    {
        case "Red":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(keyPress.KeyChar);
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Login":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("   -------- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Register":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("              --------------------- ");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        case "Green.Quit":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                                      -----------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Gray;
            break;
    }
}