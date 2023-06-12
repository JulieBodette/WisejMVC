using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Security.Cryptography;
using Wisej.Web;

namespace WisejMVC
{
	public class StudentController
	{

		public string AddStudent(string name, int id, int age, string email)
		{
			//attempts to add a student to the database
			//returns a string with the validation errors
			StudentModel model = new StudentModel() { Name = name, Id = id, Age = age, Email = email };
			string errorMessage = StudentModel.ValidateData(model);

			//add code here that calls a method to add to the database
			//StudentModel needs to have the method that interacts with the database itself.
			return errorMessage;
		}

		//get the database connection string
		//THIS CODE DOES NOT WORK
		//public static string CnnVal(string name)
		//{
		//	return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		//}

		//public List<StudentModel> GetStudents()
		//{
		//	using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(StudentController.CnnVal("Students")))
		//	{
		//		//using SQL query sent in by text
		//		var output = connection.Query<StudentModel>("select * from Students").ToList();
		//		return output;
		//	}
		//}
	}
}
