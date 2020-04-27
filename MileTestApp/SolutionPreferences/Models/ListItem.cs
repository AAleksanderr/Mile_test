namespace SolutionPreferences.Models
{
    public class ListItem
    {
        public int Id { get; set; }
        public Tree Tree { get; set; }
        public string ParentId { get; set; }
    }
}