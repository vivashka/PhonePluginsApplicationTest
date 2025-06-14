using System.Collections.Generic;

namespace EmployeesFetchPlugin.Models
{
    public class Root
    {
        public List<User> users { get; set; }
        public int total { get; set; }
        public int skip { get; set; }
        public int limit { get; set; }
    }
}