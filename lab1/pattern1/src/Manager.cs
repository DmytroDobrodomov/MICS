

namespace Managers{
    
class Manager{
    public string name;
    public string desc = "A manager helps client to manage!";
    public string role = "none";

    public Manager(string name_){
        name = name_;
    }

    public string GetInfo(){
        return "\n__________________\nName: " + name + "\nRole: " + role + "\n" + desc + "\n__________________\n";
    }
}

}