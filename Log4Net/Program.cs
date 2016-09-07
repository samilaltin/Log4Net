using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace Log4Net
{
    class Program 
    { 
        static ILog log = log4net.LogManager.GetLogger(typeof(Program));

        static void Main(string[] args) 
        { 
      
            log4net.Config.BasicConfigurator.Configure();

            SqlConnection connection = null; 
            try 
            {
                const string connectionString = @"data source=.\SQLSERVER2014;Database=LOLO;User id=samil;pwd=1q2w3e";
                log.Warn(String.Format("New Connection. Connection String :{0}", connectionString)); 
                connection=new SqlConnection(connectionString); 
                if(connection.State==ConnectionState.Closed) 
                    connection.Open();

                log.Info(String.Format("Connection Status : {0}",connection.State)); 
            } 
            catch (Exception excp) 
            { 
                log.Error(excp.Message); 
            } 
            finally 
            { 
                if (connection != null && connection.State == ConnectionState.Open) 
                { 
                    connection.Close(); 
                    log.Debug(String.Format("Finally block. Connection Status {0}", connection.State));
                } 
            }

            log.Info("The End"); 
        } 
    } 
}
