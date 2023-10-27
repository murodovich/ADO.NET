using System.Data.SqlClient;

namespace AdoNetCRUD;

public class UpdateFunc
{
    public static void Update(string tablename, string database, string updatetext)
    {
        using (SqlConnection connection = new SqlConnection($"Server=(localdb)\\MSSQLLocalDB;Database={database};Trusted_Connection=True;"))
        {
            connection.Open();
            var columnName = new List<string>();
            List<string> columns;
            string query = $"select top 1 * from {tablename}";
            SqlCommand sqlCommand = new SqlCommand(query, connection);

            int count = 0;
            using (SqlDataReader reader = sqlCommand.ExecuteReader())
            {
                count = reader.FieldCount;
                var collection = reader.GetColumnSchema();
                columns = collection.Select(x => x.ColumnName).ToList();
            }
            var values = updatetext.Split(',');
            if (values.Length != count)
            {
                Console.WriteLine("Xato data kiritildi");
                return;
            }
            var joinedItems = columns.Skip(1).Zip(values.Skip(1), (item1, item2) => $"{item1} = {item2.Trim()}");
            var update = string.Join(",", joinedItems);
            
            var createQuery = $"Update {tablename} set {update} where {columns[0]} = {values[0]}";
            sqlCommand = new SqlCommand(createQuery, connection);

            var res = sqlCommand.ExecuteNonQuery();
            Console.WriteLine($"{res} rows affected");



        }
    }

}
