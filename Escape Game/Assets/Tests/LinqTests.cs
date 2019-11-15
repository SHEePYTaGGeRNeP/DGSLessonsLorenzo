using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Tests
{
    class LinqTests
    {
        static readonly int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8 };

        [Test]
        /// <summary>
        /// Here the normal loop multiplies all items and adds it to the list.
        /// While the LINQ version only loops over the results in ShowResultsLessThan7 and so not all items are multiplied.
        /// </summary>
        public void PositiveLinq()
        {
            List<int> list = new List<int>();
            Debug.Log("NORMAL LOOP");
            list.AddRange(Multiply(numbers));
            ShowResultsLessThan11(list);
            Debug.Log("---------------------------");
            Debug.Log("LINQ LOOP");
            IEnumerable<int> linqCollection = numbers.Select(Multiply);
            ShowResultsLessThan11(linqCollection);
        }

        [Test]
        /// <summary>
        /// Here the normal loop multiplies all items and adds it to the list.
        /// While the LINQ version it multiplies the items twice (once in contains and once in show results).
        /// </summary>
        public void NegativeLinq()
        {
            Debug.Log("NORMAL LOOP");
            List<int> list = new List<int>();
            list.AddRange(Multiply(numbers));
            Debug.Log("Checking contains..");
            // just a simple check that doesn't do much with a normal list
            if (list.Contains(Multiply(numbers[3])))
            {
                Debug.Log(String.Empty);
                ShowResultsLessThan11(list);
            }
            Debug.Log("---------------------------");
            Debug.Log("LINQ LOOP");
            IEnumerable<int> linqCollection = numbers.Select(Multiply);
            // this time the IEnumerable is empty until we check it, which is at Contains
            // the entire collections is evaluated, but then in ShowResults we loop
            // over the collection again.
            // notice the warning, possible multiple iterations over it.
            Debug.Log("Checking contains..");
            if (linqCollection.Contains(Multiply(numbers[3])))
            {
                Debug.Log(String.Empty);
                ShowResultsLessThan11(linqCollection);
            }
        }

        private static IEnumerable<int> Multiply(IList<int> ints)
        {
            int[] result = new int[ints.Count];
            for (int index = 0; index < ints.Count; index++)
            {
                result[index] = Multiply(ints[index]);
            }
            Debug.Log($"Done multiplying {String.Concat(ints.Select(x => $"{x} ,"))}");
            return result;
        }
        private static int Multiply(int i)
        {
            Debug.Log($"Multiplying... {i} * 2= {i*2}, imagine this takes some time...");
            return i * 2;
        }

        private static void ShowResultsLessThan11(IEnumerable<int> result)
        {
            Debug.Log("Results less than 11");
            foreach (int i in result)
            {
                if (i > 10)
                    break;
                Debug.Log(i);
                continue;
            }
        }
    }

}
