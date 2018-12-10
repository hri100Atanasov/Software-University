using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class Medicament
    {
        public int MedicamentId { get; set; }
        public string Name { get; set; }
        public ICollection<PatientMedicament> Prescriptions { get; set; }
    }
}
