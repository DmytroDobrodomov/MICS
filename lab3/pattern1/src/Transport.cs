using System.Net.NetworkInformation;

public abstract class Transport{
    public Database database;
    public TransportType transportType;
    public int maxPeople;
    public int maxItemsKg;


    public Transport successor;

    public bool ValidateRequirements(ClientQuerry clientQuerry){
        return (maxItemsKg >= clientQuerry.itemsKg && maxPeople >= clientQuerry.peopleNum);
    }

    public Transport NextTransport(ClientQuerry clientQuerry){
        if(ValidateRequirements(clientQuerry)) {
            Console.WriteLine("Transport ["+this.ToString()+"] was confirimed");
            //database.ConfirimQuerry();
            return this;
        }
        if(successor == null) {
            Console.WriteLine("No more transport types left.");
            return null;
        }
        Console.WriteLine("Transport ["+this.ToString()+"] had't met the requirements. Trying next.");
        return successor.NextTransport(clientQuerry);
    }

}

/// <summary>
/// up to 4 people, items < 20kg
/// </summary>
public class Taxi : Transport{
    public Taxi(Database d){
        database = d;
        transportType = TransportType.Taxi;
        maxPeople=4;
        maxItemsKg=20;
        successor = new Universal(d);
    }
}

/// <summary>
/// up to 6 peeople, items < 200kg
/// </summary>
public class Universal : Transport{
    public Universal(Database d){
        database = d;
        transportType = TransportType.Universal;
        maxPeople=6;
        maxItemsKg=200;
        successor = new Minibus(d);
    }
}

/// <summary>
/// up to 9 peeople, items < 50kg
/// </summary>
public class Minibus : Transport{
    public Minibus(Database d){
        database = d;
        transportType = TransportType.Minibus;
        maxPeople=9;
        maxItemsKg=50;
        successor = new Van(d);
    }
}

/// <summary>
/// up to 2 peeople, items < 1000kg
/// </summary>
public class Van : Transport{
    public Van(Database d){
        database = d;
        transportType = TransportType.Van;
        maxPeople=2;
        maxItemsKg=1000;
        successor = null;
    }
}

