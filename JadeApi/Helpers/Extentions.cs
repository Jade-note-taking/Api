using System.Security.Claims;
using System.Text;

namespace JadeApi.Helpers;

public static class Extentions
{
    public static string ToHex(this byte[] bytes, bool upperCase=false)
    {
        StringBuilder result = new StringBuilder(bytes.Length*2);

        for (int i = 0; i < bytes.Length; i++)
            result.Append(bytes[i].ToString(upperCase ? "X2" : "x2"));

        return result.ToString();
    }

    public static string? GetUserId(this IEnumerable<Claim> claims)
    {
        var userId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        return userId?.Split("|").Last();
    }
}