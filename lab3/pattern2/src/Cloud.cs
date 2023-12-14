/// <summary>
/// Data in _cloud folder
/// </summary>
public class Cloud{
    public string data;
    public Cloud(){
        data = File.ReadAllText("_cloud/data");
    }

    public void CheckData(){
        Console.WriteLine(data);
    }
}