
namespace CoffeeMachine{

public class CoffeeMaker{
    public void AddWater(int ml){
        Console.WriteLine("added "+ ml + "ml of water");
    }

    public int BlendCoffee(int g){
        Console.WriteLine("blended "+ g + "g of coffee");
        return g;
    }

    public void AddCoffee(int g){
        Console.WriteLine("added "+ g + "g of coffee");
    }

    public void MakeEspresso(int ml, int g){
        AddCoffee(BlendCoffee(g));
        AddWater(ml);
    }

    public int MixMilk(int ml){
        Console.WriteLine("mixed "+ ml + "ml of milk");
        return ml;
    }
    public void AddMilk(int ml){
        Console.WriteLine("added "+ ml + "ml of milk");
    }

}

}