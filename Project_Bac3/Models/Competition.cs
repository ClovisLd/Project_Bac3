using System.Collections.Generic;

namespace Project_Bac3.Models
{
    public class Competition
    {
        public string Name {get; set;} = string.Empty;
        public List<string> Player_list {get; set;} = new List<string>();
        public Person Organisator {get; set;} = new Person {Name = "empty", Age=-1};
    }
}