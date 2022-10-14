using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class UserWeight
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WeightId { get; set; }
    }
}
