using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class PassInterpret : IInterpret
{
    public string DoInterpret(string input)
    {
        int countOpen = 0;
        int countClose = 0;

        for (int i = 0; i < input.Length; i++)
        {
            switch (input[i].ToString()) 
            {
                case "(":
                    {
                        countOpen++;
                        break;
                    }
                case ")":
                    {
                        countClose++;
                        break;
                    }
            }
        }

        if (countClose == countOpen)
        {
            return input;
        }
        else
        {
            return "Error: Count \"(\" dont match count \")\"";
        }
    }
}

