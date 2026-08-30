using CSharp_Oppg_4.Attributes;

namespace CSharp_Oppg_4.Models;

public record class Customer
{
	[CsvName("id")]
	public int Index { get; set; }
	public int CustomerId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Company { get; set; }
	public string City { get; set; }
	public string Country { get; set; }
	public string Phone1 { get; set; }
	public string Phone2 { get; set; }
	public string Email { get; set; }
	public string Subscription { get; set; }
	public DateTime Date { get; set; }
	public string Website { get; set; }


	[CsvIgnore]
	public string Testing { get; set; } = "this should not be parsed";


	//empty constructor for the CsvMapper
	public Customer() { }

	public Customer(int index, int customerId, string firstName, string lastName, string company, string city, string country, string phone1, string phone2, string email, string subscription, DateTime date, string website)
	{
		this.Index = index;
		this.CustomerId = customerId;
		this.FirstName = firstName;
		this.LastName = lastName;
		this.Company = company;
		this.City = city;
		this.Country = country;
		this.Phone1 = phone1;
		this.Phone2 = phone2;
		this.Email = email;
		this.Subscription = subscription;
		this.Date = date;
		this.Website = website;
	}
}