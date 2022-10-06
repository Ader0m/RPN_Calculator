using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class PolishInterpret : IInterpret
{
    string[] StringMass;
    List<string> Ans = new List<string>();
    List<string> Storage = new List<string>();

    void InputPrioritet3(int i)
    {
        if (Storage.Count > 0)
        {
            if (Storage[Storage.Count - 1].Equals("*") ||
                Storage[Storage.Count - 1].Equals("/") ||
                Storage[Storage.Count - 1].Equals("+") ||
                Storage[Storage.Count - 1].Equals("-") ||
                Storage[Storage.Count - 1].Equals("^")
                )
            {
                Ans.Add(Storage[Storage.Count - 1]);
                Storage.Remove(Storage[Storage.Count - 1]);
                Storage.Add(StringMass[i]);
                return;
            }
        }

        Storage.Add(StringMass[i]);
    }

    void InputPrioritet2(int i)
    {
        if (Storage.Count > 0)
        {
            if (Storage[Storage.Count - 1].Equals("*") ||
                Storage[Storage.Count - 1].Equals("/") ||
                Storage[Storage.Count - 1].Equals("^")
                )
            {
                Ans.Add(Storage[Storage.Count - 1]);
                Storage.Remove(Storage[Storage.Count - 1]);
                Storage.Add(StringMass[i]);
                return;
            }
        }

        Storage.Add(StringMass[i]);
    }

    void InputPrioritet1(int i)
    {
        if (Storage.Count > 0)
        {
            if (
                Storage[Storage.Count - 1].Equals("^")
                )
            {
                Ans.Add(Storage[Storage.Count - 1]);
                Storage.Remove(Storage[Storage.Count - 1]);
                Storage.Add(StringMass[i]);
                return;
            }
        }

        Storage.Add(StringMass[i]);
    }

    public string DoInterpret(string input)
    {
        
        StringBuilder strAns = new StringBuilder();
        StringMass = input.Split(' ');

        for (int i = 0; i < StringMass.Length; i++)
        {
            if (StringMass[i] == "^")
            {
                StringMass[i] = StringMass[i + 1];
                StringMass[i + 1] = "^";
                i++;
            }
        }

        for (int i = 0; i < StringMass.Length; i++)
        {
            switch (StringMass[i])
            {
                case "+":
                    {
                        InputPrioritet3(i);
                        break;
                    }
                case "-":
                    {
                        InputPrioritet3(i);
                        break;
                    }
                case "*":
                    {
                        InputPrioritet2(i);
                        break;
                    }
                case "/":
                    {
                        InputPrioritet2(i);
                        break;
                    }
                case "^":
                    {
                        InputPrioritet1(i);
                        break;
                    }
                case "(":
                    {
                        Storage.Add(StringMass[i]);
                        break;
                    }
                case ")":
                    {
                        for (int j = Storage.Count - 1; j > -1; j--)
                        {
                            if (!Storage[j].Equals("("))
                            {
                                Ans.Add(Storage[j]);
                                Storage.Remove(Storage[j]);
                            }
                            else
                            {
                                Storage.Remove(Storage[j]);
                                break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        if (double.TryParse(StringMass[i], out _))
                        {
                            Ans.Add(StringMass[i]);
                        }
                        else
                        {
                            return "Error: Не известный символ в строке";
                        }
                        break;
                    }
            }
        }

        Storage.Reverse();

        for (int i = 0; i < Storage.Count; i++)
        {           
            Ans.Add(Storage[i]);
        }

        foreach (string str in Ans)
        {
            strAns.Append(str + " ");
        }

        return strAns.ToString();
    }
}
