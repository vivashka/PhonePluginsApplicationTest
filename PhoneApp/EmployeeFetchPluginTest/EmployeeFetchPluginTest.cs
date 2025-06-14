using System;
using System.Collections.Generic;
using EmployeesFetchPlugin;
using NUnit.Framework;
using PhoneApp.Domain.DTO;

namespace EmployeeFetchPluginTest
{
    [TestFixture]
    public class EmployeeFetchPluginTest
    {
        [Test]
        public void LoadEmployees_EmptyList_ReturnData()
        {
            Plugin plugin = new Plugin();
            List<EmployeesDTO> dto = new List<EmployeesDTO>();
            var data = plugin.Run(dto);
            
            Assert.IsNotEmpty(data);
        }
    }
}