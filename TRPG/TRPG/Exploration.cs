using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPG
{
    class Exploration
    {
        public static bool playerTurn = false;

        public static string enemyName;

        public static void GrassLands()
        {
            //deze function gebruikt een random om te genereren welke enemy je tegenover je krijgt om tegen te vechten. en hij voert een check uit of je in een gevecht komt of niet.
            //je kunt alleen tegenover een bepaalde selectie aan enemies komen die alleen in de grasslands komt.
            int EnemyChoice;
            int EnemyEncounter;

            Random rnd = new Random();

            EnemyChoice = rnd.Next(1,6);

            EnemyEncounter = rnd.Next(1,3);

            Console.WriteLine("After a long journey you have arrived at the Grasslands.");
            Console.WriteLine("you start wandering around in the grasslands in search of loot.");
            Console.ReadKey();
            Console.Clear();

            switch (EnemyChoice)
            {
                case 1:
                    enemyName = "Shadow Skulker";
                    break;
                case 2:
                    enemyName = "Toxic Frog Brigade";
                    break;
                case 3:
                    enemyName = "Leapbloom Guardian";
                    break;
                case 4:
                    enemyName = "Misty Wraiths";
                    break;
                case 5:
                    enemyName = "Razorback Stalker";
                    break;
            }

            switch (EnemyEncounter)
            {
                case 1:
                    Console.WriteLine("you explored for a while and found some loot.");
                    Player.ExplorationFinds();
                    Player.Levelen();
                    break;
                case 2:
                    GrassLandFight();
                    break;
            }
        }

        public static void GrassLandFight()
        {
            //deze function gaat over het gevecht. hierin kun je keuzes maken of je wil aanvallen, weg rennen, healen of energie op doen. het gevecht eindigt als de enemy dood is of de speler dood is.
            //de statistieken van de enemies word elk gevecht random gegenereerd.
            Random rnd = new Random();

            bool fight = true;
            int EnemyHealth = rnd.Next(50,61);
            int EnemySpeed = rnd.Next(5,21);
            int EnemyDamage = rnd.Next(5,7);

            if (EnemySpeed <= Player.speed)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }

            while (fight == true)
            {
                while (EnemyHealth > 0 && Player.health > 0)
                {
                    if (playerTurn == true)
                    {
                        Console.WriteLine("you came across an " + enemyName);
                        Console.WriteLine("the " + enemyName + " is attacking you, what will you do?");
                        Console.WriteLine("(A)Attack (B)Heal (C)Energize (D)Run");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "a")
                        {
                            if (Player.energy >= 2)
                            {
                                EnemyHealth -= Player.damage;
                                Player.energy -= 2;

                                Console.WriteLine("the enemy now has " + EnemyHealth + " health left.");
                                Console.WriteLine("your energy dropped to " + Player.energy);
                                Console.ReadKey();
                                Console.Clear();
                                if(EnemyHealth > 0)
                                {
                                    playerTurn = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough energy to attack.");
                                Console.ReadKey();
                            }

                        }
                        else if (choice == "b")
                        {
                            Player.Heal();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "c")
                        {
                            Player.Energize();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "d")
                        {
                            Player.Run();
                        }
                        else
                        {
                            Console.WriteLine("That isn't an option.");
                            Console.WriteLine("get back to the fight.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    if(playerTurn == false)
                    {
                        Console.WriteLine("the " + enemyName + " damaged you for "+ EnemyDamage + " damage.");
                        Player.health -= EnemyDamage;
                        Console.WriteLine("you now have "+Player.health+ " health left.");
                        Console.ReadKey();
                        Console.Clear();
                        playerTurn = true;
                    }
                }
                if (EnemyHealth <= 0 && Player.health > 0)
                {
                    fight = false;
                    Player.BattleRewards();
                    Player.Levelen();
                    GamePlay.MainArea();
                }
                if(Player.health <= 0)
                {
                    Player.Death();
                }
                Console.ReadKey();
                Console.Clear();
                Player.Levelen();
            }
            Console.ReadKey();
            Console.Clear();
            Player.Levelen();
        }

        public static void Woods()
        {
            //deze function gebruikt een random om te genereren welke enemy je tegenover je krijgt om tegen te vechten. en hij voert een check uit of je in een gevecht komt of niet.
            //je kunt alleen tegenover een bepaalde selectie aan enemies komen die alleen in de woods komt.
            int EnemyChoice;
            int EnemyEncounter;

            Random rnd = new Random();

            EnemyChoice = rnd.Next(1, 6);

            EnemyEncounter = rnd.Next(1, 3);

            Console.WriteLine("After a long journey you have arrived at the woods.");
            Console.WriteLine("you start wandering through the woods in search of loot.");
            Console.ReadKey();
            Console.Clear();

            switch (EnemyChoice)
            {
                case 1:
                    enemyName = "Shadow Weavers";
                    break;
                case 2:
                    enemyName = "Tree Guardian";
                    break;
                case 3:
                    enemyName = "Earth Devourer";
                    break;
                case 4:
                    enemyName = "Dusk Stalker";
                    break;
                case 5:
                    enemyName = "Fungus Freak";
                    break;
            }

            switch (EnemyEncounter)
            {
                case 1:
                    Console.WriteLine("you explored for a while and found some loot.");
                    Player.ExplorationFinds();
                    Player.Levelen();
                    break;
                case 2:
                    WoodsFight();
                    break;
            }
        }

        public static void WoodsFight()
        {
            //deze function gaat over het gevecht. hierin kun je keuzes maken of je wil aanvallen, weg rennen, healen of energie op doen. het gevecht eindigt als de enemy dood is of de speler dood is.
            //de statistieken van de enemies word elk gevecht random gegenereerd.
            Random rnd = new Random();

            bool fight = true;
            int EnemyHealth = rnd.Next(50, 61);
            int EnemySpeed = rnd.Next(5, 21);
            int EnemyDamage = rnd.Next(5, 7);

            if (EnemySpeed <= Player.speed)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }

            while (fight == true)
            {
                while (EnemyHealth > 0 && Player.health > 0)
                {
                    if (playerTurn == true)
                    {
                        Console.WriteLine("you came across an " + enemyName);
                        Console.WriteLine("the " + enemyName + " is attacking you, what will you do?");
                        Console.WriteLine("(A)Attack (B)Heal (C)Energize (D)Run");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "a")
                        {
                            if (Player.energy >= 2)
                            {
                                EnemyHealth -= Player.damage;
                                Player.energy -= 2;

                                Console.WriteLine("the enemy now has " + EnemyHealth + " health left.");
                                Console.WriteLine("your energy dropped to " + Player.energy);
                                Console.ReadKey();
                                Console.Clear();
                                if (EnemyHealth > 0)
                                {
                                    playerTurn = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough energy to attack.");
                                Console.ReadKey();
                            }

                        }
                        else if (choice == "b")
                        {
                            Player.Heal();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "c")
                        {
                            Player.Energize();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "d")
                        {
                            Player.Run();
                        }
                        else
                        {
                            Console.WriteLine("That isn't an option.");
                            Console.WriteLine("get back to the fight.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    if (playerTurn == false)
                    {
                        Console.WriteLine("the " + enemyName + " damaged you for " + EnemyDamage + " damage.");
                        Player.health -= EnemyDamage;
                        Console.WriteLine("you now have " + Player.health + " health left.");
                        Console.ReadKey();
                        Console.Clear();
                        playerTurn = true;
                    }
                }
                if (EnemyHealth <= 0 && Player.health > 0)
                {
                    fight = false;
                    Player.BattleRewards();
                    Player.Levelen();
                    GamePlay.MainArea();
                }
                if (Player.health <= 0)
                {
                    Player.Death();
                }
                Console.ReadKey();
                Console.Clear();
                Player.Levelen();
            }
            Console.ReadKey();
            Console.Clear();
            Player.Levelen();
        }

        public static void Mountains()
        {
            //deze function gebruikt een random om te genereren welke enemy je tegenover je krijgt om tegen te vechten. en hij voert een check uit of je in een gevecht komt of niet.
            //je kunt alleen tegenover een bepaalde selectie aan enemies komen die alleen in de mountains komt.
            int EnemyChoice;
            int EnemyEncounter;

            Random rnd = new Random();

            EnemyChoice = rnd.Next(1, 6);

            EnemyEncounter = rnd.Next(1, 3);

            Console.WriteLine("After a long journey you have arrived at the mountains.");
            Console.WriteLine("you start wandering through the mountains in search of loot.");
            Console.ReadKey();
            Console.Clear();

            switch (EnemyChoice)
            {
                case 1:
                    enemyName = "Molten Forgemasters";
                    break;
                case 2:
                    enemyName = "Rock Chasm Crushers";
                    break;
                case 3:
                    enemyName = "Mountain Ravens";
                    break;
                case 4:
                    enemyName = "Glacier Guardians";
                    break;
                case 5:
                    enemyName = "Avalanche Howlers";
                    break;
            }

            switch (EnemyEncounter)
            {
                case 1:
                    Console.WriteLine("you explored for a while and found some loot.");
                    Player.ExplorationFinds();
                    Player.Levelen();
                    break;
                case 2:
                    MountainFight();
                    break;
            }
        }

        public static void MountainFight()
        {
            //deze function gaat over het gevecht. hierin kun je keuzes maken of je wil aanvallen, weg rennen, healen of energie op doen. het gevecht eindigt als de enemy dood is of de speler dood is.
            //de statistieken van de enemies word elk gevecht random gegenereerd.
            Random rnd = new Random();

            bool fight = true;
            int EnemyHealth = rnd.Next(50, 61);
            int EnemySpeed = rnd.Next(5, 21);
            int EnemyDamage = rnd.Next(5, 7);

            if (EnemySpeed <= Player.speed)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }

            while (fight == true)
            {
                while (EnemyHealth > 0 && Player.health > 0)
                {
                    if (playerTurn == true)
                    {
                        Console.WriteLine("you came across an " + enemyName);
                        Console.WriteLine("the " + enemyName + " is attacking you, what will you do?");
                        Console.WriteLine("(A)Attack (B)Heal (C)Energize (D)Run");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "a")
                        {
                            if (Player.energy >= 2)
                            {
                                EnemyHealth -= Player.damage;
                                Player.energy -= 2;

                                Console.WriteLine("the enemy now has " + EnemyHealth + " health left.");
                                Console.WriteLine("your energy dropped to " + Player.energy);
                                Console.ReadKey();
                                Console.Clear();
                                if (EnemyHealth > 0)
                                {
                                    playerTurn = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough energy to attack.");
                                Console.ReadKey();
                            }

                        }
                        else if (choice == "b")
                        {
                            Player.Heal();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "c")
                        {
                            Player.Energize();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "d")
                        {
                            Player.Run();
                        }
                        else
                        {
                            Console.WriteLine("That isn't an option.");
                            Console.WriteLine("get back to the fight.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    if (playerTurn == false)
                    {
                        Console.WriteLine("the " + enemyName + " damaged you for " + EnemyDamage + " damage.");
                        Player.health -= EnemyDamage;
                        Console.WriteLine("you now have " + Player.health + " health left.");
                        Console.ReadKey();
                        Console.Clear();
                        playerTurn = true;
                    }
                }
                if (EnemyHealth <= 0 && Player.health > 0)
                {
                    fight = false;
                    Player.BattleRewards();
                    Player.Levelen();
                    GamePlay.MainArea();
                }
                if (Player.health <= 0)
                {
                    Player.Death();
                }
                Console.ReadKey();
                Console.Clear();
                Player.Levelen();
            }
            Console.ReadKey();
            Console.Clear();
            Player.Levelen();
        }

        public static void Caverns()
        {
            //deze function gebruikt een random om te genereren welke enemy je tegenover je krijgt om tegen te vechten. en hij voert een check uit of je in een gevecht komt of niet.
            //je kunt alleen tegenover een bepaalde selectie aan enemies komen die alleen in de caverns komt.
            int EnemyChoice;
            int EnemyEncounter;

            Random rnd = new Random();

            EnemyChoice = rnd.Next(1, 6);

            EnemyEncounter = rnd.Next(1, 3);

            Console.WriteLine("After a long journey you have arrived at the caverns.");
            Console.WriteLine("you start wandering through the caverns in search of loot.");
            Console.ReadKey();
            Console.Clear();

            switch (EnemyChoice)
            {
                case 1:
                    enemyName = "Slimey Phantasms";
                    break;
                case 2:
                    enemyName = "Crystalline Spearforms";
                    break;
                case 3:
                    enemyName = "Shadow Trackers";
                    break;
                case 4:
                    enemyName = "Gloomstone Gorgons";
                    break;
                case 5:
                    enemyName = "Cavern Serpentids";
                    break;
            }

            switch (EnemyEncounter)
            {
                case 1:
                    Console.WriteLine("you explored for a while and found some loot.");
                    Player.ExplorationFinds();
                    Player.Levelen();
                    break;
                case 2:
                    CavernFight();
                    break;
            }
        }

        public static void CavernFight()
        {
            //deze function gaat over het gevecht. hierin kun je keuzes maken of je wil aanvallen, weg rennen, healen of energie op doen. het gevecht eindigt als de enemy dood is of de speler dood is.
            //de statistieken van de enemies word elk gevecht random gegenereerd.
            Random rnd = new Random();

            bool fight = true;
            int EnemyHealth = rnd.Next(50, 61);
            int EnemySpeed = rnd.Next(5, 21);
            int EnemyDamage = rnd.Next(5, 7);

            if (EnemySpeed <= Player.speed)
            {
                playerTurn = true;
            }
            else
            {
                playerTurn = false;
            }

            while (fight == true)
            {
                while (EnemyHealth > 0 && Player.health > 0)
                {
                    if (playerTurn == true)
                    {
                        Console.WriteLine("you came across an " + enemyName);
                        Console.WriteLine("the " + enemyName + " is attacking you, what will you do?");
                        Console.WriteLine("(A)Attack (B)Heal (C)Energize (D)Run");
                        string choice = Console.ReadLine().ToLower();
                        if (choice == "a")
                        {
                            if (Player.energy >= 2)
                            {
                                EnemyHealth -= Player.damage;
                                Player.energy -= 2;

                                Console.WriteLine("the enemy now has " + EnemyHealth + " health left.");
                                Console.WriteLine("your energy dropped to " + Player.energy);
                                Console.ReadKey();
                                Console.Clear();
                                if (EnemyHealth > 0)
                                {
                                    playerTurn = false;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You don't have enough energy to attack.");
                                Console.ReadKey();
                            }

                        }
                        else if (choice == "b")
                        {
                            Player.Heal();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "c")
                        {
                            Player.Energize();
                            Console.ReadKey();
                            Console.Clear();
                            playerTurn = false;

                        }
                        else if (choice == "d")
                        {
                            Player.Run();
                        }
                        else
                        {
                            Console.WriteLine("That isn't an option.");
                            Console.WriteLine("get back to the fight.");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    if (playerTurn == false)
                    {
                        Console.WriteLine("the " + enemyName + " damaged you for " + EnemyDamage + " damage.");
                        Player.health -= EnemyDamage;
                        Console.WriteLine("you now have " + Player.health + " health left.");
                        Console.ReadKey();
                        Console.Clear();
                        playerTurn = true;
                    }
                }
                if (EnemyHealth <= 0 && Player.health > 0)
                {
                    fight = false;
                    Player.BattleRewards();
                    Player.Levelen();
                    GamePlay.MainArea();
                }
                if (Player.health <= 0)
                {
                    Player.Death();
                }
                Console.ReadKey();
                Console.Clear();
                Player.Levelen();
            }
            Console.ReadKey();
            Console.Clear();
            Player.Levelen();
        }
    }
}
