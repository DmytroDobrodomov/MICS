using Managers;
using Clients;
using Services;


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

    public void EnterAsClient(){
        while(true){
            Console.WriteLine("Select a service type(info/register/credit/deposit/exit): ");
            string serviceType = Console.ReadLine();
            if(serviceType[0] == 'e') return;
            Manager manager = managerFactory.GetManager(serviceType);
            manager.TalkToClient();
        }
    }
    
}
