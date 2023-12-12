public class ClientQuerry{
    public string clientName{ get; set; }
    public string date{ get; set; }
    public TransportType transportType{ get; set; }

    public int peopleNum{ get; set; }
    public int itemsKg{ get; set; }

    public String GetInfo(){
        return "___querry___\nClient name: "+
        clientName+
        "\nDate: "+date+
        "\nTransport type: "+transportType.ToString()+
        "\nPeople num: "+peopleNum+
        "\nItems, kg"+itemsKg;
    }

}