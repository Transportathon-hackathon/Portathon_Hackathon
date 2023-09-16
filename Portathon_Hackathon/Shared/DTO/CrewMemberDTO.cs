using Portathon_Hackathon.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Portathon_Hackathon.Shared.DTO
{
    public class CrewMemberDTO
    {

        public int Id { get; set; }
        public string MemberName { get; set; }

    }
}
