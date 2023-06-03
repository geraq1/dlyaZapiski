namespace Lab4.Domain
{

    public class Staff
    {
        public int Id { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public int? PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Position { get; set; }
        public int? AppointmentId { get; set; }
        public bool IsFree { get; set; }

        public bool SelectStaff (Staff staff)
        {
            return staff.IsFree;
        }
    }
    
}
