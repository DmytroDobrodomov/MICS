
namespace Managers{

class DepositManager : Manager{
    public DepositManager(Bank B) : base(B){
        role = "deposit manager";
        desc = "deposit manager helps to manage deposits";
    }

    protected void GiveDeposit(Services.Deposit deposit){
        BANK.deposits.Add(deposit);
    }

    protected override void taskMain(){
        Console.WriteLine("Deposit manager: Whait bro. First, I have to register u. What's your name?\nYou: ");
        string name = Console.ReadLine();
        int cl = RegisterClient(name);
        GiveDeposit(new Services.Deposit(100.0f,Services.DepositType.standard,BANK.clients[cl],true));
        
    }
    protected override void taskInfo(){
        Console.WriteLine("Deposit manager: Here you go, deposit history:");
        foreach(Services.Deposit dp in BANK.deposits){
            Console.WriteLine("\t|Deposit:"+dp.depositType.ToString()+" = " + dp.money);
        }
    }

}

}