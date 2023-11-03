using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class achievementDb : MonoBehaviour
{
    public string connection;
    public achievement achievementHelper;
    private float time;

    public void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";

        //create table if it doesnt exist
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS achievements (achievement1 VARCHAR(5) NOT NULL,achievement2 VARCHAR(5) NOT NULL,achievement3 VARCHAR(5) NOT NULL,achievement4 VARCHAR(5) NOT NULL,achievement5 VARCHAR(5) NOT NULL,achievement6 VARCHAR(5) NOT NULL,achievement7 VARCHAR(5) NOT NULL,achievement8 VARCHAR(5) NOT NULL,achievement9 VARCHAR(5) NOT NULL,achievement10 VARCHAR(5) NOT NULL,achievement11 VARCHAR(5) NOT NULL,achievement12 VARCHAR(5) NOT NULL, killCount INT, weaponCount INT, finishedCount INT);";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        dbConnection.Open();
        dbCommand.CommandText = "SELECT COUNT(*) FROM achievements";
        int rowCount = Convert.ToInt32(dbCommand.ExecuteScalar());

        if (rowCount == 0)
        {
            IDbCommand insertCommand = dbConnection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO achievements (achievement1, achievement2, achievement3, achievement4, achievement5, achievement6, achievement7, achievement8, achievement9, achievement10, achievement11, achievement12, killCount, weaponCount, finishedCount) VALUES ('false','false','false','false','false','false','false','false','false','false','false','false',0,0,0);";
            insertCommand.ExecuteNonQuery();
        }

        dbConnection.Close();
        readKillCount();
        readWeaponCount();
        readFinishCount();
    }

    //ACHIEVEMNET 1====================================================================================

    public void Update()
    {
        
        time += Time.deltaTime;

        if (time >= 5.0f)
        {
            readAchievement1(); readAchievement7();
            readAchievement2(); readAchievement8();
            readAchievement3(); readAchievement9();
            readAchievement4(); readAchievement10();
            readAchievement5(); readAchievement11();
            readAchievement6(); readAchievement12();
            readKillCount();
            readWeaponCount();
            readFinishCount();

            time = 0;
        }
    }

    public void updateAchievement1()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement1 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement1();
    }

    public void readAchievement1()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement1 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement1"));

            if (result == "true")
            {
                achievementHelper.achivement1 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 2====================================================================================

    public void updateAchievement2()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement2 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement2();
    }

    public void readAchievement2()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement2 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement2"));

            if (result == "true")
            {
                achievementHelper.achivement2 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement3()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement3 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement3();
    }

    public void readAchievement3()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement3 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement3"));

            if (result == "true")
            {
                achievementHelper.achivement3 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement4()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement4 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement4();
    }

    public void readAchievement4()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement4 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement4"));

            if (result == "true")
            {
                achievementHelper.achivement4 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement5()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement5 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement5();
    }

    public void readAchievement5()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement5 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement5"));

            if (result == "true")
            {
                achievementHelper.achivement5 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement6()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement6 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement6();
    }

    public void readAchievement6()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement6 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement6"));

            if (result == "true")
            {
                achievementHelper.achivement6 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement7()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement7 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement7();
    }

    public void readAchievement7()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement7 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement7"));

            if (result == "true")
            {
                achievementHelper.achivement7 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement8()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement8 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement1();
    }

    public void readAchievement8()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement8 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement8"));

            if (result == "true")
            {
                achievementHelper.achivement8 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement9()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement9 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement9();
    }

    public void readAchievement9()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement9 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement9"));

            if (result == "true")
            {
                achievementHelper.achivement9 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement10()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement10 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement10();
    }

    public void readAchievement10()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement10 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement10"));

            if (result == "true")
            {
                achievementHelper.achivement10 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement11()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement11 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement11();
    }

    public void readAchievement11()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement11 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement11"));

            if (result == "true")
            {
                achievementHelper.achivement11 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //ACHIEVEMNET 1====================================================================================

    public void updateAchievement12()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET achievement12 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readAchievement12();
    }

    public void readAchievement12()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT achievement12 FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result = reader.GetString(reader.GetOrdinal("achievement12"));

            if (result == "true")
            {
                achievementHelper.achivement12 = true;
            }
        }
        reader.Close();
        dbConnection.Close();
    }

    //========================================================================================================================================================

    public void updateKillCount(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET killCount = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readKillCount();
    }

    public void readKillCount()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT killCount FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();
        
        while (reader.Read())
        {
            achievementHelper.killedEnemies = reader.GetInt32(reader.GetOrdinal("killCount"));
        }
        reader.Close();
        dbConnection.Close();
    }

    public void updateWeaponCount(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET weaponCount = "+ newValue +";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readWeaponCount();
    }

    public void readWeaponCount()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT weaponCount FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            achievementHelper.obtainedWeapons = reader.GetInt32(reader.GetOrdinal("weaponCount"));
        }
        reader.Close();
        dbConnection.Close();
    }

    public void updateFinishCount(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE achievements SET finishedCount = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readFinishCount();
    }

    public void readFinishCount()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT finishedCount FROM achievements;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            achievementHelper.finished = reader.GetInt32(reader.GetOrdinal("finishedCount"));
        }
        reader.Close();
        dbConnection.Close();
    }


}
