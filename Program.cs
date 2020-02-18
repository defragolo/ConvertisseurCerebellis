using System;

namespace ConvertisseurCerebellis
{
    class Program
    {
        static void Main(string[] args)
        {
            hexaConversion();
        }

        private static void hexaConversion()
        {
            while (true)
            {
                string hexValString = askUserToTypeHexa();
                bool success = Int32.TryParse(hexValString, out int number);
                if (success && (Convert.ToInt32(hexValString, 10) == 0))
                {
                    break;
                }
                uint numTest = intConversion(hexValString);
                float floatTest = floatConversion(numTest);
                string stringTest = stringConversion(hexValString);
                showConversions(numTest, floatTest, stringTest);
            }
        }

        private static string askUserToTypeHexa()
        {
            Console.WriteLine("Veuillez saisir le code Hexadecimal : " + " \"0\" " + " pour quitter le programme");
            string hexValString = Console.ReadLine();
            return hexValString;
        }

        private static void showConversions(uint numTest, float floatTest, string stringTest)
        {
            Console.WriteLine("String val = {0}", stringTest);
            Console.WriteLine("Int val = {0}", numTest);
            Console.WriteLine("Float val = {0}", floatTest);
        }

        private static string stringConversion(string hexValString)
        {
            //string conversion
            byte[] raw = new byte[hexValString.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hexValString.Substring(i * 2, 2), 16);
            }
            string stringTest = System.Text.Encoding.UTF8.GetString(raw);
            return stringTest;
        }

        private static float floatConversion(uint numTest)
        {
            //float conversion
            byte[] floatVals = BitConverter.GetBytes(numTest);
            float floatTest = BitConverter.ToSingle(floatVals, 0);
            return floatTest;
        }

        private static uint intConversion(string hexValString)
        {
            // int conversion
            return uint.Parse(hexValString, System.Globalization.NumberStyles.AllowHexSpecifier);
        }
    }
}