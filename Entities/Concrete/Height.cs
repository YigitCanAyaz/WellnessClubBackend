using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Height : IEntity
    {
        public int Id { get; set; }
        public double Meter { get; set; }
    }
}
