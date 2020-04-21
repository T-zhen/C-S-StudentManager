using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagerModel.ObjExt;
using StudentManagerModel;
using System.Data.SqlClient;
using System.Data;
using Common;

namespace StudentManagerDAL
{
    /// <summary>
    /// 学生管理数据访问服务
    /// </summary>
    public class StudentServer
    {
        /// <summary>
        /// 返回指定学生的信息
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudents(int cid)
        {
            string sql = "SELECT StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassId=Students.ClassId WHERE StudentClass.ClassId=" + cid;
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);
            List<StudentExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }

        /// <summary>
        /// 返回学生表
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private static List<StudentExt> DataReturnObj(SqlDataReader reader)
        {
            List<StudentExt> list = new List<StudentExt>();
            while (reader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNo = reader["CardNo"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StuImage = reader["StuImage"].ToString()
                });
            }

            return list;
        }

        /// <summary>
        /// 根据ID或Name模糊查询
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public List<StudentExt> GetStudentIDorName(string target)
        {
            string sql = string.Format("SELECT StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,StuImage,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassId=Students.ClassId WHERE StudentId LIKE '%{0}%' OR StudentName LIKE '%{0}%'",target);
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);
            List<StudentExt> list = DataReturnObj(reader);
            reader.Close();
            return list;
        }

        /// <summary>
        /// 根据学生姓名查询
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int UpdateStudentInfor(StudentExt student)
        {
            string sql = string.Format("UPDATE Students SET StudentName='{0}',Gender='{1}',Birthday='{2}',StudentIdNo='{3}',CardNo='{4}',StuImage='{5}',Age={6},PhoneNumber='{7}',StudentAddress='{8}',ClassId={9} WHERE StudentId={10}", student.StudentName, student.Gender, student.Birthday, student.StudentIdNo, student.CardNo, student.StuImage, student.Age, student.PhoneNumber, student.StudentAddress, student.ClassId, student.StudentId);
            return DBHelper.SQLHelper.ExecuteNonQurey(sql);
        }


        /// <summary>
        /// 根据ID 进行查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public StudentExt GetStudentById(int id)
        {
            string sql = string.Format("SELECT StudentId,StudentName,Gender,Birthday,StudentIdNo,CardNo,StuImage,Age,PhoneNumber,StudentAddress,Students.ClassId,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassId=Students.ClassId WHERE StudentId = {0}", id);
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);
            StudentExt student = null;//清空原有数据
            while (reader.Read())
            {
                student = new StudentExt()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNo = reader["CardNo"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                    StuImage = reader["StuImage"].ToString(),
                    ClassId = Convert.ToInt32(reader["ClassId"])
                };
            }
            return student;
        }


        /// <summary>
        /// 对一个班的进行查询制表 
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int cid)
        {
            string sql= "SELECT StudentId ,StudentName,Gender,Birthday,StudentIdNo,CardNo,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassId=Students.ClassId WHERE StudentClass.ClassId="+cid;

            DataTable table = DBHelper.SQLHelper.GetDataset(sql).Tables[0];
            return table;
        }


        /// <summary>
        /// 通过班级ID来查询学生
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public List<StudentExt>  GetStudentsClassid(int cid)
        {
            string sql = "SELECT StudentId ,StudentName,Gender,Birthday,StudentIdNo,CardNo,Age,PhoneNumber,StudentAddress,StudentClass.ClassName FROM Students INNER JOIN StudentClass ON StudentClass.ClassId=Students.ClassId WHERE StudentClass.ClassId=" + cid;
            SqlDataReader reader = DBHelper.SQLHelper.GetReader(sql);
           List<StudentExt>  list = new List<StudentExt> ();
            while (reader.Read())
            {
                
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(reader["StudentId"]),
                    Age = Convert.ToInt32(reader["Age"]),
                    Birthday = Convert.ToDateTime(reader["Birthday"]),
                    CardNo = reader["CardNo"].ToString(),
                    ClassName = reader["ClassName"].ToString(),
                    Gender = reader["Gender"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    StudentAddress = reader["StudentAddress"].ToString(),
                    StudentIdNo = reader["StudentIdNo"].ToString(),
                    StudentName = reader["StudentName"].ToString(),
                   // StuImage = reader["StuImage"].ToString(),
                   // ClassId = Convert.ToInt32(reader["ClassId"])
                });       
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// 添加学生
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public int  AddStudent(StudentExt student) 
        {

            string sql = string.Format(" INSERT INTO Students VALUES('{0}','{1}','{2}','{3}','{4}',{5},'{6}','{7}','{8}','{9}')", student.StudentName, student.Gender, student.Birthday, student.StudentIdNo, student.CardNo, student.StuImage, student.Age, student.PhoneNumber, student.StudentAddress, student.ClassId);
            return DBHelper.SQLHelper.ExecuteNonQurey(sql);
           
        }


        public int DeleteStudentById(int sid)
        {
            string sql = "DELETE FROM Students WHERE StudentId=" + sid;
            return DBHelper.SQLHelper.ExecuteNonQurey(sql);
        }

        StudentClassServer classServer = new StudentClassServer();

        public List<StudentExt> GetStudentByExcel(string path)
        {
            List<StudentExt> list = new List<StudentExt>();
            string sql = string.Format("select * from [{0}$]",Common.ImportOrExportData.SheetName(path));//通过方法获取其路径下的Excel第一章名字
            DataSet ds = Common.OleDbHelper.GetDataSet(sql,path);//成表返回
            DataTable dt = ds.Tables[0];//第一张表
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new StudentExt()
                {
                    StudentName = row["姓名"].ToString(),
                    Gender = row["性别"].ToString(),
                    Birthday = Convert.ToDateTime(row["出生日期"]),
                    Age = DateTime.Now.Year - Convert.ToDateTime(row["出生日期"]).Year,
                    CardNo = row["考勤卡号"].ToString(),
                    StudentIdNo = row["身份证号"].ToString(),
                    PhoneNumber = row["电话号码"].ToString(),
                    StudentAddress = row["家庭住址"].ToString(),
                    ClassName = row["班级名称"].ToString(),
                    ClassId = classServer.GetClassIdByName(row["班级名称"].ToString())
                });
            }
            return list;
        }


        /// <summary>
        /// ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CheckStuId(string id)
        {
            string sql = "SELECT COUNT(*) FROM Students WHERE StudentIdNo='" + id + "'";
            object res = DBHelper.SQLHelper.ExecuteScalar(sql);
            return (int)res;
        }


        /// <summary>
        /// 查询相关学生信息
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public int InsertStudent(StudentExt stu)
        {
            string sql = string.Format("INSERT INTO Students(StudentName,Gender,Birthday,StudentIdNo,CardNo,Age,PhoneNumber,StudentAddress,ClassId) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', {5}, '{6}', '{7}', {8})", stu.StudentName, stu.Gender, stu.Birthday, stu.StudentIdNo, stu.CardNo, stu.Age, stu.PhoneNumber, stu.StudentAddress, stu.ClassId);
            return DBHelper.SQLHelper.ExecuteNonQurey(sql);
        }



       
    }
}
