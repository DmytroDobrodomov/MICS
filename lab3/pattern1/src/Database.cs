using System;
using System.IO;
using System.Text.Json;


public class Database{
    public const String datapasePath = "db/";
    public Transport TransportChain(ClientQuerry querry){
        Console.WriteLine("Your querry: people="+querry.peopleNum+"; items,kg="+querry.itemsKg);
        Taxi taxi = new(this);
        Transport res = taxi.NextTransport(querry);
        return res;
    }

    public void SaveQuerry(ClientQuerry querry){
        String filename = datapasePath + querry.transportType.ToString() + "_" + querry.date + ".json"; 
        String jstring = JsonSerializer.Serialize<ClientQuerry>(querry);
        File.WriteAllText(filename,jstring);
    }

    public ClientQuerry LoadQuerry(String filename){
        String jstring = File.ReadAllText(datapasePath + filename+ ".json");
        return JsonSerializer.Deserialize<ClientQuerry>(jstring);
    }
}
    
