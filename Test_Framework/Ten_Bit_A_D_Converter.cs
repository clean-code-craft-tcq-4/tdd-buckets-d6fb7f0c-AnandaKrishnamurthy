using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    internal class Ten_Bit_A_D_Converter
    {
        int Amps_Morethan_Limits(double Amps)
        {

            int Result = 0;
            if ((Amps >= 1023) || (Amps < 0))
            {
                Result = -999;
                Print_On_Console("Error Invalid Temperature exceeds More/Less than Scale limits 0/1022 = " + Result);
            }
            return Result;
        }

        double Clacluate_Amps_If_Valid_Range(double Amps)
        {
            if ((Amps >= -15) & (Amps < 1023))
            {

                return ((30 * Amps / 1022) - 15);
            }
            return 0;
        }



        void Print_On_Console(string output)
        {
            Console.WriteLine(output);
        }
        public double Ten_Bit_Analog_to_Degital_Convertion_Float(double Amps)
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

        Tuple<int, int> INT_Float_Parts(double Split_Input)
        {
            Int32 left, right;
            Split__Int_Float_Parts(Split_Input, out right, out left);

            return Tuple.Create(right, left);
        }

        public List<int> Ten_Bit_Analog_to_Degital_Convertion_Float_Round_off(Func<double, double> Twelve_Bit_Analog_to_Degital_Convertion_Float, List<double> UserList)
        {
            List<int> result = new List<int>();
            for (int i = 0; i <= UserList.Count - 1; i++)
            {
                if ((UserList[i] <= 1022) & (UserList[i] >= 0))
                {
                    double result_1 = Twelve_Bit_Analog_to_Degital_Convertion_Float(UserList[i]);
                    result.Add((int)Math.Round(Twelve_Bit_Analog_to_Degital_Convertion_Float(UserList[i])));
                    Print_On_Console("Scaled temperature is = " + result[i].ToString());
                }
                else
                    result.Add(Amps_Morethan_Limits(UserList[i]));
            }
            return result;
        }

    }
}
