using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Student", Schema = "dbo")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string LastName {get;set;} = string.Empty;
        public string StudentCode {get;set;} = string.Empty;
        public DateTime BirthDate {get;set;}
        public ICollection<Score>? Scores {get;set;}
    }

}