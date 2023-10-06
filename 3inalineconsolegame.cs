//initial commit
Random random = new Random();
bool playerOwin = false;
bool playerXwin = false;
string[] emptybox = { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
string[] box = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
string firline = emptybox[0] + "|" + emptybox[1] + "|" + emptybox[2];
string secline = emptybox[3] + "|" + emptybox[4] + "|" + emptybox[5];
string thiline = emptybox[6] + "|" + emptybox[7] + "|" + emptybox[8];
string plych = "";
string aich = "";
void choosechar()
{
    string ans = "";
    do
    {
        Console.Clear();
        Console.WriteLine("Choose 'O' or 'X'");
        ans = Console.ReadLine().ToUpper();
    } while (ans != "O" && ans != "X");
    plych = ans;
    aich = plych == "O" ? "X" : "O";
}
void drawboard()
{
    Console.Clear();
    Console.WriteLine($"{firline}");
    Console.WriteLine("-----");
    Console.WriteLine($"{secline}");
    Console.WriteLine("-----");
    Console.WriteLine($"{thiline}");
}
void maketurn()
{
    string pc = "";
    do
    {
        Console.WriteLine("Enter a box number you want to make a turn (1 to 9).");
        pc = Console.ReadLine();
        if (box.Contains(pc))
        {
            int num = Convert.ToInt32(pc) - 1;
            emptybox[num] = plych;
            box[num] = plych;
            firline = emptybox[0] + "|" + emptybox[1] + "|" + emptybox[2];
            secline = emptybox[3] + "|" + emptybox[4] + "|" + emptybox[5];
            thiline = emptybox[6] + "|" + emptybox[7] + "|" + emptybox[8];
            drawboard();
            break;
        }
        else continue;
    } while (!box.Contains(pc));
}
void aiturn()
{
    string cc = "";
    do
    {
        cc = random.Next(1, 10).ToString();
        if (box.Contains(cc))
        {
            int num = Convert.ToInt32(cc) - 1;
            emptybox[num] = aich;
            box[num] = aich;
            firline = emptybox[0] + "|" + emptybox[1] + "|" + emptybox[2];
            secline = emptybox[3] + "|" + emptybox[4] + "|" + emptybox[5];
            thiline = emptybox[6] + "|" + emptybox[7] + "|" + emptybox[8];
            drawboard();
            break;
        }
        else continue;
    } while (!box.Contains(cc));
}
void checkwin(string orx)
{
    bool gotwinner = false;
    if (firline == $"{orx}|{orx}|{orx}" || secline == $"{orx}|{orx}|{orx}" || thiline == $"{orx}|{orx}|{orx}") gotwinner = true;
    else if (firline.Substring(0, 1) == orx && secline.Substring(0, 1) == orx && thiline.Substring(0, 1) == orx) gotwinner = true;
    else if (firline.Substring(2, 1) == orx && secline.Substring(2, 1) == orx && thiline.Substring(2, 1) == orx) gotwinner = true;
    else if (firline.Substring(4) == orx && secline.Substring(4) == orx && thiline.Substring(4) == orx) gotwinner = true;
    else if ((firline.Substring(0, 1) == orx) && (secline.Substring(2, 1) == orx) && (thiline.Substring(4) == orx)) gotwinner = true;
    else if (firline.Substring(4) == orx && secline.Substring(2, 1) == orx && thiline.Substring(0, 1) == orx) gotwinner = true;
    if (orx == "O" && gotwinner == true) playerOwin = true;
    if (orx == "X" && gotwinner == true) playerXwin = true;
}

void input()
{
    Console.WriteLine();
    Console.WriteLine(playerOwin && plych == "O" || playerXwin && plych == "X" ? "Player wins!" : (playerOwin && aich == "O" || playerXwin && aich == "X" ? "Computer wins!" : "No One Won"));
    Console.ReadLine();
}

bool end()
{
    int count = 0;
    for (int i = 0; i < box.Length; i++)
    {
        if (emptybox[i] == " ") count++;
    }
    return count == 0 ? true : false;
}
void playgame()
{
    choosechar();
    while (!end())
    {
        drawboard();
        aiturn();
        checkwin("X");
        checkwin("O");
        if (playerOwin || playerXwin) break;
        if (!end())
        {
            maketurn();
            checkwin("X");
            checkwin("O");
            if (playerOwin || playerXwin) break;
        }
    }
    input();
}
playgame();
