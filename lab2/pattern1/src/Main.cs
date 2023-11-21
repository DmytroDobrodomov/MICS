
CoffeeMachine.CoffeeMachine coffeeMachine = new();

string result = coffeeMachine.GetEspresso(CoffeeMachine.Size.big);
Console.WriteLine("\nResult = "+result+"\n\n");

result = coffeeMachine.GetLatte(CoffeeMachine.Size.normal);
Console.WriteLine("\nResult = "+result+"\n\n");

result = coffeeMachine.GetCappucino(CoffeeMachine.Size.normal);
Console.WriteLine("\nResult = "+result+"\n\n");