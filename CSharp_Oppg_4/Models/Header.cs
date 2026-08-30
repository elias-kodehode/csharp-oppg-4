record Header(string Value)
{
	public static implicit operator string(Header header) => header.Value;
	public static implicit operator Header(string Value) => new(Value);
}


