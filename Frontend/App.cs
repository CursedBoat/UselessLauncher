namespace UselessLauncher.FrontEnd
{
    using UselessLauncher.Backend;
    using Terminal.Gui;
    using NStack;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing the different screens
    /// </summary>
    class App {
        /// <summary>
        /// TopLevel function that returns the Main Menu.
        /// </summary>
        /// <param name="windowName">Window Name</param>
        /// <returns>Main Menu</returns>
        public static Toplevel MainMenu(string windowName = "UselessLauncher", string name = "MainMenu" )
        {
            

            Application.Init();

            var top = Application.Top;
            var win = new Window(windowName){
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            
            top.Add( win );
            top.Add( App.Menu( top ) );

            // Magic change titlebar button oooOooOo
            var titleButton = new Button(3, 14, "Magic change titlebar button oooOooOo");
            titleButton.Clicked += () => { Application.Shutdown(); Application.Run( App.MainMenu(":D") ); };

            // View library
            var viewLibrary = new Button(3, 8, "View library");
            viewLibrary.Clicked += () => { Application.Shutdown(); Application.Run( App.Library() ); };

            // Labels
            win.Add(
                titleButton, viewLibrary,

                new Label(3, 1, @" //*---------------------------------------------------*\\"),
                new Label(3, 2, $"||Welcome to UselessLauncher!! What would you like to do?||"),
                new Label(3, 3, @" \\*---------------------------------------------------*//"),
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar!")
            );

            return top;
        }

        public static Toplevel Library(string windowName = "Library", string name = "Library"){                 
            Application.Init();  
            var top = Application.Top;
            var win = new Window(windowName){
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            
            top.Add( win );
            top.Add( App.Menu( top ) );

            var goBack = new Button(3, 14, "<- Main Menu");
            goBack.Clicked += () => { Application.Shutdown(); Application.Run( App.MainMenu() ); };

            win.Add(
                goBack,
                
                new Label(3, 1, @"Under development lol"),
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar!")
            );

            string[] fileArray = Directory.GetFiles(@"Games\", "*.json");
            // I think this is how we add the games
            for (int i = 3; i < fileArray.Count() + 3; i++){
                int index = i - 2;
                string fileName = fileArray[index - 1];
                
                string json = File.ReadAllText(fileName);
                if ( json == "" || json == null ) { json = @"[{""gameName"":""Error: Bad file"",""absolutePath"":""Error""}]"; }

                GameData? _game = JsonConvert.DeserializeObject<GameData>( json.Substring(1, json.Length-2) );

                var game = new Button(3, i, _game.gameName );
                game.Clicked += () => {
                    //MessageBox.Query(76, 15, "Ayo", "Did it just work??!??!?!?$!3215315", "OK");
                    try{
                        if (_game.gameName == "Error: Bad file") { throw new Exception("Bad file"); }
                    }
                    catch{

                        if ( Error() ) { Application.Run( App.Library() ); }
                        
                        static bool Error()
                        {
                            var n = MessageBox.Query(15, 15, "Error", "JSON file empty or corrupted", "OK");
                            return n == 0;
                        }
                    }

                    try{
                        UselessLauncher.Backend.Commands.LaunchGame( fileName );
                    }
                    catch{

                        if ( Error() ) { Application.Run( App.Library() ); }
                        
                        static bool Error()
                        {
                            var n = MessageBox.Query(15, 15, "Error", "App directory possibly doesn't exist", "OK");
                            return n == 0;
                        }
                    } 
                };

                win.Add(
                    game
                );
            }

            return top;
        }

        public static Toplevel AddGame(string windowName = "Add a game", string name = "AddGame"){
            Application.Init();  
            var top = Application.Top;
            var win = new Window(windowName){
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            static bool Error(){
                var n = MessageBox.Query(15, 15, "Something went wrong", "Did you enter all the information correctly?", "OK");
                return n == 0;
            }
            
            var goBack = new Button(3, 14, "<- Main Menu");
            goBack.Clicked += () => { Application.Shutdown(); Application.Run( App.MainMenu() ); };

            top.Add( win );
            top.Add( App.Menu( top ) );

            var _name = new Label("Name: ") { X = 3, Y = 2 };
            var path = new Label("Absolute path: "){
                X = Pos.Left(_name),
                Y = Pos.Top(_name) + 1
            };
            var abbreviation = new Label("Abbreviation"){
                X = Pos.Left(path),
                Y = Pos.Top(path) + 1
            };
            var nameText = new TextField("")
            {
                X = Pos.Right(path),
                Y = Pos.Top(_name),
                Width = 40
            };
            var pathText = new TextField("")
            {
                X = Pos.Left(nameText),
                Y = Pos.Top(path),
                Width = Dim.Width(nameText)
            };
            var abbreviationText = new TextField(""){
                X = Pos.Left(pathText),
                Y = Pos.Top(abbreviation),
                Width = Dim.Width(pathText)
            };

            var addGame = new Button( 3, 6, "Add the game" );
            addGame.Clicked += () => {
                try{
                    if (abbreviationText.Text.ToString() == "" || nameText.Text.ToString() == "" || pathText.Text.ToString() == ""){
                        throw new Exception("invalid arguments");
                    }
                    
                    Commands.CreateGameDB( abbreviationText.Text.ToString() );
                    Commands.CreateGameEntry( abbreviationText.Text.ToString(),  nameText.Text.ToString(), pathText.Text.ToString() );
                }
                catch{
                    if ( Error() ) { Application.Run( App.AddGame() ); }
                }
                MessageBox.Query(76, 15, "Success!", "The game has been added.", "OK");
            };

            win.Add(
                goBack, _name, path, abbreviation, nameText, pathText, abbreviationText, addGame
            );

            return top;
        }

        public static MenuBar Menu(Toplevel top){
            var menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_File", new MenuItem [] {
                            new MenuItem ("_Info", "" , () => { InfoDialog(); }),
                            new MenuItem ("_Quit", "", () => { if ( Quit() ) top.RequestStop(); }),
                            new MenuItem ("_Add Game", "", () => { if ( Confirm("add a game") ) Application.Shutdown(); Application.Run( App.AddGame() ); } )
                        }),
                    });
            
            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            static bool Confirm( string confirmWhat )
            {
                var n = MessageBox.Query(50, 7, "Confirm", $"Are you sure you want to {confirmWhat}?", "Yes", "No");
                return n == 0;
            }

            static bool InfoDialog(){
                var n = MessageBox.Query(76, 25, "Info", Variables.Art.Banner(true), "OK");
                return n == 0;
            }

            
            
            return menu;
        }
    }
    
}