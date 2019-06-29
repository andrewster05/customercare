using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerCare.Data.Enums
{
    // TODO: Update using a table lookup to store Countries and State data
    public enum Country
    {
        Afghanistan = 1,
        Canada = 38,
        China = 44,
        [Display(Name = "United States")]
        UnitedStates = 231
    }
}
