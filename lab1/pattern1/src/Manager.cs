

namespace Managers{

/// <summary>
/// main class for manager
/// every manager can do 3 things:
/// do their main job, giving info AND stop talking with client.
/// 
/// all managers can register client in bank
/// </summary>
class Manager{
    public Bank BANK;
    public string desc = "A manager helps client to manage!";
    public string role = "none";
    public string GetInfo(){
        return "\n__________________\n" + "\nRole: " + role + "\n" + desc + "\n__________________\n";
    }

    public Manager(Bank B){
        BANK = B;
    }

    protected int RegisterClient(string name){
        int ret = BANK.AddClient(name);
        return ret;
    }
    public string ConsultClient(Clients.Client target){
        return "Consultation...\n";
    }
    public void TalkToClient(){
        Console.WriteLine("Manager: Hello, dude!");
        while(true){
            Console.WriteLine("Manager: What do u want? (main/info/bye)\nYou: ");
            string querry = Console.ReadLine();
            if(querry[0] == ManagerTask.main.ToString()[0]){
                taskMain();
            }
            else if(querry[0] == ManagerTask.info.ToString()[0]){
                taskInfo();
            }
            else if(querry[0] == ManagerTask.bye.ToString()[0]){
                taskBye();
                return;
            }
        }
    }

    ///<summary> do this manager's main job</summary>
    protected virtual void taskMain(){
        Console.WriteLine("Manager: I can register you. What's your name?\nYou: ");
        string name = Console.ReadLine();
        RegisterClient(name);
    }
    protected virtual void taskInfo(){
        Console.WriteLine("Manager: Some general info about bank! Talk to credit manager to manage credit. Same with deposit manager.");
    }
    protected void taskBye(){
        Console.WriteLine("Manager: Ok bye.\n");
    }
}


    /// <summary>
    /// actions that manager can do
    /// </summary>
    enum ManagerTask{
        
        ///<summary> do this manager's main job</summary>
        main,
        info,
        bye
    }
}