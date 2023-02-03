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

            errors.Add(new Errors {
                ApplicationName = "Application WXY",
                Layer = "Application",
                Module = "WXY.exe",
                Alert = "System error",
                AlertTeam = "Everyone",
                Severity = "High",
                ServerName = "WXY_Server",
                ErrorCode = 911,
                ErrorMessage = "The program can't start because nsa321.dll is missing from your computer. Try reinstalling the program to fix this problem.",
                ErrorDate = System.DateTime.Now,
                User = "system"

            });

            errors.Add(new Errors {
                ApplicationName = "Application WXY",
                Layer = "Application",
                Module = "WXY.exe",
                Alert = "Logic error",
                AlertTeam = "Developer",
                Severity = "Important",
                ServerName = "WXY_Server",
                ErrorCode = 432,
                ErrorMessage = "Report of medication being wrongly assigned to patients. Medications  are 1 level of above severity from patients diagnosis. Animal medications assigned to humans and vice versa.",
                ErrorDate = System.DateTime.Now,
                User = "system"

            });

            errors.Add(new Errors {
                ApplicationName = "Application WXY",
                Layer = "Application",
                Module = "WXY.exe",
                Alert = "Logic error",
                AlertTeam = "Developer",
                Severity = "Low",
                ServerName = "WXY_Server",
                ErrorCode = 431,
                ErrorMessage = "Localization error for Europeans. US metric system is being applied to Europe.",
                ErrorDate = System.DateTime.Now,
                User = "system"

            });

            errors.Add(new Errors {
                ApplicationName = "Application WXY",
                Layer = "Application",
                Module = "WXY.exe",
                Alert = "System error",
                AlertTeam = "Everyone",
                Severity = "Critical",
                ServerName = "WXY_Server",
                ErrorCode = 0000,
                ErrorMessage = "Free subscriptions to everyone. Paywall not working.",
                ErrorDate = System.DateTime.Now,
                User = "system"

            });

            errors.Add(new Errors {
                ApplicationName = "Application Diagnosis",
                Layer = "Application",
                Module = "Root Folder",
                Alert = "Code error",
                AlertTeam = "Developer",
                Severity = "Low",
                ServerName = "main",
                ErrorCode = 002,
                ErrorMessage = "SyntaxError: illegal character" +
                "   sample#Function();" +
                "---------^",
                ErrorDate = System.DateTime.Now,
                User = "user"

            });

            errors.Add(new Errors {
                ApplicationName = "Application Diagnosis",
                Layer = "Application",
                Module = "PatientView Folder",
                Alert = "Code error",
                AlertTeam = "Developer",
                Severity = "Low",
                ServerName = "main",
                ErrorCode = 002,
                ErrorMessage = "Reference Error            D:200:1\nname is not defined            D:200:2\nReferenceError: name is not defined            D:200:2\n\tat <anonymous>:2:3" +
                "\tat Object.LoadPatient._evaluateOn   (<anonymous>:200:14)" +
                "\tat Object.LoadPatient._evaluateAndWrap   (<anonymous>:278:48)" +
                "\tat Object.LoadPatient._evaluate   (<anonymous>:450:82)",
                ErrorDate = System.DateTime.Now,
                User = "user"

            });

            errors.Add(new Errors {
                ApplicationName = "Application Diagnosis",
                Layer = "Application",
                Module = "Status Folder",
                Alert = "Code error",
                AlertTeam = "Developer",
                Severity = "Low",
                ServerName = "main",
                ErrorCode = 002,
                ErrorMessage = "Reference Error            D:450:1\nname is not defined            D:450:2\nReferenceError: patientStatus is not defined            D:450:2\n\tat <anonymous>:2:3",
                ErrorDate = System.DateTime.Now,
                User = "user"

            });

            errors.Add(new Errors {
                ApplicationName = "Application Diagnosis",
                Layer = "Application",
                Module = "Status Folder",
                Alert = "Code error",
                AlertTeam = "Developer",
                Severity = "Low",
                ServerName = "main",
                ErrorCode = 002,
                ErrorMessage = "TypeError: console.log(...) is not a function                                       angular.js:1604" +
                "\tat p.app.controller.Status.Patient...     (https://google.com)" +
                "\tat fn (evall at <anonymous> (https://www.youtube.com/), <anonymous>:4:539)" +
                "\tat p.app.controller.Status.self.init.onload (https://www.geeksforgeeks.org/)" +
                "\tat https://developer.mozilla.org/en-US/docs/Web/JavaScript" +
                "\tat p.app.controller.Status.self.init.wait " +
                "\tat p.app.controller.Status.self.init.hold " +
                "\tat p.app.controller.Status.self.init.load " +
                "\tat p.app.controller.Status.self.init.display ",
                ErrorDate = System.DateTime.Now,
                User = "user"

            });

            return errors;
        }
    }
}
