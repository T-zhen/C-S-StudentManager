using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerModel;
using System.Data.SqlClient;

namespace StudentManagerDAL
{
    public class ScoreListServer
    {

        /// <summary>
        /// 返回成绩表
        /// </summary>
        /// <returns></returns>
        public List<ScoreList> GetScoreList()
        {
            string sql = "SELECT * FROM ScoreList";
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);//读取整张表信息
            List<ScoreList> list = new List<ScoreList>();//新建一个泛型
            while (reader.Read())
            {
                list.Add(new ScoreList()
                {
                    ID=Convert.ToInt32(reader["ID"]),           
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    UpdateTime = Convert.ToDateTime(reader["UpdateTime"])

                });
            }
            reader.Close();
            return list;

        }


        /// <summary>
        /// 返回未及格学生
        /// </summary>
        /// <returns></returns>
        public List<ScoreList> GetScoreListsNO()
        {
            String sql = "select * from scorelist where ScoreList.CSharp<60 OR ScoreList.SQLServerDB<60";
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);//读取整张表信息
            List<ScoreList> list = new List<ScoreList>();//新建一个泛型
            while (reader.Read())
            {
                list.Add(new ScoreList()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    UpdateTime = Convert.ToDateTime(reader["UpdateTime"])

                });
            }
            reader.Close();
            return list;

        }

        /// <summary>
        ///通过学生id 来查询成绩
        /// </summary>
        /// <returns></returns>
        public List<ScoreList> GetScoreListsStuID(int Stuid)
        {
            string sql = string.Format( "select * from ScoreList where ScoreList.StudentId={0}",Stuid);
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);//读取
            List<ScoreList> list = new List<ScoreList>();//新建一个泛型
            while (reader.Read())
            {
                list.Add(new ScoreList()
                {
                    ID = Convert.ToInt32(reader["ID"]),
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    CSharp = Convert.ToInt32(reader["CSharp"]),
                    SQLServerDB = Convert.ToInt32(reader["SQLServerDB"]),
                    UpdateTime = Convert.ToDateTime(reader["UpdateTime"])
                });
            }
            reader.Close();
            return list;
        }
    }
}
