using CSharp_Oppg_4.Csv;
using CSharp_Oppg_4.Generators;

new CsvBuilder<Customer>()
	.ParseObjects(CsvGenerator.GetCustomersBogus())
	.WriteToFile("customers.csv")
	.Build();

var entries = CsvReader.Read("customers.csv");

var mappedCustomers = CsvMapper.MapToList<Customer>(entries);

Console.WriteLine($"Mapped {mappedCustomers.Count} customers.");

foreach(var c in mappedCustomers)
	Console.WriteLine("Index: {0}, Country: {1}, First Name: {2}, Last Name: {3}, Email: {4}", c.Index, c.Country, c.FirstName, c.LastName, c.Email);

