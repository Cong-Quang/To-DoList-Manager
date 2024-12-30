using System;
using System.Collections.Generic;
using System.IO;
public class HandleTD
{
    private static HandleTD gi;
    public string url_Data = "Data.json";
    public DataManager dataManager = new DataManager();
    public List<User> users;
    public static HandleTD gI()
    {
        if (gi == null) gi = new HandleTD();
        return gi;
    }
    public void setup()
    {
        checkFile();
        dataManager.LoadData();
        users = dataManager.LoadData();
    }
    public void checkFile()
    {
        if (!File.Exists(url_Data))
        {
            var sampleData = new List<User>{
            new User {
                Username = "admin",
                Password = "admin123",
                Tasks = new List<Task>
                {
                    new Task
                    {
                        Id = 1,
                        Title = "Welcome Task",
                        Description = "This is your first task. Feel free to edit or delete it.",
                        DueDate = DateTime.Now.AddDays(7),
                        IsCompleted = false
                    }
                }
            }};
            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(sampleData, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(url_Data, jsonData);
        }
        else ReadFile();
    }
    public List<User> ReadFile()
    {
        if (File.Exists(url_Data))
        {
            string jsonData = File.ReadAllText(url_Data);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<User>>(jsonData);
        }
        return new List<User>();
    }
    public void UpdateFile(List<User> users)
    {
        string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(users, Newtonsoft.Json.Formatting.Indented);

        File.WriteAllText(url_Data, jsonData);
    }
}
