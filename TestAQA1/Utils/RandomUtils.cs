using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationTests.Utils
{
    public static class RandomUtils
    {
        public static T GetRandomItem<T>(IList<T> items)
        {
            if (items == null || items.Count == 0)
                throw new ArgumentException("List is null or empty");

            var rnd = new Random();
            int index = rnd.Next(items.Count);
            return items[index];
        }
    }
}
