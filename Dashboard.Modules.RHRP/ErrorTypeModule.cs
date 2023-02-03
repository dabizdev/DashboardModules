using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Common.Interfaces;
using Dashboard.Common.Models;

namespace Dashboard.Modules.RHRP
{
    public class ErrorTypeModule : IGetData
    {
        public List<Errors> GetData()
        {
            var errors = new List<Errors>();

            errors.Add(new Errors
            {
                ApplicationName = "Application 1",
                Layer = "Data Layer",
                Module = "SQL Database",
                Alert = "SQL Connection Error",
                AlertTeam = "Database Team",
                Severity = "High",
                ServerName = "SQL01",
                ErrorCode = 10060,
                ErrorMessage = "A network-related or instance-specific error occurred while establishing a connection to SQL Server. The server was not found or was not accessible.",
                ErrorDate = System.DateTime.Now,
                User = "system"
            });

            errors.Add(new Errors
            {
                ApplicationName = "Application 2",
                Layer = "Presentation Layer",
                Module = "User Interface",
                Alert = "JavaScript Error",
                AlertTeam = "Front-End Team",
                Severity = "Low",
                ServerName = "WebServer01",
                ErrorCode = 10061,
                ErrorMessage = "Uncaught TypeError: Cannot read property 'value' of undefined at HTMLInputElement.onchange",
                ErrorDate = System.DateTime.Now,
                User = "user"
            });

            errors.Add(new Errors
            {
                ApplicationName = "Application 3",
                Layer = "Business Layer",
                Module = "Web Service",
                Alert = "500 Internal Server Error",
                AlertTeam = "Back-End Team",
                Severity = "High",
                ServerName = "AppServer02",
                ErrorCode = 500,
                ErrorMessage = "An error occurred while processing the request. Please contact support.",
                ErrorDate = System.DateTime.Now,
                User = "system"
            });

            errors.Add(new Errors
            {
                ApplicationName = "Application 4",
                Layer = "Data Layer",
                Module = "NoSQL Database",
                Alert = "MongoDB Connection Error",
                AlertTeam = "Database Team",
                Severity = "High",
                ServerName = "MongoDB01",
                ErrorCode = 101,
                ErrorMessage = "Error connecting to MongoDB server: couldnnx = ('127.0.0.1', 27017): [Errno 111] Connection refused",
                ErrorDate = System.DateTime.Now,
                User = "system"
            });

            errors.Add(new Errors
            {
                ApplicationName = "Application 5",
                Layer = "Presentation Layer",
                Module = "Website",
                Alert = "404 Page Not Found",
                AlertTeam = "Front-End Team",
                Severity = "Low",
                ServerName = "WebServer02",
                ErrorCode = 404,
                ErrorMessage = "The requested URL was not found on this server.",
                ErrorDate = System.DateTime.Now,
                User = "user"
            });

            return errors;
        }
    }
}
