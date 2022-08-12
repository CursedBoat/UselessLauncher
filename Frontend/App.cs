namespace UselessLauncher.FrontEnd
{
    using UselessLauncher.Backend;
    using Terminal.Gui;
    using NStack;

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
            top.Add( App.Menu() );

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
            top.Add( App.Menu() );

            var goBack = new Button(3, 14, "<- Go back");
            goBack.Clicked += () => { Application.Shutdown(); Application.Run( App.MainMenu() ); };

            win.Add(
                goBack,
                
                new Label(3, 1, @"Under development lol"),
                new Label(3, 18, "Press F9 or ESC plus 9 to activate the menubar!")
            );

            // I think this is how we add the games
            for (int i = 3; i < 6; i++){
                int index = i - 2;
                var game = new Button(3, i, $"Hypothetical Game {index.ToString()}");
                game.Clicked += () => { MessageBox.Query(76, 15, "Ayo", "Did it just work??!??!?!?$!3215315", "OK"); };

                win.Add(
                    game
                );
            }

            return top;
        }

        public static MenuBar Menu(){
            var menu = new MenuBar(new MenuBarItem[] {
                        new MenuBarItem ("_File", new MenuItem [] {
                            new MenuItem ("_Open Notepad", "Opens... notepad", () => { System.Diagnostics.Process.Start("notepad.exe"); } ),                           
                            new MenuItem ("_Quit", "", () => { if ( Quit() ) Application.Shutdown(); }),
                            new MenuItem ("_Info", "" , () => { InfoDialog(); })
                        }),
                    });
            
            static bool Quit()
            {
                var n = MessageBox.Query(50, 7, "Quit Demo", "Are you sure you want to quit this demo?", "Yes", "No");
                return n == 0;
            }

            static bool InfoDialog(){
                var n = MessageBox.Query(76, 15, "Info", Variables.Art.Banner(true), "OK");
                return n == 0;
            }
            
            return menu;
        }
    }
    
}