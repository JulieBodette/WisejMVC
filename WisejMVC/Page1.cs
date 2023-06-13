using System;
using Wisej.Web;
using System.Collections.Generic;

namespace WisejMVC
{
	public partial class Page1 : Page
	{
		public Page1()
		{
			InitializeComponent();
		}

		StudentController controller = new StudentController();
		List<StudentModel> PeopleList = new List<StudentModel>();

		private void Page1_Load(object sender, System.EventArgs e)
		{
			//DOES NOT WORK
			//PeopleList = controller.GetStudents();
			//dataGridView1.DataSource = PeopleList;
			PeopleList = controller.GetStudents();
			dataGridView1.DataSource = PeopleList;

			//add data
			//StudentModel model = new StudentModel() { Name = "John", Id = 12345, Age = 30, Email = "John@school.com" };
			//model.Id = 10;
			//PeopleList.Add(model);
			//PeopleList.Add(new StudentModel() { Name = "Julie", Id = 11111, Age = 26, Email = "Julie@example.com" });
			//PeopleList.Add(new StudentModel() { Name = "Jane", Id = 76394, Age = 24, Email = "Jane-email@domain.com" });
			//PeopleList.Add(new StudentModel() { Name = "Jack", Id = 9, Age = 19, Email = "Jack_is_greatgmail.com" });

		}

		private void button1_Click(object sender, EventArgs e)
		{

			//example of valid data
			//StudentModel model = new StudentModel() { Name = "John", Id =1, Age = 30, Email = "John@school.com" };

			//example of invalid data
			//StudentModel model = new StudentModel() { Name = "John", Id = 999999, Age = 30, Email = "bademail" };



			//read the data from the view
			int id = Int32.Parse(txtId.Text);
			string email = txtEmail.Text;
			string name = txtName.Text;
			int age = Int32.Parse(txtAge.Text);

			//controller does this- need to move this code to controller
			string errorMessage = controller.AddStudent(name, id, age, email);
			AlertBox.Show(errorMessage);
			//also need to save data to database (do this in the AddStudent method)


			//clear the textboxes
			txtId.Text = "";
			txtEmail.Text = "";
			txtName.Text = "";
			txtAge.Text = "";
			
		}

	}
}
