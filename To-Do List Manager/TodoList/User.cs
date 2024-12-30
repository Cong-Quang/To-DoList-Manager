using System.Collections.Generic;
using System.Linq;
using To_Do_List_Manager;
public class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<Task> Tasks { get; set; } = new List<Task>();
}
public class HandleUser
{
    private static HandleUser gi;
    public static HandleUser gI()
    {
        if (gi == null) gi = new HandleUser();
        return gi;
    }
    public User Login(string username, string password, List<User> users)
    {
        return users.FirstOrDefault(u => u.Username == username && u.Password == password);
    }

    public bool Register(string username, string password, List<User> users, DataManager dataManager)
    {
        if (users.Any(u => u.Username == username))
            return false;

        users.Add(new User { Username = username, Password = password });
        dataManager.SaveData(users);
        return true;
    }
    public bool CheckLogin(string inputUsername, string inputPassword, List<User> userList)
    {
        var matchedUser = userList.FirstOrDefault(user =>
            user.Username == inputUsername && user.Password == inputPassword);

        return matchedUser != null;
    }

}