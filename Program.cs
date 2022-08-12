namespace Startup{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using static System.Console;
    using Terminal.Gui;
    using NStack;
    using UselessLauncher.FrontEnd;

    class Startup{
        public static void Main(string[] args){
            Application.Run( App.MainMenu($"UselessLauncher {Variables.ProgramInfo.Version()}") );
            //Test.Test.Interesting();
        }
    }
}