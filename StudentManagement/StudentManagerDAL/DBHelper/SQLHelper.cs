using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentManagerDAL.DBHelper
{
    class SQLHelper
    {
        static string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;//通过配置文件获取数据库访问路径
        /// <summary>
        /// 返回受影响行数
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>影响行数</returns>
        public static int ExecuteNonQurey(string sql) 
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql,con);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //计入系统日志
                throw ex;
            }
            finally
            {
                con.Close();
            }
  
        }



        public static int ExecuteNonQurey(string sql, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                //计入系统日志
                throw ex;
            }
            finally
            {
                con.Close();
            }

        }



        /// <summary>
        /// 返回受影响的首行首列
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>首行首列</returns>
        public static object ExecuteScalar(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql,con) ;
            try
            {
                con.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        //参数处理
        public static object ExecuteScalar(string sql,SqlParameter[]Parameters)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            if (Parameters!=null)
            {
                cmd.Parameters.AddRange(Parameters);
            }
            try
            {
                con.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                con.Close();
            }
        }



        /// <summary>
        /// 查询结果用DataReader读取
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql) 
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql,con);
            try
            {
                con.Open();
                //当关闭reader时connetion同时关闭
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();//抛异常后仍关闭
                throw ex;
            }
        }

        /// <summary>
        /// 查询结果用DataReader读取
        /// </summary>
        /// <param name="sql">查询的SQL语句</param>
        /// <param name="parameters">SQL语句中的所有参数</param>
        /// <returns></returns>
        public static SqlDataReader GetReader(string sql,SqlParameter[]parameters)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            if (parameters!=null)
            {
                cmd.Parameters.AddRange(parameters);//将SQL语句中的所有参数接收
            }
            try
            {
                con.Open();
                //当关闭reader时connetion同时关闭
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                con.Close();//抛异常后仍关闭
                throw ex;
            }
        }



        /// <summary>
        /// 查询结果返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataset(string sql)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql,con);
            DataSet set = new DataSet();
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(set);
                return set;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
