
using Football;

//prototype
//Objects that will be duplicated -----------------------------------------
Player goalkeeper = new Player();
goalkeeper.position = PlayerPosition.goalkeeper;
goalkeeper.description = "The goalkeeper stands on the ally goal";

Player defender = new Player();
defender.position = PlayerPosition.defender;
defender.description = "The defender helps goalkeeper";

Player midfielder = new Player();
midfielder.position = PlayerPosition.midfielder;
midfielder.description = "The midfielder stands on the field's middle";

Player forward = new Player();
forward.position = PlayerPosition.forward;
forward.description = "The forward player used to attack enemy team";
//-------------------------------------------------------------------------

FTeam ourCmd = new FTeam("silly squad team");
ourCmd.PushCmdPlayer(goalkeeper.CopyPlayer("Sonia"));
ourCmd.PushCmdPlayer(forward.CopyPlayer("Dima (me))"));
ourCmd.PushCmdPlayer(forward.CopyPlayer("Dima"));
ourCmd.PushCmdPlayer(forward.CopyPlayer("Dima"));
ourCmd.PushCmdPlayer(goalkeeper.CopyPlayer("some reserve goalkeeper"));
ourCmd.PushCmdPlayer(midfielder.CopyPlayer("Sasha"));
ourCmd.PushCmdPlayer(midfielder.CopyPlayer("Nikita"));
ourCmd.PushCmdPlayer(midfielder.CopyPlayer("Pasha"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("Dania"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("Ania"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("Suren"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("a"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("b"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("c"));
ourCmd.PushCmdPlayer(defender.CopyPlayer("d"));

FTeam secondCmd = new FTeam("enemy team");
secondCmd.PushCmdPlayer(goalkeeper.CopyPlayer("Poor Goalkeeper T_T"));

Field f = new(ourCmd,secondCmd);
f.GetMatchInfo();