//basic console math game
Random rnd = new Random();
int score = 0;
List<string> rec = new List<string>() { "NO GAMES YET" };
string gk = "";
int gamenum = 0;
bool gameon = true;
void reinit()
{
    gameon = true;
    menu();
    while (gameon) mathgame();
}

void menu()
{
    bool good = false;
    score = 0;
    while (!good)
    {
        Console.WriteLine("WELCOME TO MATH GAME!");
        Console.WriteLine("\n0- MULTIPLICATION\n1- DIVISION\n2- ADDITION\n3- SUBTRACTION");
        Console.WriteLine("4- CHECK RECORDS\n");
        gk = Console.ReadLine();
        if (gk == "4")
        {
            Console.Clear();
            showrecords(rec);
        }
        else if (gk == "0" || gk == "1" || gk == "2" || gk == "3") good = true;
        Console.Clear();
    }
}
void showrecords(List<string> ll)
{
    for (int i = 0; i < ll.Count; i++) Console.WriteLine(ll[i]);
    Console.ReadLine();
    Console.Clear();
}
void mathgame()
{
    Console.Clear();
    List<string> op = new List<string>() { "*", "/", "+", "-" };
    int x = rnd.Next(0, 10);
    int y = rnd.Next(0, 10);
    int ope = Convert.ToInt32(gk);
    int ans = -9999;
    if (ope == 0) ans = x * y;
    else if (ope == 2) ans = x + y;
    else if (ope == 3) ans = x - y;
    else if (ope == 1)
    {
        y = rnd.Next(1, 101);
        x = rnd.Next(0, 101);
        while (x % y != 0)
        {
            x = rnd.Next(0, 101);
            y = rnd.Next(1, 101);
        }
        ans = x / y;
    }
    Console.WriteLine($"{x} {op[ope]} {y}\n");
    Console.WriteLine("INPUT Q OR q TO QUIT\n");
    string g = Console.ReadLine();
    int ggg;
    bool gg = int.TryParse(g, out ggg);
    if (gg && ans == Convert.ToInt32(g))
    {
        score++;
        Console.WriteLine("\nCORRECT\n");
    }
    else if (g == "q" || g == "Q")
    {
        if (rec[0] == "NO GAMES YET") rec.Clear(); 
        rec.Add($"GAME {++gamenum}: SCORE = {score}");
        gameon = false;
        Console.Clear();
        reinit();
    }
    else
    {
        Console.WriteLine("\nWRONG\n");
        Console.WriteLine($"THE ANSWER IS: {ans}\n");
    }
    Console.WriteLine($"SCORE: {score}");
    g = Console.ReadLine();
    if (g == "q" || g == "Q")
    {
        if (rec[0] == "NO GAMES YET") rec.Clear();
        rec.Add($"GAME {++gamenum}: SCORE = {score}");
        gameon = false;
        Console.Clear();
        reinit();
    }
    Console.Clear();
}
reinit();
