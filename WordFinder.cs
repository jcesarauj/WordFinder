using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordFinder
{
	public class WordFinder
	{
		private readonly HashSet<string> _matrix;
		private readonly HashSet<string> _resultSet;

		public WordFinder(IEnumerable<string> matrix)
		{
			_matrix = new HashSet<string>(matrix);
			_resultSet = new HashSet<string>();
		}

		public IEnumerable<string> Find(IEnumerable<string> wordstream)
		{
			SearchInLine(wordstream);
			SearchInColumn(wordstream);
			return _resultSet.ToList();
		}

		private void SearchInLine(IEnumerable<string> wordstream)
		{
			var lineStringBuilder = new StringBuilder();

			var characterMatrix = wordstream
				.Select(row => row.ToCharArray())
				.ToArray();

			for (var i = 0; i < characterMatrix.Length; i++)
			{
				lineStringBuilder.Length = 0;

				for (var j = 0; j < characterMatrix[i].Length; j++)
				{
					lineStringBuilder.Append(characterMatrix[i][j]);
				}

				_resultSet.UnionWith(_matrix.Where(searchTerm =>
												 lineStringBuilder.ToString().Contains(searchTerm)));
			}
		}

		private void SearchInColumn(IEnumerable<string> wordstream)
		{
			var columnStringBuilder = new StringBuilder();

			var characterMatrix = wordstream
				.Select(row => row.ToCharArray())
				.ToArray();

			for (var i = 0; i < characterMatrix.Length; i++)
			{
				columnStringBuilder.Length = 0;

				for (var j = 0; j < characterMatrix[i].Length; j++)
				{
					columnStringBuilder.Append(characterMatrix[j][i]);
				}

				_resultSet.UnionWith(_matrix.Where(searchTerm =>
												 columnStringBuilder.ToString().Contains(searchTerm)));
			}
		}
	}
}
