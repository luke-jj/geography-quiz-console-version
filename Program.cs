/**
 * Summary. (use period)
 *
 * Description. (use period)
 *
 * @link   URL
 * @file   This files defines the MyClass class.
 * @author Luca J
 * @since  2019-01-28
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using project_stub.Models;

namespace project_stub {

    public class Program {

        public static void Main(string[] args) {
            StartGame();
        }

        public static void StartGame() {
            var controller = new ViewController(
                    new View(),
                    new ViewModel(new Context()));
            controller.StartMainMenu();
        }
    }

    /*
     * EventObject is used to store information about an event and pass it to
     * other processes.
     */
    public class EventObject {
        public string EventType { get; set; }
        public string EventContents { get; set; }
        public object EventStore { get; set; }
    }

    /*
     * This class controls the current view, its associated viewmodel, and
     * exposes an API of relevant user controls.
     */
    public class ViewController {
        private View _view;
        private ViewModel _viewModel;

        public ViewController(View view, ViewModel viewModel) {
            _view = view;
            _viewModel = viewModel;
        }

        /*
         * Listen for user actions and return an event object containing
         * information about the event.
         *
         * @return {EventObject} object holding information about a user event.
         */
        private EventObject listenForEvent() {
            EventObject e = new EventObject();
            e.EventType = "user";
            e.EventContents = Console.ReadLine();

            return e;
        }

        /*
         * Start the main menu.
         */
        public void StartMainMenu() {
            while(true) {
                _view.DrawMainMenu();
                processMainMenuInput(listenForEvent());
            }
        }

        /*
         * Start a new quiz.
         */
        public void StartNewQuiz() {
            Quiz quiz = new Quiz();
            _view.DrawNewQuizUsernameScreen();

            try {
                processNewUserName(listenForEvent(), quiz);
            } catch (ArgumentException ae) {
                _view.DrawNewQuizUsernameScreen(ae.Message);
                listenForEvent();
                return;
            }

            _view.DrawNewQuizModeScreen();

            try {
                processQuizMode(listenForEvent(), quiz);
            } catch (ArgumentException ae) {
                _view.DrawNewQuizModeScreen(ae.Message);
                listenForEvent();
                return;
            }
            // Console.WriteLine($"{quiz.Mode} {quiz.Player}");
            // listenForEvent();
        }

        private void processMainMenuInput(EventObject e) {
            var format = e.EventContents.ToLower().Trim();

            if (format == "show") {
                // TODO: request scores from viewmodell and return highscores
            } else if (format.Contains("show")) {
                var playername = format.Split(" ")[1];
                // TODO: search for player name and return his highscores
            } else if (format == "start") {
                StartNewQuiz();
            } else if (format == "quit" || format == "exit") {
                Environment.Exit(0);
            } else {
                // TODO: return invalid input
            }
        }

        private void processNewUserName(EventObject e, Quiz quiz) {
            var username = e.EventContents.Trim().ToUpper();

            if (validateUsername(username)) {
                quiz.Player = username;
            } else {
                throw new ArgumentException("Username may only contain alphanumeric characters, a hyphen or underscore and must not start with or end in a hyphen or underscore.");
            }
        }

        private void processQuizMode(EventObject e, Quiz quiz) {
            var quizMode = e.EventContents.Trim();

            if (quizMode == "1") {
                quiz.Mode = 1;
            } else if (quizMode == "2") {
                quiz.Mode = 2;
            } else if (quizMode == "3") {
                quiz.Mode = 3;
            } else {
                throw new ArgumentException("Not a valid quiz mode choice");
            }
        }

        /*
         * Return true if username consists of alphanumeric characters, may
         * also contain underscore or hypen, except for beginning and end of
         * name.
         *
         * @param {string} the username to be tested
         * @return {bool} true or false
         */
        private bool validateUsername(string username) {
            Regex rx = new Regex(@"^[A-Za-z0-9]+(?:[_-][A-Za-z0-9]+)*$");
            return rx.IsMatch(username) ? true : false;
        }
    }


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
            Console.WriteLine("1 - Guess the country");
            Console.WriteLine("2 - Guess the flag");
            Console.WriteLine("3 - Guess the captial");
            Console.WriteLine(notification);
            Console.Write(_prompt);
        }

        public void DrawHighScores(string[] scores) {
            // TODO: finish after database interaction is complete
        }
    }


    public class ViewModel {
        public Context context;

        public ViewModel(Context context) {
            context = context;
        }
    }


    public class Context {
        public List<Country> countries { get; set; }

        public Context() {
            countries = new List<Country>();
        }

        public void SaveToDatabase() {
        }

        public void ReadFromDatabase() {
        }
    }

    public class Quiz {
        public Question[] Questions { get; set; }
        public int Score { get; set; } = 0;
        public string Player { get; set; }
        public int Mode { get; set; }
    }

    public class Question {
    }
}

namespace project_stub.Models {

    public class Country {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public string Flagdescription { get; set; }

        public Country(int id,
                       string name,
                       string capital,
                       string flagdescription) {
            Id = id;
            Name = name;
            Capital = capital;
            Flagdescription = flagdescription;
        }
    }
}
