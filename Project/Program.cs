using Project;
using System.ComponentModel.Design;
using System.Runtime.ExceptionServices;

var directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
var inventoryPath = Path.Combine(directory, "Inventory.txt");
var characterPath = Path.Combine(directory, "Character.txt");

Inventory inventory = new Inventory();
Character character = new Character();
Village village = new Village();
Monster monster = new Monster();
Random random = new Random();

//Check is there any save. If not create a new one
bool inventoryCheck = false;
bool characterCheck = false;

if (File.Exists(inventoryPath))
{
    inventoryCheck = true;
}
if (File.Exists(characterPath))
{
    characterCheck = true;
}

if (inventoryCheck && characterCheck)
{
    Console.WriteLine("Save loading... \n");
    Loading();
}
else
{
    Console.WriteLine("Save not found... \n \n");
    Console.WriteLine("Welcome! What should I call you? \n");
    character.name = Console.ReadLine();

    Saving();
}

//Game Start
while (true)
{
    //Main Menu
    Console.Clear();
    character.health = character.maxHealth;
    Saving();

    //Level Up
    while (character.experience >= character.maxExperience)
    {
        Console.WriteLine("Congratulations! You gained a new level \nYou feel stronger now");
        Console.ReadLine();
        Console.Clear();
        character.level++;
        character.experience -= character.maxExperience;
        Saving();
    }

    Console.WriteLine(" " + character.name + "\n Level: " + character.level + "\n");
    Console.WriteLine(" [1] Character \n [2] Inventory \n [3] Village \n [4] Adventure \n [5] Exit \n");
    var desicion = Console.ReadLine();

    //Character Screen
    if (desicion == "1")
    {
        Console.Clear();
        Console.WriteLine(" Character Name:  {0} \n Character Level: {1} \n Character Experience: {2}/{3} \n Character Health: {4} \n Character Attack: {5} \n Character Defence: {6} \n",
            character.name, character.level, character.maxExperience, character.experience, character.health, character.attack, character.defence);
        Console.ReadLine();
    }

    //Inventory Screen
    else if (desicion == "2")
    {
        Console.Clear();
        Console.WriteLine(" Money: {0} \n Food: {1} \n Water: {2} \n Wood: {3} \n Stone: {4} \n Sand: {5} \n Iron: {6} \n Artifact: {7} \n Slime Ball: {8} \n Primitive Knife: {9} \n Wolf Hide: {10} \n Alpha Wolf Fang: {11}",
            inventory.money, inventory.food, inventory.water, inventory.wood, inventory.stone, inventory.sand, inventory.iron, inventory.artifact, inventory.slimeBall, inventory.primitiveKnife, inventory.wolfHide, inventory.alphaWolfFang);
        Console.ReadLine();
    }

    //Village Screen
    else if (desicion == "3")
    {
        Console.Clear();
        Console.WriteLine(" " +
            "[1] Manor      L: " + village.manorLevel + "\n " +
            "[2] House      L: " + village.houseLevel + "\n " +
            "[3] Farm       L: " + village.farmLevel + "\n " +
            "[4] Well       L: " + village.wellLevel + "\n " +
            "[5] WoodCutter L: " + village.woodcutterLevel + "\n " +
            "[6] StoneMine  L: " + village.stonemineLevel + "\n " +
            "[7] Market     L: " + village.marketLevel + " \n \n " +
            "[Anything Else] Main Menu");
        var villageDesicion = Console.ReadLine();

        if (villageDesicion == "1")
        {
            Console.Clear();
            Console.WriteLine(" Manor " + " Level: " + village.manorLevel + "\n " + village.manorDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "2")
        {
            Console.Clear();
            Console.WriteLine(" House " + "Level: " + village.houseLevel + "\n" + village.houseDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "3")
        {
            Console.Clear();
            Console.WriteLine(" Farm " + "Level: " + village.farmLevel + "\n" + village.farmDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "4")
        {
            Console.Clear();
            Console.WriteLine(" Well " + " Level: " + village.wellLevel + "\n" + village.wellDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "5")
        {
            Console.Clear();
            Console.WriteLine(" Woodcutter " + "Level: " + village.woodcutterLevel + "\n" + village.woodcutterDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "6")
        {
            Console.Clear();
            Console.WriteLine(" Stone Mine " + "Level: " + village.stonemineLevel + "\n" + village.stonemineDescription);
            Console.ReadLine();
        }
        else if (villageDesicion == "7")
        {
            Console.Clear();
            Console.WriteLine(" Market " + "Level: " + village.marketLevel + "\n" + village.marketDescription);
        }
    }

    //Adventure Screen
    else if (desicion == "4")
    {
        Console.Clear();
        Console.WriteLine("Where you want to go? \n" +
            " [1] Forest \n" +
            " [2] Shoreline \n" +
            " [3] Mines \n" +
            " [4] Dungeons \n" +
            " [Anything Else] Return \n");
        var adventureDesicion = Console.ReadLine();

        //Forest
        if (adventureDesicion == "1")
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Forest \n" +
                    " [1] Collect Wood \n" +
                    " [2] Collect Food \n" +
                    " [3] Find monster \n" +
                    " [4] Return \n");
                var forestDesicion = Console.ReadLine();

                //Collecting Wood
                if (forestDesicion == "1")
                {
                    int luck = random.Next(0, 10);

                    //Collect wood
                    if (luck <= 4)
                    {
                        inventory.wood += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} wood! \n", luck);
                        Console.ReadLine();
                    }

                    //Battle
                    else
                        Battle();
                }

                //Collecting Food
                else if (forestDesicion == "2")
                {
                    //Collect Food
                    int luck = random.Next(0, 10);
                    if (luck <= 4)
                    {
                        inventory.food += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} food! \n", luck);
                        Console.ReadLine();
                    }

                    //Battle
                    else
                        Battle();
                }

                //Search for Monster
                else if (forestDesicion == "3")
                    Battle();

                //Return to Adventure Screen
                else if (forestDesicion == "4")
                    break;
            }
        }

        //Shoreline
        else if (adventureDesicion == "2")
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ShoreLiine \n" +
                    " [1] Collect stone \n" +
                    " [2] Collect sand \n" +
                    " [3] Find monster \n" +
                    " [4] Return \n");
                var shoreLineDesicion = Console.ReadLine();

                // Collecting Stone
                if (shoreLineDesicion == "1")
                {
                    int luck = random.Next(0, 10);
                    if (luck <= 4)
                    {
                        inventory.stone += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} stone!", luck);
                        Console.ReadLine();
                    }
                 // Battle
                    else
                        Battle();
                }

                //Collecting Sand
                if (shoreLineDesicion == "2")
                {
                    int luck = random.Next(0, 10);
                    if (luck <= 4)
                    {
                        inventory.sand += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} sand!", luck);
                        Console.ReadLine();
                    }
                 //Battle
                    else
                        Battle();
                }

                //Search for Monster
                if (shoreLineDesicion == "3")
                    Battle();

                //Return to Adventure Screen
                if (shoreLineDesicion == "4")
                    break;
            }
        }

        //Mines
        else if (adventureDesicion == "3")
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Mines \n" +
                    " [1] Collect stone \n" +
                    " [2] Collect iron \n" +
                    " [3] Find monster \n" +
                    " [4] Return \n");
                var minesDesicion = Console.ReadLine();

                // Collecting Stone
                if (minesDesicion == "1")
                {
                    int luck = random.Next(0, 10);
                    if (luck <= 4)
                    {
                        inventory.stone += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} stone!", luck);
                        Console.ReadLine();
                    }
                    // Battle
                    else
                        Battle();
                }

                //Collecting Iron
                if (minesDesicion == "2")
                {
                    int luck = random.Next(0, 10);
                    if (luck <= 4)
                    {
                        inventory.iron += luck;
                        Console.Clear();
                        Console.WriteLine("You found {0} iron!", luck);
                        Console.ReadLine();
                    }
                    //Battle
                    else
                        Battle();
                }

                //Search for Monster
                if (minesDesicion == "3")
                    Battle();

                //Return to Adventure Screen
                if (minesDesicion == "4")
                    break;
            }
        }

        //Dungeons
        else if (adventureDesicion == "4")
        {
            while(true)
            {
                Console.Clear();
                Console.WriteLine("Dungeons \n " +
                    " [1] Explore \n" +
                    " [2] Return");
                var dungeonDesicion = Console.ReadLine();

                //Explore dungeon
                if (dungeonDesicion == "1")
                {
                    int luck = random.Next(0, 20);
                    // Finds artifact               Chance 1/21
                    if (luck == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Congratulations you found an artifact!");
                        inventory.artifact++;
                        Console.ReadLine();
                    }
                    // Finds money                  Chance 5/21
                    else if (luck <= 5)
                    {
                        Console.Clear();
                        inventory.money += luck * 3;
                        Console.WriteLine("You found {0} money", luck * 3);
                        Console.ReadLine();
                    }
                    // Finds nothing                Chance 5/21
                    else if (luck <= 10)
                    {
                        Console.Clear();
                        Console.WriteLine("The corridors going deeper and deeper");
                        Console.ReadLine();
                    }       
                    // Finds Monster                Chance 10/21
                    else if (luck <= 20)
                        Battle();
                }

                //Return
                else if (dungeonDesicion == "2")
                    break;
            }
        }
    }

    //Exit
    else if (desicion == "5")
    {
        Console.Clear();
        Console.WriteLine("See you later...");
        Environment.Exit(0);
    }

}


void Saving()
{
    string food = ("Food " + inventory.food + " ").ToString();
    string water = ("Water " + inventory.water + " ").ToString();
    string money = ("Money " + inventory.money + " ").ToString();
    string wood = ("Wood " + inventory.wood + " ").ToString();
    string stone = ("Stone " + inventory.stone + " ").ToString();
    string sand = ("Sand " + inventory.sand + " ").ToString();
    string iron = ("Iron " + inventory.iron + " ").ToString(); 
    string artifact = ("Artifact " + inventory.artifact + " ").ToString();
    string slimeBall = ("SlimeBall " + inventory.slimeBall + " ").ToString();
    string primitiveKnife = ("PrimitiveKnife " + inventory.primitiveKnife + " ").ToString();
    string wolfHide = ("WolfHide " + inventory.wolfHide + " ").ToString();
    string alphaWolfFang = ("AlphaWolfFang " + inventory.alphaWolfFang + " ").ToString();

    string inventoryOutput = food + "\n" + water + "\n" + money + "\n" + wood + "\n" + stone + "\n" + sand + "\n" + iron + "\n" + artifact + "\n" + slimeBall + "\n" + primitiveKnife + "\n" + wolfHide + "\n" + alphaWolfFang;

    File.WriteAllText(inventoryPath, inventoryOutput);

    string name = ("Name " + character.name + " ").ToString();
    string level = ("Level " + character.level + " ").ToString();
    string experience = ("Experience " + character.experience + " ").ToString();

    string characterOutput = name + "\n" + level + "\n" + experience;

    File.WriteAllText(characterPath, characterOutput);
}
void Loading()
{
    string inventoryInput = File.ReadAllText(inventoryPath);

    int food = Convert.ToInt32(inventoryInput.Split(' ')[1]);
    int water = Convert.ToInt32(inventoryInput.Split(' ')[3]);
    int money = Convert.ToInt32(inventoryInput.Split(' ')[5]);
    int wood = Convert.ToInt32(inventoryInput.Split(' ')[7]);
    int stone = Convert.ToInt32(inventoryInput.Split(' ')[9]);
    int sand = Convert.ToInt32(inventoryInput.Split(' ')[11]);
    int iron = Convert.ToInt32(inventoryInput.Split(' ')[13]);
    int artifact = Convert.ToInt32(inventoryInput.Split(' ')[15]);
    int slimeBall = Convert.ToInt32(inventoryInput.Split(' ')[17]);
    int primitiveKnife = Convert.ToInt32(inventoryInput.Split(' ')[19]);
    int wolfHide = Convert.ToInt32(inventoryInput.Split(' ')[21]);
    int alphaWolfFang = Convert.ToInt32(inventoryInput.Split(' ')[23]);

    inventory.food = food;
    inventory.water = water;
    inventory.money = money;
    inventory.wood = wood;
    inventory.stone = stone;
    inventory.sand = sand;
    inventory.iron = iron;
    inventory.artifact = artifact;
    inventory.slimeBall = slimeBall;
    inventory.primitiveKnife = primitiveKnife;
    inventory.wolfHide = wolfHide;
    inventory.alphaWolfFang = alphaWolfFang;

    string characterInput = File.ReadAllText(characterPath);

    string name = characterInput.Split(" ")[1];
    int level = Convert.ToInt32(characterInput.Split(" ")[3]);
    double experience = Convert.ToDouble(characterInput.Split(" ")[5]);

    character.name = name;
    character.level = level;
    character.experience = experience;
}
void MonsterCreater()
{
    int num = random.Next(0, 10);
    int level = random.Next(character.level - 2, character.level + 2);
    if (level <= 0)
        level = 1;

    if (num <= 3)
    {
        monster.Slime(level);
    }
    else if (num <= 6)
    {
        monster.Goblin(level);
    }
    else if (num <= 8)
    {
        monster.Wolf(level);
    }
    else if (num == 9)
    {
        monster.AlphaWolf(level);
    }
}
void Battle()
{
    Console.Clear();
    MonsterCreater();

    int turn = 0;

    int defenceCooldown = 0;
    bool isDefenceCoolDown = false;
    int monsterDefence = 0;
    bool isMonsterDefence = false;
    int monsterSpecial = 0;
    bool isMonsterSpecial = false;

    int sentence = random.Next(0, 3);

    if (sentence == 0)
        Console.WriteLine(monster.name + " decided to found you, but your desicions are yours...");
    else if (sentence == 1)
        Console.WriteLine(monster.name + " looks cute but its behaviors are not");
    else if (sentence == 2)
        Console.WriteLine("Looking into " + monster.name + "'s eyes... What now?");

    //Battle start
    while (true)
    {
        // is Monster or Character  dead?

        if (monster.health <= 0)
        {
            Console.WriteLine("Congratulations! You defeated " + monster.name + " (" + monster.level + " Level) \n");
            character.health = character.maxHealth;
            int luck = random.Next(1, 3);
            if (monster.index == 1)
            {
                inventory.slimeBall += luck;
                inventory.money += luck * 2;
                character.experience += monster.level * 2;

                Console.WriteLine(" Slime Ball +" + luck +
                    "\n Money +" + luck * 2 +
                    "\n Experience +" + monster.level * 2);
            }
            else if (monster.index == 2)
            {
                inventory.primitiveKnife += luck;
                inventory.money += luck * 3;
                character.experience += monster.level * 2.5;

                Console.WriteLine(" Primitive Knife +" + luck +
                    "\n Money +" + luck * 3 +
                    "\n Experience +" + monster.level * 2.5);
            }
            else if (monster.index == 3)
            {
                inventory.wolfHide += luck;
                inventory.money += luck * 4;
                character.experience += monster.level * 3;

                Console.WriteLine(" Wolf Hide +" + luck +
                    "\n Money +" + luck * 4 +
                    "\n Experience +" + monster.level * 3);
            }
            else if (monster.index == 4)
            {
                inventory.alphaWolfFang += luck - 1;
                inventory.wolfHide += luck;
                inventory.money += luck * 5;
                character.experience += monster.level * 5;

                Console.WriteLine(" Alpha Wolf Fang +" + (luck - 1) +
                    "\n Wolf Hide +" + luck +
                    "\n Money +" + luck * 5 +
                    "\n Experience +" + monster.level * 5);
            }
            Saving();
            Console.ReadLine();
            break;
        }
        if (character.health <= 0)
        {
            Console.WriteLine("Looks like you lost the battle...");
            Saving();
            Console.ReadLine();

            break;
        }


        // Turn increase and cooldown check

        turn++;

        if (isMonsterSpecial && monsterSpecial > 0)
            monsterSpecial--;
        if (monsterSpecial == 0 && isMonsterSpecial)
        {
            isMonsterSpecial = false;
            Console.WriteLine("Monster looks weaker than before. (All stats decreased)");
            if (monster.index == 1)
            {
                monster.attack -= 2 * monster.level;
                monster.defence -= 1 * monster.level;
                monsterSpecial -= 3;
            }
            else if (monster.index == 2)
            {
                monster.attack -= 4 * monster.level;
                monster.defence -= 2 * monster.level;
                monsterSpecial -= 3;
            }
            else if (monster.index == 3)
            {
                monster.attack -= 5 * monster.level;
                monster.defence -= 3 * monster.level;
                monsterSpecial -= 3;
            }
            else if (monster.index == 4)
            {
                monster.attack -= 6 * monster.level;
                monster.defence -= 5 * monster.level;
                monsterSpecial -= 3;
            }
        }

        if (isMonsterDefence && monsterDefence > 0)
            monsterDefence--;
        if (monsterDefence == 0 && isMonsterDefence)
        {
            isMonsterDefence = false;
            monster.defence -= 3 * monster.level;
            Console.WriteLine(monster.name + "looks weaker than before. (Defence decreased");
        }

        if (isDefenceCoolDown && defenceCooldown > 0)
            defenceCooldown--;
        if (defenceCooldown == 0 && isDefenceCoolDown)
        {
            Console.WriteLine("You no longer feel tough");
            character.defence -= 10 * character.level;
            isDefenceCoolDown = false;
        }

        // Battle Info and actions

        Console.WriteLine("Turn: " + turn + "\n");

        Console.WriteLine(" " + monster.name + " (" + monster.level + ")\n" +
            " Health: " + monster.maxHealth + "/" + monster.health + "\n \n");

        Console.WriteLine(" " + character.name + " (" + character.level + ")\n" +
            " Heatlh: " + character.maxHealth + "/" + character.health + "\n" +
            " Attack: " + character.attack + " Defence: " + character.defence + "\n");

        Console.WriteLine(" Your action? \n" +
            " [1] Attack \n" +
            " [2] Defend \n" +
            " [3] Flee \n");

        // Character actions

        while (true)
        {
            var action = Console.ReadLine();

            //Character Attack
            if (action == "1")
            {
                Console.Clear();
                int characterDamage = character.attack - monster.defence;
                if (characterDamage > 0)
                {
                    Console.WriteLine(monster.name + " received " + characterDamage + " damage.");
                    monster.health -= characterDamage;
                }
                else
                {
                    Console.WriteLine(monster.name + "is tougher than you think. (0 damage)");
                }
                break;
            }

            //Character Defence
            else if (action == "2")
            {
                Console.Clear();
                if (defenceCooldown != 0)
                {
                    Console.WriteLine("You can't use this action. (wait {0} turn) \n", defenceCooldown);
                    Console.WriteLine(" Your action? \n" +
                        " [1] Attack \n" +
                        " [2] Defend \n" +
                        " [3] Flee \n");
                }
                    
                else
                {
                    Console.WriteLine("you feel tougher than before. (+{0} Defence)", 10 * character.level);
                    character.defence += 10 * character.level;
                    defenceCooldown += 3;
                    isDefenceCoolDown = true;
                    break;
                }
            }

            //Character Flee
            else if (action == "3")
            {
                Console.Clear();
                int flee = random.Next(1, 5);
                if (flee == 1)
                {
                    Console.WriteLine("You escaped successfully...");      //Chance: 1/4
                    break;
                }
                else
                    Console.WriteLine("You failed to escape...");
            }
        }

        // Monster actions

        int monsterDamage;
        int roll = random.Next(1, 11);

        // Monster Normal attack            Chance: 7/10
        if (roll <= 7)
        {
            monsterDamage = monster.attack - character.defence;
            if (monsterDamage <= 0)
                Console.WriteLine("Monster didn't hurt you at all.");
            else
            {
                character.health -= monsterDamage;
                Console.WriteLine("You received " + monsterDamage + " damage.");
            }
        }

        //Monster Defend                    Chance: 2/10
        else if (roll <= 9)
        {
            monster.defence += 3 * monster.level;
            monsterDefence += 2;
            isMonsterDefence = true;
            Console.WriteLine(monster.name + "looks tougher than before");
        }

        //Monster Special Ability           Chance: 1/10
        else
        {
            Console.WriteLine("Looks like " + monster.name + " feels stronger.");
            isMonsterSpecial = true;
            monsterSpecial += 3;
            if (monster.index == 1)
            {
                monster.health += 5 * monster.level;
                monster.attack += 2 * monster.level;
                monster.defence += 1 * monster.level;
            }
            else if (monster.index == 2)
            {
                monster.attack += 4 * monster.level;
                monster.defence += 2 * monster.level;
            }
            else if (monster.index == 3)
            {
                monster.attack += 5 * monster.level;
                monster.defence += 3 * monster.level;
            }
            else if (monster.index == 4)
            {
                monster.health += 6 * monster.level;
                monster.attack += 6 * monster.level;
                monster.defence += 5 * monster.level;
            }
        }
    }
}
