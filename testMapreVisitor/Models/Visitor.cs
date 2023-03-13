using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace testMapreVisitor.Models
{
 
    public class Visitor
    {


        public Guid Id { get; set; }
        [JsonProperty]
        [Required(ErrorMessage = "Field {0} is required")]
        //[Range(minimum: 1, maximum: 20, ErrorMessage = "Name must be between {0} and {20} characters")]
        public string Name { get; set; }

        [JsonProperty]

       [Required(ErrorMessage = "Field {0} is required")]
        //[Range(minimum: 1, maximum: 20, ErrorMessage = "Last Name must be between {0} and {20} characters")]
        public string LastName { get; set; }

        [JsonProperty]
        
        [Required(ErrorMessage = "Field {0} is required")]
        [EmailAddress]
        public string Mail { get; set; }

        [JsonProperty]

        [Required(ErrorMessage = "Field {0} is required")]
        [Phone]
        public string Phone { get; set; }

        [JsonProperty]

        [Required(ErrorMessage = "Field Date visit is required")]
        public DateTime DateVisit { get; set; } = DateTime.Now;
    
    }

    
}
 