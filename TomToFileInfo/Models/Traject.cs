using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
//namespace TomTomFileInformatie.Models 
namespace TomToFileInfo.Models 
{ 
    public class Traject 
    { 
        public int ID { get; set; } 
        public String TrajectName { get; set; } 
        public DateTime JamDateTime { get; set; } 
        public virtual ICollection<Jam> Jams { get; set; } 
    } 
} 