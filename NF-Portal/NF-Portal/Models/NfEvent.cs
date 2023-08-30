using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace NF_Portal.Models
{
    public class NfEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Datum")]
        public DateTime EventDate { get; set; }
        [DisplayName("Ersatztermin")]
        public DateTime AdditionalDate { get; set; }
        [DisplayName("Ansprechpartner")]
        public string Person { get; set; }
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        [DisplayName("Intro-Text")]
        public string IntroText { get; set; }
        [DisplayName("Beschreibung")]
        public string Description { get; set; }
        [DisplayName("Treffpunkt")]
        public string Location { get; set; }
        [DisplayName("Zusätzliche Informationen")]
        public string AdditionalInformation { get; set; }
        [DisplayName("Anmeldeschluss")]
        public DateTime Deadline { get; set; }

        [ValidateNever]
        public virtual int NfProgramId { get; set; }
        [ValidateNever]
        public virtual NfProgram NfProgram { get; set; }
    }
}