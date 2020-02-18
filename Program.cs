using System;

namespace ConvertisseurCerebellis
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                Console.WriteLine("Veuillez saisir le code Hexadecimal : " + " \"0\" " + " pour quitter le programme");
                string hexValues = Console.ReadLine();

                int number;
                bool success = Int32.TryParse(hexValues, out number);
                if (success && (Convert.ToInt32(hexValues, 10) == 0))
                {
                    break;
                }
                //string hexValues = "48 65 6C 6C 6F 20 57 6F 72 6C 64 21";
                string[] hexValuesSplit = hexValues.Split(' ');
                foreach (string hex in hexValuesSplit)
                {
                    // Convert the number expressed in base-16 to an integer.
                    int value = Convert.ToInt32(hex, 16);
                    // Get the character corresponding to the integral value.
                    string stringValue = Char.ConvertFromUtf32(value);
                    char charValue = (char)value;
                    //int intValue = (int)value;
                    Console.WriteLine("hexadecimal value = {0}, int value = {1}, char value = {2} or {3}",
                                        hex, value, stringValue, charValue);
                }

            }
        }
    }
}
