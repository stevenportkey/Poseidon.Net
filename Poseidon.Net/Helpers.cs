using System.Collections.Generic;
using System.Linq;

namespace Poseidon.Net
{
    using InputType = IDictionary<string, IList<string>>;

    public static class Helpers
    {
        internal static string ToJsonString(this IList<string> values)
        {
            return "[" + string.Join(",", values.Select(x => $"\"{x}\"")) + "]";
        }

        internal static string ToJsonString(this IList<List<string>> values)
        {
            return "[" + string.Join(",", values.Select(x => x.ToJsonString())) + "]";
        }
    }
}