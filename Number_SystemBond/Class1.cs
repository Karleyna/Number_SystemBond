using System;
using System.Collections.Generic;
using System.Globalization;
namespace Number_SystemBond
{
   public static class ConvertNumberSystem 
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
        private static double decimalNumber;
        private static int n = 0, n2 = 0;
        private static string s;
        private static string anynumber = " ";
        private static int c2 = 0;
        

        private static void ConverTen()
        {          
            string[] number;
            if (s.Contains(","))  //встречается ли символ в строке
            {
                number = s.Split(',');//razdelitel
            }
            else
            {
                number = s.Split('.');
            }
            int c = number[0].Length - 1;

            int tmp = 0;

            for (int i = 0; i < number[0].Length; i++)
            {
                if (!int.TryParse(number[0][i].ToString(), out tmp))
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
        }
        private static void ConvertOutTen()
        {
            string[] number2;
            string s2 = Convert.ToString(decimalNumber);//float
            number2 = s2.Split(',');
            int anyNumber = 0;
            int part = Convert.ToInt32(number2[0]);
           
            
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
                
                if (number2.Length > 1)
                {
                    anynumber += '.';
                    part = Convert.ToInt32(number2[1]);
                    if ((part * n2) % Math.Pow(10, number2[1].Length) == 0)
                    {
                        part = (int)((part * n2) / Math.Pow(10, number2[1].Length));
                        if (part < 10)
                            anynumber += Convert.ToString(part);
                        else
                            anynumber += digits2[part];

                    }
                    else
                    {
                        while ((part * n2) % Math.Pow(10, number2[1].Length) > 0)
                        {
                            part = (int)((part * n2) % Math.Pow(10, number2[1].Length));
                            part = (int)((part * n2) / Math.Pow(10, number2[1].Length));
                            if (part < 10)
                                anynumber += Convert.ToString(part);
                            else
                                anynumber += digits2[part];//sdelat polem

                        }
                    }
                    
                }

        }
        public static string ConverterNS(int n1, int n22, string str)
        {
            
            s = str.ToUpper();
            n = n1;
            n2 =n22;
            ConverTen();
            if (n22 == 10)
            {
               str = Convert.ToString((float)(decimalNumber));
            }
            else
            {
                ConvertOutTen();
                str = "";
                Console.Write($"Result: ({n1}) {s} = ({n22}) ");
                for (int i = c2; i > 0; i--)
                {
                    str +=anynumber[i];
                }
              
                for (int i = c2 + 1; i < anynumber.Length; i++)
                {
                    str += anynumber[i];
                }

            }
            

            return str;
        }

    }
}
