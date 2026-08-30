namespace CSharp_Oppg_4.Csv;

public static class CsvParser
{
	public static List<string> Parse(string line)
	{
		List<string> values = [];
		var current = "";
		var insideQuotes = false;

		foreach(var ch in line)
		{
			if(ch == '"')
			{
				insideQuotes = !insideQuotes;
			}
			else if(ch == ',' && !insideQuotes)
			{
				values.Add(current);
				current = "";
			}
			else
			{
				current += ch;
			}
		}
		values.Add(current);
		return values;
	}


}
