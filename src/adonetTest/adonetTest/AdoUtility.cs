using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace adonetTest
{
    public class AdoUtility
    {
        public void SelectData()
        {
            try
            {
                using (SqlCommand cmd =
                    new SqlCommand("Select * from StudentTable", DbConnection.Connection()))

                {
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr["Name"] + ",  " + sdr["Email"] + ",  " + sdr["Mobile"]);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void SelectMultipleData()
        {
            try
            {
                using (SqlCommand cmd =
                    new SqlCommand("Select * from Customers; Select * from Orders", DbConnection.Connection()))

                {
                    // Executing the SQL query  
                    SqlDataReader sdr = cmd.ExecuteReader();

                    while (sdr.Read())
                    {
                        Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2]);
                    }
                    while (sdr.NextResult())
                    {
                        Console.WriteLine("\nSecond Result Set:");
                        //Looping through each record
                        while (sdr.Read())
                        {
                            Console.WriteLine(sdr[0] + ",  " + sdr[1] + ",  " + sdr[2]);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void SelectDataBySQLAdapter()
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from Customers;select * from Orders", DbConnection.Connection());
            //Using Data Table
            DataTable dt = new DataTable();
            da.Fill(dt);
            //The following things are done by the Fill method
            //1. Open the connection
            //2. Execute Command
            //3. Retrieve the Result
            //4. Fill/Store the Retrieve Result in the Data table
            //5. Close the connection
            Console.WriteLine("Using Data Table");
            //Active and Open connection is not required
            //dt.Rows: Gets the collection of rows that belong to this table
            //DataRow: Represents a row of data in a DataTable.
            foreach (DataRow row in dt.Rows)
            {
                //Accessing using string Key Name
                Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
                //Accessing using integer index position
                //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
            }
            Console.WriteLine("---------------");
            //Using DataSet
            DataSet ds = new DataSet();
            da.Fill(ds, "customer"); //Here, the datatable student will be stored in Index position 0
            Console.WriteLine("Using Data Set");
            //Tables: Gets the collection of tables contained in the System.Data.DataSet.
            //Accessing the datatable from the dataset using the datatable name
            foreach (DataRow row in ds.Tables["customer"].Rows)
            {
                //Accessing the data using string Key Name
                Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
            }
        }
    }
}
