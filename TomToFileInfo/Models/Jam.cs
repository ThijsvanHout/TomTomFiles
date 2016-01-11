using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TomToFileInfo.Models
{
    public class Jam
    {
        public int JamID { get; set; }
        public int TrajectID { get; set; }
        public int RegionID { get; set; }
        public String JamText { get; set; }

        public virtual Traject Traject { get; set; }
        public virtual Region Region { get; set; }

    }

}