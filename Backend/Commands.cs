namespace UselessLauncher.Backend{
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    class Commands{
        public static void Repeat(int count, Action action){
            for (int i = 0; i < count; i++){
                action();
            }
        }

        public static void LaunchGame(string name){
            //string json = File.ReadAllText(@$"Games\{name}.json");
            string json = File.ReadAllText(name);
            GameData? game = JsonConvert.DeserializeObject<GameData>( json.Substring(1, json.Length-2) );
            System.Diagnostics.Process.Start(game.absolutePath);
        }

        public static void CreateGameDB(string name){
            System.IO.Directory.CreateDirectory("Games");
            using (StreamWriter w = File.AppendText($"Games/{name}.json")) {}
        }

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

    public class GameData{
        public string? gameName { get; set; }
        public string? absolutePath { get; set; }
    }
    }