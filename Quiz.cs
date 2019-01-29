using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using project_stub.Models;

namespace project_stub {

    public class Quiz {
        public List<Question> Questions { get; set; }
        public List<Country> Countries { get; set; }
        public int Score { get; set; } = 0;
        public string Player { get; set; }
        public int Mode { get; set; }

        public Quiz() {
            Questions = new List<Question>();

        }

        /*
         * Shuffle the elements of a list of Country objects
         *
         * @param {List<Country>} list to be shuffled
         */
        public void Shuffle(List<Country> list) {
            Random rng = new Random();
            int size = list.Count;
            while (size > 1) {
                size--;
                int random = rng.Next(size + 1);
                Country temp = list[random];
                list[random] = list[size];
                list[size] = temp;
            }
        }

        public void Start() {

            foreach (var question in Questions) {
                if (Mode == 1) {
                    Console.Clear();
                    Console.WriteLine($"Name: {Player}");
                    Console.WriteLine("Guess the country name:");
                    Console.WriteLine($"{question.Answer.Alpha_2} - {question.Answer.Capital}");
                    Console.WriteLine("Choices:");

                    foreach(var choice in question.Choices) {
                        Console.WriteLine($"{choice.Name}");
                    }

                    var pick = Console.ReadLine();
                    if (pick == question.Answer.Name) {
                        Score += 10;
                        Console.WriteLine("Correct");
                        Console.ReadLine();
                    } else {
                        Console.WriteLine("False");
                        Console.ReadLine();
                    }

                } else if (Mode == 2) {
                    Console.Clear();
                    Console.WriteLine($"Name: {Player}");
                    Console.WriteLine("Guess the flag:");
                    Console.WriteLine($"{question.Answer.Name} - {question.Answer.Capital}");
                    Console.WriteLine("Choices:");

                    foreach(var choice in question.Choices) {
                        Console.WriteLine($"{choice.Alpha_2}");
                    }

                    var pick = Console.ReadLine();
                    if (pick == question.Answer.Alpha_2) {
                        Score += 10;
                        Console.WriteLine("Correct");
                        Console.ReadLine();
                    } else {
                        Console.WriteLine("False");
                        Console.ReadLine();
                    }

                } else {
                    Console.Clear();
                    Console.WriteLine($"Name: {Player}");
                    Console.WriteLine("Guess the Capital:");
                    Console.WriteLine($"{question.Answer.Name} - {question.Answer.Alpha_2}");
                    Console.WriteLine("Choices:");

                    foreach(var choice in question.Choices) {
                        Console.WriteLine($"{choice.Capital}");
                    }

                    var pick = Console.ReadLine();
                    if (pick == question.Answer.Capital) {
                        Score += 10;
                        Console.WriteLine("Correct");
                        Console.ReadLine();
                    } else {
                        Console.WriteLine("False");
                        Console.ReadLine();
                    }
                }
            }
        }

    }
}
