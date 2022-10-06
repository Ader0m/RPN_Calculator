using System.Text;

input();
//main();
//main1("6 * 8 + 3 * 4 - 2 / 5");
//main1("61 * 8 + 32 * 4 - 21 / 5,3");
//main1("(3 + 4) * (5 + 6.18) - ,31");

void input()
{
    while (true)
    {
        Console.WriteLine("Поддерживает возведение в степень. Pow(a b)");
        string outputString; 
        PolishCalculator polishCalculator = new PolishCalculator();
        InterpretManager interpretManager = new InterpretManager();


        string inputString = Console.ReadLine();
        outputString = interpretManager.DoInterpret(inputString);

        Console.WriteLine(outputString);
        if (!outputString.Contains("Error"))
        {
            Console.WriteLine(polishCalculator.Calculate(outputString));
        }
       
    }
}

void main()
{ 
    string inputString = "POW(2 POW(2 2)) / 2";
    string outputString;

    InterpretManager interpretManager = new InterpretManager();
    outputString = interpretManager.DoInterpret(inputString);

    Console.WriteLine(outputString);

    PolishCalculator polishCalculator = new PolishCalculator();
    
    Console.WriteLine(polishCalculator.Calculate(outputString));
}


void main1(string str)
{
    string inputString = str;
    string outputString;

    InterpretManager interpretManager = new InterpretManager();
    outputString = interpretManager.DoInterpret(inputString);

    Console.WriteLine(outputString);

    PolishCalculator polishCalculator = new PolishCalculator();

    Console.WriteLine(polishCalculator.Calculate(outputString));
}
