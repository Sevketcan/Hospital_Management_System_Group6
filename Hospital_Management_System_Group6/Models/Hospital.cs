using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public List<Doctor> Doctors { get; set; }
    }
}
