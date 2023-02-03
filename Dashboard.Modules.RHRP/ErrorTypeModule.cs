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

            return errors;
        }
    }
}
