using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravellerStudent.Model.Core;

namespace TravellerStudent.Repository.Core
{
    public abstract class BaseRepository<T> where T : class
    {
        #region Members
        protected RepositoryContext _context;
        #endregion Members

        #region Constructors
        public BaseRepository(RepositoryContext context)
        {
            _context = context;
        }
        #endregion Constructors

        #region Methods
        /// <summary>
        /// Executes the insert, update and delete operation.
        /// </summary>
        /// <param name="commandText">Represents the name of the stored procedure.</param>
        /// <param name="commandParameters">Represents all the neccessary parameters for the stored procedure.</param>
        public void ExecuteCommand(string commandText, params SqlParameter[] commandParameters)
        {
            using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, connection, sqlTransaction))
                    {
                        try
                        {
                            sqlCommand.CommandType = CommandType.StoredProcedure;
                            sqlCommand.Parameters.AddRange(commandParameters);
                            sqlCommand.ExecuteNonQuery();
                            sqlTransaction.Commit();
                        }
                        catch (SqlException)
                        {
                            sqlTransaction.Rollback();
                            throw;
                        }
                    }
                }
            }

        }
        /// <summary>
        /// Execute bool returning stored procedures.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public bool ExecuteCheckCommand(string commandText, params SqlParameter[] commandParameters)
        {
            Int16 result;
            using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                using (SqlTransaction sqlTransaction = connection.BeginTransaction())
                {
                    using (SqlCommand sqlCommand = new SqlCommand(commandText, connection, sqlTransaction))
                    {
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.AddRange(commandParameters);
                        sqlCommand.Parameters.Add("@ReturnValue", SqlDbType.SmallInt);
                        sqlCommand.Parameters["@ReturnValue"].Direction = ParameterDirection.Output;
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        sqlDataReader.Close();
                        result = (Int16)sqlCommand.Parameters["@ReturnValue"].Value;
                    }
                }
            }
            return result == 1 ? true : false;
        }
        /// <summary>
        /// This method is used to execute the neccessary read commands.
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="readerToModel"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public List<T> ExecuteReadCommand(string commandText, Func<SqlDataReader, T> readerToModel, params SqlParameter[] commandParameters)
        {
            List<T> readResult = new List<T>(0);
            using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddRange(commandParameters);
                    using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                    {
                        while (sqlDataReader.Read())
                        {
                            readResult.Add(readerToModel(sqlDataReader));
                        }
                    }
                }
            }
            return readResult;
        }


        /// <summary>
        /// This method is used when desiring to retrieve a single scalar value from the database. It can also get parameteres but it also can reeceive null
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="commandParameters"></param>
        /// <returns></returns>
        public object ExecuteScalarCommand(string commandText, params SqlParameter[] commandParameters)
        {

            using (SqlConnection connection = new SqlConnection(_context.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(commandText, connection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    if (commandParameters != null)
                    {
                        sqlCommand.Parameters.AddRange(commandParameters);
                    }
                    return sqlCommand.ExecuteScalar();
                }
            }

        }

        /// <summary>
        /// Method that needs to be overridden by every class that inherits this one.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected abstract T ReaderToModel(SqlDataReader reader);
        #endregion Methods
    }
}
