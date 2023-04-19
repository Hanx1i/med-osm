using System;
using System.Collections.Generic;

namespace WpfApp1.model
{
	public class Employer
	{
		public int Id { get; set; }
		public string PersonalNum { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Patronymic { get; set; }
		public DateTime Dob { get; set; }
		public DateTime StartDate { get; set; } = DateTime.UtcNow;
		public DateTime EndDate { get; set;	}

        //public List<Contract> Contracts { get; set; }
        //public int MedCartId { get; set; }
        //public MedCart MedCart { get; set; }
        public Company Company { get; set; }
	}
}

