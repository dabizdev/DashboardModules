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

namespace Dashboard.Modules.RHRP
{
    public class ErrorTypeModule : IGetData
    {
        public SqlConnection connection = new SqlConnection("Server=tcp:qtcstudents2022.database.windows.net,1433;Initial Catalog=DashboardDatabase;Persist Security Info=False;User ID=qtcUser;Password=#Classof2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public List<Errors> GetData()
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

            return errors;
        }

        // this method below will add a error to the sql db
        public void AddData(Errors errorToAdd)
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
        public List<Errors> GetUserErrors(String userName)
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

    }
}
