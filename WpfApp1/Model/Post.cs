using System.Collections.Generic;

namespace WpfApp1.model
{
	
	public class Post
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public int ContractId { get; set; }
		public List<Contract> Contracts { get; set; } = new();
	}
}

