using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_stub.Models {

    public class Country {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Alpha_2 { get; set; }
        public string Alpha_3 { get; set; }
        public string Capital { get; set; }

        public Country(
                int id,
                string name,
                string alpha_2,
                string alpha_3,
                string capital) {
            Id = id;
            Name = name;
            Alpha_2 = alpha_2;
            Alpha_3 = alpha_3;
            Capital = capital;
        }

        public override string ToString() {
            return $"{Id}, {Name}, {Alpha_2}, {Alpha_3}, {Capital}";
        }
    }

}

