String cmdRegister = "reg";
String cmdLoad = "load";
String cmdConfirim = "y";


Database database = new Database();


Console.WriteLine("Select mode: \n\t[reg] - select optimal solution for client and try to save it\n\t[load] - try to read saved querry");
String mode = Console.ReadLine();

if(mode == cmdRegister){

    Console.WriteLine("\n__________________\nREGISTER\n__________________\nPeople num: ");

    int p = int.Parse(Console.ReadLine());

    Console.WriteLine("Your items mass: ");
    int m;
    m = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter date: ");
    string d = Console.ReadLine();
    
    Console.WriteLine("What's ur name: ");
    string n = Console.ReadLine();

    
    ClientQuerry querry = new ClientQuerry(){
        clientName=n,
        date=d,
        peopleNum = p,
        itemsKg=m

    };

    Transport selectedTransport = database.TransportChain(querry);
    if(selectedTransport == null){
        Console.WriteLine("[Client] error: transprt wasn't selected");
        return;
    }

    querry.transportType = selectedTransport.transportType;

    Console.WriteLine("Do you want to confirim this? [enter \"y\" to confirim]:");
    String conf = Console.ReadLine();
    if(conf != cmdConfirim) return;
    database.SaveQuerry(querry);
    Console.WriteLine(querry.GetInfo());

}
else if(mode == cmdLoad){
    Console.WriteLine("\n__________________\nLOAD QUERRY\n__________________\nEnter querry name: ");
    String pth = Console.ReadLine();
    ClientQuerry querry = database.LoadQuerry(pth);
    Console.WriteLine(querry.GetInfo());
}

