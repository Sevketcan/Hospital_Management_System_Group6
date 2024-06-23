using Hospital_Management_System_Group6.Models;

namespace Hospital_Management_System_Group6.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public DateTime Time { get; set; }

        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public List<Prescriptions> Prescriptions { get; set; }
    }
}
