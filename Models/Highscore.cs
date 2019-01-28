using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_stub.Models {

    public class Highscore {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public Highscore(int id, string playerName, int score) {
            Id = id;
            PlayerName = playerName;
            Score = score;
        }

        public override string ToString() {
            return $"{Id}, {PlayerName}, {Score}";
        }
    }
}

