using System.Net.Http;

//commands
string Cmdbrowser = "browser";
string Cmdproxy = "proxy";

//browser and proxy (different components)
SomeBrowser someBrowser = new();
MyProxy myProxy = new MyProxy(someBrowser,100);

string cmd = "";

Console.WriteLine("use commands:\n"+Cmdbrowser+"/"+Cmdproxy+" + <url>");
while(true){
    cmd = Console.ReadLine();
    string cmd_ = cmd.Substring(0,cmd.IndexOf(' '));
    string url = cmd.Substring(cmd.IndexOf(' ')+1);
    if(cmd_ == Cmdbrowser){
        await someBrowser.GetPage(url);
    }
    else if (cmd_ == Cmdproxy){
        await myProxy.GetPage(url);
    }

}


