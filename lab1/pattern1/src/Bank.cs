using Managers;
using Clients;
using Services;
using System.Dynamic;


/// <summary>
/// this class cantains all data (like credits/deposits/clients)
/// you can EnterAsClient() and talk with managers
/// </summary>
class Bank{

    public List<Credit> credits;
    public List<Deposit> deposits;
    public List<Client> clients;

    public ManagerFactory managerFactory;

    public int AddClient(string name){
        Client client = new Client(name);
        Console.WriteLine(client.ToString());
        clients.Add(client);
        return clients.Count-1;
    }


    public Bank(){
        clients = new();
        deposits = new();
        credits = new();
        managerFactory = new(this);
    }

    /// <summary>
    /// main function to interact with managers
    /// </summary>
    public void EnterAsClient(){
        while(true){
            Console.WriteLine("Select a service type(info/register/credit/deposit/exit): ");
            //user enters command - a type of service he needs
            string serviceType = Console.ReadLine();
            //if selected exit option
            if(serviceType[0] == BankServiceType.exit.ToString()[0]) return;
            foreach(BankServiceType st in (BankServiceType[]) Enum.GetValues(typeof(BankServiceType))){
                Manager manager = null;
                string st_string = st.ToString();
                //if 1-char short command
                if(serviceType.Length == 1 && serviceType[0]==st_string[0]) manager = managerFactory.GetManager(st);
                //normal length command
                else if(serviceType[0]==st_string[0]) manager = managerFactory.GetManager(st);
                if(manager != null) {manager.TalkToClient(); break;}
            }
        }
    }
    
}


public enum BankServiceType{
    info,
    register,
    credit,
    deposit,
    exit
}