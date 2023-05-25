using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("Score", Schema = "dbo")]
    public class Score
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long StudentId { get; set; }
        public long CourseId { get; set; }
        public int Puntuation { get; set; }
        [ForeignKey(nameof(StudentId))] public Student? Student { get; set; }
        [ForeignKey(nameof(CourseId))] public Course? Course { get; set; }
    }
}