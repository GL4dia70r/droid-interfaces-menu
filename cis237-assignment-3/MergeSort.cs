using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment_3
{
    internal class MergeSort
    {
        protected int _aSize;
        protected IComparable[] _array;

        // Main entry point to sort
        public MergeSort(IComparable[] a, int length)
        {
            this._aSize = length;
            this._array = a;

            IComparable[] aux = new IComparable[a.Length];
            this._array.CopyTo(aux, 0);

            Sort(a, aux, 0, a.Length - 1);
        }

        // mergesort a[lo..hi] using auxiliary array aux[lo..hi]
        private static void Sort(
            IComparable[] a,
            IComparable[] aux,
            int lo,
            int hi
          )
        {
            if (hi <= lo) return;
            int mid = lo + (hi - lo) / 2;
            Sort(a, aux, lo, mid);
            Sort(a, aux, mid + 1, hi);
            Merge(a, aux, lo, mid, hi);
        }


        // Merge a[lo .. mid] with a[mid+1 .. hi] using aux[lo .. hi]
        private static void Merge(IComparable[] a, IComparable[] aux, int lo, int mid, int hi)
        {

            // Copy to aux[]
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
            }

            // Merge back to a[]
            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                { // Index past left subarray max index
                    a[k] = aux[j++];
                }
                else if (j > hi)
                { // index past right subarray max index
                    a[k] = aux[i++];
                }
                else if (aux[j].CompareTo(aux[i]) < 0)
                {  // compare
                    a[k] = aux[j++];
                }
                else
                {
                    a[k] = aux[i++];
                }
            }
        }

        
    }
}
