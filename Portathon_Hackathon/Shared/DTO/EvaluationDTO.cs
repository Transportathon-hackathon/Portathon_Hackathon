using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class EvaluationDTO
    {
        public string EvaluationMessage { get; set; }

        [Range(1, 5, ErrorMessage = "Evaluation score must be between 1 and 5.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal EvaluationScore { get; set; }
        public int ReservationId { get; set; }
    }
}
