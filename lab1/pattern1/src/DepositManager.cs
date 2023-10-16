
namespace Managers{

class DepositManager : Manager{
    public DepositManager(Bank b) : base(b){
        role = "deposit manager";
        desc = "deposit manager helps to manage deposits";
    }

    public void GiveDeposit(Services.Deposit deposit){
        bank.deposits.Add(deposit);
    }

    public override void TalkToClient()
    {
        Console.WriteLine("Deposit manager: Hello, dude! I manage deposits.");
        while(true){
            Console.WriteLine("Deposit manager: What do u want? (info/deposit/bye)\nYou: ");
            string querry = Console.ReadLine();
            if(querry[0] == 'i'){
                Console.WriteLine("Deposit manager: Here you go, deposit history:");
                foreach(Services.Deposit dp in bank.deposits){
                    Console.WriteLine("\t|Deposit:"+dp.depositType.ToString()+" = " + dp.money);
                }
            }
            else if(querry == "deposit"){
                Console.WriteLine("Deposit manager: Whait bro. First, I have to register u. What's your name?\nYou: ");
                string name = Console.ReadLine();
                int cl = RegisterClient(name);
                GiveDeposit(new Services.Deposit(100.0f,Services.DepositType.standard,bank.clients[cl],true));
            }
            else if(querry == "bye"){
                Console.WriteLine("Deposit manager: Ok bye.\n");
                return;
            }
        }
    }

}

}