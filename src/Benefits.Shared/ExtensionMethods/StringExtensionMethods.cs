using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Benefits.Shared.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static string ToMd5Fingerprint(this string s)
        {
            var bytes = Encoding.Unicode.GetBytes(s.ToCharArray());
            var hash = MD5.Create().ComputeHash(bytes);

            // concat the hash bytes into one long string
            return hash.Aggregate(new StringBuilder(32),
                (sb, b) => sb.Append(b.ToString("X2")))
                .ToString();
        }
    }
}
