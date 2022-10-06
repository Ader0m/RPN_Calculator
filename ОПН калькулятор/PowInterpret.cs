using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class PowInterpret : IInterpret
{
    public string DoInterpret(string input)
    {
        string result = input;
        int index;

        
        result = result.Replace("POW", "pow");
        result = result.Replace("Pow", "pow");

        while (result.Contains("pow"))
        {
            index = result.IndexOf("p");
            if (index == -1)
            {
                break;
            }
            result = result.Remove(index, 3);
            result = result.Insert(index, "^ ");
            for (int i = index; i < result.Length; i++)
            {
                if (result[i] == '(')
                {
                    result = result.Remove(i, 1);
                    i--;
                }
                if (result[i] == ')')
                {
                    result = result.Remove(i, 1);
                    i--;
                }
            }
        }


        return result;
    }
}

