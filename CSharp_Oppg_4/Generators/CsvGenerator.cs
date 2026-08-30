using Bogus;

namespace CSharp_Oppg_4.Generators;

public class CsvGenerator
{

	public static Customer[] GetCustomersBogus()
	{

		Randomizer.Seed = new Random(512312);
		int users = 0;
		var testData = new Faker<Customer>()
			.StrictMode(true)
			.RuleFor(x => x.Index, f => users++)
			.RuleFor(x => x.Country, f => f.Address.Country())
			.RuleFor(x => x.City, f => f.Address.City())
			.RuleFor(x => x.Email, f => f.Person.Email)
			.RuleFor(x => x.Phone1, f => f.Person.Phone)
			.RuleFor(x => x.Phone2, f => f.Person.Phone)
			.RuleFor(x => x.Company, f => f.Company.CompanyName())
			.RuleFor(x => x.CustomerId, f => 1000 + users)
			.RuleFor(x => x.Date, f => f.Date.Past())
			.RuleFor(x => x.Subscription, f => "Basic")
			.RuleFor(x => x.FirstName, f => f.Person.FirstName)
			.RuleFor(x => x.LastName, f => f.Person.LastName)
			.RuleFor(x => x.Website, f => f.Person.Website)
			.RuleFor(x => x.Testing, f => "hello");
		return [.. testData.Generate(50)];
	}

	public static Customer[] GetCustomers() => [
	new Customer(
		1, 1001, "John", "Doe", "Acme Corporation", "Oslo", "Norway",
		"+47 123 45 678", "+47 987 65 432", "john.doe@example.com",
		"Premium", new DateTime(2026, 8, 21), "https://www.acme.example"),

	new Customer(
		2, 1002, "Emma", "Hansen", "Nordic Solutions AS", "Bergen", "Norway",
		"+47 456 78 901", "+47 912 34 567", "emma.hansen@example.com",
		"Basic", new DateTime(2026, 7, 15), "https://www.nordicsolutions.example"),

	new Customer(
		3, 1003, "Liam", "Smith", "TechWorld Ltd", "London", "United Kingdom",
		"+44 20 1234 5678", "+44 7700 900123", "liam.smith@example.com",
		"Premium", new DateTime(2026, 6, 10), "https://www.techworld.example"),

	new Customer(
		4, 1004, "Sofia", "Garcia", "Iberia Consulting", "Madrid", "Spain",
		"+34 91 123 4567", "+34 600 123 456", "sofia.garcia@example.com",
		"Enterprise", new DateTime(2026, 5, 22), "https://www.iberiaconsulting.example"),

	new Customer(
		5, 1005, "Oliver", "Müller", "Müller & Partners", "Berlin", "Germany",
		"+49 30 123456", "+49 151 12345678", "oliver.muller@example.com",
		"Basic", new DateTime(2026, 4, 18), "https://www.mullerpartners.example"),

	new Customer(
		6, 1006, "Ava", "Johnson", "Bright Future Inc.", "New York", "United States",
		"+1 212 555 0101", "+1 917 555 0199", "ava.johnson@example.com",
		"Premium", new DateTime(2026, 3, 12), "https://www.brightfuture.example"),

	new Customer(
		7, 1007, "Noah", "Andersen", "Fjord Consulting", "Trondheim", "Norway",
		"+47 734 56 789", "+47 998 76 543", "noah.andersen@example.com",
		"Enterprise", new DateTime(2026, 2, 8), "https://www.fjordconsulting.example"),

	new Customer(
		8, 1008, "Isabella", "Rossi", "Rossi Design Studio", "Rome", "Italy",
		"+39 06 1234 5678", "+39 333 1234567", "isabella.rossi@example.com",
		"Basic", new DateTime(2026, 1, 25), "https://www.rossidesign.example"),

	new Customer(
		9, 1009, "Lucas", "Silva", "SouthTech", "Lisbon", "Portugal",
		"+351 21 123 4567", "+351 912 345 678", "lucas.silva@example.com",
		"Premium", new DateTime(2025, 12, 14), "https://www.southtech.example"),

	new Customer(
		10, 1010, "Mia", "Larsson", "ScandiSoft AB", "Stockholm", "Sweden",
		"+46 8 123 456", "+46 70 123 4567", "mia.larsson@example.com",
		"Enterprise", new DateTime(2025, 11, 30), "https://www.scandisoft.example")
];

}
