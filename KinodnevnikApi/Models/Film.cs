using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinodnevnikApi.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> Date_Issue { get; set; }
        public Nullable<int> Duration { get; set; }
    }
}
