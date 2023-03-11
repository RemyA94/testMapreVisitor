using Microsoft.AspNetCore.Identity;
using testMapreVisitor.DbContext;

namespace testMapreVisitor.Models
{
    
    public class Visitor 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Phone { get; set; }
        public DateTime DateVisit { get; set; } = DateTime.Now;
    
    }

    
}
 