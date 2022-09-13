using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Xunit;

namespace Test_Framework
{
    public class UnitTest1
    {
        Consecutive_Range_Check InstanceConsecutive_Range_Check = new Consecutive_Range_Check();
        List<int> Input1 = new List<int> {1,3,2,2,4,6,8,9,1000,1001,1002};
        List<int> Input2 = new List<int> { 1 };
        List<int> Input3 = new List<int> { 2, 2, 2, 2, 2 };
        List<int> Input4 = new List<int> {1,2,3,10,10,10,11,12,13};
        List<int> Input5 = new List<int> { 0, 0, 0 };

        internal void Help_Method(List<int> CurrentSamples_Without_Non_Consecutive_No,List<int> Expected_List)
        {
            for (int i = 0; i < CurrentSamples_Without_Non_Consecutive_No.Count - 1; i++)
            {
                Debug.Assert(CurrentSamples_Without_Non_Consecutive_No[i] == Expected_List[i]);
            }

        }



        [Fact]
        public void Test_Method_Main_Range_Dictionary()
        {
            /* Test case with Test sample list 1 */
            
            Dictionary<string, int[]> Consecutove_Range_Of_CurrentSamples = new Dictionary<string, int[]>();

            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Main_Range_Dictionary(Input1);
            var Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1-4"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 5);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["8-9"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 2);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1000-1002"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);

            /* Test case with Test sample list 2 */
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Main_Range_Dictionary(Input2);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 1);

            /* Test case with Test sample list 3 */         
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Main_Range_Dictionary(Input3);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["2-2"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 5);

            /* Test case with Test sample list 4 */         
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Main_Range_Dictionary(Input4);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1-3"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["10-13"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 6);


            /* Test case with Test sample list 5 */
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Main_Range_Dictionary(Input5);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["0-0"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);
            
        }

        [Fact]
        public void Test_method_Delete_NonCosecutive_Numbers()
        {
            /* Test case with Test sample list 1 */
            Input1.Sort();
            List<int> CurrentSamples_Without_Non_Consecutive_No = new List<int>();
             CurrentSamples_Without_Non_Consecutive_No=InstanceConsecutive_Range_Check.Delete_NonCosecutive_Numbers(Input1.ToArray());
             List<int> Expected_List_1 = new List<int> {1,2,2,3,4,8,9,1000,1001,1002};         
             Debug.Assert(CurrentSamples_Without_Non_Consecutive_No.Count() == Expected_List_1.Count());
             Help_Method(CurrentSamples_Without_Non_Consecutive_No, Expected_List_1);  


            /* Test case with Test sample list 2 */
            Consecutive_Range_Check Instance_1Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input2.Sort();            
            CurrentSamples_Without_Non_Consecutive_No = Instance_1Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input2.ToArray());
            List<int> Expected_List_2 = new List<int> {1};
            Debug.Assert(CurrentSamples_Without_Non_Consecutive_No.Count() == Expected_List_2.Count());
            Help_Method(CurrentSamples_Without_Non_Consecutive_No, Expected_List_2);

            /* Test case with Test sample list 3 */
            Consecutive_Range_Check Instance_2Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input3.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_2Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input3.ToArray());
            List<int> Expected_List_3 = new List<int> { 2, 2, 2, 2, 2 };
            Debug.Assert(CurrentSamples_Without_Non_Consecutive_No.Count() == Expected_List_3.Count());
            Help_Method(CurrentSamples_Without_Non_Consecutive_No, Expected_List_3);
            /* Test case with Test sample list 4 */

            Input4.Sort();
            Consecutive_Range_Check Instance_3Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            CurrentSamples_Without_Non_Consecutive_No = Instance_3Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input4.ToArray());
            List<int> Expected_List_4 = new List<int> { 1, 2, 3, 10, 10, 10, 11, 12, 13 };
            Debug.Assert(CurrentSamples_Without_Non_Consecutive_No.Count() == Expected_List_4.Count());
            Help_Method(CurrentSamples_Without_Non_Consecutive_No, Expected_List_4);


            /* Test case with Test sample list 5 */
            Consecutive_Range_Check Instance_4Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input5.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_4Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input4.ToArray());
            List<int> Expected_List_5 = new List<int> { 1, 2, 3, 10, 10, 10, 11, 12, 13 };
            Debug.Assert(CurrentSamples_Without_Non_Consecutive_No.Count() == Expected_List_5.Count());
            Help_Method(CurrentSamples_Without_Non_Consecutive_No, Expected_List_5);
        }


        [Fact]
        public void Test_Method_Saparate_Cosecutive_Numbers_With_Ranges()
        {
            /* Test case with Test sample list 1 */
            Input1.Sort();
            List<int> CurrentSamples_Without_Non_Consecutive_No = new List<int>();
            Dictionary<string, int[]> Consecutove_Range_Of_CurrentSamples = new Dictionary<string, int[]>();
            CurrentSamples_Without_Non_Consecutive_No = InstanceConsecutive_Range_Check.Delete_NonCosecutive_Numbers(Input1.ToArray());
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            var Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1-4"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 5);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["8-9"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 2);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1000-1002"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);

            /* Test case with Test sample list 2 */
            Consecutive_Range_Check Instance_1Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input2.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_1Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input2.ToArray());
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 1);

            /* Test case with Test sample list 3 */
            Consecutive_Range_Check Instance_2Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input3.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_2Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input3.ToArray());
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["2-2"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 5);

            /* Test case with Test sample list 4 */
            Consecutive_Range_Check Instance_3Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input4.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_3Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input4.ToArray());
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["1-3"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["10-13"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 6);


            /* Test case with Test sample list 5 */
            Consecutive_Range_Check Instance_4Consecutive_Range_Check = new Consecutive_Range_Check();
            CurrentSamples_Without_Non_Consecutive_No.Clear();
            Input5.Sort();
            CurrentSamples_Without_Non_Consecutive_No = Instance_4Consecutive_Range_Check.Delete_NonCosecutive_Numbers(Input5.ToArray());
            Consecutove_Range_Of_CurrentSamples = InstanceConsecutive_Range_Check.Saparate_Cosecutive_Numbers_With_Ranges(CurrentSamples_Without_Non_Consecutive_No.ToArray());
            Consecutive_Range_Of_CurrentSample_Range = Consecutove_Range_Of_CurrentSamples["0-0"];
            Debug.Assert(Consecutive_Range_Of_CurrentSample_Range.Count() == 3);
            
        }

    }


}
