namespace Variables{
    class ProgramInfo{
        public static string Version(){
            return "0.0b1";
        }
    }
    class Art{
        public static string Banner(bool withInfo = false) { 
            if (withInfo == false) {return @" 
 _    _          _               _                            _               
| |  | |        | |             | |                          | |              
| |  | |___  ___| | ___  ___ ___| |     __ _ _   _ _ __   ___| |__   ___ _ __ 
| |  | / __|/ _ \ |/ _ \/ __/ __| |    / _` | | | | '_ \ / __| '_ \ / _ \ '__|
| |__| \__ \  __/ |  __/\__ \__ \ |___| (_| | |_| | | | | (__| | | |  __/ |   
 \____/|___/\___|_|\___||___/___/______\__,_|\__,_|_| |_|\___|_| |_|\___|_|   ";
            }
            else{return @" 
 _    _          _               _                            _               
| |  | |        | |             | |                          | |              
| |  | |___  ___| | ___  ___ ___| |     __ _ _   _ _ __   ___| |__   ___ _ __ 
| |  | / __|/ _ \ |/ _ \/ __/ __| |    / _` | | | | '_ \ / __| '_ \ / _ \ '__|
| |__| \__ \  __/ |  __/\__ \__ \ |___| (_| | |_| | | | | (__| | | |  __/ |   
 \____/|___/\___|_|\___||___/___/______\__,_|\__,_|_| |_|\___|_| |_|\___|_|   
                                                    (C) 2022 SNTHE/CursedBoat

// How to use \\
----------------

Select File>Add Game to start adding games.


Remember to NOT mess around with the Games folder in the directory that the 
executable lives in.

This is the 'database' that the game information lives in


Still in very very very early stages of development.
Expect loads of bugs.";
            }        
        }
    }
}