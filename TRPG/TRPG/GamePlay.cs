using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    class GamePlay
    {
        public static bool rested = false;
        public static bool shoesCrafted = false;
        public static bool glovesCrafted = false;
        public static bool swordCrafted = false;
        public static bool leggingsCrafted = false;
        public static bool chestplateCrafted = false;
        public static bool helmetCrafted = false;

        public static void Name()
        {
            //hier word de speler naar zijn naam gevraagd en word opgeslagen tot je stopt met spelen.
            Console.WriteLine("What is your name?");
            Player.name = Console.ReadLine().ToLower();
            NameConfirmation();
        }

        public static void NameConfirmation()
        {
            //hier krijg je de vraag of je eker weet dat je zo wil heten of dat je toch een andere naam wil.
            string choice;

            Console.WriteLine("So your name is " + Player.name + "?");
            Console.WriteLine("(A)Yes (B)No");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    Console.Clear();
                    CreateNewGame();
                    break;

                case "b":
                    Name();
                    break;

                default:
                    Console.WriteLine("you need to choose an option.");
                    NameConfirmation();
                    break;
            }
        }

        public static void CreateNewGame()
        {
            //hier kies je welke ras je wil zijn. elke ras heeft zijn eigen statistieken.
            string choice;

            Console.WriteLine("To start off you will need to choose the race you want to be.");
            Console.WriteLine("you can choose between the races:");
            Console.WriteLine("(A) Human (B) Mage (C) Ogre");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    Player.playerRace = "human";
                    Player.Races();
                    RaceChoice();
                    break;

                case "b":
                    Player.playerRace = "mage";
                    Player.Races();
                    RaceChoice();
                    break;

                case "c":
                    Player.playerRace = "ogre";
                    Player.Races();
                    RaceChoice();
                    break;

                default:
                    Console.WriteLine("you need to choose an option.");
                    CreateNewGame();
                    break;
            }
        }

        public static void RaceChoice()
        {
            //in deze function geeft weer wat je basis statistieken zijn als je jouw gekozen ras gebruikt. en geeft achteraf de optie of je nog van ras wil veranderen of dat je bij dat ras wil blijven.
            string choice;

            Console.WriteLine("If you choose to be an " + Player.playerRace + " these wil be your stats and abilities.");
            Console.WriteLine("*    Stats    *");
            Console.WriteLine("* health: " + Player.health + " *");
            Console.WriteLine("* damage: " + Player.damage + " *");
            Console.WriteLine("* speed: " + Player.speed + "  *");
            Console.WriteLine("* Energy: " + Player.energy + " *");
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to be an " + Player.playerRace + "?");
            Console.WriteLine("(A)Yes (B)No ");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    Console.Clear();
                    ClassChoice();
                    break;
                case "b":
                    CreateNewGame();
                    break;
                default:
                    Console.WriteLine("you need to choose an option.");
                    RaceChoice();
                    break;
            }
        }

        public static void ClassChoice()
        {
            //in deze funtion krijgt de speler de keuze welke klasse hij wil zijn. elke klasse heeft weer een bepaalde boost in de statistieken van de speler.
            string choice;

            Console.WriteLine("now you will have to choose what your class will be.");
            Console.WriteLine("(A)Sprinter (B)Fighter (C)Tank");
            choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a":
                    Console.WriteLine("this will raise your speed by 3.");
                    Player.chosenClass = "Sprinter";
                    ClassAcceptence();
                    break;
                case "b":
                    Console.WriteLine("this will raise your damage by 5 and you energy by 4.");
                    Player.chosenClass = "Fighter";
                    ClassAcceptence();
                    break;
                case "c":
                    Console.WriteLine("This will raise your health by 15.");
                    Player.chosenClass = "Tank";
                    ClassAcceptence();
                    break;
                default:
                    Console.WriteLine("That isn't an option.");
                    Console.ReadKey();
                    Console.Clear();
                    ClassChoice();
                    break;
            }
        }

        public static void ClassAcceptence()
        {
            //in deze function krjg je de keuze of je blij bent met je keuze qua klasse of dat je het nog wil veranderen.
            string choice;

            Console.WriteLine("are you sure you want to be " + Player.chosenClass + "?");
            Console.WriteLine("(A)Yes (B)No");
            choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a":
                    if (Player.chosenClass == "Sprinter")
                    {
                        Player.speed += 3;
                        Player.maxEnergy += 3;
                        Player.energy += 3;
                    }
                    else if (Player.chosenClass == "Fighter")
                    {
                        Player.damage += 5;
                        Player.maxEnergy += 4;
                        Player.energy += 4;
                    }
                    else if (Player.chosenClass == "Tank")
                    {
                        Player.maxHealth += 15;
                        Player.health += 15;
                    }

                    Console.Clear();
                    MainArea();
                    break;
                case "b":
                    Console.Clear();
                    ClassChoice();
                    break;
                default:
                    Console.WriteLine("that isn't an option.");
                    Console.ReadKey();
                    Console.Clear();
                    ClassAcceptence();
                    break;
            }
        }

        public static void MainArea()
        {
            //in deze function kun je steeds kiezen wat je wil gaan doen je kunt armor craften, skills equipped, items kopen/verkopen, info opvragen, statistieken bekijken en op exploration gaan.
            string choice;

            Console.WriteLine("Welcome to the Village Square from here you can choose where you want to go or what you want to do.");
            Console.WriteLine("what would you like to do?");
            Console.WriteLine("(A)Explore (B)Shop (C)Rest (D)check stats (E)Craft (F)Info");

            choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a":
                    Console.Clear();
                    Explore();
                    break;
                case "b":
                    Console.Clear();
                    Shop();
                    break;
                case "c":
                    Console.Clear();
                    Rest();
                    break;
                case "d":
                    Console.Clear();
                    DisplayStats();
                    break;
                case "e":
                    Console.Clear();
                    Crafting();
                    break;
                case "f":
                    Console.Clear();
                    Info();
                    break;
                default:
                    Console.WriteLine("you need to choose an option.");
                    Console.ReadKey();
                    Console.Clear();
                    MainArea();
                    break;
            }
        }

        public static void Info()
        {
            //hier kan de speler info opvragen van een hele boel verschillende dingen zoals exploration, enemies, skills, crafting, resting en de shop.
            string choice;

            Console.WriteLine("On what subject do you want information?");
            Console.WriteLine("(A)exploration (B)Enemies (C)Crafting (D)Resting (E)Shop (F)Back");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    Console.Clear();
                    ExplorationInfo();
                    break;

                case "b":
                    Console.Clear();
                    EnemyInfo();
                    break;

                case "c":
                    Console.Clear();
                    CraftingInfo();
                    break;

                case "d":
                    Console.Clear();
                    RestingInfo();
                    break;

                case "e":
                    Console.Clear();
                    ShopInfo();
                    break;

                case "f":
                    Console.Clear();
                    MainArea();
                    break;

                default:
                    Console.Clear();
                    Info();
                    break;
            }
        }

        public static void ShopInfo()
        {
            //hierin staat informatie over de shop.
            Console.WriteLine("In the shop you will be able to buy and sell items.");
            Console.WriteLine("you can buy Potions and energy pods.");
            Console.WriteLine("to buy items you of course need money.");
            Console.WriteLine("you can get money by just finding it while exploring or selling the items the monsters dropt.");
            Console.ReadKey();
            Console.Clear();
            Info();
        }

        public static void RestingInfo()
        {
            //hierin staat informatie over resting.
            Console.WriteLine("when you are in the village square you can rest.");
            Console.WriteLine("by resting you wil restore your energy en partially restore your health.");
            Console.WriteLine("but you can only rest once each time you get in the main area.");
            Console.ReadKey();
            Console.Clear();
            Info();
        }

        public static void CraftingInfo()
        {
            //hierin staat informatie over de crafting.
            Console.WriteLine("You can craft different types of armor to increase your stats.");
            Console.WriteLine("for every item you craft you will need different items to be able to craft it.");
            Console.WriteLine("The items you can craft and there boosts are:");
            Console.WriteLine("Helmet: health +10");
            Console.WriteLine("Chestplate: health +20");
            Console.WriteLine("Leggings: health +10");
            Console.WriteLine("Gloves: health +5");
            Console.WriteLine("Shoes:  speed +5");
            Console.WriteLine("Sword:  damage +10");
            Console.ReadKey();
            Console.Clear();
            Info();
        }

        public static void ExplorationInfo()
        {
            //hierin staat informatie over de exploration.
            Console.WriteLine("On exploration you will explore and find loot and possibly enemies.");
            Console.WriteLine("you have a 50/50 chance to explore and just find loot or to come across an enemy which you will have to fight against.");
            Console.WriteLine();
            Console.WriteLine("Once you have chosen to go on exploration you can choose where you want to go.");
            Console.WriteLine("In every area you will find different enemies with different loot.");
            Console.WriteLine("In the grasslands you will find:");
            Console.WriteLine("Shadow Skulker, Toxic Frog Brigade, Leapbloom Guardian, Misty Wraiths and the Razorback Stalker");
            Console.WriteLine();
            Console.WriteLine("In the woods you will find:");
            Console.WriteLine("Shadow Weavers, Tree Guardian, Earth Devourer, Dusk Stalker and the Fungus Freak");
            Console.WriteLine();
            Console.WriteLine("In the mountains you will find:");
            Console.WriteLine("Molten Forgemasters, Rock Chasm Crushers, Mountain Ravens, Glacier Guardians and the Avalanche Howlers");
            Console.WriteLine();
            Console.WriteLine("In the caverns you will find:");
            Console.WriteLine("Slimey Phantasms, Crystalline Spearforms, Shadow Trackers, Gloomstone Gorgons and the Cavern Serpentids");
            Console.ReadKey();
            Console.Clear();
            Info();
        }

        public static void EnemyInfo()
        {
            //hierin staat informatie over de enemies.
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("--Grasslands enemies--");
            Console.WriteLine("Shadow Skulker:");
            Console.WriteLine("A dark creature that lurks in the shadows of tall grass. Almost invisible");
            Console.WriteLine("until it attacks, it leaps out from the shadows with sharp claws to inflict damage on the");
            Console.WriteLine("player. Players must be vigilant for movements in the shadows to evade this ");
            Console.WriteLine("mysterious foe.");
            Console.WriteLine();
            Console.WriteLine("Toxic Frog Brigade:");
            Console.WriteLine("A group of colorful yet poisonous frogs that inhabit the grasslands. They ");
            Console.WriteLine("are fast and agile, capable of delivering toxic attacks. Players must tread carefully, as");
            Console.WriteLine("even a single touch from these frogs can be fatal.");
            Console.WriteLine();
            Console.WriteLine("Leapbloom Guardian:");
            Console.WriteLine("A giant, carnivorous flower hidden among other flowers in the grass.");
            Console.WriteLine("When a player gets too close, the flower launches itself with powerful leaps,");
            Console.WriteLine("attempting to engulf the player with its razor-sharp leaves.");
            Console.WriteLine();
            Console.WriteLine("Misty Wraiths:");
            Console.WriteLine("Invisible spirits that roam within the morning mist of the grasslands. They");
            Console.WriteLine("become visible only when they attack. Capable of disorienting players and affecting");
            Console.WriteLine("their vision, making them vulnerable targets.");
            Console.WriteLine();
            Console.WriteLine("Razorback Stalker:");
            Console.WriteLine("An aggressive, large species of boar with sharp tusks. They move in herds");
            Console.WriteLine("and attack players when they get too close. They can run quickly and are quite ");
            Console.WriteLine("resilient.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("--Woods enemies--");
            Console.WriteLine("Shadow Weavers:");
            Console.WriteLine("These creatures thrive in darkness and can transform themselves into");
            Console.WriteLine("shadows. They move silently among the trees and can launch attacks seemingly out");
            Console.WriteLine("of nowhere. Their presence is often only noticed by the dark patches they leave");
            Console.WriteLine("behind.");
            Console.WriteLine();
            Console.WriteLine("Tree Guardian:");
            Console.WriteLine("Living, mutated trees that protect the forest. They have roots that");
            Console.WriteLine("function as tentacles and can move swiftly. When intruders threaten the forest, these ");
            Console.WriteLine("tree guardians come to life, defending their territory with powerful strikes and magical");
            Console.WriteLine("spells.");
            Console.WriteLine();
            Console.WriteLine("Earth Devourer:");
            Console.WriteLine("These underground creatures have the ability to move through the earth.");
            Console.WriteLine("They suddenly emerge, dragging their prey underground, where they feed on the life");
            Console.WriteLine("force of their victims. The ground may tremble as a warning of their impending attack.");
            Console.WriteLine();
            Console.WriteLine("Dusk Stalker:");
            Console.WriteLine("These shadowy creatures thrive in the transition between day and night.");
            Console.WriteLine("They have the ability to become invisible at dusk and can launch attacks from the");
            Console.WriteLine("shadows. Travelers will struggle to notice them until the sun sets, facing invisible");
            Console.WriteLine("enemies that assail them.");
            Console.WriteLine();
            Console.WriteLine("Fungus Freak:");
            Console.WriteLine("A race of shadowy beings that feed on plants and trees. They have the ");
            Console.WriteLine("power to control the vegetation around them and induce mutations. Travelers must be ");
            Console.WriteLine("cautious, as seemingly innocent mushrooms can suddenly evolve into aggressive");
            Console.WriteLine("creatures under their influence.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("--Mountains enemies--");
            Console.WriteLine("Molten Forgemasters:");
            Console.WriteLine("Dwelling near volcanic regions within the mountains, these fiery");
            Console.WriteLine("creatures are masters of molten rock. They can summon rivers of lava and launch fiery");
            Console.WriteLine("projectiles. Travelers must be wary of sudden eruptions and navigate carefully to");
            Console.WriteLine("avoid being caught in the scorching embrace of these formidable adversaries.");
            Console.WriteLine();
            Console.WriteLine("Rock Chasm Crushers:");
            Console.WriteLine("These colossal beings inhabit deep chasms in the mountains. They can");
            Console.WriteLine("dislodge massive boulders and send them crashing down to crush their prey.");
            Console.WriteLine("Travelers must navigate skillfully to avoid becoming victims of these dangerous rock");
            Console.WriteLine("avalanches.");
            Console.WriteLine();
            Console.WriteLine("Mountain Ravens:");
            Console.WriteLine("These gigantic, mutated ravens dominate the skies around mountain");
            Console.WriteLine("peaks. They can summon storms and use lightning bolts to assail their prey. Travelers");
            Console.WriteLine("must beware of their sharp talons and the devastating power of the storms they");
            Console.WriteLine("unleash.");
            Console.WriteLine();
            Console.WriteLine("Glacier Guardians:");
            Console.WriteLine("Living ice creatures that guard the glaciers. They have the ability to ");
            Console.WriteLine("freeze their surroundings and can shoot icy projectiles. These beings protect ancient ");
            Console.WriteLine("treasures buried beneath the ice, and they will do anything to repel intruders.");
            Console.WriteLine();
            Console.WriteLine("Avalanche Howlers:");
            Console.WriteLine("These beings have the power to cause avalanches through their ");
            Console.WriteLine("terrifying screams. They drive travelers off the mountains by releasing enormous ");
            Console.WriteLine("masses of snow. Avoiding their howls is essential for survival in these hazardous");
            Console.WriteLine("mountainous areas.");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("--Cavern enemies--");
            Console.WriteLine("Slimey Phantasms:");
            Console.WriteLine("These slippery creatures thrive in the moist darkness of caverns. They");
            Console.WriteLine("can change shape and camouflage themselves as stalactites or stalagmites. When");
            Console.WriteLine("they strike, they envelop their prey with a slimy substance, attempting to digest it ");
            Console.WriteLine("slowly.");
            Console.WriteLine();
            Console.WriteLine("Crystalline Spearforms:");
            Console.WriteLine("Living crystal entities found in the deepest parts of caverns. They have ");
            Console.WriteLine("sharp crystal spikes as limbs and can concentrate beams of light to launch dazzling");
            Console.WriteLine("attacks. Travelers must beware of their reflective light that can fill the caverns.");
            Console.WriteLine();
            Console.WriteLine("Shadow Trackers:");
            Console.WriteLine("These shadowy beings hunt in the darkness of caverns. They have the");
            Console.WriteLine("ability to become invisible and move silently to stalk their prey. They leave only a faint");
            Console.WriteLine("shadow as a warning of their impending attack.");
            Console.WriteLine();
            Console.WriteLine("Gloomstone Gorgons:");
            Console.WriteLine("Animated statues carved from a unique, luminescent stone found only in");
            Console.WriteLine("caverns. They have the ability to petrify their prey with a gaze. The cavern walls may");
            Console.WriteLine("be adorned with these statues, creating an unsettling atmosphere for those who tread");
            Console.WriteLine("too close.");
            Console.WriteLine();
            Console.WriteLine("Cavern Serpentids:");
            Console.WriteLine("Enormous serpentine creatures that navigate the labyrinthine tunnels of");
            Console.WriteLine("the caverns. They have bioluminescent scales, casting an eerie glow in the darkness.");
            Console.WriteLine("Travelers must be cautious of their swift movements and the venomous bite of these ");
            Console.WriteLine("underground serpents.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
            Console.Clear();
            Info();
        }

        public static void Explore()
        {
            //in deze function kan de speler gaan exploren en krijgt de speler de keuze naar welke area hij wil gaan om te exploren.
            string choice;

            Console.WriteLine("where would you like to go and explore?.");
            Console.WriteLine("(A)The grasslands (B)The woods (C)The mountains (D)The caverns (E)Back");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    rested = false;
                    Exploration.GrassLands();
                    break;
                case "b":
                    rested = false;
                    Exploration.Woods();
                    break;
                case "c":
                    rested = false;
                    Exploration.Mountains();
                    break;
                case "d":
                    rested = false;
                    Exploration.Caverns();
                    break;
                case "e":
                    Console.Clear();
                    MainArea();
                    break;
                default:
                    Console.WriteLine("you need to choose an option.");
                    Explore();
                    break;
            }
        }

        public static void Rest()
        {
            //in deze function gaat de speler rusten waardoor hij energie en health erbij op krijgt. de speler kan maar 1 keer rusten per keer dat hij in de main area komt.
            if (rested == false)
            {
                Console.WriteLine("You seek a place to rest.");
                Console.WriteLine("After a little while you have found shelter and decide to take a little nap.");
                Console.WriteLine();
                Console.WriteLine("ZZZ");
                Console.WriteLine("ZZ");
                Console.WriteLine("Z");
                Console.WriteLine();
                Console.WriteLine("You woke up feeling energized again.");
                Console.WriteLine("Feeling energized you are ready to continue your exploration.");
                if (Player.health <= Player.maxHealth)
                {
                    Player.health += 15;
                    if (Player.health > Player.maxHealth)
                    {
                        Player.health = Player.maxHealth;
                    }
                }
                Player.energy = Player.maxEnergy;
                rested = true;
                Console.ReadKey();
                Console.Clear();
                MainArea();
            }
            else
            {
                Console.WriteLine("you have already rested and don't feel the urge to rest.");
                Console.ReadKey();
                Console.Clear();
                MainArea();
            }
        }

        public static void DisplayStats()
        {
            //in deze function worden je statistieken, skills en items weergegeven.
            Console.WriteLine("Your stats are:");
            Console.WriteLine("Name: " + Player.name);
            Console.WriteLine("health: " + Player.health + "/" + Player.maxHealth);
            Console.WriteLine("damage: " + Player.damage);
            Console.WriteLine("speed: " + Player.speed);
            Console.WriteLine("Energy: " + Player.energy + "/" + Player.maxEnergy);
            Console.WriteLine("Level: " + Player.level);
            Console.WriteLine("Experience: " + Player.xp + "/" + Player.xpNeeded);
            Console.WriteLine("money: " + Player.money);
            Console.WriteLine();
            Console.WriteLine("Your inventory items are:");
            Console.WriteLine("iron: " + Player.iron);
            Console.WriteLine("wood: " + Player.wood);
            Console.WriteLine("leather: " + Player.leather);
            Console.WriteLine("fiber: " + Player.fiber);
            Console.WriteLine("Energy pod: " + Player.energyPod);
            Console.WriteLine("potion: " + Player.potion);
            Console.ReadKey();
            Console.Clear();
            MainArea();
        }

        public static void Shop()
        {
            //in deze function kan de speler kiezen of hij items wil kopen of verkopen of dat hij skills wil kopen.
            string choice;

            Console.WriteLine("Welcome to the shop.");
            Console.WriteLine("what would you like to do?");
            Console.WriteLine("(A)Buy (B)Sell (C)Leave");
            choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                    Console.Clear();
                    ShopItems();
                    break;
                case "b":
                    Console.Clear();
                    SellShop();
                    break;
                case "c":
                    Console.WriteLine("Thanks for visiting.");
                    Console.WriteLine("I hope to see you again.");
                    Console.ReadKey();
                    Console.Clear();
                    MainArea();
                    break;
                default:
                    Console.WriteLine("you need to choose an option.");
                    Shop();
                    break;
            }
        }

        public static void ShopItems()
        {
            //in deze function kan de speler zien wat hij kan kopen in de store.
            //als hij iets wil kopen en hij heeft genoeg geld dan kan krijgt hij het item wat hij kocht, heeft hij niet genoeg geld geeft de function aan dat de speler niet genoeg geld heeft.
            string choice;

            Console.WriteLine("What would you like to buy?");
            Console.WriteLine("Today in the stock is:");
            Console.WriteLine("(A)health potion -$20- (B)EnergyPods -$15- (C)Back");

            choice = Console.ReadLine().ToLower();
            switch (choice)
            {
                case "a":
                    if (Player.money >= 20)
                    {
                        Player.potion++;
                        Player.money -= 20;
                        Console.WriteLine("you have bought an health potion.");
                        Console.WriteLine("you now have " + Player.potion + " health potions.");
                        Console.ReadKey();
                        Console.Clear();
                        ShopItems();
                    }
                    else
                    {
                        Console.WriteLine("you don't have enough money to buy an health potion.");
                        Console.ReadKey();
                        Console.Clear();
                        ShopItems();
                    }
                    break;
                case "b":
                    if (Player.money >= 15)
                    {
                        Player.energyPod++;
                        Player.money -= 15;
                        Console.WriteLine("you have bought an energy pod.");
                        Console.WriteLine("you now have " + Player.energyPod + " energy pods.");
                        Console.ReadKey();
                        Console.Clear();
                        ShopItems();
                    }
                    else
                    {
                        Console.WriteLine("you don't have enough money to buy an energy pod.");
                        Console.ReadKey();
                        Console.Clear();
                        ShopItems();
                    }
                    break;
                case "c":
                    Console.Clear();
                    Shop();
                    break;
            }
        }

        public static void SellShop()
        {
            //in deze function kan de speler zien wat hij kan verkopen in de store.
            //als hij iets wil verkopen en hij heeft het item dan verkoopt hij er 1 en krijgt hij het geld ervoor, heeft hij niet genoeg geeft het spel dat aan en krijgt hij geen geld
            string choice;

            Console.WriteLine("what would you like to sell?");
            Console.WriteLine("(A)potion -$15- (B)Energy pod -$10- (C)fiber -$3- (D)iron -$8- (E)wood -$4- (F)leather -$6- (G)Back");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "a":
                    if (Player.potion >= 1)
                    {
                        Player.potion--;
                        Player.money += 15;
                        Console.WriteLine("you have sold the potion and got 15 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any potions to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "b":
                    if (Player.energyPod >= 1)
                    {
                        Player.energyPod--;
                        Player.money += 10;
                        Console.WriteLine("you have sold the energy pod and got 10 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any potions to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "c":
                    if (Player.fiber >= 1)
                    {
                        Player.fiber--;
                        Player.money += 3;
                        Console.WriteLine("you have sold the piece of fiber and got 8 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any fiber to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "d":
                    if (Player.iron >= 1)
                    {
                        Player.iron--;
                        Player.money += 8;
                        Console.WriteLine("you have sold the piece of iron and got 8 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any iron to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "e":
                    if (Player.wood >= 1)
                    {
                        Player.wood--;
                        Player.money += 4;
                        Console.WriteLine("you have sold the piece of wood and got 4 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any wood to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "f":
                    if (Player.leather >= 1)
                    {
                        Player.leather--;
                        Player.money += 6;
                        Console.WriteLine("you have sold the piece of leather and got 6 money");
                        Console.ReadKey();
                        SellShop();
                    }
                    else
                    {
                        Console.WriteLine("you don't have any leather to sell.");
                        Console.ReadKey();
                        Console.Clear();
                        SellShop();
                    }
                    break;
                case "g":
                    Console.Clear();
                    Shop();
                    break;
            }
        }

        public static void Crafting()
        {
            //hier kan de speler zien wat hij can craften en wat hij ervoor nodig heeft.
            //als hij de items heeft word het item gecraft, heeft hij niet genoeg items geeft het spel dat aan.
            int HelmetHealth = 10;
            int ChestPlateHealth = 20;
            int LeggingsHealth = 10;
            int GloveHealth = 5;
            int ShoeSpeed = 5;
            int SwordDam = 10;

            string choice;

            Console.WriteLine("Gear costs:");
            Console.WriteLine("Helmet = 3 leather and 2 iron");
            Console.WriteLine("Chestplate = 12 leather, 8 fiber , 3 wood and 4 iron");
            Console.WriteLine("Leggings = 9 leather, 6 fiber and 2 wood");
            Console.WriteLine("Gloves = 4 leather and 3 fiber");
            Console.WriteLine("Shoes = 5 leather and 4 fiber");
            Console.WriteLine("Sword = 3 wood and 8 iron");
            Console.WriteLine();
            Console.WriteLine("what would you like to craft?");
            Console.WriteLine("(A)Helmet (B)Chestplate (C)Leggings (D)Gloves (E)Shoes (F)Sword (G)Back");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    if (helmetCrafted == false && Player.iron >= 2 && Player.leather >= 3)
                    {
                        Console.WriteLine("The helmet is crafted and you have equipped it.");
                        Console.WriteLine("your health got a little boost.");
                        Console.WriteLine("you got an extra " + HelmetHealth + " health");
                        Player.maxHealth = Player.maxHealth + HelmetHealth;
                        Console.WriteLine("you now have " + Player.maxHealth + " Max health.");
                        Player.health += HelmetHealth;
                        helmetCrafted = true;
                        Player.iron -= 2;
                        Player.leather -= 3;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (helmetCrafted == true)
                    {
                        Console.WriteLine("you already have crafted an helmet.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.iron < 2 && Player.leather < 3)
                    {
                        Console.WriteLine("you don't have the right resouces to craft a Helmet.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "b":
                    if (chestplateCrafted == false && Player.leather >= 12 && Player.fiber >= 8 && Player.wood >= 3 && Player.iron >= 4)
                    {
                        Console.WriteLine("The chestplate is crafted and you have equipped it.");
                        Console.WriteLine("your health got a little boost.");
                        Console.WriteLine("you got an extra " + ChestPlateHealth + " health");
                        Player.maxHealth = Player.maxHealth + ChestPlateHealth;
                        Console.WriteLine("you now have " + Player.maxHealth + " Max health.");
                        Player.health += ChestPlateHealth;
                        chestplateCrafted = true;
                        Player.leather -= 12;
                        Player.fiber -= 8;
                        Player.wood -= 3;
                        Player.iron -= 4;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (chestplateCrafted == true)
                    {
                        Console.WriteLine("you already have crafted a ChestPlate.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.leather < 12 && Player.fiber < 8 && Player.wood < 3 && Player.iron < 4)
                    {
                        Console.WriteLine("you don't have the right resouces to craft a ChestPlate.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "c":
                    if (leggingsCrafted == false && Player.leather >= 9 && Player.fiber >= 6 && Player.wood >= 2)
                    {
                        Console.WriteLine("The leggings are crafted and you have equipped them.");
                        Console.WriteLine("your health got a little boost.");
                        Console.WriteLine("you got an extra " + LeggingsHealth + " health");
                        Player.maxHealth = Player.maxHealth + LeggingsHealth;
                        Console.WriteLine("you now have " + Player.maxHealth + " Max health.");
                        Player.health += LeggingsHealth;
                        leggingsCrafted = true;
                        Player.leather -= 9;
                        Player.fiber -= 6;
                        Player.wood -= 2;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (leggingsCrafted == true)
                    {
                        Console.WriteLine("you already have crafted Leggings.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.leather < 9 && Player.fiber < 6 && Player.wood < 2)
                    {
                        Console.WriteLine("you don't have the right resouces to craft leggings.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "d":
                    if (glovesCrafted == false && Player.leather >= 4 && Player.fiber >= 3)
                    {
                        Console.WriteLine("The gloves are crafted and you have equipped them.");
                        Console.WriteLine("your health got a little boost.");
                        Console.WriteLine("you got an extra " + GloveHealth + " health");
                        Player.maxHealth = Player.maxHealth + GloveHealth;
                        Console.WriteLine("you now have " + Player.maxHealth + " Max health.");
                        Player.health += GloveHealth;
                        glovesCrafted = true;
                        Player.leather -= 4;
                        Player.fiber -= 3;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (glovesCrafted == true)
                    {
                        Console.WriteLine("you already have crafted gloves.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.leather < 4 && Player.fiber < 3)
                    {
                        Console.WriteLine("you don't have the right resouces to craft gloves.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "e":
                    if (shoesCrafted == false && Player.leather >= 5 && Player.fiber >= 4)
                    {
                        shoesCrafted = true;
                        Console.WriteLine("The shoes are crafted and you have equipped them.");
                        Console.WriteLine("your speed got a little boost.");
                        Console.WriteLine("you got an extra " + ShoeSpeed + " speed");
                        Player.speed = Player.speed + ShoeSpeed;
                        Console.WriteLine("you now have " + Player.speed + " speed.");
                        Player.speed += ShoeSpeed;
                        Player.leather -= 5;
                        Player.fiber -= 4;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (shoesCrafted == true)
                    {
                        Console.WriteLine("you already have crafted shoes.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.leather < 5 && Player.fiber < 4)
                    {
                        Console.WriteLine("you don't have the right resouces to craft shoes.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "f":
                    if (swordCrafted == false && Player.iron >= 8 && Player.wood >= 3)
                    {
                        Console.WriteLine("The sword is crafted and you have equipped it.");
                        Console.WriteLine("your damage got a little boost.");
                        Console.WriteLine("you got an extra " + SwordDam + " damage");
                        Player.damage = Player.damage + SwordDam;
                        Console.WriteLine("you now have " + Player.damage + " damage.");
                        Player.damage += SwordDam;
                        swordCrafted = true;
                        Player.iron -= 8;
                        Player.wood -= 3;
                        Console.ReadKey();
                        Console.Clear();
                        MainArea();
                    }
                    else if (swordCrafted == true)
                    {
                        Console.WriteLine("you already have crafted a sword.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    else if (Player.iron < 8 && Player.wood < 3)
                    {
                        Console.WriteLine("you don't have the right resouces to craft a sword.");
                        Console.ReadKey();
                        Console.Clear();
                        Crafting();
                    }
                    break;
                case "g":
                    Console.Clear();
                    MainArea();
                    break;
                default:
                    Console.WriteLine("you need to choose an option.");
                    Crafting();
                    break;
            }
        }

        public static void QuitGame()
        {
            //in deze funtion kan de speler het spel beeindigen.
            string choice;

            Console.WriteLine("Are you sure you want to quit playing?");
            Console.WriteLine("(A)Yes (B)No");
            choice = Console.ReadLine().ToLower();

            switch (choice)
            {
                case "a":
                    System.Environment.Exit(0);
                    break;

                case "b":
                    if (Player.health <= 0)
                    {
                        Player.Death();
                    }
                    if (Player.health >= 1)
                    {
                        MainArea();
                    }
                    break;

                default:
                    Console.WriteLine("you need to choose an option.");
                    Console.ReadKey();
                    QuitGame();
                    break;
            }
        }
    }
}
