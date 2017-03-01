using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Applabs.Marketing.Demo.Models
{
    [MetadataType(typeof(ALSEmployeeDate))]
    public partial class ALSEmployee
    {
    }
    public class ALSEmployeeDate
    {

        [DataType(DataType.Date)]

        public string D_O_B { get; set; }
    }


    [MetadataType(typeof(ALSMarketingDate))]
    public partial class ALSMarketing
    {

    }
    public class ALSMarketingDate
    {
        [DataType(DataType.Date)]
        public string Date { get; set; }
    }
}