using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using AgileTestProj.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Agile.Repository.Abstract.Models
{
    public class Ticket
    {
        [Key]
        public Guid TicketId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public ETicketStatus? TicketStatus { get; set; }
    }
}
