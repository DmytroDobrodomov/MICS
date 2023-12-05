namespace Football{
    public class FTeam{
        List<Player> players;
        public string teamName;


        public FTeam(string name){
            players = new List<Player>();
            teamName = name;
        }

        public void PushTeamPlayer(Player player){
            //a command can't have more than one goalkeeper OR more than 11 players
            //all additional players will be in reserve
            if((player.position == PlayerPosition.goalkeeper && HasGoalkeeper())||(players.Count>=11)){
                player.reservePlayer = true;
            }
            players.Add(player);
        }

        public bool HasGoalkeeper(){
            foreach(Player pl in players){
                if(pl.position == PlayerPosition.goalkeeper) return true;
            }
            return false;
        }
        public void GetMembers(){
            Console.WriteLine("Command name: "+teamName);
            foreach(Player i in players){
                if(!i.reservePlayer) Console.WriteLine(i.name+": "+i.position.ToString());
                else Console.WriteLine(i.name+": (in reserve)");
            }
        }
    }

    public class Field{
        public FTeam team1;
        public FTeam team2;

        public Field(FTeam t1, FTeam t2){
            team1 = t1;
            team2 = t2;
        }

        public void GetMatchInfo(){
            Console.WriteLine("We have 2 teams:");
            team1.GetMembers();
            Console.WriteLine("___________________");
            team2.GetMembers();
        }


    }


}