using System.Collections.Generic;
using System.Linq;

namespace CodeBuild
{
    /// <summary>
    /// 应用程序地址
    /// </summary>
    public static class AppServices
    {
        public static List<T> ToList<T>(this IEnumerable<object> input)
        {
            return input.Select(node => (T)node).ToList();
        }
        public static T[] ToArray<T>(this IEnumerable<object> input)
        {
            return input.Select(node => (T)node).ToArray();
        }
    }
}