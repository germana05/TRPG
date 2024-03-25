using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    class Player
    {
        public static string name { get; set; }
        public static string playerRace { get; set; }
        public static string chosenClass { get; set; }

        public static int maxHealth { get; set; }
        public static int health { get; set; }
        public static int damage { get; set; }
        public static int speed { get; set; }
        public static int energy { get; set; }
        public static int maxEnergy { get; set; }
        public static int money { get; set; }
        public static int potion { get; set; }
        public static int energyPod { get; set; }
        public static int leather { get; set; }
        public static int iron { get; set; }
        public static int fiber { get; set; }
        public static int wood { get; set; }


        public static int level;
        public static int xp = 0;
        public static int xpNeeded = 100;
        public static int xPAdded;

        public static void Levelen()
        {
            //deze function checkt of de xp hoog genoeg is om een level omhoog te gaan en als dat zo is gaat hij en level omhoog.
            if(xp >= xpNeeded)
            {
                level++;
                xp = 0;
                xpNeeded += 50;
                Console.WriteLine("You have gained a level.");
                Console.WriteLine("by leveling up you have gained an skill point which you can use in the skillshop.");
                Console.ReadKey();
                Console.Clear();
                GamePlay.MainArea();
            }
        }

        public static void Death()
        {
            //in deze function word gecheckt of je nog leeft. als je niet meer leeft krijg je de optie om opnieuw te spelen of om te stoppen.
            string choice;

            if (health <= 0)
            {
                Console.WriteLine("you have been defeated.");
                Console.WriteLine("do you want to play again or stop playing?");
                Console.WriteLine("(A)play again (B)quit");
                choice = Console.ReadLine().ToLower();

                switch (choice)
                {
                    case "a":
                        GamePlay.CreateNewGame();
                        break;

                    case "b":
                        GamePlay.QuitGame();
                        break;

                    default:
                        Death();
                        break;
                }
            }
        }

        public static void Races()
        {
            //in deze function word gecheckt welke race je hebt gekozen en veranderd je statistieken op basis van je keuze.
            if (playerRace == "human")
            {
                maxHealth = 100;
                health = 100;
                damage = 8;
                speed = 12;
                energy = 15;
                maxEnergy = 15;
            }
            else if (playerRace == "mage")
            {
                maxHealth = 80;
                health = 80;
                damage = 15;
                speed = 5;
                energy = 18;
                maxEnergy = 18;
            }
            else if (playerRace == "ogre")
            {
                maxHealth = 150;
                health = 150;
                damage = 13;
                speed = 3;
                energy = 13;
                maxEnergy = 13;
            }
        }

        public static void Heal()
        {
            //deze function geeft je health erbij op als je een potion gebruikt. het kan alleen als je een potion hebt anders geeft hij aan dat je geen potion hebt.
            if (potion >= 1)
            {
                health += 30;
                potion--;
                if (health >= maxHealth)
                {
                    health = maxHealth;
                }
            }
            else
            {
                Console.WriteLine("you don't have any potions");
            }
        }

        public static void Energize()
        {
            //deze function geeft je energie erbij als je een energy pod gebruikt. het kan alleen als je een energy pod hebt anders geeft hij aan dat je geen energy pod hebt.

            if (energyPod >= 1)
            {
                energy += 10;
                if (energy >= maxEnergy)
                {
                    energy = maxEnergy;
                }
                Console.WriteLine("you have restored some energy.");
                Console.WriteLine("your now have " + energy + " energy.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("you don't have any energy pods");
            }
        }

        public static void Run()
        {
            //in deze funtion word een 1 op 3 kans gegeven om te vluchten van een gevecht. heb je geluk vlucht je van het gevecht zo niet gaat de beurt terug naar enemy.
            int RunChance;

            Random rnd = new Random();
            Console.WriteLine("you tried to run away");
            RunChance = rnd.Next(1, 4);

            switch (RunChance)
            {
                case 1:
                    Console.WriteLine("you couldn't run away");
                    Exploration.playerTurn = false;
                    Console.ReadKey();
                    Console.Clear();
                    break;
                case 2:
                    Console.WriteLine("you got away and ran back to the village.");
                    Console.ReadKey();
                    Console.Clear();
                    GamePlay.MainArea();
                    break;
                case 3:
                    Console.WriteLine("you couldn't run away");
                    Exploration.playerTurn = false;
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }

        public static void ExplorationFinds()
        {
            //deze function gebruikt een random om rewards te geven na een exploration zonder gevecht.
            Random rnd = new Random();

            xPAdded = rnd.Next(16, 33);
            xp = xp + xPAdded;
            money = money + rnd.Next(14,39);
            Levelen();
            Console.ReadKey();
            Console.Clear();
            GamePlay.MainArea();
        }

        public static void BattleRewards()
        {
            //in deze function generate hij random rewards die je kunt krijgen van de battles.
            int LeatherDrop;
            int IronDrop;
            int FiberDrop;
            int WoodDrop;

            Random rnd = new Random();
            xPAdded = rnd.Next(10, 28);
            money = money + rnd.Next(10,17);
            Console.WriteLine("you got "+ xPAdded + " XP.");
            xp = xp + xPAdded;

            if (Exploration.enemyName == "Razorback Stalker" || Exploration.enemyName == "Earth Devourer" || Exploration.enemyName == "Avalanche Howlers")
            {
                LeatherDrop = rnd.Next(0, 4);
                Console.WriteLine("The "+ Exploration.enemyName + " dropped " + LeatherDrop + " leather.");
                leather = leather + LeatherDrop;
            }
            else if (Exploration.enemyName == "Molten Forgemasters" || Exploration.enemyName == "Cavern Serpentids" || Exploration.enemyName == "Earth Devourer")
            {
                IronDrop = rnd.Next(0, 3);
                Console.WriteLine("The " + Exploration.enemyName + " dropped " + IronDrop + " iron.");
                iron = iron + IronDrop;
            }
            else if (Exploration.enemyName == "Leapbloom Guardian" || Exploration.enemyName == "Gloomstone Gorgons" || Exploration.enemyName == "Fungus Freak")
            {
                FiberDrop = rnd.Next(0, 3);
                Console.WriteLine("The " + Exploration.enemyName + " dropped " + FiberDrop + " fiber.");
                fiber = fiber + FiberDrop;
            }
            else if (Exploration.enemyName == "Tree Guardian" || Exploration.enemyName == "Toxic Frog Brigade" || Exploration.enemyName == "Fungus Freak")
            {
                WoodDrop = rnd.Next(0, 3);
                Console.WriteLine("The " + Exploration.enemyName + " dropped " + WoodDrop + " wood.");
                wood = wood + WoodDrop;
            }

            Console.ReadKey();
            Console.Clear();
            Levelen();
        }
    }
}
