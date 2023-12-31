

namespace Football
{
    public enum PlayerPosition{
        goalkeeper,
        defender,
        midfielder,
        forward
    }

/// <summary>
/// player on the field
/// can be duplicated to make a prototype pattern
/// </summary>
    public class Player
    {
        public string name = "unknown";
        public PlayerPosition position;
        public string description = "no description";
        public bool reservePlayer = false;

    /// <summary>
    /// this function clones player (without name)
    /// </summary>
    /// <returns>new Player</returns>
        public Player CopyPlayer(string newName){
            Player ret = new();
            ret.name = newName;
            ret.position =  position;
            ret.description = description;
            return ret;
        }


        public void GetPlayerInfo(){
            Console.WriteLine("Name: " + name + "\tposition:" + position + "\n" + description+"\n");
        }


    }
}