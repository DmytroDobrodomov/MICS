public class Offer{
    public string clientName;
    public string clientPhone;
    public string offerDate;
    

}

public enum TransportType{
    /// <summary>
    /// up to 4 people, items < 20kg
    /// </summary>
    Taxi,

    /// <summary>
    /// up to 6 peeople, items < 200kg
    /// </summary>
    Universal,

    /// <summary>
    /// up to 9 peeople, items < 50g
    /// </summary>
    Minibus,

    /// <summary>
    /// up to 2 peeople, items < 1000kg
    /// </summary>
    Van
}