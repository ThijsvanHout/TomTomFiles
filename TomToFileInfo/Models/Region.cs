using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace TomToFileInfo.Models 
{ 
    public class Region 
    { 
        public int RegionID { get; set; } 
        public String RegionName { get; set; } 
        public virtual ICollection<Jam> Jams { get; set; } 
    } 
}