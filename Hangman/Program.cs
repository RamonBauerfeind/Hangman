using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            while (true)
            {
                int action;
                bool end = false;

                Console.WriteLine("### HANGMAN ###");
                Console.WriteLine("###############");
                Console.WriteLine();
                Console.WriteLine("Wähle eine Aktion aus :");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("[1] Spielen");
                Console.WriteLine("[2] Beenden");
                Console.ResetColor();
                Console.WriteLine();
                Console.Write("Aktion : ");
                action = Convert.ToInt32(Console.ReadLine());

                switch (action)
                {
                    case 1:
                        StartGame();
                        break;
                    case 2:
                        end = true;
                        break;
                }

                if (end == true)
                {
                    break;
                }

                Console.Clear();
            }
        }

        static void StartGame()
        {
            int index;
            string word;

            string[] words = new string[]
            {
                "Apfelkuchen",
                "Gemüsesuppe",
                "Kraftfahrzeug",
                "Lastwagen",
                "Videospiel",
                "Alarmanlage",
                "Vollkornbrot"
            };

            Random rnd = new Random();
            index = rnd.Next(0, words.Length);
            word = words[index].ToLower();

            GameLoop(word);
        }

        static void GameLoop(string word)
        {
            int lives = 10;
            string hiddenWord = "";
            string tempHiddenWord;

            for(int i = 0; i < word.Length; i++)
            {
                hiddenWord += "_";
            }

            while(true)
            {
                char character;
                bool foundCharacterInWord = false;

                Console.Clear();
                Console.WriteLine("Gesuchtes Wort : " + hiddenWord);
                Console.Write("Noch übrige Versuche : ");

                for(int i = 0; i < lives; i++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("X");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.Write("Buchstabe : ");
                character = Convert.ToChar(Console.ReadLine().ToLower());

                for(int i = 0; i < word.Length; i++)
                {
                    if(word[i] == character)
                    {
                        foundCharacterInWord = true;
                        break;
                    }
                }

                tempHiddenWord = hiddenWord;
                hiddenWord = "";

                if(foundCharacterInWord)
                {
                    for(int i = 0; i < word.Length; i++)
                    {
                        if(word[i] == character)
                        {
                            hiddenWord += character;
                        }
                        else if(tempHiddenWord[i] != '_')
                        {
                            hiddenWord += tempHiddenWord[i];
                        }
                        else
                        {
                            hiddenWord += '_';
                        }
                    }

                    if (hiddenWord == word)
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Gewonnen!!!");
                        Console.WriteLine("Das Wort war : " + word);
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
                else
                {
                    hiddenWord = tempHiddenWord;

                    if(lives > 1)
                    {
                        lives -= 1;
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Game Over!!!");
                        Console.ReadKey();
                        Console.ResetColor();
                        break;
                    }
                }
            }
        }
    }
}
