using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgileTestProj.Enums
{
    public enum ETicketStatus
    {
        ToDo = 0,
        InProgress = 1,
        [Display(Name = "Done")]
        Done = 2
    }
}
