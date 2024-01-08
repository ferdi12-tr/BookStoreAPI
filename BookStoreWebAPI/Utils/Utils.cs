using System.Text.RegularExpressions;

namespace BookStoreWebAPI.Utils
{
	public class Utils
	{
		public static string CenerateSlug(string title)
		{
			string str = title;
			str = str.ToLower();
			str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
			str = Regex.Replace(str, @"\s+", " ").Trim();
			str = Regex.Replace(str, @"\s", "-");
			return str;
		}
	}
}
