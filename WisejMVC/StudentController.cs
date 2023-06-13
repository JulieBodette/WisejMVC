using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Dapper;

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
		public static string CnnVal(string name)
		{
			//return ConfigurationManager.ConnectionStrings[name].ConnectionString;
			return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=StudentData;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
		}

		public List<StudentModel> GetStudents()
		{
			using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(StudentController.CnnVal("Students")))
			{
				//using SQL query sent in by text
				var output = connection.Query<StudentModel>("select * from Students").ToList();
				return output;
			}
		}
	}
}
