using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blazor.Components.Application.Models
{
    public class TodoItem
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }
    }
}
