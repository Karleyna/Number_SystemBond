using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{ 
    static Dictionary<char, int> digits = new Dictionary<char, int>()
    {
        {'A',10},
        {'B',11},
        {'C',12},
        {'D',13},
        {'E',14},
        {'F',15},
        {'G',16},
        {'H',17},
        {'I',18},
        {'J',19},
        {'K',20},
        {'L',21},
        {'M',22},
        {'N',23},
        {'O',24},
        {'P',25},
        {'Q',26},
        {'R',27},
        {'S',28},
        {'T',29},
        {'U',30},
        {'V',31},
        {'W',32},
        {'X',33},
        {'Y',34},
        {'Z',35},
    };
    static Dictionary<int, string> digits2 = new Dictionary<int, string>()
    {
        {10,"A"},
        {11,"B"},
        {12,"C"},
        {13,"D"},
        {14,"E"},
        {15,"F"},
        {16,"G"},
        {17,"H"},
        {18,"I"},
        {19,"J"},
        {20,"K"},
        {21,"L"},
        {22,"M"},
        {23,"N"},
        {24,"O"},
        {25,"P"},
        {26,"Q"},
        {27,"R"},
        {28,"S"},
        {29,"T"},
        {30,"U"},
        {31,"V"},
        {32,"W"},
        {33,"X"},
        {34,"Y"},
        {35,"Z"},
    };
    public static int Main()  
    {
        Console.WriteLine("Enter number ");
        string s = Console.ReadLine().ToUpper();
        Console.WriteLine("Number System 1 ");
        int n = 0;
        int.TryParse(Console.ReadLine(), out n);
        string[] number;
        if (s.Contains(","))  //встречается ли символ в строке
        {
            number = s.Split(',');//razdelitel
        }
        else
        {
            number = s.Split('.');
        }

        double decimalNumber = 0;
        int c = number[0].Length - 1;

        int tmp = 0;

        for (int i = 0; i < number[0].Length; i++)
        { if (!int.TryParse(number[0][i].ToString(),out tmp))
            {
                tmp = digits[number[0][i]];
            }
            decimalNumber += tmp * Math.Pow(n, c);
            c--;
        }

        if (number.Length > 1)
        {
            for (int i = 1; i <= number[1].Length; i++)
            { 
                if (!int.TryParse(number[1][i - 1].ToString(), out tmp))
                    {
                        tmp = digits[number[1][i - 1]];
                }

                    decimalNumber += tmp * Math.Pow(n, -i);
            }
        }       
        
        //перевод в любую из 10
        Console.WriteLine("\nEnter Number system 2 ");
        int n2 = Convert.ToInt32(Console.ReadLine());
        string[] number2;
        string s2 = Convert.ToString(decimalNumber);//float
        number2 = s2.Split(',');
        int anyNumber = 0;
        int part = Convert.ToInt32(number2[0]);
        string anynumber = " ";
        int c2 = 0;
        
        if (n2 == 10)
        {
            Console.WriteLine($"{s} ({n}) = {(float)decimalNumber} (10)");
        }
          else
          {
              while (part >= 1)
              {
                  if (part % n2 < 10)
                  {
                      anyNumber = part % n2;
                      part /= n2;
                      anynumber += Convert.ToString(anyNumber);
                      c2++;
                  }

                  else
                  {
                      anyNumber = part % n2;
                      part /= n2;
                      anynumber += digits2[anyNumber];
                      c2++;
                  }
              }
              Console.Write($"Result: ({n}) {s} = ({n2}) ");
              for (int i = c2; i > 0; i--)
              {
                  Console.Write(anynumber[i]);
              }
              if (number2.Length > 1)
              {
                  anynumber += '.';
                  part = Convert.ToInt32(number2[1]);
                  if ((part * n2) % Math.Pow(10, number2[1].Length) == 0)
                  {
                      part = (int)((part * n2) / Math.Pow(10, number2[1].Length));
                      if(part<10)
                      anynumber += Convert.ToString(part);
                      else
                      anynumber += digits2[part];

                  }
                  else
                  {
                      while ((part * n2) % Math.Pow(10, number2[1].Length) > 0 ) 
                      {
                          part = (int)((part * n2) % Math.Pow(10, number2[1].Length));
                          part = (int)((part * n2) / Math.Pow(10, number2[1].Length));
                          if (part < 10)
                              anynumber += Convert.ToString(part);
                          else
                              anynumber += digits2[part];

                      }
                  }
                  for(int i = c2 + 1; i < anynumber.Length; i++)
                  {
                      Console.Write(anynumber[i]);
                  }


              }

          }
       //ToString(2,s2);
       
        return 0;
    }
}
