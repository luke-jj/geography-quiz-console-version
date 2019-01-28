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
using System.Threading.Tasks;

namespace project_stub
{
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
     * This class controls the current view its associated viewmodel, and
     * exposes an API .
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
         * @return {EventObject} object containing info about a user event
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
            _view.DrawNewQuizScreen("Enter username:");
            processNewUserName(listenForEvent());
            // TODO: continue here
        }

        private void processMainMenuInput(EventObject e) {
            var format = e.EventContents.ToLower().Trim();
            if (format == "show") {
                // request scores from viewmodell and return highscores
            } else if (format.Contains("show")) {
                var playername = format.Split(" ")[1];
                // search for player name and return his highscores
            } else if (format == "start") {
                StartNewQuiz();
            } else if (format == "quit" || format == "exit") {
                Environment.Exit(0);
            } else {
                // return invalid input
            }
        }

        private void processNewUserName(EventObject e) {
            // TODO: finish this bad boy
        }
    }


    public class View {
        private string _prompt = " >  ";

        public void DrawMainMenu() {
            Console.Clear();
            Console.WriteLine("Welcome To The Quiz Game");
            Console.WriteLine("------------------------");
            Console.WriteLine("SHOW highscores");
            Console.WriteLine("SHOW PLAYERNAME highscores");
            Console.WriteLine("START new quiz");
            Console.WriteLine("QUIT quiz game");
            Console.Write(_prompt);
        }

        public void DrawNewQuizScreen(string notification) {
            Console.Clear();
            Console.WriteLine("Preparing a new quiz ...");
            Console.WriteLine(notification);
            Console.Write(_prompt);
        }

        public void DrawHighScores(string scores) {
            // TODO: finish after database interaction is complete
        }
    }


    public class ViewModel {
        private Context _context;

        public ViewModel(Context context) {
            _context = context;
        }
    }


    public class Context {
    }

    public class Quiz {
        public Question[] Questions { get; set; }
        public int Score { get; set; }

        public Quiz(int score) {
            Score = score;
        }
    }

    public class Question {
    }
}
