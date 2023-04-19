namespace WpfApp1.model
{
	public class InspectionResult
	{
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }

		public int InspectionId { get; set; }
		public Inspection Inspection { get; set; }
	}
}

