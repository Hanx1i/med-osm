using System;
namespace WpfApp1.model
{
	public class Contract
	{
		public int Id { get; set; }
		public int Salary { get; set; }
		public string Subdivision { get; set; }

		public Post Post { get; set; }
		public Employer Employer { get; set; }
	}
}

