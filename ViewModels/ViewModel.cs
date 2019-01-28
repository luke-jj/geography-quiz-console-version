using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using project_stub.Models;
using project_stub.Data;

namespace project_stub.ViewModels {

    public class ViewModel {
        public Context context;

        public ViewModel(Context context) {
            this.context = context;
        }

        /*
         * Return true if username consists of alphanumeric characters, may
         * also contain underscore or hypen, except for beginning and end of
         * name.
         *
         * @param {string} the username to be tested
         * @return {bool} true or false
         */
        public bool validateUsername(string username) {
            Regex rx = new Regex(@"^[A-Za-z0-9]+(?:[_-][A-Za-z0-9]+)*$");
            return rx.IsMatch(username) ? true : false;
        }
    }
}
