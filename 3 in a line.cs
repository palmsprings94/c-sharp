//initial commit
Random random = new Random();
bool playerOwin = false;
bool playerXwin = false;
string[] box = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
string[] boxcheck = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
string firline = box[0] + "|" + box[1] + "|" + box[2];
string secline = box[3] + "|" + box[4] + "|" + box[5];
string thiline = box[6] + "|" + box[7] + "|" + box[8];
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
    string numa = "";
    do
    {
        Console.WriteLine("Enter the box number you want to make a turn.");
        numa = Console.ReadLine();
        if (box.Contains(numa))
        {
            int num = Convert.ToInt32(numa) - 1;
            box[num] = plych;
            firline = box[0] + "|" + box[1] + "|" + box[2];
            secline = box[3] + "|" + box[4] + "|" + box[5];
            thiline = box[6] + "|" + box[7] + "|" + box[8];
            drawboard();
            break;
        }
        else continue;
    } while (!box.Contains(numa));
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
            box[num] = aich;
            firline = box[0] + "|" + box[1] + "|" + box[2];
            secline = box[3] + "|" + box[4] + "|" + box[5];
            thiline = box[6] + "|" + box[7] + "|" + box[8];
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
    if (orx == "O" && gotwinner == true)
    {
        playerOwin = true;
    }
    if (orx == "X" && gotwinner == true)
    {
        playerXwin = true;
    }
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
        if (box[i] == boxcheck[i]) count++;
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
