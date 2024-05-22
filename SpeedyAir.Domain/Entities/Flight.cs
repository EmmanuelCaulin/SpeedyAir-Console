using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyAir.Domain.Entities
{
    public sealed class Flight
    {
        public int number {  get; set; }
        public string departure { get; set; }
        public string arrival { get; set; }
        public int day { get; set; }
    }
}
