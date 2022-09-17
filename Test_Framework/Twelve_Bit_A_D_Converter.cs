using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    internal class Twelve_Bit_A_D_Converter
    {
        int Amps_Morethan_Limits(double Amps)
        {

            int Result = 0;
            if (Amps >= 4095)
            {
                Result = -1;
                Print_On_Console("Error Temperature exceeds more than Scale limits 4095 = " + Result);

            }
            else
                Result = 0;


            return Result;
        }

        public double Clacluate_Amps_If_Valid_Range(double Amps)
        {
            if ((Amps > 0) & (Amps < 4095))
            {

                return 10 * Amps / 4094;

            }
            return 0;
        }



        void Print_On_Console(string output)
        {
            Console.WriteLine(output);
        }
        public double Twelve_Bit_Analog_to_Degital_Convertion_Float(double Amps)
        {
            return Clacluate_Amps_If_Valid_Range(Amps);


        }
        public static void Split__Help(Double value, Int32 places, out int left, out int right)
        {
            left = (Int32)Math.Truncate(value);
            right = (Int32)((value - left) * Math.Pow(10, places));
        }
        public static void Split__Int_Float_Parts(Double value, out Int32 left, out Int32 right)
        {
            Split__Help(value, 1, out left, out right);
        }

        public Tuple<int, int> INT_Float_Parts(double Split_Input)
        {
            Int32 left, right;
            Split__Int_Float_Parts(Split_Input, out right, out left);

            return Tuple.Create(right, left);
        }

        public List<int> Twelve_Bit_Analog_to_Degital_Convertion_Float_Round_off(Func<double, double> Twelve_Bit_Analog_to_Degital_Convertion_Float, List<double> UserList)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= UserList.Count - 1; i++)
            {             
               
                if (UserList[i] <= 4094)
                {
                    result.Add((int)Math.Round(Twelve_Bit_Analog_to_Degital_Convertion_Float(UserList[i])));

                    Print_On_Console("Scaled temperature is = " + result.ToString());
                }
                else
                    result.Add(Amps_Morethan_Limits(UserList[i]));
            }
            return result;
        }


    }
}
