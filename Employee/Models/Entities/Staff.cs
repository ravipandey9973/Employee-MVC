using Microsoft.VisualBasic;

namespace Employee.Models.Entities
{
    public class Staff
    {
        public Guid     Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } =string.Empty;
        public DateTime DateOfJoining { get; set; }
        public string Subscribed { get; set;}= string.Empty;


        public string DateOfJoiningFormatted
        {
            get { return DateOfJoining.ToString("dd-MM-yyyy"); }
        }
    }
}
