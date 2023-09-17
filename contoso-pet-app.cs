using System.ComponentModel.Design;
using System.Transactions;

string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";

int maxPets = 8;

string[,] ourAnimals = new string[maxPets, 6];

for (int i = 0; i < maxPets; i++)
{
    if (i == 0)
    {
        animalSpecies = "dog";
        animalID = "d1";
        animalAge = "2";
        animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
        animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
        animalNickname = "Lola";
    }
    else if (i == 1)
    {
        animalSpecies = "dog";
        animalID = "d2";
        animalAge = "9";
        animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
        animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
        animalNickname = "Loki";
    }
    else if (i == 2)
    {
        animalSpecies = "cat";
        animalID = "c3";
        animalAge = "1";
        animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
        animalPersonalityDescription = "friendly";
        animalNickname = "Puss";
    }
    else if (i == 3)
    {
        animalSpecies = "cat";
        animalID = "c4";
        animalAge = "2";
        animalPhysicalDescription = "small white male";
        animalPersonalityDescription = "quiet";
        animalNickname = "Totomojang";
    }
    else
    {
        animalSpecies = "";
        animalID = "";
        animalAge = "";
        animalPhysicalDescription = "";
        animalPersonalityDescription = "";
        animalNickname = "";
    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
}

string? readResult;
string menuSelection = "";
int petnums = 0;
for (int i = 0; i < maxPets; i++)
{
    if (ourAnimals[i, 0] != "ID #: ") petnums++;
}
do
{
    Console.Clear();

    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number or type Exit to exit the program");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 6; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
            break;
        case "2":
            if (petnums >= maxPets)
            {
                Console.WriteLine($"Sorry, can't add any more pets. There's {petnums}/{maxPets} in the home.");
                Console.ReadLine();
                break;
            }
            string go = "";
            do
            {
                Console.WriteLine();
                string species = "";
                do
                {
                    Console.WriteLine("Enter \"dog\" or \"cat\".");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        try
                        {
                            species = readResult.ToLower();
                        }
                        catch
                        {
                            species = "kiryu";
                        }
                    }
                } while ((species != "dog") && (species != "cat"));
                animalSpecies = species;
                animalID = species.Substring(0, 1) + (petnums + 1).ToString();
                bool xz = false;
                do
                {
                    int age = 0;
                    Console.WriteLine("Enter the pet's age. Enter \"?\" if unknown.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        if (readResult != "?")
                        {
                            try
                            {
                                age = int.Parse(readResult);
                                animalAge = age.ToString();
                                xz = true;
                            }
                            catch
                            {
                                xz = false;
                            }
                        }
                        else
                        {
                            animalAge = readResult;
                            xz = true;
                        }
                    }
                } while (xz == false);
                xz = false;
                do
                {
                    Console.WriteLine("Enter pet's nickname. Leave blank if no nickname.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        if (readResult == "" || readResult == " ")
                        {
                            animalNickname = "TBD";
                            xz = true;
                        }
                        else
                        {
                            animalNickname = readResult;
                            xz = true;
                        }
                    }
                } while (xz == false);
                xz = false;
                do
                {
                    Console.WriteLine("Enter pet's physical description. Leave blank if unknown.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        if (readResult == "" || readResult == " ")
                        {
                            animalPhysicalDescription = "TBD";
                            xz = true;
                        }
                        else
                        {
                            animalPhysicalDescription = readResult;
                            xz = true;
                        }
                    } 
                } while (xz == false);
                xz = false;
                do
                {
                    Console.WriteLine("Enter pet's personality traits or leave blank if unknown.");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                        if (readResult == "" || readResult == " ")
                        {
                            animalPersonalityDescription = "TBD";
                            xz = true;
                        }
                        else
                        {
                            animalPersonalityDescription = readResult;
                            xz = true;
                        }
                } while (xz == false);

                petnums++;
                ourAnimals[(petnums - 1), 0] = "ID #: " + animalID;
                ourAnimals[(petnums - 1), 1] = "Species: " + animalSpecies;
                ourAnimals[(petnums - 1), 2] = "Age: " + animalAge;
                ourAnimals[(petnums - 1), 3] = "Nickname: " + animalNickname;
                ourAnimals[(petnums -1), 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[(petnums -1), 5] = "Personality: " + animalPersonalityDescription;
                if (petnums < maxPets)
                {
                    do
                    {
                        Console.WriteLine($"There's space for {maxPets - petnums} pets left in the home. Enroll another pet? \"Y\"/\"N\"");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            try
                            {
                                go = readResult.ToLower();
                            }
                            catch
                            {
                                continue;
                            }
                        }

                    } while ((go != "y") && (go != "n"));
                }
                else
                {
                    Console.WriteLine("\nOur pethouse is currently full. Press Enter to continue.");
                    Console.ReadLine();
                }


            } while ((petnums < maxPets) && (go == "y"));
            break;
        case "3":
            for (int i = 0; i < petnums; i++)
            {
                bool xz = false;
                int age;
                if (ourAnimals[i, 2] == "Age: ?")
                {
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 1].Substring(9)} {ourAnimals[i, 0].Substring(6)} :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            if (readResult != "" && readResult != "?" && readResult != " ")
                            {
                                try
                                {
                                    age = int.Parse(readResult);
                                    animalAge = age.ToString();
                                    ourAnimals[i, 2] = "Age: " + animalAge;
                                    xz = true;
                                }
                                catch
                                {
                                    xz = false;
                                }
                                }
                            }

                        } while (xz == false);
                }
                if (ourAnimals[i, 4] == "Physical description: TBD")
                {
                    do
                    {
                        xz = false;
                        Console.WriteLine($"Enter physical description for {ourAnimals[i, 1].Substring(9)} {ourAnimals[i, 0].Substring(6)} :");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            if (readResult != "" && readResult != " ")
                            {
                                animalPhysicalDescription = readResult;
                                ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                                xz = true;
                            }
                        }

                    } while (xz == false);
                }
            }
            Console.WriteLine("\nOur animals all have age and physical descriptive data. Press Enter to continue.");
            Console.ReadLine();
            break;
        case "4":
            for (int i = 0; i < petnums; i++)
            {
                bool xz = false;
                if (ourAnimals[i, 3] == "Nickname: TBD")
                {
                    Console.WriteLine();
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 1].Substring(9)} {ourAnimals[i, 0].Substring(6)}:");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            if (readResult != "" && readResult != " ")
                            {
                                animalNickname = readResult;
                                ourAnimals[i, 3] = "Nickname: " + animalNickname;
                                xz = true;
                            }
                        }

                    } while (xz == false);
                }
                if (ourAnimals[i, 5] == "Personality: TBD")
                {
                    do
                    {
                        xz = false;
                        Console.WriteLine($"Enter {ourAnimals[i, 1].Substring(9)} {ourAnimals[i, 0].Substring(6)} personality:");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            if (readResult != "" && readResult != " ")
                            {
                                animalPersonalityDescription = readResult;
                                ourAnimals[i, 5] = "Physical description: " + animalPersonalityDescription;
                                xz = true;
                            }
                        }

                    } while (xz == false);
                }
            }
            Console.WriteLine("\nOur animals all have nicknames and personality data. Press Enter to continue.");
            Console.ReadLine();
            break;
        case "5":
            bool fz = false;
            bool cz = false;
            do
            {
                Console.WriteLine("Enter animal ID of animal whose age you want changed:");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    string inp;
                    try
                    {
                        inp = readResult.ToLower();
                    }
                    catch
                    {
                        continue;
                    }
                    for (int i = 0; i < petnums; i++)
                    {
                        if (inp == ourAnimals[i, 0].Substring(6))
                        {
                            do
                            {
                                int age = 0;
                                Console.WriteLine("Enter the pet's age.");
                                readResult = Console.ReadLine();
                                if (readResult != null)
                                {
                                    if (readResult != "" && readResult != " ")
                                    {
                                        try
                                        {
                                            age = int.Parse(readResult);
                                            animalAge = age.ToString();
                                            ourAnimals[i, 2] = "Age: " + animalAge;
                                            Console.WriteLine($"Pet {ourAnimals[i, 0].Substring(6)} age has been changed.");
                                            do
                                            {
                                                Console.WriteLine("Do you wanna change another pet's age? \"y\"/\"n\"");
                                                readResult = Console.ReadLine();
                                                try
                                                {
                                                    inp = readResult.ToLower();
                                                    fz = inp == "y" ? false : true;
                                                    cz = true;
                                                }
                                                catch
                                                {
                                                    continue;
                                                }

                                            } while (inp != "y" && inp != "n");
                                        }
                                        catch
                                        {
                                            cz = false;
                                        }
                                    }
                                }
                            } while (cz == false);
                        }
                    }
                }
            } while (fz == false);
            break;



    }
} while (menuSelection != "exit");
