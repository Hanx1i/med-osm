using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WpfApp1.model
{
    [Index("Code", IsUnique = true)]
    public class Company
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string LegalAddress { get; set; }

        public List<Employer> Employers { get; set; } = new();
    }
}

