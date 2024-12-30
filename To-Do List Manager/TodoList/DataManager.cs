using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


public class DataManager
{
    private static DataManager gi;
    public static DataManager gI()
    {
        if (gi == null) { gi = new DataManager(); }
        return gi;
    }
    private string filePath = "data.json";

    public List<User> LoadData()
    {
        if (!File.Exists(filePath))
            return new List<User>();

        string json = File.ReadAllText(filePath);
        return JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
    }

    public void SaveData(List<User> users)
    {
        string json = JsonConvert.SerializeObject(users, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
    public bool Register(string username, string password, List<User> users, DataManager dataManager)
    {
        if (users.Any(u => u.Username == username))
            return false;

        users.Add(new User { Username = username, Password = password });
        dataManager.SaveData(users);
        return true;
    }
}
