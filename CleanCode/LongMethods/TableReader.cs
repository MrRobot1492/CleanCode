using System.Configuration;
using System.Data;
using System.Data.SqlClient;

internal class TableReader
{
    public DataTable GetDataTable(string tableName)
    {
        string strConn = ConfigurationManager.ConnectionStrings["FooFooConnectionString"].ToString();
        SqlConnection conn = new SqlConnection(strConn);
        SqlDataAdapter da = new SqlDataAdapter($"SELECT * FROM {tableName} ORDER BY id ASC", conn);
        DataSet ds = new DataSet();
        da.Fill(ds, "FooFoo");
        DataTable dt = ds.Tables["FooFoo"];
        return dt;
    }
}