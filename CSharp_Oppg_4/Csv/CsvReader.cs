namespace CSharp_Oppg_4.Csv;

public class CsvReader
{

	/// <summary>
	/// Read CSV file and convert it to a List of dictionary for easy further mapping
	/// </summary>
	/// <param name="path"></param>
	/// <returns></returns>
	/// <exception cref="Exception"></exception>
	public static List<Dictionary<string, string>> Read(string path)
	{
		var lines = File.ReadAllLines(path);

		if(lines.Length == 0)
			return [];

		var headers = CsvParser.Parse(lines[0]);

		var result = new List<Dictionary<string, string>>();

		foreach(var line in lines.Skip(1))
		{
			var values = CsvParser.Parse(line);

			if(values.Count != headers.Count)
			{
				throw new Exception("CSV header does not match the given values");
			}

			var entry = headers
				.Select((header, index) => new KeyValuePair<string, string>(header, values[index]))
				.ToDictionary(x => x.Key, x => x.Value);

			result.Add(entry);
		}
		return result;
	}
}
