public class Cloud{
    public string data;
    public Cloud(){
        data = File.ReadAllText("_cloud/data");
    }

    public void CheckData(){
        Console.WriteLine(data);
    }
}