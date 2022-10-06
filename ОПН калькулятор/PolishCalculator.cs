using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class PolishCalculator
{
    private string[] registerSolve(int index, double result, string[] stringMass)
    {
        string[] outMass = new string[stringMass.Length - 2];
        int supIndex = 0;

        for (int i = 0; i < stringMass.Length; i++)
        {
            if (!(i == index || i == index + 1 || i == index + 2))
            {
                outMass[supIndex] = stringMass[i];
                supIndex++;
            }
            if (i == index + 2)
            {
                outMass[supIndex] = result.ToString();
                supIndex++;
            }
        }


        return outMass;
    }

    private string[] solve(string[] inputStringMass)
    {

        string[] localStringMass = inputStringMass;
        double first;
        double second;


        for (int i = 0; i < localStringMass.Length; i++)
        {
            if (double.TryParse(localStringMass[i], out first))
            {
                if (double.TryParse(localStringMass[i + 1], out second))
                {
                    if (!double.TryParse(localStringMass[i + 2], out _))
                    {
                        switch (localStringMass[i + 2])
                        {
                            case "+":
                                {
                                    localStringMass = registerSolve(i, first + second, localStringMass);
                                    break;
                                }
                            case "-":
                                {
                                    localStringMass = registerSolve(i, first - second, localStringMass);
                                    break;
                                }
                            case "*":
                                {
                                    localStringMass = registerSolve(i, first * second, localStringMass);
                                    break;
                                }
                            case "/":
                                {
                                    if (second == 0)
                                    {
                                        string[] mass = new string[1];
                                        mass[0] = "Error: ZeroExeption";
                                        return mass;
                                    }
                                    localStringMass = registerSolve(i, first / second, localStringMass);                                 
                                    break;
                                }
                            case "^":
                                {
                                    localStringMass = registerSolve(i, Math.Pow(first, second), localStringMass);
                                    break;
                                }
                        }
                    }
                }
            }
        }


        return localStringMass;
    }
    public string Calculate(string input)
    {
        string[] inputMass;
        string[] resultMass;


        inputMass = input.Split(" ");

        while (true)
        {
            resultMass = solve(inputMass);

            if (resultMass.GetHashCode() == inputMass.GetHashCode())
            {
                break;
            }

            inputMass = resultMass;
        }


        return resultMass[0];
    }
}

