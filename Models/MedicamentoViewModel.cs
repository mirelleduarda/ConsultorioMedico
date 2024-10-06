using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ConsultorioMedico.Models
{
    public class MedicamentoViewModel
    {
        public List<SelectListItem> Medicamentos { get; set; } = new List<SelectListItem>();
    }
}

