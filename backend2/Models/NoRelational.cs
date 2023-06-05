using System.ComponentModel.DataAnnotations;   
using System.ComponentModel.DataAnnotations.Schema;    

namespace backend2.Models
{
    [Table("NoRelational", Schema="dbo")]
    public class NoRelational
    {  
        // No incremental key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Value {get;set;} = string.Empty;
        public string Childs {get;set;} = string.Empty;
    }
}