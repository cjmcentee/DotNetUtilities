using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardLibraryExtensions
{
    public static class IListExtension
    {
        public static T MinValue<T>(this IList<T> list, Func<T, double> valueFunction) {
            return list[list.IndexOfMin(valueFunction)];
        }

        public static int IndexOfMin<T>(this IList<T> list, Func<T, double> valueFunction) {
            if (list == null) throw new ArgumentNullException("list");

            IEnumerator<T> enumerator = list.GetEnumerator();
            bool isEmptyList = !enumerator.MoveNext();

            if (isEmptyList) throw new ArgumentOutOfRangeException("list", "list is empty");

            int minIndex = 0;
            double minValue = valueFunction(enumerator.Current);
            for (int i = 1; enumerator.MoveNext(); ++i) {
                double currentValue = valueFunction(enumerator.Current);
                if (currentValue < minValue) {
                    minValue = currentValue;
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
