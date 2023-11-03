using System.Data;
using TMPro;
using UnityEngine;
using Mono.Data.Sqlite;

public class gameProfiles : MonoBehaviour
{
    public TextMeshProUGUI text1, text2, text3;
    private string connection;
    // Start is called before the first frame update
    void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM users";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string name = reader.GetString(0);
            text1.SetText("Name: " + name);
        }

        reader.Close();
        dbConnection.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
