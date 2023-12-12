using System.Diagnostics;

public class Device{
    public Device(Cloud c){
        cloud = c;
    }

    public string data;
    public int connSpd =0;
    public ConnectionQuality connQlt = 0;

    public Cloud cloud;

    public ILoader dataLoader;

    public void GetConnection(){
        Console.WriteLine("Trying to get connection...");
        System.Threading.Thread.Sleep(1000);

        connSpd = new Random().Next(0,64);
        if(connSpd <= 0) connQlt = ConnectionQuality.None;
        if(connSpd < 16) connQlt = ConnectionQuality.Low;
        else if(connSpd < 32) connQlt = ConnectionQuality.Medium;
        else connQlt = ConnectionQuality.High;
        Console.WriteLine("Your connection speed is " + connQlt.ToString()+" (" + connSpd + "chars per 100 miliseconds)");
    }

    public void DefineLoader(){
        Console.WriteLine("Selected loader for data");
        switch(connQlt){
            case ConnectionQuality.Low:
                dataLoader = new LoaderLow();
                break;
            case ConnectionQuality.Medium:
                dataLoader = new LoaderMedium();
                break;
            case ConnectionQuality.High:
                dataLoader = new LoaderHigh();
                break;
            default: 
                dataLoader = null;
                break;
        }
        Console.WriteLine(data);
    }

    public void PushData(string d){
        data += d;
        Console.Write(d);
    }


    public void CloudData(){
        GetConnection();
        DefineLoader();
        if(dataLoader == null){
            Console.WriteLine("Your connection is too low");
            return;
        }
        Console.WriteLine("\n_______________________\nYour data\n_______________________\n");
        dataLoader.Load(this,cloud,connSpd);
        //Console.WriteLine(data);
    }


}