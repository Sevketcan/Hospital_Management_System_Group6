using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Branch { get; set; }

        public int HospitalId { get; set; }
        public Hospital Hospital { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
