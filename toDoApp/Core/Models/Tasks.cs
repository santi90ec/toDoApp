using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Tasks
    {
        public int idTask { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public int idUser { get; set; }
    }
}
