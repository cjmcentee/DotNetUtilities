using System.Collections.Generic;
using System.Linq;

namespace StandardLibraryExtensions
{
    public static class ListExtensions
    {
        public static List<T> New<T>(params T[] values) {
            return new List<T>(values.ToList());
        }
    }
}
