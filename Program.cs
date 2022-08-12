namespace Startup{
    using Terminal.Gui;
    using UselessLauncher.FrontEnd;
    using UselessLauncher.Backend;
    using Newtonsoft.Json;

    class Startup{
        public static void Main(string[] args){
            Application.Run( App.MainMenu($"UselessLauncher {Variables.ProgramInfo.Version()}") );
            Application.Shutdown();
            //Test.Test.Interesting();
            //UselessLauncher.Backend.Commands.CreateGameDB("CCode");
            //UselessLauncher.Backend.Commands.CreateGameEntry("CCode", "CrossCode", @"D:\Video Games\CrossCode\CrossCode.exe");
            
        }
    }
}