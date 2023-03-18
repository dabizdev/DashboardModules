using System.Data;
using System.Data.SqlClient;
using Dashboard.Common.Interfaces;
using Dashboard.Common.Models;
using Oracle.ManagedDataAccess.Client;

namespace Dashboard.Modules.RHRP
{
    public class ErrorTypeModule : IErrorTypeModule
    {
        public SqlConnection connection = new SqlConnection("Server=tcp:qtcstudents2022.database.windows.net,1433;Initial Catalog=DashboardDatabase;Persist Security Info=False;User ID=qtcUser;Password=#Classof2023;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        public OracleConnection conn = new OracleConnection("Data Source = (description= (retry_count=20)(retry_delay=3)(address=(protocol=tcps)(port=1522)(host=adb.us-sanjose-1.oraclecloud.com))(connect_data=(service_name=g8243a756b1194c_y6lsus3vet9k1ffq_high.adb.oraclecloud.com))(security=(ssl_server_dn_match=yes))); User Id = ADMIN; password=#Classof2023;");

        public List<Errors> GetData(string integrationPoint)
        {
            var errors = new List<Errors>();

            switch (integrationPoint)
            {
                case "SQL":
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
                    break;

                case "Oracle":

                    string query3 = "Select * FROM errorstable"; // query that we want to execute

                    // retreive data from sql database and save below
                    OracleDataAdapter data2 = new OracleDataAdapter(query3, conn);

                    // create a data table and populate it with data above
                    DataTable dt2 = new DataTable();
                    data2.Fill(dt2);

                    // if we have at least 1 row of Errors, retreive it and print 
                    if (dt2.Rows.Count > 0)
                    {
                        // loop through all the rows in the data table
                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            // create a new Error and populate it (reference Error.cs for format)
                            Errors currentError = new Errors
                            {
                                ApplicationName = Convert.ToString(dt2.Rows[i]["ApplicationName"]),
                                Layer = Convert.ToString(dt2.Rows[i]["Layer"]),
                                Module = Convert.ToString(dt2.Rows[i]["Module"]),
                                Alert = Convert.ToString(dt2.Rows[i]["Alert"]),
                                AlertTeam = Convert.ToString(dt2.Rows[i]["AlertTeam"]),
                                Severity = Convert.ToString(dt2.Rows[i]["Severity"]),
                                ServerName = Convert.ToString(dt2.Rows[i]["ServerName"]),
                                ErrorCode = Convert.ToInt32(dt2.Rows[i]["ErrorCode"]),
                                ErrorMessage = Convert.ToString(dt2.Rows[i]["ErrorMessage"]),
                                ErrorDate = Convert.ToDateTime(dt2.Rows[i]["ErrorDate"]),
                                User = Convert.ToString(dt2.Rows[i]["UserName"])
                            };

                            // add the current Error to the arraylist
                            errors.Add(currentError);


                        }


                    }
                    break;

            }
            return errors;
        }

    }
}
