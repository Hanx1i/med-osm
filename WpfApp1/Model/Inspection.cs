using System;
namespace WpfApp1.model
{
	public class Inspection
	{
		public int Id { get; set; }
		public DateTime DateOfPassage { get; set; } = DateTime.UtcNow;
		public string ToleranceMark { get; set; }

		public MedCart MedCart { get; set; }
        public InspectionResult InspectionResult { get; set; }
        public Doctor Doctor { get; set; }
	}
}

