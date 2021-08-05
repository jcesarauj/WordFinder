using System;

namespace WordFinder
{
	class Program
	{
		public static void Main()
		{
			var matrix = new string[] { "chill", "cold", "wind" };
			var wordstream = new string[] { "abcdc", "fgwio", "chill", "pqnsd", "uvdxy" };
			var result = new WordFinder(matrix).Find(wordstream);
			Console.WriteLine(string.Join(",", result));
		}		
	}
}
