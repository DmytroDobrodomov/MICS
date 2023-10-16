
namespace Managers{

class CreditManager : Manager{
    public CreditManager(Bank b) : base(b){
        role = "credit manager";
        desc = "credit manager helps to manage credits";
    }

    public void GiveCredit(Services.Credit credit){
        bank.credits.Add(credit);
    }

    public override void TalkToClient()
    {
        Console.WriteLine("Credit manager: Hello, dude! I manage credits.");
        while(true){
            Console.WriteLine("Credit manager: What do u want? (info/credit/bye)\nYou: ");
            string querry = Console.ReadLine();
            if(querry[0] == 'i'){
                Console.WriteLine("Credit manager: Here you go, credit history:");
                foreach(Services.Credit cr in bank.credits){
                    Console.WriteLine("\t|Credit:"+cr.creditType.ToString()+" = " + cr.money);
                }
            }
            else if(querry[0] == 'c'){
                Console.WriteLine("Credit manager: Whait bro. First, I have to register u. What's your name?\nYou: ");
                string name = Console.ReadLine();
                int cl = RegisterClient(name);
                GiveCredit(new Services.Credit(100.0f,Services.CreditType.standard,bank.clients[cl]));
            }
            else if(querry[0] == 'b'){
                Console.WriteLine("Credit manager: Ok bye.\n");
                return;
            }
        }
    }

}

}