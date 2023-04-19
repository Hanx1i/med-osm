using System;
using System.Collections.Generic;

namespace WpfApp1.model
{
	public class Doctor
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }

		public List<Inspection> Inspections { get; set; }
	}
}

