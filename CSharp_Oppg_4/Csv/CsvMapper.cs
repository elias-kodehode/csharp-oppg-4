using System.Reflection;
using CSharp_Oppg_4.Attributes;

namespace CSharp_Oppg_4.Csv;

internal class CsvMapper
{
	public static List<T> MapToList<T>(IEnumerable<Dictionary<string, string>> entries) where T : class, new()
	{
		return entries.Select(x => MapTo<T>(x)).ToList();
	}



	public static T MapTo<T>(Dictionary<string, string> entry) where T : class, new()
	{
		var instance = new T();

		var properties = typeof(T)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.CanWrite && p.GetCustomAttribute<CsvIgnoreAttribute>() is null);

		foreach(var prop in properties)
		{
			var csvName = prop.GetCustomAttribute<CsvNameAttribute>();
			var key = csvName?.Name ?? prop.Name;

			if(!entry.TryGetValue(key, out var value))
				continue;



			var convertedValue = ConvertValue(value, prop.PropertyType);

			prop.SetValue(instance, convertedValue);
		}

		return instance;
	}


	private static object? ConvertValue(string value, Type targetType)
	{
		var underlyingType = Nullable.GetUnderlyingType(targetType);

		if(underlyingType != null)
		{
			if(string.IsNullOrWhiteSpace(value))
				return null;

			targetType = underlyingType;
		}

		if(targetType.IsEnum)
			return Enum.Parse(targetType, value, ignoreCase: true);

		return System.Convert.ChangeType(value, targetType);
	}


}
