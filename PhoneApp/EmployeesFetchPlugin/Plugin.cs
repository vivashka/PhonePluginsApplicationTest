using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EmployeesFetchPlugin.Mappers;
using EmployeesFetchPlugin.Models;
using NLog;
using NLog.Layouts;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;

namespace EmployeesFetchPlugin
{
    [Author(Name = "Vladimir Cheranev")]
    public class Plugin : IPluggable
    {

        private readonly string url = "https://dummyjson.com/users";
        
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            
            var content =  GetEmployees();
            
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(content);
            var employeesList = EmployeesMapper.ToListEmployees(root);

            int index = 0;
            StringBuilder info = new StringBuilder();

            info.Append("Загружено объектов" + employeesList.Count);
            // foreach(var employee in employeesList)
            // {
            //     info.Append(string.Format("\n{0} Name: {1} | Phone: {2}", index, employee.Name, employee.Phone));
            //     ++index;
            // }
            logger.Info(info);

            employeesList.AddRange(args.Cast<EmployeesDTO>());
            return employeesList.Cast<DataTransferObject>();
        }

        private string GetEmployees()
        {
            try
            {
                logger.Info("Start loading Employees");
                var client = new HttpClient();
                
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                string content = response.Content.ReadAsStringAsync().Result;

                return content;

            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                
                return "";
            }
        }
    }
}