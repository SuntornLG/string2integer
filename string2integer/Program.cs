using System;

namespace string2integer
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = "No digit found";
            var result = GetIntFromString("5fdfd7xxx3o0");
            if (result.HasValue)
                response = string.Format("Found digit : {0}", result);

            Console.WriteLine(response);
        }

        static int? GetIntFromString(string param)
        {
            // ASII 48 - 57 for digit number.
            byte[] asciiBytes = System.Text.Encoding.ASCII.GetBytes(param);
            int? resultNum = null;
            foreach (var n in asciiBytes)
            {
                var num = GetNumber(n);
                if (num != -1)
                {
                    resultNum = Concat(resultNum, num);
                }
            }
            return resultNum;
        }

        static int Concat(int? a, int b)
        {
            a = ((a << 2) + a) << 1;
            if (a != null)
                return a.Value + b;
            else
                return b;
        }

        static int GetNumber(byte asiiCode)
        {
            switch (asiiCode)
            {
                case 48:
                    return 0;
                case 49:
                    return 1;
                case 50:
                    return 2;
                case 51:
                    return 3;
                case 52:
                    return 4;
                case 53:
                    return 5;
                case 54:
                    return 6;
                case 55:
                    return 7;
                case 56:
                    return 8;
                case 57:
                    return 9;
            }
            return -1;
        }
    }
}
