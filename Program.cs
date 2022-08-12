namespace Startup{
    using Terminal.Gui;
    using UselessLauncher.FrontEnd;
    using UselessLauncher.Backend;
    using Newtonsoft.Json;

    class Startup{
        public static void Main(string[] args){
            // Runs the program
            Application.Run( App.MainMenu($"UselessLauncher {Variables.ProgramInfo.Version()}") );
            Application.Shutdown(); 
        }
    }
}