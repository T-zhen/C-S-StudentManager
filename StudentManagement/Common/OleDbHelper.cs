using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Common
{
    public class OleDbHelper
    {
        private static string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0";


        /// <summary>
        /// 增删改操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Uptdate(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);//打开Excel数据源
            OleDbCommand cmd = new OleDbCommand(sql, conn);//将执行存储
            try
            {
                //尝试执行并返回受影响结果
                conn.Open();
                int result = cmd.ExecuteNonQuery();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }


        /// <summary>
        /// 返回单一结果查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object GetSingleResult(string sql)
        {
            OleDbConnection con = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql,con);
            try
            {
                con.Open();
                object result = cmd.ExecuteScalar();
                return result;
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
        /// 执行多结果查询（select）
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataReader GetReader(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            try
            {
                conn.Open();
                OleDbDataReader objReader =
                    cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return objReader;
            }
            catch (Exception ex)
            {
                conn.Close();
                throw ex;
            }
        }


        /// <summary>
        /// 执行返回数据集的查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql)
        {
            OleDbConnection conn = new OleDbConnection(connString);
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd); //创建数据适配器对象
            DataSet ds = new DataSet();//创建一个内存数据集
            try
            {
                conn.Open();   //与数据库查询同源
                da.Fill(ds);  //使用数据适配器填充数据集
                return ds;  //返回数据集
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }



        /// <summary>
        /// 读取数据到DataSet中
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static DataSet GetDataSet(string sql, string path)
        {
            OleDbConnection conn = new OleDbConnection(string.Format(connString, path));
            OleDbCommand cmd = new OleDbCommand(sql, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd); //创建数据适配器对象
            DataSet ds = new DataSet();//创建一个内存数据集
            try
            {
                conn.Open();
                da.Fill(ds);  //使用数据适配器填充数据集
                return ds;  //返回数据集
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
