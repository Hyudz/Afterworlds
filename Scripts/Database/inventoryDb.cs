using Mono.Data.Sqlite;
using System;
using System.Data;
using UnityEngine;

public class inventoryDb : MonoBehaviour
{
    // Start is called before the first frame update
    public string connection;
    public inventoryForge items;
    public sceneInfo sceneinfo;
    //public storeItems storeitems;
    public gameloadDb gameHelper;
    public void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";

        //create table if it doesnt exist
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS inventoryItems (bootsTier INT NOT NULL, armorTier INT NOT NULL, shieldTier INT NOT NULL, orangeite INT NOT NULL, greenite INT NOT NULL, blueite INT NOT NULL, coins INT NOT NULL, skin1 VARCHAR (5),skin2 VARCHAR (5),skin3 VARCHAR (5),skin4 VARCHAR (5),skin5 VARCHAR (5),skin6 VARCHAR (5), inUseSkin VARCHAR(50) NOT NULL);";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        dbConnection.Open();
        dbCommand.CommandText = "SELECT COUNT(*) FROM inventoryItems";
        int rowCount = Convert.ToInt32(dbCommand.ExecuteScalar());

        if (rowCount == 0)
        {
            IDbCommand insertCommand = dbConnection.CreateCommand();
            insertCommand.CommandText = "INSERT INTO inventoryItems (bootsTier, armorTier, shieldTier, orangeite, greenite, blueite, coins, skin1,skin2,skin3,skin4,skin5,skin6, inUseSkin) VALUES (0, 0, 0, 0, 0, 0, 0,'false','false','false','false','false','false','default');";
            insertCommand.ExecuteNonQuery();
        }

        readSkin1();
        readSkin2();
        readSkin3();
        readSkin4();
        readSkin5();
        readSkin6();

        readArmorTier();
        readBootsTier();
        readShieldTier();
        readCoins();
        readBlueite();
        readGreenite();
        readOrangeite();

        dbConnection.Close();
    }

    public void readBootsTier()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT bootsTier FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.boots_tier = reader.GetInt32(reader.GetOrdinal("bootsTier"));
        }

        reader.Close();
        dbConnection.Close();

        if (items.boots_tier == 1)
        {
            gameHelper.defaultMovement = 210.0f;
        }
        else if (items.boots_tier == 2)
        {
            gameHelper.defaultMovement = 220.0f;
        }
        else if (items.boots_tier == 3)
        {
            gameHelper.defaultMovement = 230.0f;
        }
    }

    public void updateBootsTier(int newTier)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET bootsTier = " + newTier +";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readBootsTier();
    }

    public void readArmorTier()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT armorTier FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.armor_tier = reader.GetInt32(reader.GetOrdinal("armorTier"));
        }
        reader.Close();
        dbConnection.Close();

        if (items.armor_tier == 1)
        {
            gameHelper.defaultHp = 30;
        }
        else if (items.armor_tier == 2)
        {
            gameHelper.defaultHp = 40;
        } else if (items.armor_tier == 3)
        {
            gameHelper.defaultHp = 50;
        }

    }

    public void updateArmorTier(int newTier)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET armorTier = " + newTier + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readArmorTier();
    }

    public void readShieldTier()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT shieldTier FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.shield_tier = reader.GetInt32(reader.GetOrdinal("shieldTier"));
        }

        reader.Close();
        dbConnection.Close();

        if (items.shield_tier == 1)
        {
            gameHelper.defaultShield = 1;
            sceneinfo.shield = 1;
        }
        else if (items.shield_tier == 2)
        {
            gameHelper.defaultShield = 2;
            sceneinfo.shield = 2;
        }
        else if (items.shield_tier == 3)
        {
            gameHelper.defaultShield = 4;
            sceneinfo.shield = 4;
        }
    }

    public void updateShieldTier(int newTier)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET shieldTier = " + newTier + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readShieldTier();
    }

    //MATERIALS ===============================================================================================

    public void readOrangeite()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT orangeite FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.orangeite_values = reader.GetInt32(reader.GetOrdinal("orangeite"));
        }

        reader.Close();
        dbConnection.Close();
    }

    public void updateOrangeite(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET orangeite = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readOrangeite();
    }

    public void readBlueite()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT blueite FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.blueite_values = reader.GetInt32(reader.GetOrdinal("blueite"));
        }

        reader.Close();
        dbConnection.Close();
    }

    public void updateBlueite(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET blueite = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readBlueite();
    }

    public void readGreenite()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT greenite FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            items.greenite_values = reader.GetInt32(reader.GetOrdinal("greenite"));
        }

        reader.Close();
        dbConnection.Close();
    }

    public void updateGreenite(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET greenite = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readGreenite();
    }

    //SKIN1===================================================================================================
    public void updateSkin1()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin1 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readSkin1();

    }

    public void readSkin1()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin1 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.redSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    //SKIN2=========================================================================================================

    public void updateSkin2()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin2 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        readSkin2();
    }

    public void readSkin2()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin2 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.yellowSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    //SKIN3======================================================================================================
    public void updateSkin3()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin3 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        readSkin3();
    }

    public void readSkin3()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin3 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.blueSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    //SKIN 4=============================================================================================================

    public void updateSkin4()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin4 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        readSkin4();
    }

    public void readSkin4()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin4 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.thunderSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    //SKIN 5==========================================================================================

    public void updateSkin5()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin5 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        readSkin5();
    }

    public void readSkin5()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin5 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.voidSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    //SKIN 6================================================================================================

    public void updateSkin6()
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET skin6 = 'true';";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

        readSkin6();
    }

    public void readSkin6()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT skin6 FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            string result;
            result = reader.GetString(0);

            if (result == "true")
            {
                items.legendSkin = true;
            }

        }

        reader.Close();
        dbConnection.Close();
    }

    public void updateInUseSkin(string newSkin)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET inUseSkin = " + newSkin + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void readCoins()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT coins FROM inventoryItems;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            sceneinfo.aftercoins = reader.GetInt32(reader.GetOrdinal("coins"));
        }

        reader.Close();
        dbConnection.Close();
    }

    public void updateCoins(int newValue)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE inventoryItems SET coins = " + newValue + ";";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
        readCoins();
    }
}
