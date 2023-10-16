

namespace Managers{
    
class Manager{
    public Bank bank;
    public string desc = "A manager helps client to manage!";
    public string role = "none";
    public string GetInfo(){
        return "\n__________________\n" + "\nRole: " + role + "\n" + desc + "\n__________________\n";
    }

    public Manager(Bank b){
        bank = b;
    }

    public int RegisterClient(string name){
        int ret = bank.AddClient(name);
        return ret;
    }
    public string ConsultClient(Clients.Client target){
        return "Consultation...\n";
    }
    public virtual void TalkToClient(){
        Console.WriteLine("Manager: Hello, dude!");
        while(true){
            Console.WriteLine("Manager: What do u want? (info/register/bye)\nYou: ");
            string querry = Console.ReadLine();
            if(querry == "info"){
                Console.WriteLine("Manager: Ok.Talk to credit manager to manage credit. Same with deposit manager.");
            }
            else if(querry == "register"){
                Console.WriteLine("Manager: I can register you. What's your name?\nYou: ");
                string name = Console.ReadLine();
                RegisterClient(name);
            }
            else if(querry == "bye"){
                Console.WriteLine("Manager: Ok bye.\n");
                return;
            }
        }
    }
}

}