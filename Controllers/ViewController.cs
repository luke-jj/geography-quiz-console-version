using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using project_stub.Data;
using project_stub.Models;
using project_stub.Views;
using project_stub.ViewModels;

namespace project_stub.Controllers {

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
            Random rng = new Random();

            quiz.Countries = _viewModel.context.countries;
            quiz.Shuffle(quiz.Countries);

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

            for (int i = 0; i < 10; i++) {
                var answer = quiz.Countries[i];
                var choices = new List<Country>();

                choices.Add(answer);

                for (int j = 0; j < 3; j++) {
                    int random = rng.Next(10, quiz.Countries.Count - 2);
                    choices.Add(quiz.Countries[random]);
                }

                quiz.Shuffle(choices);
                var question = new Question(answer, choices);
                quiz.Questions.Add(question);
            }

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

            if (_viewModel.validateUsername(username)) {
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
    }
}
