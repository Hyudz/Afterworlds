using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using UnityEngine.UIElements;
using System.IO;

public class user_profiles : MonoBehaviour
{

    public TMP_InputField nameField;
    private string dbConnection;
    public Canvas dialougeBox;
    
    private void Start()
    {
        dialougeBox = GetComponent<Canvas>();
        dialougeBox.enabled = false;
        //string dbName = "URI=file:" + Application.persistentDataPath + "/users.db";
        string dbPath = Path.Combine(Application.persistentDataPath, "users.db");
        dbConnection = "URI=file:" + dbPath;

        Debug.Log("Database path: " + dbPath);
        Debug.Log("Database connection: " + dbConnection);

        Debug.Log("Here:" + databaseExist());
        if(databaseExist())
        {
            Debug.Log("It works");
        } else
        {
            
            createTable();
            dialougeBox.enabled =true;

            Debug.Log("It falls here");

        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private bool databaseExist()
    {

        //Establish a connection to the database
        IDbConnection databaseConnection = new SqliteConnection(dbConnection);

        //open the connection
        databaseConnection.Open();

        //Establish a command
        IDbCommand command = databaseConnection.CreateCommand();

        //Create a query
        command.CommandText = "SELECT * FROM sqlite_master WHERE type='table';";

        //Execute the query
        IDataReader reader = command.ExecuteReader();
        
        bool dbExists = reader.Read();
        Debug.Log("dbExists: " + dbExists);
        return dbExists;
    }

    private void createTable()
    {
        IDbConnection databaseConnection = new SqliteConnection(dbConnection);
        databaseConnection.Open();
        IDbCommand command = databaseConnection.CreateCommand();
        command.CommandText = "CREATE TABLE user_profile (userId INT PRIMARY KEY NOT NULL, Name VARCHAR(50) NOT NULL, Level INT NOT NULL);";
        IDataReader reader = command.ExecuteReader();
        reader.Read();

    }


    public void CreateProfile()
    {
        string name = nameField.text;
        IDbConnection databaseConnection = new SqliteConnection(dbConnection);
        databaseConnection.Open();
        IDbCommand command = databaseConnection.CreateCommand();
        command.CommandText = "INSERT INTO user_profile (userId , Name , Level ) VALUES (1, '"+name +"', 1);";
        IDataReader reader = command.ExecuteReader();
        reader.Read();
        dialougeBox.enabled = false;
    }
}
