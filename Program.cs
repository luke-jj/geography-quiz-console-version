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

using project_stub.Controllers;
using project_stub.Data;
using project_stub.Models;
using project_stub.Views;
using project_stub.ViewModels;

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
}

