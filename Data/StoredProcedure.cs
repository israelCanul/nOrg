using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using narilearsi.ModelDB;

namespace narilearsi.Data
{
    public class StoredProcedure : IDisposable
    {
        private string strConnString = string.Empty;
        private readonly IConfiguration _configuration;
        private string strSpName = string.Empty;
        private Hashtable hstParameters = new Hashtable();
        private DataSet dtsReturn;
        private SqlCommand sqlComando;
        private SqlDataAdapter dAdpt;
        private DataSet _mdts = null;

        //setting a Stored Procedure
        public StoredProcedure(IConfiguration configuration, string Name, string schema = "dbo", ConnectionDB ConnectionDB = ConnectionDB.narilearsi)
        {
            _configuration = configuration;
            if (schema == null || schema.Trim() == string.Empty) schema = "dbo";
            strSpName = schema + "." + Name;

            strConnString = GetConnectionString(ConnectionDB);
        }


        private string GetConnectionString(ConnectionDB ConnectionDB)
        {
            //Cadena ambiente DEV
            string connectionString = _configuration["connectingString:rdsDataBase"];

            switch (ConnectionDB)
            {
                case ConnectionDB.Auth:
                    connectionString = connectionString.Replace("rdsCommon", "rdsAuthentication");
                    break;
                case ConnectionDB.narilearsi:
                    connectionString = connectionString.Replace("rdsCommon", "narilearsi");
                    break;
                case ConnectionDB.MasterAuth:
                    connectionString = connectionString.Replace("rdsCommon", "rdsMasterAuth");
                    break;
            }
            return connectionString;
        }
        // adding parameter to Stored Procedure
        public void AddParameter(string name, object value)
        {
            SqlParameter parameter = new SqlParameter(name, value);
            hstParameters.Add(name, parameter);
        }
        // Getting parameter to Stored Procedure
        public SqlParameter GetParameter(string parametername)
        {
            SqlParameter param;
            if (hstParameters == null)
                param = null;
            else
                param = hstParameters[parametername] as SqlParameter;
            return param;
        }





        //EXECUTE ******
        public DataSet execute()
        {
            dtsReturn = new DataSet();
            sqlComando = new SqlCommand();

            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = strSpName;

            // Se agregan los parametros al comando siempre y cuando existan parametros
            if (hstParameters != null && hstParameters.Count > 0)
            {
                foreach (System.Collections.DictionaryEntry s in hstParameters)
                    sqlComando.Parameters.Add(s.Value);
            }

            try
            {
                using (SqlConnection conn1 = new SqlConnection(strConnString))
                {
                    sqlComando.Connection = conn1;
                    sqlComando.CommandTimeout = 19000; // GeneralCompartido.gCommandTimeout;
                    dAdpt = new SqlDataAdapter(sqlComando);
                    dAdpt.Fill(dtsReturn);
                    conn1.Close();
                }
            }
            catch (SqlException ex)
            {
                if (dtsReturn == null)
                    dtsReturn = new DataSet();
                dtsReturn.Tables.Clear();
                dtsReturn.Tables.Add(this.MakeDataTableResult(ex.Message));
            }

            // Asignamos el dataset a la propiedad de la clase que lo contendra
            _mdts = dtsReturn;
            return dtsReturn;
        }

        public Task<DataSet> executeAsync()
        {
            dtsReturn = new DataSet();
            sqlComando = new SqlCommand();

            sqlComando.CommandType = CommandType.StoredProcedure;
            sqlComando.CommandText = strSpName;

            // Se agregan los parametros al comando siempre y cuando existan parametros
            if (hstParameters != null && hstParameters.Count > 0)
            {
                foreach (System.Collections.DictionaryEntry s in hstParameters)
                    sqlComando.Parameters.Add(s.Value);
            }

            try
            {
                return Task.Run(() =>
                {

                    using (SqlConnection conn1 = new SqlConnection(strConnString))
                    {
                        sqlComando.Connection = conn1;
                        sqlComando.CommandTimeout = 19000; // GeneralCompartido.gCommandTimeout;
                        dAdpt = new SqlDataAdapter(sqlComando);
                        dAdpt.Fill(dtsReturn);
                        conn1.Close();
                    }
                    // Asignamos el dataset a la propiedad de la clase que lo contendra
                    _mdts = dtsReturn;
                    return dtsReturn;
                });
            }
            catch (SqlException ex)
            {
                return Task.Run(() =>
                {
                    if (dtsReturn == null)
                        dtsReturn = new DataSet();
                    dtsReturn.Tables.Clear();
                    dtsReturn.Tables.Add(this.MakeDataTableResult(ex.Message));
                    // Asignamos el dataset a la propiedad de la clase que lo contendra
                    _mdts = dtsReturn;
                    return dtsReturn;
                });
            }
        }



        //DISPOSED *******
        private bool disposedValue;      // To detect redundant calls
        public void Dispose()
        {
            // Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    hstParameters = null;
                    if (_mdts != null)
                        _mdts.Dispose();
                    if (dtsReturn != null)
                        dtsReturn.Dispose();
                    if (dAdpt != null)
                        dAdpt.Dispose();
                    if (sqlComando != null)
                        sqlComando.Dispose();
                }
            }
            this.disposedValue = true;
        }


        //HELPERS ******
        public DataSet dtsTablas
        {
            get
            {
                return _mdts;
            }
        }
        private DataTable ConvertArrayIntToDataTable(dynamic value)
        {
            DataTable ret = new DataTable();
            ret.Columns.Add();
            //dynamic dynJson = JsonConvert.DeserializeObject(value);
            foreach (var item in value)
            {
                ret.Rows.Add(item);
            }
            return ret;
        }
        public void ParametersClear()
        {
            hstParameters.Clear();
        }
        public DataTable MakeDataTableResult(string strMessage)
        {
            // Create new DataTable.
            DataTable myDataTable = new DataTable("DataTable");

            // Declare DataColumn and DataRow variables.
            DataColumn myDataColumn;
            DataRow myDataRow;

            // Create new DataColumn, set DataType, ColumnName and add to DataTable.    
            myDataColumn = new DataColumn("id", typeof(Int32));
            myDataTable.Columns.Add(myDataColumn);

            // Create second column.
            myDataColumn = new DataColumn("item", typeof(string));
            myDataTable.Columns.Add(myDataColumn);

            // Create new DataRow objects and add to DataTable.    
            myDataRow = myDataTable.NewRow();
            myDataRow["id"] = -1;
            myDataRow["item"] = strMessage;
            myDataTable.Rows.Add(myDataRow);

            // Set to DataGrid.DataSource property to the table.
            // DataGrid1.DataSource = myDataTable
            return myDataTable;
        }
        public string ToJson()
        {
            var ret = new StringBuilder();
            try
            {
                if (_mdts == null)
                    return "";

                DataTableReader dr = _mdts.Tables[0].CreateDataReader();
                int rowCount = _mdts.Tables[0].Rows.Count;
                int rowIndex = 1;

                if (!dr.HasRows)
                    return "";

                if (_mdts.Tables[0].Rows.Count > 0)
                    ret.Append("[");

                while (dr.Read())
                {
                    ret.Append("{");
                    for (int index = 0; index < dr.FieldCount; index++)
                    {

                        ret.Append("\"");
                        ret.Append(dr.GetName(index));
                        ret.Append("\":\"");
                        ret.Append(dr[index].ToString());
                        ret.Append("\"");

                        if (index + 1 < dr.FieldCount)
                            ret.Append(",");

                    }

                    ret.Append("}");

                    if (rowCount > 1 && rowIndex < rowCount)
                        ret.Append(",");
                    rowIndex++;
                }


                if (_mdts.Tables[0].Rows.Count > 0)
                    ret.Append("]");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
            }
            return ret.ToString();
        }
    }
}
