using System.Data;
using System.Data.SqlClient;

namespace ToDoList.Data
{
    public sealed class DbSession
    {
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public DbSession()
        {
            try
            {
                Connection = new SqlConnection("Server=CFNOTE000017\\SQLEXPRESS;Database=ToDoList;Trusted_Connection=True;");
                Connection.Open();
            }
            catch(Exception e)
            {
                using (Connection)
                {
                    Connection.Close();
                }
            }
            
        }
    }
}


