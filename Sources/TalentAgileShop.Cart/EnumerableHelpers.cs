using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentAgileShop.Cart
{
    public static class EnumerableHelpers
    {
        public static IEnumerable<IEnumerable<T>> Partition<T>(this IEnumerable<T> sequence, int size)
        {
            var partition = new List<T>(size);
            foreach (var item in sequence)
            {
                partition.Add(item);
                if (partition.Count != size) continue;
                yield return partition;
                partition = new List<T>(size);
            }
            if (partition.Count > 0)
                yield return partition;
        }
    }
}
