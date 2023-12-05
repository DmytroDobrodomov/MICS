using CoffeeMachine;

namespace CoffeeMachine{

public enum Size{
    normal,
    big
}

/// <summary>
/// main component that makes the process easy (facade)
/// </summary>
public class CoffeeMachine{
    private CoffeeMaker coffeeMaker;
    private Diode diode;
    private PaymentTerminal paymentTerminal;

    public CoffeeMachine(){
        coffeeMaker = new();
        diode = new();
        paymentTerminal = new();
        Console.WriteLine("Placed new coffee machine! ___________");
    }

    public string GetHotWater(Size size){
        Console.WriteLine("Selected Hot water mode: size="+size.ToString());
        paymentTerminal.GetPayment();
        if(size == Size.normal){
            coffeeMaker.AddWater(50);
        }
        else{
            coffeeMaker.AddWater(100);
        }
        diode.Light();
        return "Hot water";
    }

    public string GetEspresso(Size size){
        Console.WriteLine("Selected Espresso mode: size="+size.ToString());
        paymentTerminal.GetPayment();
        if(size == Size.normal){
            coffeeMaker.MakeEspresso(40,10);
        }
        else{
            coffeeMaker.MakeEspresso(100,20);
        }
        diode.Light();
        return "Espresso";
    }

    public string GetLatte(Size size){
        Console.WriteLine("Selected Latte mode: size="+size.ToString());
        paymentTerminal.GetPayment();
        if(size == Size.normal){
            coffeeMaker.MakeEspresso(40,10);
            coffeeMaker.AddMilk(coffeeMaker.MixMilk(150));
        }
        else{
            coffeeMaker.MakeEspresso(60,15);
            coffeeMaker.AddMilk(coffeeMaker.MixMilk(200));
        }
        diode.Light();
        return "Latte";
    }

    public string GetCappucino(Size size){
        Console.WriteLine("Selected Latte mode: size="+size.ToString());
        paymentTerminal.GetPayment();
        if(size == Size.normal){
            coffeeMaker.AddMilk(coffeeMaker.MixMilk(100));
            coffeeMaker.MakeEspresso(40,10);
        }
        else{
            coffeeMaker.AddMilk(coffeeMaker.MixMilk(150));
            coffeeMaker.MakeEspresso(60,15);
        }
        diode.Light();
        return "Cappucino";
    }
}

}