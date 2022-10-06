using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class CorrectDoubleInterpret : IInterpret
{
    public string DoInterpret(string input)
    {
        string result = input;


        result = result.Replace(".", ",");


        return result;
    }
}

