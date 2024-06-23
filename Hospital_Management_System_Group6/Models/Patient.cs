using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Tc { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public List<Appointment> Appointments { get; set; }
        public List<Prescriptions> Prescriptions { get; set; }
    }
}
