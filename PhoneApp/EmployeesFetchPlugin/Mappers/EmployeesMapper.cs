using System.Collections.Generic;
using EmployeesFetchPlugin.Models;
using PhoneApp.Domain.DTO;

namespace EmployeesFetchPlugin.Mappers
{
    public static class EmployeesMapper
    {
        public static List<EmployeesDTO> ToListEmployees(Root root)
        {
            var list = new List<EmployeesDTO>();

            foreach (var user in root.users)
            {
                var employee = new EmployeesDTO()
                {
                    Name = string.Format("{0} {1}", user.firstName, user.lastName),
                    Phone = user.phone
                };
                
                list.Add(employee);
            }

            return list;
        }
    }
}