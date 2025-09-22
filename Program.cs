using App;
// Anvandare
// Resurser, dolda baserade po rool
//Logga in
//Logga out
// Skapa en anvandare om man are en Admin
// se schema
// Lamna in uppgifter
//
//Fo uppgifter ratade med betyg (betyg kan vara en Enum)

// olika anvandare (IUser)

List<IUser> users = new List<IUser>();
users.Add(new Student("s1.com", "1", "fatima"));
users.Add(new Student("s2.com", "12", "lina"));
users.Add(new Student("s3.com", "123", "joel"));
users.Add(new Student("s4.com", "1234", "kiven"));
users.Add(new Student("s5.com", "12345", "jenjera"));

users.Add(new Admin("admin.com", "password123"));
users.Add(new Teacher("t", "t"));

users.Add(new Admin("admin", "admin"));


List<string> documents = new List<string>();

IUser? active_user= null; // kollar VEM om user are active

List<string> students_results = new List<string>();
List<string> students_names = new List<string>();



bool running = true;

while (running)
{
  Console.Clear();

  if (active_user == null)
  {
    Console.Write("Username: ");
    string username= Console.ReadLine();

    Console.Clear();
    Console.Write("Password: ");
    string password= Console.ReadLine();

    Console.Clear();
    foreach (IUser user in users)
    {
      if (user.TryLogin(username, password))
      {
      active_user= user;
      
        break;
      }
    }
    }
    else 
    {
      Console.Clear();
      Console.WriteLine("--- School System ----");

      if (active_user.IsRole(Role.Admin))
      {
        Console.WriteLine("Welcome Admin");
      }
      if (active_user.IsRole(Role.Teacher))
      {
        Console.WriteLine("Welcome Teacher");
        Console.WriteLine();
        Console.WriteLine("1. Add a task: ");
        Console.WriteLine("2. Show tasks: ");
        Console.WriteLine("3. Remove a task: ");
        Console.WriteLine("4. Upload students results: ");
        Console.WriteLine("5. Show students results: ");
        Console.WriteLine("6. Remove students results: ");
        Console.WriteLine("close: To Log out: ");
        string inputTeacher = Console.ReadLine();

        switch(inputTeacher)
        {
          case "1": // Add doc
          Console.Clear();

          Console.WriteLine("The titel: ");
          inputTeacher = Console.ReadLine();
          documents.Add(inputTeacher);
          break;

          case "2": // Show doc
          Console.WriteLine("You have the following:  ");

           foreach(string doc in documents)
           {
            Console.WriteLine(doc + " ");
         
           }
           Console.WriteLine("Press ENTER to continue...");
           Console.ReadLine();
           break;

           case "3": // remove doc

           Console.Clear();

          Console.WriteLine("Choose the document to remove: ");
          foreach(string doc in documents)
           {
            Console.WriteLine(doc + " ");
         
           }

          inputTeacher = Console.ReadLine();
          
          if (inputTeacher != null && inputTeacher != "")
          {
            Console.WriteLine($"Removing: {inputTeacher}");
            documents.Remove(inputTeacher);
          } 
          else 
          {
            Console.WriteLine("Invalid input. Close.");
          }
          break;

          case "4": // upload results
          Console.Clear();

          Console.WriteLine("Enter the students name: ");
          inputTeacher= Console.ReadLine();
          foreach(IUser user in users)
          {
            if(user is Student s && s.Name == inputTeacher){
               Console.WriteLine("Enter the students result: ");
              inputTeacher = Console.ReadLine();
              s.Results.Add(inputTeacher);
            }
          }
          break;

          case "5": // show students results
          Console.WriteLine("There are those results on the system:  ");

          foreach(IUser user in users)
          {
            if(user is Student s)
            {
              Console.Write( s.Name + " result is: ");
              foreach(string result in s.Results)
              {
                Console.WriteLine();
                Console.WriteLine(result);
              }
            }
          }
           Console.WriteLine();
           Console.WriteLine("Press ENTER to continue...");
           Console.ReadLine();


          break;

          case "6": // remove students result
          Console.Clear();

          Console.WriteLine("Choose the result to remove: ");
          foreach(string result in students_results)
           {
            Console.WriteLine(result + " ");
         
           }

          inputTeacher = Console.ReadLine();
          
          if (inputTeacher != null && inputTeacher != "")
          {
            Console.WriteLine($"Removing: {inputTeacher}");
            students_results.Remove(inputTeacher);
          } 
          else 
          {
            Console.WriteLine("Invalid input. Close.");
          }
          break;

          case "close": // log out
          running = false;
          break;

          default: break;
        }


      }
      if (active_user.IsRole(Role.Student))
      {
        Console.WriteLine("Welcome Student");

      }

  }

  Console.WriteLine("The system is done");

  /*switch (active_user.GetRole())
  {
    case Role.Teacher:
       Console.WriteLine("Welcome Teacher ");
    break;
    case Role.Admin:
       Console.WriteLine("Welcome Admin");
    break;
    case Role.Student:
       Console.WriteLine("Welcome Student ");
    break;

    defualt: break;

  }*/

  

}

