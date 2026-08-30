namespace CSharp_Oppg_4.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class CsvNameAttribute(string name) : Attribute
{
	public string Name { get; } = name;
}