using System;
using System.Collections.Generic;

namespace WpfApp1.model
{
	public class MedCart
	{
		public int Id { get; set; }
		public string Number { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public Employer Employer { get; set; }
		public List<Inspection> Inspections { get; set; }
	}
}

