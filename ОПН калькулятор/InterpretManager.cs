using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class InterpretManager : IInterpret
{
    IInterpret[] interprets;

    public string DoInterpret(string input)
    {
        string result = input;

        foreach (var interpret in interprets)
        {
            result = interpret.DoInterpret(result);
            if (result.Contains("Error"))
            {
                break;
            }
        }

        return result;
    }

    public InterpretManager()
    {
        interprets = new IInterpret[5];
        interprets[0] = new PassInterpret();     
        interprets[1] = new CorrectDoubleInterpret();
        interprets[2] = new PowInterpret();
        interprets[3] = new SpaceInterpret();
        interprets[4] = new PolishInterpret(); // Обязательно последний
        
    }
}

