using System.ComponentModel.DataAnnotations;

namespace TSD2491_oblig_1_261660.Models
{
    public class Bruker
    {
        public int Id { get; set; }
        
        public string? Navn { get; set; }
        
        public string? Kontakt { get; set; }
        
        public int Spill { get; set; }
    }
          
}

