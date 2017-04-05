using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SampleWebApp.Automation.Helpers.Utility
{
    public class SqlQueryParameter
    {
        public string Name { get; set; }
        public SqlDbType Type { get; set; }
        public object Value { get; set; }
    }

    public class SqlServerUtility : IDisposable
    {
        private readonly SqlDataAdapter _sqlAdapter;
        private readonly SqlConnection _sqlConn;

        public SqlServerUtility(string dbConnectionString)
        {
            _sqlConn = new SqlConnection(dbConnectionString);
            _sqlAdapter = new SqlDataAdapter();
        }

        #region IDisposable Members

        public void Dispose()
        {
            _sqlAdapter.Dispose();
            CloseConnection();
            _sqlConn.Dispose();
        }

        #endregion

        private void OpenConnection()
        {
            if ((_sqlConn.State == ConnectionState.Closed) || (_sqlConn.State == ConnectionState.Broken))
                _sqlConn.Open();
        }

        private void CloseConnection()
        {
            if (_sqlConn.State == ConnectionState.Open)
                _sqlConn.Close();
        }

        public DataTable GetSchema()
        {
            OpenConnection();
            return _sqlConn.GetSchema();
        }

        public DataTable Select(string sqlCmd, IList<SqlQueryParameter> sqlParas)
        {
            var dt = new DataTable();
            dt.Clear();

            OpenConnection();
            _sqlAdapter.SelectCommand = new SqlCommand(sqlCmd);
            _sqlAdapter.SelectCommand.Parameters.Clear();
            foreach (var sqlPara in sqlParas)
                _sqlAdapter.SelectCommand.Parameters.Add(sqlPara.Name, sqlPara.Type).Value = sqlPara.Value;
            _sqlAdapter.SelectCommand.Connection = _sqlConn;
            _sqlAdapter.Fill(dt);
            _sqlAdapter.SelectCommand.ExecuteNonQuery();
            return dt;
        }

        public object Insert(string sqlCmd, IList<SqlQueryParameter> sqlParas)
        {
            object newId = null;

            OpenConnection();
            _sqlAdapter.InsertCommand = new SqlCommand(sqlCmd);
            _sqlAdapter.InsertCommand.CommandText += "SELECT SCOPE_IDENTITY();";
            _sqlAdapter.InsertCommand.Parameters.Clear();
            foreach (var sqlPara in sqlParas)
                _sqlAdapter.InsertCommand.Parameters.Add(sqlPara.Name, sqlPara.Type).Value = sqlPara.Value;

            // Start a local transaction
            var sqlTrans = _sqlConn.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            _sqlAdapter.InsertCommand.Connection = _sqlConn;
            _sqlAdapter.InsertCommand.Transaction = sqlTrans;
            try
            {
                //_sqlAdapter.InsertCommand.ExecuteNonQuery();
                newId = _sqlAdapter.InsertCommand.ExecuteScalar();
                // Attempt to commit the transaction
                sqlTrans.Commit();
            }
            catch (Exception ex1)
            {
                var ex = new List<Exception> {ex1};
                // Attempt to roll back the transaction
                try
                {
                    sqlTrans.Rollback();
                }
                catch (Exception ex2)
                {
                    ex.Add(ex2);
                }

                throw new AggregateException(ex);
            }

            return newId;
        }

        public void Update(string sqlCmd, IList<SqlQueryParameter> sqlParas)
        {
            OpenConnection();
            _sqlAdapter.UpdateCommand = new SqlCommand(sqlCmd);
            _sqlAdapter.UpdateCommand.Parameters.Clear();
            foreach (var sqlPara in sqlParas)
                _sqlAdapter.UpdateCommand.Parameters.Add(sqlPara.Name, sqlPara.Type).Value = sqlPara.Value;

            // Start a local transaction
            var sqlTrans = _sqlConn.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            _sqlAdapter.UpdateCommand.Connection = _sqlConn;
            _sqlAdapter.UpdateCommand.Transaction = sqlTrans;
            try
            {
                _sqlAdapter.UpdateCommand.ExecuteNonQuery();
                // Attempt to commit the transaction
                sqlTrans.Commit();
            }
            catch (Exception ex1)
            {
                var ex = new List<Exception> {ex1};
                // Attempt to roll back the transaction
                try
                {
                    sqlTrans.Rollback();
                }
                catch (Exception ex2)
                {
                    ex.Add(ex2);
                }

                throw new AggregateException(ex);
            }
        }

        public void Delete(string sqlCmd, IList<SqlQueryParameter> sqlParas)
        {
            OpenConnection();
            _sqlAdapter.DeleteCommand = new SqlCommand(sqlCmd);
            _sqlAdapter.DeleteCommand.Parameters.Clear();
            foreach (var sqlPara in sqlParas)
                _sqlAdapter.DeleteCommand.Parameters.Add(sqlPara.Name, sqlPara.Type).Value = sqlPara.Value;

            // Start a local transaction
            var sqlTrans = _sqlConn.BeginTransaction();

            // Must assign both transaction object and connection
            // to Command object for a pending local transaction
            _sqlAdapter.DeleteCommand.Connection = _sqlConn;
            _sqlAdapter.DeleteCommand.Transaction = sqlTrans;
            try
            {
                _sqlAdapter.DeleteCommand.ExecuteNonQuery();
                // Attempt to commit the transaction
                sqlTrans.Commit();
            }
            catch (Exception ex1)
            {
                var ex = new List<Exception> {ex1};
                // Attempt to roll back the transaction
                try
                {
                    sqlTrans.Rollback();
                }
                catch (Exception ex2)
                {
                    ex.Add(ex2);
                }

                throw new AggregateException(ex);
            }
        }
    }
}