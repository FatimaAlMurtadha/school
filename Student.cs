namespace App;

class Student : IUser
{
  public string Name;
  public string Email;
  string _password; // private by defualt
  public List<string> Results = new List<string>();

  public Student (string email, string password, string name)
  {
    Email =email;
    _password = password;
    Name = name;
  }

  public bool TryLogin(string username, string password)
  {
    return username == Email && password == _password;
  }
  public bool IsRole (Role role)
   {
    return Role.Student == role;
   }
   public Role GetRole()
   {
    return Role.Student;
   }


}