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

            errors.Add(new Errors { 
                ApplicationName = "Application 1",
                Layer = "Business Layer",
                Module = "Restful API",
                Alert = "Unable To Access Restful API",
                AlertTeam = "DevOps",
                Severity = "High",
                ServerName = "AppServer01",
                ErrorCode = 00451,
                ErrorMessage = "Unable to retrieve the following data from the restful API",
                ErrorDate = System.DateTime.Now,
                User = "system"
            
            });

            errors.Add(new Errors {
                ApplicationName = "Application WXY",
                Layer = "Business Layer",
                Module = "Restful API",
                Alert = "Server Error",
                AlertTeam = "DevOps",
                Severity = "High",
                ServerName = "WXY_Server",
                ErrorCode = 500,
                ErrorMessage = "The server encountered an error and could not complete your request",
                ErrorDate = System.DateTime.Now,
                User = "system"

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
