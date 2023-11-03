using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;

public class user : MonoBehaviour
{
    private string connection;

    public void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        Debug.Log(connection);

        //create database if it doesnt exist
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS users (UID INTEGER PRIMARY KEY, Username VARCHAR(50) NOT NULL UNIQUE, UserAge INTEGER NOT NULL);";
        dbCommand.ExecuteNonQuery();
        Debug.Log("Table created successfully");
        dbConnection.Close();
    }

    public void insertUser(string name, int age)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "INSERT INTO users VALUES (@name, @age)";

        IDbDataParameter nameParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@name";
        nameParam.Value = name;
        dbCommand.Parameters.Add(nameParam);

        IDbDataParameter ageParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@age";
        nameParam.Value = age;
        dbCommand.Parameters.Add(ageParam);

        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateUser(int id, string newName)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE users SET Username = '@newName' WHERE ID = @id)";

        IDbDataParameter nameParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@newName";
        nameParam.Value = name;
        dbCommand.Parameters.Add(nameParam);

        IDbDataParameter idParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@id";
        nameParam.Value = id;
        dbCommand.Parameters.Add(idParam);

        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void deleteUser(int id)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "DELETE FROM users WHERE ID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }


}
