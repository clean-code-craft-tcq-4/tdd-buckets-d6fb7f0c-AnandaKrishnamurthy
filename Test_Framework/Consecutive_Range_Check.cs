using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Framework
{
    class Consecutive_Range_Check
    {
        List<int> Samples_Buffer_3 = new List<int>();
        public static List<int> Add_First_Element_From_Final_Sequence(List<int> Samples_Buffer_1, List<int> Samples_Buffer_3, int K)
        {
            if (Samples_Buffer_1.Count == 1)
            {
                Samples_Buffer_3.Add(Samples_Buffer_1[K]);
            }
            return Samples_Buffer_3.ToList();
        }

        public static List<int> Add_Otherthan_First_Element_From_Final_Sequence(List<int> Samples_Buffer_1, List<int> Samples_Buffer_3, int K)
        {
            if (K < Samples_Buffer_1.Count - 1)
            {
                Samples_Buffer_3.Add(Samples_Buffer_1[K]);
                Samples_Buffer_3.Add(Samples_Buffer_1[K + 1]);
            }

            return Samples_Buffer_3.ToList();

        }
        public static List<int> Combine_All_Saparated_Cosecutive_No(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_3)
        {
            for (int K = 0; K < Samples_Buffer_1.Count; K++)
            {
                Samples_Buffer_3 = Add_First_Element_From_Final_Sequence(Samples_Buffer_1, Samples_Buffer_3, K);
                Samples_Buffer_3 = Add_Otherthan_First_Element_From_Final_Sequence(Samples_Buffer_1, Samples_Buffer_3, K);
            }

            return Samples_Buffer_3.ToList();
        }
        public static List<int> Remove_NonConsecutiveElement_From_array(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            List<int> Samples_Buffer_4 = new List<int>();
            List<int> Samples_Buffer_5 = new List<int>();
            NonConsecutiveElement_Deletion inst_NonConsecutiveElement_Deletion = new NonConsecutiveElement_Deletion();
            Samples_Buffer_4 = inst_NonConsecutiveElement_Deletion.Remove_NonConsecutiveElement_From_First_Two_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList()).ToList();
            Samples_Buffer_5 = inst_NonConsecutiveElement_Deletion.Remove_NonConsecutiveElement_Except_First_Two_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2.ToList()).ToList();
            Samples_Buffer_4.AddRange(Samples_Buffer_5.ToList());
            return Samples_Buffer_4.ToList();
        }
        public static List<int> Add_If_One_Sample_Found(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_3)
        {
            if (iCurrentSamples.Count() == 1)
            {
                Samples_Buffer_3.Add(iCurrentSamples[Array_Elements]);
            }
            return Samples_Buffer_3.ToList();
        }
        public  List<int> Delete_NonCosecutive_Numbers(int[] iCurrentSamples)
        {
            int Array_Elements = 0;
            List<int> Samples_Buffer_1 = new List<int>();
            List<int> Samples_Buffer_2 = new List<int>();
            for (Array_Elements = 0; Array_Elements < iCurrentSamples.Count() - 1; Array_Elements++)
            {
                Samples_Buffer_2 = Remove_NonConsecutiveElement_From_array(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_2.ToList()).ToList();
                Samples_Buffer_1 = Samples_Buffer_2.ToList();
                Samples_Buffer_3 = Combine_All_Saparated_Cosecutive_No(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_3.ToList()).ToList();
                Samples_Buffer_1.Clear();
            }

            Samples_Buffer_3 = Add_If_One_Sample_Found(iCurrentSamples, Array_Elements, Samples_Buffer_3);

            return Samples_Buffer_3.ToList();
        }
        public List<int> Check_And_Add_First_Cosecutive_No(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if (!Samples_Buffer_2.Contains(iCurrentSamples[Array_Elements]))
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
            }
            return Samples_Buffer_1.ToList();
        }
        public List<int> Check_And_Add_Second_Cosecutive_No(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if (!Samples_Buffer_2.Contains(iCurrentSamples[Array_Elements + 1]))
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements + 1]);
            }
            return Samples_Buffer_1.ToList();
        }
        List<int> Add_Element_If_Diff_is_One(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if (Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 1)
            {

                bool bexist2 = Samples_Buffer_2.Contains(iCurrentSamples[Array_Elements + 1]);
                List<int> Samples_Buffer_Delete = new List<int>();
                List<int> Samples_Buffer_Temp = new List<int>();
                Samples_Buffer_Temp = Check_And_Add_First_Cosecutive_No(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_2.ToList()).ToList(); ;
                Samples_Buffer_Temp = Check_And_Add_Second_Cosecutive_No(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_2.ToList()).ToList();
                Samples_Buffer_1 = Samples_Buffer_Temp.ToList();
                Samples_Buffer_2 = Samples_Buffer_1.ToList();
            }
            return Samples_Buffer_2.ToList();
        }
        List<int> Add_If_2nd_3rd_Element_Diff_Zero(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 0) & (Array_Elements == 1))
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Samples_Buffer_2 = Samples_Buffer_1.ToList();
            }
            return Samples_Buffer_1.ToList();
        }

        List<int> Add_If_1st_2nd_Element_Diff_Zero(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {

            if (((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements + 1])) == 0) & (Array_Elements == 0))
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements + 1]);
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                //Samples_Buffer_2 = Samples_Buffer_1.ToList();
            }

            //Samples_Buffer_1 = Samples_Buffer_Temp.ToList();
            return Samples_Buffer_1;
        }

        List<int> Add_Element_Condition_1(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) == 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }
            return Samples_Buffer_1.ToList();
        }
        List<int> Add_Element_Condition_2(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements + 1]) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) == 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }
            return Samples_Buffer_1.ToList();
        }
        List<int> Add_Element_Condition_3(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {

            if ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements + 1]) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }
            return Samples_Buffer_1.ToList();
        }


        Dictionary<string, int[]> IsCurrentSamples_Count_One(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, Dictionary<string, int[]> Dictionary_Of_Consecutive_No)
        {
            if (iCurrentSamples.Count() == 1)
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Dictionary_Of_Consecutive_No.Add(Samples_Buffer_1[Array_Elements].ToString(), Samples_Buffer_1.ToArray());
            }
            return Dictionary_Of_Consecutive_No;
        }


        void Check_the_Elements_From_2nd_Count(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            List<int> Samples_Buffer_Temp = new List<int>();
            if (Array_Elements > 1)
            {
                Samples_Buffer_Temp = Add_Element_Condition_1(iCurrentSamples, Array_Elements, Samples_Buffer_1).ToList();
                Samples_Buffer_Temp = Add_Element_Condition_2(iCurrentSamples, Array_Elements, Samples_Buffer_1).ToList();
                Samples_Buffer_Temp = Add_Element_Condition_3(iCurrentSamples, Array_Elements, Samples_Buffer_1).ToList();
                Samples_Buffer_1 = Samples_Buffer_Temp.ToList();
            }

        }
        Dictionary<string, int[]> Add_Range_Consecutive(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_3, Dictionary<string, int[]> Dictionary_Of_Consecutive_No, int count)
        {
            if ((!((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 1) || (Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 0))) || (Array_Elements == count))
            {
                Samples_Buffer_3 = Samples_Buffer_1.ToList();
                string TEMP;
                TEMP = Samples_Buffer_1[0].ToString() + "-" + Samples_Buffer_1[(Samples_Buffer_1.Count - 1)].ToString();
                Dictionary_Of_Consecutive_No.Add(TEMP, Samples_Buffer_1.ToArray());
                Samples_Buffer_1.Clear();
            }
            return Dictionary_Of_Consecutive_No;
        }

        public void Combine_String_Print_On_Console(Dictionary<string, int[]> Dictionary_Of_Consecutive_No)
        {
            Print_On_Console("Range,Readings");
            foreach (var kvp in Dictionary_Of_Consecutive_No)
            {
                int[] x = kvp.Value;
                Console.WriteLine("{0 },{1}", kvp.Key, x.Count()); //String.Join(",", kvp.Value));
            }

        }
       public  Dictionary<string, int[]> Saparate_Cosecutive_Numbers_With_Ranges(int[] iCurrentSamples)
        {
            int Array_Elements = 0;
            List<int> Samples_Buffer_1 = new List<int>();
            List<int> Samples_Buffer_2 = new List<int>();
            List<List<int>> lists = new List<List<int>>();
            Dictionary<string, int[]> Dictionary_Of_Consecutive_No = new Dictionary<string, int[]>();

            for (Array_Elements = 0; Array_Elements < iCurrentSamples.Count() - 1; Array_Elements++)
            {
                int count = iCurrentSamples.Count() - 2;
                Samples_Buffer_2 = Add_Element_If_Diff_is_One(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_2);
                Samples_Buffer_1 = Add_If_2nd_3rd_Element_Diff_Zero(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2);
                Samples_Buffer_1 = Add_If_1st_2nd_Element_Diff_Zero(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList());
                Samples_Buffer_2 = Samples_Buffer_1.ToList();
                Check_the_Elements_From_2nd_Count(iCurrentSamples, Array_Elements, Samples_Buffer_1);
                Dictionary_Of_Consecutive_No = Add_Range_Consecutive(iCurrentSamples, Array_Elements, Samples_Buffer_1, Samples_Buffer_3, Dictionary_Of_Consecutive_No, count);
            }
            Dictionary_Of_Consecutive_No = IsCurrentSamples_Count_One(iCurrentSamples, Array_Elements, Samples_Buffer_1, Dictionary_Of_Consecutive_No);
            return Dictionary_Of_Consecutive_No;

        }


        void Print_On_Console(string output)
        {
            Console.WriteLine(output);
        }

        string Read_From_Console()
        {
            return Console.ReadLine();
        }
/*
        void Is_Input_Data_Valid_Array(List<int> UserList, string inputString, ref string[] inputString_Array, ref int i)
        {
            int result;
            if (!int.TryParse(inputString_Array[i], out result))
            {
                Console.WriteLine("Sorry, '{0}' is not a valid number.", inputString_Array[i]);
                UserList.Clear();
                Print_On_Console("ReEnter Periodic current samples from a charging session: ");
                inputString = Read_From_Console();
                inputString_Array = inputString.Split(',');
                i = -1;
            }
            else UserList.Add(result);

        }



        List<int> Evaluate_Convert_To_Int_Input_Data()
        {
            List<int> UserList = new List<int>();
            Print_On_Console("Enter Periodic current samples from a charging session: ");
            var input_Var = Console.ReadLine();
            var input_Var1 = input_Var.Split(',');
            string s = input_Var;
            for (int i = 0; i < input_Var1.ToList().Count; i++)
            {

                Is_Input_Data_Valid_Array(UserList, input_Var, ref input_Var1, ref i);

            }
            return UserList;
        }

*/

        public Dictionary<string, int[]>  Main_Range_Dictionary(List<int> CurrentSamples_Unsorted)
        {
            Consecutive_Range_Check InstanceConsecutive_Range_Check = new Consecutive_Range_Check();
           // List<int> CurrentSamples_Unsorted = new List<int>();   //2,1, 2, 15, 4, 5, 6, 10, 2, 20, 21, 22, 23, 24, 25, 21,21,22,22};
          // CurrentSamples_Unsorted = InstanceConsecutive_Range_Check.Evaluate_Convert_To_Int_Input_Data();
            List<int> CurrentSamples_Without_Non_Consecutive_No = new List<int>();
            CurrentSamples_Unsorted.Sort();
            Dictionary<string, int[]> Dictionary_of_CurrentSamples = new Dictionary<string, int[]>();
            CurrentSamples_Without_Non_Consecutive_No = InstanceConsecutive_Range_Check.Delete_NonCosecutive_Numbers(CurrentSamples_Unsorted.ToArray());
            Dictionary_of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            InstanceConsecutive_Range_Check.Combine_String_Print_On_Console(Dictionary_of_CurrentSamples);
            return Dictionary_of_CurrentSamples;



        }
    }
}
