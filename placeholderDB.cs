using System.Text.Json;
using System.Text.Json.Serialization;


public class PlaceholderDB
{

    string filename = "test.json";
    

    public void Seed()
    {

        Account account1 = new Account("michealbubley", "lolcow");
        Account account2 = new Account("kating", "bomba");
        Account account3 = new Account("betalux", "benalux");

        List<Account> holder = [account1, account2, account3];


        string jsonString = JsonSerializer.Serialize(holder, new JsonSerializerOptions { WriteIndented = true });
        File.AppendAllText(filename, jsonString + Environment.NewLine);


    }
    public bool SearchAccount(string username, string password)
    {
        string jsonContent = File.ReadAllText(filename);
        List<Account> accounts = JsonSerializer.Deserialize<List<Account>>(jsonContent)!;
        
        foreach (var item in accounts)
        {
            if (item.Username == username && item.Password == password)
            {
                return true;
            }
        }
        return false;


    }



}