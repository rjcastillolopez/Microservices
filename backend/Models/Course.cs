using System.ComponentModel.DataAnnotations;   
using System.ComponentModel.DataAnnotations.Schema;                          

namespace backend.Models
{
    [Table("Course", Schema = "dbo")]
    public class Course
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Code {get;set;} = string.Empty;
        public ICollection<Score>? Scores {get;set;}
    }
}