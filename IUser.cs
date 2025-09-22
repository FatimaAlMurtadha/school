
namespace App;

interface IUser
{
  public bool TryLogin(string username, string password); // Method to Check Login

  public bool IsRole (Role role); // Method Check the role
  public Role GetRole(); // Method Get role code "sidan"


}

enum Role // Define roles on the whole system
{
  None, 
  Student,
  Teacher,
  Admin,
}