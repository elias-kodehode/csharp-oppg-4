using System.Reflection;
using CSharp_Oppg_4.Attributes;

namespace CSharp_Oppg_4.Csv;

internal class CsvMapper
{

	/// <summary>
	/// Map a list of CSV Key/Value pairs to a list of generic c# objects
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entries"></param>
	/// <returns></returns>
	public static List<T> MapToList<T>(IEnumerable<Dictionary<string, string>> entries) where T : class, new()
	{
		return [.. entries.Select(MapTo<T>)];
	}


	/// <summary>
	/// Map a dictionary of CSV Key/Value Pairs to a generic C# object
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="entry"></param>
	/// <returns></returns>
	public static T MapTo<T>(Dictionary<string, string> entry) where T : class, new()
	{
		var instance = new T();

		/*
		 * Get All public instance properties of <T>, that does NOT have the CsvIgnore Attribute
		 * */
		var properties = typeof(T)
			.GetProperties(BindingFlags.Public | BindingFlags.Instance)
			.Where(p => p.CanWrite && p.GetCustomAttribute<CsvIgnoreAttribute>() is null);


		foreach(var prop in properties)
		{
			/*
			 * If the property has a CsvName Attribute, use that as the key
			 * If not, use the name of the property
			 * */
			var csvName = prop.GetCustomAttribute<CsvNameAttribute>();
			var key = csvName?.Name ?? prop.Name;


			/*
			 * Get the value of the property
			 */
			if(!entry.TryGetValue(key, out var value))
				continue;


			/*
			 * Attempt to convert the value to a specific type
			 */
			var convertedValue = ConvertValue(value, prop.PropertyType);

			/*
			 * Set the value of the property to the converted value
			 */
			prop.SetValue(instance, convertedValue);
		}

		return instance;
	}


	/// <summary>
	/// Convert the property value to a specific type
	/// </summary>
	/// <param name="value"></param>
	/// <param name="targetType"></param>
	/// <returns></returns>
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
