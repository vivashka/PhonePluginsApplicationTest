namespace EmployeesFetchPlugin.Models
{
       public class Address
    {
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string stateCode { get; set; }
        public string postalCode { get; set; }
        public Coordinates coordinates { get; set; }
        public string country { get; set; }
    }
}