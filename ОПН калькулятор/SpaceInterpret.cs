using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class SpaceInterpret : IInterpret
{
    public string DoInterpret(string input)
    {
        string saveString = input;
        string result = input;


        for(int i = 0; i < result.Length; i++)
        {
            //Добавляем пробелы от операторов
            if (result[i] == '+' || result[i] == '-' || result[i] == '*' || result[i] == '/')
            {
                result = result.Insert(i, " ");
                i++;
                result = result.Insert(i + 1, " ");
                i++;
                continue;
            }

            // удаляем лишние пробелы
            if (i > 0 && result[i - 1].Equals(' ') && result[i].Equals(' '))
            {
                result = result.Remove(i - 1, 1);
                i--;
            }

            //Ставим пробелы после открывающейся скобки и до закрывающейся скобки
            if (result[i].Equals('('))
            {
                saveString = result;
                result = result.Substring(0, i + 1);
                result += " ";
                result += saveString.Substring(i + 1, saveString.Length - i - 1);    
            }
            else if (result[i].Equals(')'))
            {
                saveString = result;
                result = result.Substring(0, i);
                result += " ";
                result += saveString.Substring(i, saveString.Length - i);
                i++;
            }
        }


        return result;
    }
}

