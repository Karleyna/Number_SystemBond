using System;
using System.Collections.Generic;
using System.Globalization;
namespace Number_SystemBond
{
   public static class ConvertNumberSystem 
   {
        static Dictionary<char, int> digits = new Dictionary<char, int>()//словарь для перевода из любой в десятичную
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
        static Dictionary<int, string> digits2 = new Dictionary<int, string>()//словарь для перевода в любую из 10
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
        private static double decimalNumber = 0;
        private static string anynumber = " ";
        private static int c2 = 0;
        

        private static float ConverTen(int n, string str)//перевод из любой в десятичную
        {          
            string[] number;
            if (str.Contains(","))  //встречается ли символ в строке
            {
                number = str.Split(',');//razdelitel
            }
            else
            {
                number = str.Split('.');
            }
            int c = number[0].Length - 1;//переменая для длины

            int tmp = 0;

            for (int i = 0; i < number[0].Length; i++)
            {
                try
                {
                    if (!int.TryParse(number[0][i].ToString(), out tmp))//если не число то сверяем со словарем и переводим значение из буквы в цифру
                    {
                        tmp = digits[number[0][i]];
                    }
                    if (tmp >= n)// проверка на то, не превышает ли число систему счисления исходную
                    {
                        return n;
                    }
                }
                catch (KeyNotFoundException)// проверка на сторонние символы
                {
                    return n;
                }
                decimalNumber += tmp * Math.Pow(n, c);//перевод в десятичную
                c--;
            }

            if (number.Length > 1 && number.Length < 3)//проверка на дробную часть и на то, нет ли лишних знаков препинания
            {
                try {
                    for (int i = 1; i <= number[1].Length; i++)
                    {
                        if (!int.TryParse(number[1][i - 1].ToString(), out tmp))//если не число то сверяем со словарем и переводим значение из буквы в цифру
                        {
                            tmp = digits[number[1][i - 1]];
                        }
                        if (tmp >= n)// проверка на то, не превышает ли число систему счисления исходную
                        {
                            return n;
                        }

                        decimalNumber += tmp * Math.Pow(n, -i);
                    }

                }
                catch (KeyNotFoundException)// проверка на сторонние символы
                {
                    return n;
                }
            }                 
            else
            {
               // проверка на то, есть ли сторонние символы в строке
                return n;
            }
            return (float)decimalNumber;
        }
        private static string ConvertOutTen(int n2)
        {
            string[] number2;
            if (decimalNumber == 0)//проверка на то нет ли ошибок во введенном числе(если есть то перевода не состоялось и перемная равна 0)
            {
                return Convert.ToString(n2);
            }
            string s2 = Convert.ToString((float)decimalNumber);//float переводим в строку для разделения
            number2 = s2.Split(',');//разделяем на целую и дробную часть
            int anyNumber = 0;//переменная для записи числа
            int part = Convert.ToInt32(number2[0]);//переменная для расчётов
           
            
                while (part >= 1)
                {
                    if (part % n2 < 10)
                    {
                        anyNumber = part % n2;
                        part /= n2;
                        anynumber += Convert.ToString(anyNumber);//записываем остаток от деления
                        c2++;//считаем длину целой части
                    }

                    else
                    {
                        anyNumber = part % n2;
                        part /= n2;
                        anynumber += digits2[anyNumber];//если число больше 10 то записываем  значение из словаря
                        c2++;
                    }
                }
                
                if (number2.Length > 1)
                {
                    anynumber += '.';//разделяем дробную часть
                    part = Convert.ToInt32(number2[1]);
                    if ((part * n2) % Math.Pow(10, number2[1].Length) == 0)//считаем дробную часть

                    {
                        part = (int)((part * n2) / Math.Pow(10, number2[1].Length));
                        if (part < 10)
                            anynumber += Convert.ToString(part);//цифра
                        else
                            anynumber += digits2[part];//буква

                    }
                    else
                    {
                        while ((part * n2) % Math.Pow(10, number2[1].Length) > 0)
                    {
                            part = (int)((part * n2) % Math.Pow(10, number2[1].Length));//записываем остаток
                            part = (int)((part * n2) / Math.Pow(10, number2[1].Length));//записываем целую часть от деления
                            if (part < 10)
                                anynumber += Convert.ToString(part);//цифра
                            else
                                anynumber += digits2[part];//буква

                        }
                    }
                    
                }
            return anynumber;

        }
        public static string ConverterNS(int n, int n2, string str)
        {
            
             str.ToUpper();
            float number = ConverTen(n,str);
            if (number != n)//если не равняется n значит ошибок нет и продолжаем считать дальше
            {
                if (n == n2)
                {
                    return str;
                }
                if (n2 == 10)//если система счисления равна 10 то сразу выводим переведенный результат
                {
                    str = Convert.ToString(number);
                }
                else
                {
                    ConvertOutTen(n2);//переводим в нужную систему
                    str = "";
                    for (int i = c2; i > 0; i--) //разворачиваем строку
                    {
                        str += anynumber[i];
                    }

                    for (int i = c2 + 1; i < anynumber.Length; i++)
                    {
                        str += anynumber[i];
                    }

                }

                return str;//результат
            }
            else
            {
                return "Mistake!";
            }
        }

    }
}
