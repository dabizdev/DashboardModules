using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Common.Interfaces;
using Dashboard.Common.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Internal;
using Oracle.ManagedDataAccess.Client;

namespace Dashboard.Modules.RHRP
{
    public class ErrorTypeModule : IGetData
    {
        public SqlConnection connection = new SqlConnection("Server=tcp:qtcstudents2022.database.windows.net,1433;Initial Catalog=DashboardDatabase;Persist Security Info=False;User ID=qtcUser;Password=#Classof2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public OracleConnection conn = new OracleConnection("Data Source = (description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.us-sanjose-1.oraclecloud.com))(connect_data=(service_name=g8243a756b1194c_y6lsus3vet9k1ffq_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=yes))); User Id = ADMIN; password=#Classof2023;");

        // leave as is to implement IGetData interface
        public List<Errors> GetData()
        {
            return new List<Errors>();
        }

        // method to get the sql data
        public List<Errors> GetSQLData()
        {
            var errors = new List<Errors>();

            string query = "Select * FROM ErrorsTable"; // query that we want to execute

            // retreive data from sql database and save below
            SqlDataAdapter data = new SqlDataAdapter(query, connection);

            // create a data table and populate it with data above
            DataTable dt = new DataTable();
            data.Fill(dt);

            // if we have at least 1 row of Errors, retreive it and print 
            if (dt.Rows.Count > 0)
            {
                // loop through all the rows in the data table
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // create a new Error and populate it (reference Error.cs for format)
                    Errors currentError = new Errors
                    {
                        ApplicationName = Convert.ToString(dt.Rows[i]["ApplicationName"]),
                        Layer = Convert.ToString(dt.Rows[i]["Layer"]),
                        Module = Convert.ToString(dt.Rows[i]["Module"]),
                        Alert = Convert.ToString(dt.Rows[i]["Alert"]),
                        AlertTeam = Convert.ToString(dt.Rows[i]["AlertTeam"]),
                        Severity = Convert.ToString(dt.Rows[i]["Severity"]),
                        ServerName = Convert.ToString(dt.Rows[i]["ServerName"]),
                        ErrorCode = Convert.ToInt32(dt.Rows[i]["ErrorCode"]),
                        ErrorMessage = Convert.ToString(dt.Rows[i]["ErrorMessage"]),
                        ErrorDate = Convert.ToDateTime(dt.Rows[i]["ErrorDate"]),
                        User = Convert.ToString(dt.Rows[i]["UserName"])
                    };

                    // add the current Error to the arraylist
                    errors.Add(currentError);
                }
            }

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

        // this method below will add a error to the sql db
        public void AddSQLData(Errors errorToAdd)
        {
            try
            {
                // query that we want to execute to insert into rule table
                string query = "INSERT INTO [dbo].[ErrorsTable] (ApplicationName, Layer, Module, Alert, AlertTeam, Severity, ServerName, ErrorCode, ErrorMessage, ErrorDate, UserName)";
                query += " VALUES (@AppName, @Layer, @Module, @Alert, @AlertTeam, @Severity, @ServName, @ErrorCode, @ErrMess, @ErrDate, @User)";
                
                using (connection)
                using (var command = new SqlCommand(query, connection))
                {
                    // create SQLParameter to parameterize values inserted (avoid sql injection)
                    SqlParameter[] sqlParams = new SqlParameter[11];

                    // store all the parameters in sqlParams
                    sqlParams[0] = new SqlParameter("@AppName", errorToAdd.ApplicationName);
                    sqlParams[1] = new SqlParameter("@Layer", errorToAdd.Layer);
                    sqlParams[2] = new SqlParameter("@Module", errorToAdd.Module);
                    sqlParams[3] = new SqlParameter("@Alert", errorToAdd.Alert);
                    sqlParams[4] = new SqlParameter("@AlertTeam", errorToAdd.AlertTeam);
                    sqlParams[5] = new SqlParameter("@Severity", errorToAdd.Severity);
                    sqlParams[6] = new SqlParameter("@ServName", errorToAdd.ServerName);
                    sqlParams[7] = new SqlParameter("@ErrorCode", errorToAdd.ErrorCode);
                    sqlParams[8] = new SqlParameter("@ErrMess", errorToAdd.ErrorMessage);
                    sqlParams[9] = new SqlParameter("@ErrDate", errorToAdd.ErrorDate);
                    sqlParams[10] = new SqlParameter("@User", errorToAdd.User);

                    // add all 11 sqlParams to the command
                    for(int i = 0; i<sqlParams.Length; i++)
                    {
                        command.Parameters.Add(sqlParams[0]);

                    }

                    connection.Open();

                    command.ExecuteNonQuery(); // use ExecuteNonQuery because we don't expect to return anything

                    connection.Close();

                    Debug.WriteLine("Error added: " + errorToAdd);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        // this method below will retreive the errors of a specific User from the sql db given user name
        public List<Errors> GetSQLUserErrors(String userName)
        {
            var userErrors = new List<Errors>();

            try
            {
                // query that we want to execute to insert into rule table
                string query = "SELECT * FROM [dbo].[ErrorsTable] WHERE UserName=@User";

                using (connection)
                using (var command = new SqlCommand(query, connection))
                {
                    // create SQLParameter to parameterize values inserted (avoid sql injection)
                    SqlParameter[] sqlParams = new SqlParameter[1];

                    // add the parameter missing to the query
                    sqlParams[0] = new SqlParameter("@User", userName);

                    command.Parameters.Add(sqlParams[0]);

                    connection.Open();

                    // retreive data from sql database and save below
                    SqlDataAdapter data = new SqlDataAdapter(query, connection);

                    // create a data table and populate it with data above
                    DataTable dt = new DataTable();
                    data.Fill(dt);

                    // if we have at least 1 row of Errors, retreive it and print 
                    if (dt.Rows.Count > 0)
                    {
                        // loop through all the rows in the data table
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            // create a new Error and populate it (reference Error.cs for format)
                            Errors currentError = new Errors
                            {
                                ApplicationName = Convert.ToString(dt.Rows[i]["ApplicationName"]),
                                Layer = Convert.ToString(dt.Rows[i]["Layer"]),
                                Module = Convert.ToString(dt.Rows[i]["Module"]),
                                Alert = Convert.ToString(dt.Rows[i]["Alert"]),
                                AlertTeam = Convert.ToString(dt.Rows[i]["AlertTeam"]),
                                Severity = Convert.ToString(dt.Rows[i]["Severity"]),
                                ServerName = Convert.ToString(dt.Rows[i]["ServerName"]),
                                ErrorCode = Convert.ToInt32(dt.Rows[i]["ErrorCode"]),
                                ErrorMessage = Convert.ToString(dt.Rows[i]["ErrorMessage"]),
                                ErrorDate = Convert.ToDateTime(dt.Rows[i]["ErrorDate"]),
                                User = Convert.ToString(dt.Rows[i]["UserName"])
                            };

                            // add the current Error to the arraylist
                            userErrors.Add(currentError);
                        }
                    }
                    connection.Close();

                    Debug.WriteLine("userName passed in: " + userName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            // return the errors of a specific user
            return userErrors;
        }


        /* 
            All methods below are meant to be used for the oracle database
         */
        // method below gets all errors stored on a specified oracle database
        public List<Errors> GetOracleData()
        {
            var errors = new List<Errors>();

            string query = "Select * FROM errorstable"; // query that we want to execute

            // retreive data from sql database and save below
            OracleDataAdapter data = new OracleDataAdapter(query, conn);

            // create a data table and populate it with data above
            DataTable dt = new DataTable();
            data.Fill(dt);

            // if we have at least 1 row of Errors, retreive it and print 
            if (dt.Rows.Count > 0)
            {
                // loop through all the rows in the data table
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // create a new Error and populate it (reference Error.cs for format)
                    Errors currentError = new Errors
                    {
                        ApplicationName = Convert.ToString(dt.Rows[i]["ApplicationName"]),
                        Layer = Convert.ToString(dt.Rows[i]["Layer"]),
                        Module = Convert.ToString(dt.Rows[i]["Module"]),
                        Alert = Convert.ToString(dt.Rows[i]["Alert"]),
                        AlertTeam = Convert.ToString(dt.Rows[i]["AlertTeam"]),
                        Severity = Convert.ToString(dt.Rows[i]["Severity"]),
                        ServerName = Convert.ToString(dt.Rows[i]["ServerName"]),
                        ErrorCode = Convert.ToInt32(dt.Rows[i]["ErrorCode"]),
                        ErrorMessage = Convert.ToString(dt.Rows[i]["ErrorMessage"]),
                        ErrorDate = Convert.ToDateTime(dt.Rows[i]["ErrorDate"]),
                        User = Convert.ToString(dt.Rows[i]["UserName"])
                    };

                    // add the current Error to the arraylist
                    errors.Add(currentError);
                }
            }

            return errors;
        }

        // this method below will add a error to the oracle db
        public void AddOracleData(Errors errorToAdd)
        {
            try
            {
                // query that we want to execute to insert into rule table
                string query = "INSERT INTO errorstable (ApplicationName, Layer, Module, Alert, AlertTeam, Severity, ServerName, ErrorCode, ErrorMessage, ErrorDate, UserName)";
                query += " VALUES (@AppName, @Layer, @Module, @Alert, @AlertTeam, @Severity, @ServName, @ErrorCode, @ErrMess, @ErrDate, @User)";

                using (conn)
                using (var command = new OracleCommand(query, conn))
                {
                    // create OracleParameter to parameterize values inserted (avoid injection)
                    OracleParameter[] oracleParams = new OracleParameter[11];

                    // store all the parameters in sqlParams
                    oracleParams[0] = new OracleParameter("@AppName", errorToAdd.ApplicationName);
                    oracleParams[1] = new OracleParameter("@Layer", errorToAdd.Layer);
                    oracleParams[2] = new OracleParameter("@Module", errorToAdd.Module);
                    oracleParams[3] = new OracleParameter("@Alert", errorToAdd.Alert);
                    oracleParams[4] = new OracleParameter("@AlertTeam", errorToAdd.AlertTeam);
                    oracleParams[5] = new OracleParameter("@Severity", errorToAdd.Severity);
                    oracleParams[6] = new OracleParameter("@ServName", errorToAdd.ServerName);
                    oracleParams[7] = new OracleParameter("@ErrorCode", errorToAdd.ErrorCode);
                    oracleParams[8] = new OracleParameter("@ErrMess", errorToAdd.ErrorMessage);
                    oracleParams[9] = new OracleParameter("@ErrDate", errorToAdd.ErrorDate);
                    oracleParams[10] = new OracleParameter("@User", errorToAdd.User);

                    // add all 11 sqlParams to the command
                    for (int i = 0; i < oracleParams.Length; i++)
                    {
                        command.Parameters.Add(oracleParams[0]);

                    }

                    conn.Open();

                    command.ExecuteNonQuery(); // use ExecuteNonQuery because we don't expect to return anything

                    conn.Close();

                    Debug.WriteLine("Error added: " + errorToAdd);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        // this method below will retreive the errors of a specific User from the sql db given user name
        public List<Errors> GetOracleUserErrors(String userName)
        {
            var userErrors = new List<Errors>();

            try
            {
                // query that we want to execute to insert into rule table
                string query = "SELECT * FROM errorstable WHERE UserName=@User";

                using (conn)
                using (var command = new OracleCommand(query, conn))
                {
                    // create OracleParameter to parameterize values inserted (avoid injection)
                    OracleParameter[] oracleParams = new OracleParameter[1];

                    // add the parameter missing to the query
                    oracleParams[0] = new OracleParameter("@User", userName);

                    command.Parameters.Add(oracleParams[0]);

                    conn.Open();

                    // retreive data from sql database and save below
                    OracleDataAdapter data = new OracleDataAdapter(query, conn);

                    // create a data table and populate it with data above
                    DataTable dt = new DataTable();
                    data.Fill(dt);

                    // if we have at least 1 row of Errors, retreive it and print 
                    if (dt.Rows.Count > 0)
                    {
                        // loop through all the rows in the data table
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            // create a new Error and populate it (reference Error.cs for format)
                            Errors currentError = new Errors
                            {
                                ApplicationName = Convert.ToString(dt.Rows[i]["ApplicationName"]),
                                Layer = Convert.ToString(dt.Rows[i]["Layer"]),
                                Module = Convert.ToString(dt.Rows[i]["Module"]),
                                Alert = Convert.ToString(dt.Rows[i]["Alert"]),
                                AlertTeam = Convert.ToString(dt.Rows[i]["AlertTeam"]),
                                Severity = Convert.ToString(dt.Rows[i]["Severity"]),
                                ServerName = Convert.ToString(dt.Rows[i]["ServerName"]),
                                ErrorCode = Convert.ToInt32(dt.Rows[i]["ErrorCode"]),
                                ErrorMessage = Convert.ToString(dt.Rows[i]["ErrorMessage"]),
                                ErrorDate = Convert.ToDateTime(dt.Rows[i]["ErrorDate"]),
                                User = Convert.ToString(dt.Rows[i]["UserName"])
                            };

                            // add the current Error to the arraylist
                            userErrors.Add(currentError);
                        }
                    }
                    conn.Close();

                    Debug.WriteLine("userName passed in: " + userName);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }

            // return the errors of a specific user
            return userErrors;
        }

    }
}
