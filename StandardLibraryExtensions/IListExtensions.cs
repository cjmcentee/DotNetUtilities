﻿using System;
using System.Collections.Generic;

namespace StandardLibraryExtensions
{
    public static class IListExtensions
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

        public static T MaxValue<T>(this IList<T> list, Func<T, double> valueFunction) {
            return list[list.IndexOfMax(valueFunction)];
        }

        public static int IndexOfMax<T>(this IList<T> list, Func<T, double> valueFunction) {
            if (list == null) throw new ArgumentNullException("list");

            IEnumerator<T> enumerator = list.GetEnumerator();
            bool isEmptyList = !enumerator.MoveNext();

            if (isEmptyList) throw new ArgumentOutOfRangeException("list", "list is empty");

            int minIndex = 0;
            double maxValue = valueFunction(enumerator.Current);
            for (int i = 1; enumerator.MoveNext(); ++i) {
                double currentValue = valueFunction(enumerator.Current);
                if (currentValue > maxValue) {
                    maxValue = currentValue;
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
