using System.Reflection;
using CSharp_Oppg_4.Attributes;

namespace CSharp_Oppg_4.Csv;



public class CsvBuilder<T>
{
	readonly string _header = "";
	readonly List<string> _lines = [];
	readonly List<PropertyInfo> _properties = [];

	bool _writeToFile = false;
	string _writePath = "";


	public CsvBuilder()
	{
		_properties = [.. typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(x => x.GetCustomAttribute<CsvIgnoreAttribute>() is null)];
		_header = string.Join(",", _properties.Select(p => p.GetCustomAttribute<CsvNameAttribute>()?.Name ?? p.Name));
	}

	public CsvBuilder<T> ParseObject(T obj)
	{
		List<string> values = [];
		foreach(var property in _properties)
		{
			var value = property.GetValue(obj)?.ToString() ?? "";
			values.Add(EscapeCsv(value));
		}


		_lines.Add(string.Join(",", values));
		return this;
	}

	public CsvBuilder<T> ParseObjects(IEnumerable<T> objects)
	{
		foreach(var o in objects)
			ParseObject(o);

		return this;
	}


	public CsvBuilder<T> WriteToFile(string path)
	{
		_writeToFile = true;
		_writePath = path;
		return this;
	}

	public string Build()
	{
		var temp = string.Join(Environment.NewLine, [_header, .. _lines]);

		if(_writeToFile)
		{
			File.WriteAllText(_writePath, temp);
		}

		return temp;
	}

	public List<string> BuildList()
	{

		if(_writeToFile)
		{
			Build();
		}
		return [_header, .. _lines];
	}

	private static string EscapeCsv(string value)
	{
		if(value.Contains(',') || value.Contains('"') || value.Contains('\n'))
		{
			value = value.Replace("\"", "\"\"");
			return $"\"{value}\"";
		}

		return value;
	}
}