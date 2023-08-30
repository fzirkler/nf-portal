using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;

namespace NF_Portal.Models
{
    public class NfProgram
    {
        public int Id { get; set; }
        [DisplayName("Von")]
        public DateTime From { get; set; }
        [DisplayName("Bis")]
        public DateTime To { get; set; }
        [DisplayName("Beschreibung")]
        public string Description { get; set; }
        [DisplayName("Editierbar")]
        public bool Editable { get; set; }

        [ValidateNever]
        public virtual ICollection<NfEvent> NfEvents { get; set; }
    }
}
