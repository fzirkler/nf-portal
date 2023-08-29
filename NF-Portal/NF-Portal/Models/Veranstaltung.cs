using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NF_Portal.Models
{
    public class Veranstaltung
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Termin { get; set; }
        public DateTime Ersatztermin { get; set; }
        public string Auskunftsperson { get; set; }
        public string Telefon { get; set; }
        public string IntroText { get; set; }
        public string Beschreibung { get; set; }
        public string Treffpunkt { get; set; }
        public string Bemerkung { get; set; }
        public DateTime Anmeldeschluss { get; set; }
        [ValidateNever]
        public Programm Programm { get; set; }
        [ValidateNever]
        public int ProgrammId { get; set; }
    }
}
