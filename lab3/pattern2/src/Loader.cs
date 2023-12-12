public interface ILoader{
    public string buffer{get;set;}
    public void Load(Device device, Cloud cloud, int spd);
}


public class LoaderHigh : ILoader{
    public string buffer{get;set;}
    public void Load(Device device, Cloud cloud, int spd){
        for(int i = 0; i < cloud.data.Length; i+=spd){
            System.Threading.Thread.Sleep(100);
            buffer="";
            for(int j = i; j < i+spd; j++){
                if(j < cloud.data.Length) buffer+=cloud.data[j];
            }
            device.PushData(buffer);
        }
    }
}

public class LoaderMedium : ILoader{
    public string buffer{get;set;}
    public void Load(Device device, Cloud cloud, int spd){
        for(int i = 0; i < cloud.data.Length; i+=spd){
            System.Threading.Thread.Sleep(100);
            buffer="";
            for(int j = i; j < i+spd; j++){
                if(j < cloud.data.Length) {
                    if((cloud.data[j] == '\n') || (j%4!=0))
                    buffer+=cloud.data[j];
                }
            }
            device.PushData(buffer);
        }
    }
}


public class LoaderLow : ILoader{
    public string buffer{get;set;}
    public void Load(Device device, Cloud cloud, int spd){
        for(int i = 0; i < cloud.data.Length; i+=spd){
            System.Threading.Thread.Sleep(100);
            buffer="";
            for(int j = i; j < i+spd; j++){
                if(j < cloud.data.Length) {
                    if((cloud.data[j] == '\n') || (j%3!=0))
                    buffer+=cloud.data[j];
                }
            }
            device.PushData(buffer);
        }
    }
}