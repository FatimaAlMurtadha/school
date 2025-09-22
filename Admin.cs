namespace App;

class Admin : IUser
{
  // Fields for both username and password
  public string Username;
  string _password;

  public Admin(string username, string password) // Constructor
  {
    Username = username;
    _password = password;
  }
  public bool TryLogin(string username, string password) // The same method to check login with return value.
  {
    return username == Username && password == _password; // if true LOGIN
  }

   public bool IsRole (Role role) // The same method to check the role with return value.
   {
    return Role.Admin == role; // if true return the role
   }

   public Role GetRole() // The same get method to bring the role based side with return value.
   {
    return Role.Admin;
   }
   
}