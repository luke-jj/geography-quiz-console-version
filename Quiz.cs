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
    }
}
