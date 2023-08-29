using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace NF_Portal.Models
{
    public class Programm
    {
        [Key]
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }

        [ValidateNever]
        public ICollection<Veranstaltung> Veranstaltungs { get; set; }
    }
}
