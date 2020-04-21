using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerModel;
using System.Data.SqlClient;

namespace StudentManagerDAL
{
    public class AdminServer
    {
        /// <summary>
        /// 与数据库验证信息
        /// </summary>
        /// <param name="adm"></param>
        /// <returns></returns>
        public Admins GetAdmins(Admins adm)
        {
            string sql = string.Format("SELECT * FROM Admins WHERE LoginId={0}",adm.LoginId);
            //string sql = string.Format("select * from Admins WHERE LogingId=@id and LoginPwd=@Pwd");
            SqlParameter[] parameter =
            {
                new SqlParameter("@id",System.Data.SqlDbType.Int),
                new SqlParameter("@Pwd",System.Data.SqlDbType.VarChar,50)
            };
            parameter[0].Value = adm.LoginId;
            parameter[1].Value = adm.LoginPwd;
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql,parameter);
            Admins use = null;
            while (reader.Read())
            {
                use = new Admins()
                {
                    AdminName = reader["AdminName"].ToString(),
                    LoginId=(int)reader["LoginId"],
                    LoginPwd=(int)reader["LoginPwd"],
                };

            }
            reader.Close();
            return use;
        }


        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admins"></param>
        /// <returns></returns>
        public int AddAdmins(Admins admins)
        {
            string sql =string.Format("INSERT INTO Admins VALUES({0}, {1}, '{2}')",admins.LoginId,admins.LoginPwd,admins.AdminName);
            return DBHelper.SQLHelper.ExecuteNonQurey(sql);
        }



      
    }
}
