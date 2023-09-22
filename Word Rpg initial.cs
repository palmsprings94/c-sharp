Random rand = new Random();
string? input;
//player stats
string name;
int hp;
int mp;
int str = 0;
int iq;
int exp;
int gold = 500;
string job;
string spell;
int monkill = 0;
int xshower = 0;
int xslept = 0;
int xate = 0;
bool fatalisalive = true;
bool chk;
do
{
    chk = false;
    Console.Clear();
    Console.WriteLine("Enter player name: (No spaces allowed)");
    input = Console.ReadLine();
    name = input;
    if (input != null && input != "" && !input.Contains(" "))
    {
        Console.WriteLine();
        chk = true;
    }
} while (chk == false);

do
{
    Console.Clear();
    Console.WriteLine($"Welcome to Word RPG {name}! Press the corresponding numbers to make a choice.\n");
    Console.WriteLine("Choose a job:\n");
    Console.WriteLine("1 - Fighter");
    Console.WriteLine("2 - Spellcaster");
    input = Console.ReadLine();
    job = "";
    switch (input)
    {
        case "1":
            job = "Fighter";
            hp = 250;
            mp = 100;
            str = 15;
            iq = 15;
            exp = 0;
            spell = "Vicious slash";
            Console.WriteLine($"\nYou have chosen the {job} class. Press Enter to continue.");
            Console.ReadLine();
            break;
        case "2":
            job = "Spellcaster";
            hp = 100;
            mp = 250;
            str = 5;
            iq = 25;
            exp = 0;
            spell = "Lightning blade";
            Console.WriteLine($"\nYou have chosen the {job} class. Press Enter to continue.");
            Console.ReadLine();
            break;
    }
} while (job != "Fighter" && job != "Spellcaster");

do
{
    chk = true;
    Console.Clear();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1 - Hunt a monster.");
    Console.WriteLine("2 - Train in the encampment.");
    Console.WriteLine("3 - Take a relaxing shower.");
    Console.WriteLine("4 - Buy a meal in town.");
    Console.WriteLine("5 - Go to sleep.");
    Console.WriteLine("6 - Kill Fatalis.");
    Console.WriteLine("7 - Check battle stats.");
    Console.WriteLine("8 - Retire from your journey.");
    string? menu;
    menu = Console.ReadLine();

    switch (menu)
    {
        default:
            chk = true;
            break;
        case "8":
            Console.Clear();
            Console.WriteLine($"Congratulations {name}! You have successfully retired in one piece!");
            Console.WriteLine($"Monsters killed: {monkill}");
            Console.WriteLine($"Times showered: {xshower}");
            Console.WriteLine($"Times ate: {xate}");
            Console.WriteLine($"Times slept: {xslept}");
            Console.WriteLine(fatalisalive == true ? "World Boss Killed: No" : "World Boss Killed: Yes");
            Console.WriteLine($"\nThanks for playing {name}!");
            Console.ReadLine();
            chk = false;
            break;
        case "1":
            string[] monslist = { "Goblin", "Demon", "Dokidoki" };
            int monsindex = rand.Next(0, 3);
            string currenemy = monslist[monsindex];
            int enehp = 0;
            int enestr = 0;
            int eneiq = 0;
            int enegold;
            int enexp;
            string eneskill;
            bool battend = false;
            bool run = false;
            switch (currenemy)
            {
                case "Goblin":
                    enehp = 90;
                    enestr = 20;
                    eneiq = 10;
                    enegold = 100;
                    enexp = 100;
                    eneskill = "Throw oiled club";
                    break;
                case "Demon":
                    enehp = 80;
                    enestr = 10;
                    eneiq = 25;
                    enegold = 100;
                    enexp = 100;
                    eneskill = "Life Drain";
                    break;
                case "Dokidoki":
                    enehp = 100;
                    enestr = 20;
                    eneiq = 20;
                    enegold = 150;
                    enexp = 150;
                    eneskill = "Gay kiss";
                    break;
            }
            Console.WriteLine($"You have encountered a {currenemy}!");
            do
            {
                do
                {
                    Console.WriteLine("1 - Attack");
                    Console.WriteLine("2 - Cast Skill");
                    Console.WriteLine("3 - Run Away");
                    input = Console.ReadLine();
                } while (input != "1" && input != "2" && input != "3");
                
                switch (input)
                {
                    case "1":
                        int plydmg = rand.Next(1, (str + 1));
                        enehp -= plydmg;
                        Console.WriteLine($"{name} strikes with their weapon and deal {plydmg} damage to {currenemy}!");
                        if (enehp > 0)
                        {
                            int monsdmgtype = rand.Next(0, 2);
                            int monsdmg = monsdmgtype == 0 ? rand.Next(1, (enestr + 1)) : rand.Next(1, (eneiq + 1));

                        }

                }
                
                


            } while (battend == false);
        

    }
} while (chk == true);
