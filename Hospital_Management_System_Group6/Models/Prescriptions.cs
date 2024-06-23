using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Models
{
    public class Prescriptions
    {
        public int Id { get; set; }
        public string Medicine { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }
    }
}
