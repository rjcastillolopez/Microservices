namespace backend2.Models
{
    public class Relational
    {
        public long Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string Value {get;set;} = string.Empty;
        public long ParentId {get;set;} = -1;  // -1 means no parent
    }
}