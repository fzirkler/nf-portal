namespace NF_Portal.Models
{
    public class NfEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime AdditionalDate { get; set; }
        public string Person { get; set; }
        public string Phone { get; set; }
        public string IntroText { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string AdditionalInformation { get; set; }
        public DateTime Deadline { get; set; }

        public int NfProgramId { get; set; }
        public NfProgram NfProgram { get; set; }
    }
}