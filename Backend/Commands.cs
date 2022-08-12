namespace UselessLauncher.Backend{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;

    /// <summary>
    /// Class containing the different backend commands
    /// </summary>
    class Commands{
        /// <summary>
        /// Repeat x times
        /// </summary>
        /// <param name="count">Number of times to repeat</param>
        /// <param name="action">Action to repeat</param>
        public static void Repeat(int count, Action action){
            for (int i = 0; i < count; i++){
                action();
            }
        }
        
        /// <summary>
        /// Launches the game
        /// </summary>
        /// <param name="name">Directory of the JSON file</param>
        public static void LaunchGame(string name){
            string json = File.ReadAllText(name);
            GameData? game = JsonConvert.DeserializeObject<GameData>( json.Substring(1, json.Length-2) );
            System.Diagnostics.Process.Start(game.absolutePath);
        }

        /// <summary>
        /// Initializes the JSON database for the game
        /// </summary>
        /// <param name="name">Name of the game</param>
        public static void CreateGameDB(string name){
            System.IO.Directory.CreateDirectory("Games");
            using (StreamWriter w = File.AppendText($"Games/{name}.json")) {}
        }

        /// <summary>
        /// Creates the game entry
        /// </summary>
        /// <param name="name">Abbreviated game name</param>
        /// <param name="gameName">Long game name</param>
        /// <param name="absolutePath">Absolute path to the game</param>
        public static void CreateGameEntry(string name, string gameName, string absolutePath){
            List<GameData> _data = new List<GameData>();
            _data.Add(new GameData()
            {
                gameName = gameName,
                absolutePath = absolutePath,
            });

            using (StreamWriter file = File.CreateText(@$"Games/{name}.json")){
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, _data);
            }
        }
    }

    /// <summary>
    /// Object containing the game data
    /// </summary>
    public class GameData{
        public string? gameName { get; set; }
        public string? absolutePath { get; set; }
    }
    }