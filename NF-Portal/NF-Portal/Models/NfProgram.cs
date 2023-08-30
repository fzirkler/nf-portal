using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NF_Portal.Models
{
    public class NfProgram
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; }

        [ValidateNever]
        public ICollection<NfEvent> NfEvents { get; set; }
    }
}
