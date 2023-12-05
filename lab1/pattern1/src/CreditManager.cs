
namespace Managers{

class CreditManager : Manager{
    public CreditManager(Bank B) : base(B){
        role = "credit manager";
        desc = "credit manager helps to manage credits";
    }

    protected void GiveCredit(Services.Credit credit){
        BANK.credits.Add(credit);
    }


    protected override void taskMain(){
        Console.WriteLine("Credit manager: Whait bro. First, I have to register u. What's your name?\nYou: ");
        string name = Console.ReadLine();
        int cl = RegisterClient(name);
        GiveCredit(new Services.Credit(100.0f,Services.CreditType.standard,BANK.clients[cl]));
    }
    protected override void taskInfo(){
        Console.WriteLine("Credit manager: Here you go, credit history:");
                foreach(Services.Credit cr in BANK.credits){
                    Console.WriteLine("\t|Credit:"+cr.creditType.ToString()+" = " + cr.money);
                }
    }

}

}