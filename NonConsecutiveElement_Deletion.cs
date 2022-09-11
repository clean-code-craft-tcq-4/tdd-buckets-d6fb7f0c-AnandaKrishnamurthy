using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consecutive_No_Range_Checker
{
    public class NonConsecutiveElement_Deletion
    {
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
        public List<int> Add_if_elements_Difference_One_From_2nd_Element(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 1))
            {
                Samples_Buffer_1 = Check_And_Add_First_Cosecutive_No(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2).ToList();
                Samples_Buffer_1 = Check_And_Add_Second_Cosecutive_No(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2).ToList();
            }


            return Samples_Buffer_1.ToList();
        }

        public List<int> Add_if_elements_Difference_Zero_From_2nd_Element(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {

            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) == 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }

            if ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements + 1]) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) == 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }
            if ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements + 1]) == 0) & ((Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 1) & (Math.Abs(iCurrentSamples[Array_Elements] - iCurrentSamples[Array_Elements - 1]) != 0)))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);

            }

            return Samples_Buffer_1.ToList();
        }

        public List<int> Add_if_elements_First_Two_Difference_One(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 1))
            {

                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements + 1]);

            }
            return Samples_Buffer_1.ToList();
        }

        public List<int> Add_if_elements_First_Two_Difference_Zero(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            if ((Math.Abs(iCurrentSamples[Array_Elements] - (iCurrentSamples[Array_Elements + 1])) == 0))
            {
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements]);
                Samples_Buffer_1.Add(iCurrentSamples[Array_Elements + 1]);
            }

            return Samples_Buffer_1.ToList();

        }
        public List<int> Remove_NonConsecutiveElement_From_array(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            List<int> arr4 = new List<int>();
            List<int> arr5 = new List<int>();
            arr4 = Remove_NonConsecutiveElement_From_First_Two_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList()).ToList();
            arr5 = Remove_NonConsecutiveElement_Except_First_Two_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2.ToList()).ToList();
            arr4.AddRange(arr5.ToList());
            return arr4.ToList();
        }

        public List<int> Remove_NonConsecutiveElement_Except_First_Two_Element(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1, List<int> Samples_Buffer_2)
        {
            if (Array_Elements != 0)
            {
                Samples_Buffer_1 = Add_if_elements_Difference_One_From_2nd_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList(), Samples_Buffer_2.ToList()).ToList();
                Samples_Buffer_1 = Add_if_elements_Difference_Zero_From_2nd_Element(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList()).ToList();

            }
            return Samples_Buffer_1.ToList();
        }

        public List<int> Remove_NonConsecutiveElement_From_First_Two_Element(int[] iCurrentSamples, int Array_Elements, List<int> Samples_Buffer_1)
        {
            if (Array_Elements == 0)
            {
                Samples_Buffer_1 = Add_if_elements_First_Two_Difference_One(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList()).ToList();
                Samples_Buffer_1 = Add_if_elements_First_Two_Difference_Zero(iCurrentSamples, Array_Elements, Samples_Buffer_1.ToList()).ToList();
            }
            return Samples_Buffer_1.ToList();
        }
    }
}
