namespace App;

class Teacher :IUser
{
  public string Username;
  string _password;

  public Teacher(string username, string password)
  {
    Username = username;
    _password = password;
  }
  public bool TryLogin(string username, string password)
  {
    return username == Username && password == _password;
  }
  public bool IsRole (Role role)
   {
    return Role.Teacher == role;
   }

   public Role GetRole()
   {
    return Role.Teacher;
   }
   
}

/*class Result
{
  public string Student_Name;
  public string Student_Result;

  public Result (string student_name, string student_result)
  {
    Student_Name= student_name;
    Student_Result = student_result;
  }
}*/
