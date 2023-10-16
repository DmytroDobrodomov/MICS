
using System.Xml;

namespace Clients{

class Client{
    public string name;
    public Guid guid;
    public Client(string n){
        name = n;
        guid = new Guid();
    }
}

}