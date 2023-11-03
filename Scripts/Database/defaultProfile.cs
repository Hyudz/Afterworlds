using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public class defaultProfile : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI username;
    private string connection;

    public void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        //Debug.Log(connection);

        //create database if it doesnt exist
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;
        try
        {
            Debug.Log("Here");
            dbConnection.Open();
            dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "SELECT Username FROM users;";
            IDataReader reader = dbCommand.ExecuteReader();
            Debug.Log("Will be executed");
            if (reader.Read())
            {
                Debug.Log("Executed");
                Debug.Log(reader.GetString(0));
                string name = reader.GetString(0);
                // Set the text of the UI element (assuming username is properly initialized)
                username.SetText(name);
            } else
            {
                Debug.Log("Didnt worked!");
            }
            Debug.Log("Done executing");
            reader.Close();
        }
        catch (Exception e)
        {
            Debug.LogError("Database Error: " + e.Message);
        }
    }

    public void Update()
    {
        
    }
}
