using System;
using System.Collections.Generic;

namespace FightSim
{
    class Program
    {
        static void Main(string[] args)
        {
            Fighter f1 = new Fighter();
            Fighter f2 = new Fighter();

            int isPlaying = 1;

            SetName(f1);
            SetName(f2);
            AsciiArt(f1, f2);

            //CHOOSE WEAPON BEFORE DETERMINING DAMAGE
            ChooseWeapon(f1);
            ChooseWeapon(f2);

            f1.FighterWeaponDamage(f1);
            f2.FighterWeaponDamage(f2);

            Console.WriteLine($"{f1.name} picked the {f1.equipped}");
            Console.WriteLine($"It has {f1.w.weaponDmg} max damage");

            while (f1.GetAlive() && f2.GetAlive())
            {
                isPlaying = GetPlayerChoices(isPlaying, f1, f2);
            }

            WhoDied(f1, f2);

            Console.ReadLine();
        }

        static void WhoDied(Fighter f1, Fighter f2)
        {
            if (!f1.GetAlive())
            {
                System.Console.WriteLine($@"
                {f1.name} was defeated by {f2.name}");
            }
            if (!f2.GetAlive())
            {
                System.Console.WriteLine($@"
                {f2.name} was defeated by {f1.name}");
            }
        }

        static void SwitchCurrentPlayer(int current)
        {
            if (current == 1)
            {
                current = 2;
            }
            else if (current == 2)
            {
                current = 1;
            }
        }

        static int GetPlayerChoices(int currentFighter, Fighter f1, Fighter f2)
        {
            System.Console.WriteLine(currentFighter);
            if (currentFighter == 1)
            {
                Choices(f1, f2);
                currentFighter = 2;
            }
            else if (currentFighter == 2)
            {
                Choices(f2, f1);
                currentFighter = 1;
            }
            System.Console.WriteLine(currentFighter);
            SwitchCurrentPlayer(1);

            return currentFighter;
        }

        static void SetName(Fighter f)
        {
            Console.Write(@$"
                You are Player 1. 
                What is your name champion?
                ");
            f.name = Console.ReadLine();
            Console.Write(@$"
                

                                       Welcome to the arena {f.name}.");
        }

        static void ChooseWeapon(Fighter f)
        {
            string answer;
            Console.WriteLine("Pick your weapon, bow or sword");
            answer = Console.ReadLine();

            if (answer.ToLower() == "bow")
            {
                f.equipped = "bow";
            }
            else if (answer.ToLower() == "sword")
            {
                f.equipped = "sword";
            }
        }

        static void Choices(Fighter f, Fighter target)
        {
            string answer;
            bool validSyntax = false;

            while (!validSyntax)
            {
                Console.Write(@$"
                [ATTACK]            [HEAL]          [DO NOTHING]
                ");

                answer = Console.ReadLine();

                if (answer.ToLower() == "attack")
                {
                    f.Attack(target);
                    validSyntax = true;
                }
                else if (answer.ToLower() == "heal")
                {
                    System.Console.WriteLine("i have not programmed healing yet but lets say that you 'healed'");
                    validSyntax = true;
                }
                else if (answer.ToLower() == "do nothing")
                {
                    System.Console.WriteLine("you chose to do nothing");
                    validSyntax = true;
                }
                else
                {
                    System.Console.WriteLine("Enter a valid syntax.");
                }
            }
        }

        static void AsciiArt(Fighter f1, Fighter f2)
        {
            Console.Write(@$"


                                    {f1.name}:        {f2.name}:
                                             O                 0
                                            /|\               /|\
                                            / \               / \ 
                                            
                ");
        }
    }
}
