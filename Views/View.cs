using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using project_stub.Models;
using project_stub.Data;

namespace project_stub.Views {

    public class View {
        private string _prompt = " >  ";

        public void DrawMainMenu(string notification = "") {
            Console.Clear();
            Console.WriteLine("Welcome To The Quiz Game");
            Console.WriteLine("------------------------");
            Console.WriteLine("SHOW highscores");
            Console.WriteLine("SHOW PLAYERNAME highscores");
            Console.WriteLine("START new quiz");
            Console.WriteLine("QUIT quiz game");
            Console.WriteLine(notification);
            Console.Write(_prompt);
        }

        public void DrawNewQuizUsernameScreen(string notification = "") {
            Console.Clear();
            Console.WriteLine("Preparing a new quiz ...");
            Console.WriteLine("Enter username:");
            Console.WriteLine(notification);
            Console.Write(_prompt);
        }

        public void DrawNewQuizModeScreen(string notification = "") {
            Console.Clear();
            Console.WriteLine("Preparing a new quiz ...");
            Console.WriteLine("Choose your quiz mode (1 2 3):");
            Console.WriteLine("1 - Guess the country name");
            Console.WriteLine("2 - Guess the flag");
            Console.WriteLine("3 - Guess the captial");
            Console.WriteLine(notification);
            Console.Write(_prompt);
        }

        public void DrawHighscores(IEnumerable<Highscore> scores) {
            foreach (var score in scores) {
                Console.WriteLine($"{score.PlayerName} - {score.Score}");
            }
        }
    }
}
