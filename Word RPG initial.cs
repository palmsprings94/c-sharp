using System.Net;
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
int expthresh = 500;
int lvl = 1;
int gold = 500;
string job;
string spell = "";
int monkill = 0;
int xrest = 0;
int xate = 0;
int xboss = 0;
bool chk;
bool owh;
do
{
    chk = false;
    Console.Clear();
    Console.WriteLine("Enter player name: (No spaces allowed)");
    input = Console.ReadLine();
    name = input.ToUpper();
    if (input != null && input != "" && !input.Contains(" ")) chk = true;
} while (chk == false);

do
{
    Console.Clear();
    Console.WriteLine($"Welcome to Word RPG {name}! Press the corresponding numbers to make a choice.\n");
    Console.WriteLine("Choose a job:\n");
    Console.WriteLine("1 - Swordsman");
    Console.WriteLine("2 - Spellcaster");
    input = Console.ReadLine();
    job = "";
    switch (input)
    {
        case "1":
            job = "Swordsman";
            maxhp = 450;
            maxmp = 100;
            hp = 450;
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
            maxhp = 300;
            maxmp = 250;
            hp = 300;
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
    Console.WriteLine("What do you want to do?\n");
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
                    enehp = 120;
                    enestr = 30;
                    eneiq = 25;
                    enegold = 100;
                    enexp = 150;
                    eneskill = "DUNG TOSS";
                    break;
                case "DEMON":
                    enehp = 110;
                    enestr = 20;
                    eneiq = 35;
                    enegold = 100;
                    enexp = 150;
                    eneskill = "FIREBALL";
                    break;
                case "DOKIDOKI":
                    enehp = 200;
                    enestr = 30;
                    eneiq = 30;
                    enegold = 150;
                    enexp = 210;
                    eneskill = "JUMPOTRON";
                    break;
            }
            do
            {
                Console.Clear();
                Console.WriteLine($"You have encountered a {currenemy}!\n");
                Console.WriteLine($"{name} : HP = {hp}/{maxhp} | MP = {mp}/{maxmp}");
                Console.WriteLine($"{currenemy} : HP = {enehp}\n");
                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Cast Skill");
                Console.WriteLine("3 - Run Away");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        int plydmg = rand.Next(1, (str + 1));
                        enehp -= plydmg;
                        enehp = enehp < 0 ? 0 : enehp * 1;
                        Console.WriteLine($"{name} strikes with their weapon and deal {plydmg} damage to {currenemy}!");
                        Console.WriteLine($"{currenemy} has {enehp} HP left.");
                        if (enehp > 0)
                        {
                            int monsdmgtype = rand.Next(0, 2);
                            int monsdmg = monsdmgtype == 0 ? rand.Next(1, (enestr + 1)) : rand.Next(Convert.ToInt32(eneiq * 0.5), (eneiq + 1));
                            hp -= monsdmg;
                            hp = hp < 0 ? 0 : hp * 1;
                            Console.WriteLine(monsdmgtype == 0 ? $"{currenemy} strikes with their weapon and deals {monsdmg} damage to {name}!" : $"{currenemy} uses {eneskill} to deal {monsdmg} damage to {name}!");
                            Console.WriteLine($"{name} has {hp} HP left.");
                        }
                        else
                        {
                            Console.WriteLine($"{currenemy} has been defeated. You gained {enexp} exp and {enegold} gold.");
                            exp += enexp;
                            if (exp >= expthresh)
                            {
                                lvl++;
                                Console.WriteLine($"{name} has leveled up! You are level {lvl} now.");
                                exp -= expthresh;
                                expthresh += 100;
                                maxhp += 10;
                                maxmp += 10;
                                str += 4;
                                iq += 4;
                            }
                            hp += Convert.ToInt32(maxhp * 0.05);
                            hp = hp > maxhp ? maxhp : (hp * 1);
                            mp += Convert.ToInt32(maxmp * 0.05);
                            mp = mp > maxmp ? maxmp : (mp * 1);
                            gold += enegold;
                            monkill++;
                            battend = true;
                        }
                        if (hp <= 0)
                        {
                            Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                            chk = false;
                            battend = true;
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        if (mp >= Convert.ToInt32(maxmp * 0.10))
                        {
                            mp -= Convert.ToInt32(maxmp * 0.10);
                            plydmg = rand.Next(Convert.ToInt32(iq * 0.5), (iq + 1));
                            enehp -= plydmg;
                            enehp = enehp < 0 ? 0 : enehp * 1;
                            Console.WriteLine($"{name} uses {Convert.ToInt32(maxmp * 0.10)} MP and uses {spell} to deal {plydmg} damage to {currenemy}!");
                            Console.WriteLine($"{currenemy} has {enehp} HP left.");
                            if (enehp > 0)
                            {
                                int monsdmgtype = rand.Next(0, 2);
                                int monsdmg = monsdmgtype == 0 ? rand.Next(1, (enestr + 1)) : rand.Next(Convert.ToInt32(eneiq * 0.5), (eneiq + 1));
                                hp -= monsdmg;
                                hp = hp < 0 ? 0 : hp * 1;
                                Console.WriteLine(monsdmgtype == 0 ? $"{currenemy} strikes with their weapon and deal {monsdmg} damage to {name}!" : $"{currenemy} uses {eneskill} to deal {monsdmg} damage to {name}!");
                                Console.WriteLine($"{name} has {hp} HP left.");
                            }
                            else
                            {
                                Console.WriteLine($"{currenemy} has been defeated. You gained {enexp} exp and {enegold} gold.");
                                exp += enexp;
                                if (exp >= expthresh)
                                {
                                    exp -= expthresh;
                                    expthresh += 100;
                                    lvl++;
                                    Console.WriteLine($"\n{name} has leveled UP! You are level {lvl} now.");
                                    maxhp += 10;
                                    maxmp += 10;
                                    str += 4;
                                    iq += 4;
                                }
                                hp += Convert.ToInt32(maxhp * 0.05);
                                hp = hp > maxhp ? maxhp : (hp * 1);
                                mp += Convert.ToInt32(maxmp * 0.05);
                                mp = mp > maxmp ? maxmp : (mp * 1);
                                gold += enegold;
                                monkill++;
                                battend = true;
                            }
                            if (hp <= 0)
                            {
                                Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                                chk = false;
                                battend = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Need {Convert.ToInt32(maxmp * 0.10)} MP to cast a skill.\nYou have {mp} current MP.");
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine();
                        Console.WriteLine($"{name} chose to run away! {name} dropped some gold from running.\nPress Enter to continue.");
                        gold -= 100;
                        gold = gold < 0 ? 0 : (gold * 1);
                        battend = true;
                        Console.ReadLine();
                        break;
                }
            } while (battend == false);
            break;
        case "2":
            Console.Clear();
            Console.WriteLine($"HP = {hp}/{maxhp}");
            Console.WriteLine($"MP = {mp}/{maxmp}");
            Console.WriteLine($"Job = {job}");
            Console.WriteLine($"Level = {lvl}");
            Console.WriteLine($"Exp = {exp}/{expthresh}");
            Console.WriteLine($"Strength = {str}");
            Console.WriteLine($"Magic = {iq}");
            Console.WriteLine($"Gold = {gold}");
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            break;
        case "3":
            owh = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to Guild Restaurant!\n");
                Console.WriteLine($"Current Gold = {gold}\n");
                Console.WriteLine("Choose a meal:\n");
                Console.WriteLine("1 - Meat Steak and Potatoes  = 300 gold");
                Console.WriteLine("2 - Vegetable Roast with Eggs  = 290 gold");
                Console.WriteLine("3 - Absinthe and Berries  = 250 gold");
                Console.WriteLine("4 - Leave the restaurant.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (gold >= 300)
                        {
                            Console.WriteLine("\nYou paid 300 gold for Meal 1!");
                            Console.WriteLine("You recovered 15% of HP and MP!");
                            Console.WriteLine("You gained 1 str point!");
                            gold -= 300;
                            xate++;
                            hp += Convert.ToInt32(maxhp * 0.15);
                            hp = hp > maxhp ? maxhp : hp * 1;
                            mp += Convert.ToInt32(maxmp * 0.15);
                            mp = mp > maxmp ? maxmp : mp * 1;
                            str++;
                            Console.WriteLine("\nPress Enter to continue.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough money.");
                            Console.WriteLine("\nPress Enter to continue");
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        if (gold >= 290)
                        {
                            Console.WriteLine("\nYou paid 290 gold for Meal 2!");
                            Console.WriteLine("You recovered 15% of HP and MP!");
                            Console.WriteLine("You gained 1 iq point!");
                            gold -= 290;
                            xate++;
                            hp += Convert.ToInt32(maxhp * 0.15);
                            hp = hp > maxhp ? maxhp : hp * 1;
                            mp += Convert.ToInt32(maxmp * 0.15);
                            mp = mp > maxmp ? maxmp : mp * 1;
                            iq++;
                            Console.WriteLine("\nPress Enter to continue.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough money.");
                            Console.WriteLine("\nPress Enter to continue");
                        }
                        Console.ReadLine();
                        break;
                    case "3":
                        if (gold >= 250)
                        {
                            Console.WriteLine("\nYou paid 250 gold for Meal 3!");
                            Console.WriteLine("You recovered 15% of HP and MP!");
                            Console.WriteLine("You gained 3 Maxhp and Maxmp!");
                            gold -= 250;
                            xate++;
                            maxhp += 3;
                            maxmp += 3;
                            hp += Convert.ToInt32(maxhp * 0.15);
                            hp = hp > maxhp ? maxhp : hp * 1;
                            mp += Convert.ToInt32(maxmp * 0.15);
                            mp = mp > maxmp ? maxmp : mp * 1;
                            Console.WriteLine("\nPress Enter to continue.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough money.");
                            Console.WriteLine("\nPress Enter to continue");
                        }
                        Console.ReadLine();
                        break;
                    case "4":
                        owh = true;
                        break;
                }
            }
            while (owh == false);
            break;
        case "4":
            owh = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"Welcome to the Traveller's Inn {name}!\n");
                Console.WriteLine($"Current Gold = {gold}\n");
                Console.WriteLine("1 - Rest for the night  = 150 gold");
                Console.WriteLine("2 - Leave the inn.");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (gold >= 150)
                        {
                            Console.WriteLine("\nYou spent 150 gold to rent the inn.");
                            Console.WriteLine("You wake up clean and refreshed!");
                            Console.WriteLine("Restored to full HP and MP!");
                            gold -= 150;
                            xrest++;
                            hp = maxhp;
                            mp = maxmp;
                            Console.WriteLine("\nPress Enter to continue.");
                            owh = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You don't have enough money to rent the inn.");
                            Console.WriteLine("\nPress Enter to continue");
                            owh = true;
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        owh = true;
                        break;
                }
            } while (owh == false);
            break;
        case "5":
            int bosshp = 1000 + (xboss * 300);
            int bossstr = 90 + (xboss * 30);
            int bossiq = 100 + (xboss * 30);
            int bossgold = 1000 + (xboss * 500);
            int bossexp = 1000 + (xboss * 600);
            string bossskill = "DEATH TOUCH";
            battend = false;
            owh = false;
            do
            {
                Console.Clear();
                Console.WriteLine("You are about to challenge World Boss Fatalis, are you sure?  (Running away is prohibited!)");
                Console.WriteLine("\n1 - Yes");
                Console.WriteLine("2 - Not yet");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        owh = true;
                        break;
                    case "2":
                        owh = true;
                        battend = true;
                        break;
                }
            } while (owh == false);
            while (!battend)
            {
                Console.Clear();
                Console.WriteLine($"You challenged FATALIS!\n");
                Console.WriteLine($"{name} : HP = {hp}/{maxhp} | MP = {mp}/{maxmp}");
                Console.WriteLine($"FATALIS : HP = {bosshp}\n");
                Console.WriteLine("1 - Attack");
                Console.WriteLine("2 - Cast Skill");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine();
                        int plydmg = rand.Next(1, (str + 1));
                        bosshp -= plydmg;
                        bosshp = bosshp < 0 ? 0 : bosshp * 1;
                        Console.WriteLine($"{name} strikes with their weapon and deal {plydmg} damage to FATALIS!");
                        Console.WriteLine($"FATALIS has {bosshp} HP left.");
                        if (bosshp > 0)
                        {
                            int monsdmgtype = rand.Next(0, 2);
                            int monsdmg = monsdmgtype == 0 ? rand.Next(1, (bossstr + 1)) : rand.Next(Convert.ToInt32(bossiq * 0.5), (bossiq + 1));
                            hp -= monsdmg;
                            hp = hp < 0 ? 0 : hp * 1;
                            Console.WriteLine(monsdmgtype == 0 ? $"FATALIS strikes with its claws and deals {monsdmg} damage to {name}!" : $"FATALIS uses {bossskill} to deal {monsdmg} damage to {name}!");
                            Console.WriteLine($"{name} has {hp} HP left.");
                        }
                        else
                        {
                            Console.WriteLine($"FATALIS has been defeated. You gained {bossexp} exp and {bossgold} gold.");
                            exp += bossexp;
                            if (exp >= expthresh)
                            {
                                while (exp >= expthresh)
                                {
                                    exp -= expthresh;
                                    lvl++;
                                    expthresh += 100;
                                    maxhp += 10;
                                    maxmp += 10;
                                    str += 4;
                                    iq += 4;
                                }
                                Console.WriteLine($"{name} has leveled up! You are level {lvl} now.");
                            }
                            hp += Convert.ToInt32(maxhp * 0.05);
                            hp = hp > maxhp ? maxhp : (hp * 1);
                            mp += Convert.ToInt32(maxmp * 0.05);
                            mp = mp > maxmp ? maxmp : (mp * 1);
                            gold += bossgold;
                            monkill++;
                            battend = true;
                        }
                        if (hp <= 0)
                        {
                            Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                            chk = false;
                            battend = true;
                        }
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine();
                        if (mp >= Convert.ToInt32(maxmp * 0.10))
                        {
                            mp -= Convert.ToInt32(maxmp * 0.10);
                            plydmg = rand.Next(Convert.ToInt32(iq * 0.5), (iq + 1));
                            bosshp -= plydmg;
                            bosshp = bosshp < 0 ? 0 : bosshp * 1;
                            Console.WriteLine($"{name} uses {Convert.ToInt32(maxmp * 0.10)} MP and uses {spell} to deal {plydmg} damage to FATALIS!");
                            Console.WriteLine($"FATALIS has {bosshp} HP left.");
                            if (bosshp > 0)
                            {
                                int monsdmgtype = rand.Next(0, 2);
                                int monsdmg = monsdmgtype == 0 ? rand.Next(1, (bossstr + 1)) : rand.Next(Convert.ToInt32(bossiq * 0.5), (bossiq + 1));
                                hp -= monsdmg;
                                hp = hp < 0 ? 0 : hp * 1;
                                Console.WriteLine(monsdmgtype == 0 ? $"FATALIS strikes with its claws and deal {monsdmg} damage to {name}!" : $"FATALIS uses {bossskill} to deal {monsdmg} damage to {name}!");
                                Console.WriteLine($"{name} has {hp} HP left.");
                            }
                            else
                            {
                                Console.WriteLine($"FATALIS has been defeated. You gained {bossexp} exp and {bossgold} gold.");
                                exp += bossexp;
                                if (exp >= expthresh)
                                {
                                    while (exp >= expthresh)
                                    {
                                        exp -= expthresh;
                                        lvl++;
                                        expthresh += 100;
                                        maxhp += 10;
                                        maxmp += 10;
                                        str += 4;
                                        iq += 4;
                                    }
                                    Console.WriteLine($"{name} has leveled up! You are level {lvl} now.");
                                }
                                hp += Convert.ToInt32(maxhp * 0.05);
                                hp = hp > maxhp ? maxhp : (hp * 1);
                                mp += Convert.ToInt32(maxmp * 0.05);
                                mp = mp > maxmp ? maxmp : (mp * 1);
                                gold += bossgold;
                                monkill++;
                                battend = true;
                            }
                            if (hp <= 0)
                            {
                                Console.WriteLine($"\n{name} has been slain!\nPress Enter to exit.");
                                chk = false;
                                battend = true;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Need {Convert.ToInt32(maxmp * 0.10)} MP to cast a skill.\nYou have {mp} current MP.");
                        }
                        Console.ReadLine();
                        break;
                }
            }
            break;
        case "6":
            owh = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"Would you like to train? (Training costs {Convert.ToInt32(maxhp * .12)} HP)");
                Console.WriteLine($"Your current HP is {hp}.");
                Console.WriteLine("\n1 - Yes");
                Console.WriteLine("2 - No");
                input = Console.ReadLine();
                if (input == "1")
                {
                    if (hp > Convert.ToInt32(maxhp * .12))
                    {
                        hp -= Convert.ToInt32(maxhp * .12);
                        exp += Convert.ToInt32(expthresh * 0.2);
                        Console.WriteLine($"\nYou trained successfully! Gained {Convert.ToInt32(expthresh * 0.2)} exp!");
                        if (exp >= expthresh)
                        {
                            lvl++;
                            Console.WriteLine($"{name} has leveled up! You are level {lvl} now.");
                            exp -= expthresh;
                            expthresh += 100;
                            maxhp += 10;
                            maxmp += 10;
                            str += 4;
                            iq += 4;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not enough HP to train. Press enter to continue.");
                        owh = true;
                    }
                    Console.ReadLine();
                }
                else if (input == "2") owh = true;
            } while (owh == false);
            break;
        case "7":
            Console.Clear();
            Console.WriteLine($"Congratulations {name}! You have successfully retired in one piece!\n");
            Console.WriteLine($"Player level: {lvl}");
            Console.WriteLine($"Monsters killed: {monkill}");
            Console.WriteLine($"Times rented the inn: {xrest}");
            Console.WriteLine($"Times ate: {xate}");
            Console.WriteLine($"Times killed World Boss: {xboss}");
            Console.WriteLine($"\nThanks for playing {name}!");
            Console.ReadLine();
            chk = false;
            break;
    }
} while (chk == true);
