using System.Xml.XPath;

Random rand = new Random();
string? input;
//player stats
string name;
int maxhp = 0;
int maxmp = 0;
int hp = 0;
int mp = 0;
int str = 0;
int iq = 0;
int exp = 0;
int lvl = 1;
int gold = 500;
string job;
string spell = "";
int monkill = 0;
int xrest = 0;
int xate = 0;
bool fatalisalive = true;
bool chk;
do
{
    chk = false;
    Console.Clear();
    Console.WriteLine("Enter player name: (No spaces allowed)");
    input = Console.ReadLine();
    name = input.ToUpper();
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
    Console.WriteLine("Choose a job:");
    Console.WriteLine("1 - Swordsman");
    Console.WriteLine("2 - Spellcaster");
    input = Console.ReadLine();
    job = "";
    switch (input)
    {
        case "1":
            job = "Swordsman";
            maxhp = 250;
            maxmp = 100;
            hp = 250;
            mp = 100;
            str = 15;
            iq = 15;
            exp = 0;
            spell = "VICIOUS SLASH";
            Console.WriteLine($"\nYou have chosen the {job} class. Press Enter to continue.");
            Console.ReadLine();
            break;
        case "2":
            job = "Spellcaster";
            maxhp = 100;
            maxmp = 250;
            hp = 100;
            mp = 250;
            str = 8;
            iq = 40;
            exp = 0;
            spell = "LIGHTNING BOLT";
            Console.WriteLine($"\nYou have chosen the {job} class. Press Enter to continue.");
            Console.ReadLine();
            break;
    }
} while (job != "Swordsman" && job != "Spellcaster");

do
{
    chk = true;
    Console.Clear();
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("1 - Hunt a monster");
    Console.WriteLine("2 - Check player stats");
    Console.WriteLine("3 - Buy a meal in town");
    Console.WriteLine("4 - Rent a room in the inn to use bathroom shower and sleep");
    Console.WriteLine("5 - Kill Fatalis");
    Console.WriteLine("6 - Train in the encampment");
    Console.WriteLine("7 - Retire from your journey/Exit game");
    string? menu;
    menu = Console.ReadLine();

    switch (menu)
    {
        default:
            chk = true;
            break;
        case "4":
            Console.Clear();
            if (gold >= 100)
            {
                Console.WriteLine("You spent 100 gold to rent the inn.");
                Console.WriteLine("You wake up clean and refreshed!");
                Console.WriteLine("Restored 50% of MaxHP and MaxMP!");
                gold -= 100;
                xrest++;
                hp += (maxhp / 2);
                hp = hp > maxhp ? maxhp : (hp*1);
                mp += (maxmp / 2);
                mp = mp > maxmp ? maxmp : (mp*1);
                Console.WriteLine("\nPress Enter to continue.");
                Console.ReadLine();
                break;
            }
            else
            {
                Console.WriteLine("You don't have enough money to rent the inn.");
                Console.WriteLine("\nPress Enter to continue");
                Console.ReadLine();
                break;
            }
        case "2":
            Console.Clear();
            Console.WriteLine($"HP = {maxhp}/{hp}");
            Console.WriteLine($"MP = {maxmp}/{mp}");
            Console.WriteLine($"Job = \"{job}\"");
            Console.WriteLine($"Level = {lvl}");
            Console.WriteLine($"Exp = {exp}");
            Console.WriteLine($"Strength = {str}");
            Console.WriteLine($"Magic = {iq}");
            Console.WriteLine($"Gold = {gold}");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            break;
        case "7":
            Console.Clear();
            Console.WriteLine($"Congratulations {name}! You have successfully retired in one piece!");
            Console.WriteLine($"Player level: {lvl}");
            Console.WriteLine($"Monsters killed: {monkill}");
            Console.WriteLine($"Times rented the inn: {xrest}");
            Console.WriteLine($"Times ate: {xate}");
            Console.WriteLine(fatalisalive == true ? "World Boss Killed: No" : "World Boss Killed: Yes");
            Console.WriteLine($"\nThanks for playing {name}!");
            Console.ReadLine();
            chk = false;
            break;
        case "1":
            Console.Clear();
            string[] monslist = { "GOBLIN", "DEMON", "DOKIDOKI" };
            int monsindex = rand.Next(0, 3);
            string currenemy = monslist[monsindex];
            int enehp = 0;
            int enestr = 0;
            int eneiq = 0;
            int enegold = 0;
            int enexp = 0;
            string eneskill = "";
            bool battend = false;
            switch (currenemy)
            {
                case "GOBLIN":
                    enehp = 90;
                    enestr = 20;
                    eneiq = 15;
                    enegold = 100;
                    enexp = 100;
                    eneskill = "DUNG TOSS";
                    break;
                case "DEMON":
                    enehp = 80;
                    enestr = 10;
                    eneiq = 25;
                    enegold = 100;
                    enexp = 100;
                    eneskill = "FIREBALL";
                    break;
                case "DOKIDOKI":
                    enehp = 100;
                    enestr = 20;
                    eneiq = 20;
                    enegold = 150;
                    enexp = 150;
                    eneskill = "GAY KISS";
                    break;
            }
            Console.WriteLine($"You have encountered a {currenemy}!");
            do
            {
                Console.WriteLine($"\n{name} : HP - {maxhp}/{hp} | MP - {maxmp}/{mp}");
                Console.WriteLine($"{currenemy} : HP - {enehp}");
                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Cast Skill");
                Console.WriteLine("3 - Run Away");
                input = Console.ReadLine();
                switch (input)
                {
                    default:
                        Console.Clear();
                        battend = false;
                        break;
                    case "1":
                        Console.WriteLine();
                        int plydmg = rand.Next(1, (str + 1));
                        enehp -= plydmg;
                        Console.WriteLine($"{name} strikes with their weapon and deal {plydmg} damage to {currenemy}!");
                        Console.WriteLine($"{currenemy} has {enehp} HP left.");
                        if (enehp > 0)
                        {
                            int monsdmgtype = rand.Next(0, 2);
                            int monsdmg = monsdmgtype == 0 ? rand.Next(1, (enestr + 1)) : rand.Next(14, (eneiq + 1));
                            hp -= monsdmg;
                            Console.WriteLine(monsdmgtype == 0 ? $"{currenemy} strikes with their weapon and deal {monsdmg} damage to {name}!" : $"{currenemy} uses {eneskill} to deal {monsdmg} damage to {name}!");
                            Console.WriteLine($"{name} has {hp} HP left.");
                        }
                        else
                        {
                            Console.WriteLine($"{currenemy} has been defeated. You gained {enexp} exp and {enegold} gold.");
                            exp += enexp;
                            if (exp >= 1000)
                            {
                                Console.WriteLine($"{name} has leveled up! You are level {lvl} now.");
                                exp -= 1000;
                                lvl++;
                                maxhp += 10;
                                maxmp += 10;
                                str += 2;
                                iq += 2;
                            }
                            hp += 30;
                            hp = hp > maxhp ? maxhp : (hp*1);
                            mp += 20;
                            mp = mp > maxmp ? maxmp : (mp*1);
                            gold += enegold;
                            monkill++;
                            battend = true;
                        }
                        if (hp < 0)
                        {
                            Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                            chk = false;
                            battend = true;
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        if (mp >= 20)
                        {
                            mp -= 20;
                            plydmg = rand.Next(12, (iq + 1));
                            enehp -= plydmg;
                            Console.WriteLine($"{name} uses 20 MP and uses {spell} to deal {plydmg} damage to {currenemy}!");
                            Console.WriteLine($"{currenemy} has {enehp} HP left.");
                            if (enehp > 0)
                            {
                                int monsdmgtype = rand.Next(0, 2);
                                int monsdmg = monsdmgtype == 0 ? rand.Next(1, (enestr + 1)) : rand.Next(14, (eneiq + 1));
                                hp -= monsdmg;
                                Console.WriteLine(monsdmgtype == 0 ? $"{currenemy} strikes with their weapon and deal {monsdmg} damage to {name}!" : $"{currenemy} uses {eneskill} to deal {monsdmg} damage to {name}!");
                                Console.WriteLine($"{name} has {hp} HP left.");
                            }
                            else
                            {
                                Console.WriteLine($"{currenemy} has been defeated. You gained {enexp} exp and {enegold} gold.");
                                exp += enexp;
                                if (exp >= 1000)
                                {
                                    exp -= 1000;
                                    lvl++;
                                    maxhp += 10;
                                    maxmp += 10;
                                    str += 2;
                                    iq += 2;
                                }
                                hp += 20;
                                hp = hp > maxhp ? maxhp : (hp*1);
                                mp += 10;
                                mp = mp > maxmp ? maxmp : (mp*1);
                                gold += enegold;
                                monkill++;
                                battend = true;
                            }
                            if (hp < 0)
                            {
                                Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                                chk = false;
                                battend = true;
                            }
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Need 20 MP to cast a skill.\nYou have {mp} current MP.");
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine($"{name} chose to run away! {name} dropped some gold from running.\nPress Enter to continue.");
                        gold -= 100;
                        gold = gold < 0 ? 0 : (gold*1);
                        battend = true;
                        Console.ReadLine();
                        break;     
                }
            } while (battend == false);
            break;
                
                


        

    }
} while (chk == true);
