using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.SceneManagement;

public class gameloadDb : MonoBehaviour
{
    public string connection;
    public sceneInfo sceneinfo;
    public int rowCount;
    public int game1Uid, game2Uid, game3Uid;
    public float defaultMovement;
    public int defaultHp;
    public int defaultShield;
    public void Start()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        Debug.Log(connection);

        //create database if it doesnt exist
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();                //1                         2                   3                                   4                               5                   6                       7                       8            9                                  10                      11                      12                                      13                      14                              15                          16                      17                  18
        dbCommand.CommandText = "CREATE TABLE IF NOT EXISTS gameDataa (UID INTEGER NOT NULL, Map INT NOT NULL, MovementSpd DECIMAL(5,2) NOT NULL, AtkSpd DECIMAL(5,2) NOT NULL, CurrentHP INT NOT NULL, MaxHP INT NOT NULL, atkDmg INT NOT NULL, atkLimit INT NOT NULL, BoxWidth DECIMAL(5,2) NOT NULL, BoxHeight DECIMAL(5,2) NOT NULL, CurrentExp INT NOT NULL, MaxExp INT NOT NULL, CurrentTime  DECIMAL(5,2) NOT NULL, currentCoins INT NOT NULL, currentBlueite INT NOT NULL, currentGreenite INT NOT NULL, Shield INT NOT NULL, mapStyle VARCHAR(20) NOT NULL);";
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }
                            // 1     2              3               4           5       6           7       8               9           10              11          12          13                  14              15                      16              17              18
    public void insertGame(int UID, int map, float atkSpd, int dmg, int limit, float width, float height, int currentExp, int maxExp, float currentTime, int currentCoins, int currentBlueite, int currentGreenite, string mapStyle)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
                                     //  1    2          3           4       5      6   7      8         9       10      11            12        13          14              15              16                17        18
        dbCommand.CommandText = "INSERT INTO gameDataa VALUES (@UID, @map, @movementSpd, @atkSpd, @hp, @maxHp, @dmg, @limit, @width, @height, @currentExp, @maxExp, @currentTime, @currentCoins, @currentBlueite, @currentGreenite, @shield, @mapStyle)";

        IDbDataParameter UIDParameter = dbCommand.CreateParameter();
        UIDParameter.ParameterName = "@UID";
        UIDParameter.Value = UID;
        dbCommand.Parameters.Add(UIDParameter);

        IDbDataParameter mapParameter = dbCommand.CreateParameter();
        mapParameter.ParameterName = "@map";
        mapParameter.Value = map;
        dbCommand.Parameters.Add(mapParameter);

        IDbDataParameter movementParameter = dbCommand.CreateParameter();
        movementParameter.ParameterName = "@movementSpd";
        movementParameter.Value = defaultMovement;
        dbCommand.Parameters.Add(movementParameter);

        IDbDataParameter atkSpdParameter = dbCommand.CreateParameter();
        atkSpdParameter.ParameterName = "@atkSpd";
        atkSpdParameter.Value = atkSpd;
        dbCommand.Parameters.Add(atkSpdParameter);

        IDbDataParameter hpParameter = dbCommand.CreateParameter();
        hpParameter.ParameterName = "@hp";
        hpParameter.Value = defaultHp;
        dbCommand.Parameters.Add(hpParameter);

        IDbDataParameter maxHpParameter = dbCommand.CreateParameter();
        maxHpParameter.ParameterName = "@maxHp";
        maxHpParameter.Value = defaultHp;
        dbCommand.Parameters.Add(maxHpParameter);

        IDbDataParameter dmgParameter = dbCommand.CreateParameter();
        dmgParameter.ParameterName = "@dmg";
        dmgParameter.Value = dmg;
        dbCommand.Parameters.Add(dmgParameter);

        IDbDataParameter limitParameter = dbCommand.CreateParameter();
        limitParameter.ParameterName = "@limit";
        limitParameter.Value = limit;
        dbCommand.Parameters.Add(limitParameter);

        IDbDataParameter widthParameter = dbCommand.CreateParameter();
        widthParameter.ParameterName = "@width";
        widthParameter.Value = width;
        dbCommand.Parameters.Add(widthParameter);

        IDbDataParameter heightParameter = dbCommand.CreateParameter();
        heightParameter.ParameterName = "@height";
        heightParameter.Value = height;
        dbCommand.Parameters.Add(heightParameter);

        IDbDataParameter currentExpParameter = dbCommand.CreateParameter();
        currentExpParameter.ParameterName = "@currentExp";
        currentExpParameter.Value = currentExp;
        dbCommand.Parameters.Add(currentExpParameter);

        IDbDataParameter maxExpParameter = dbCommand.CreateParameter();
        maxExpParameter.ParameterName = "@maxExp";
        maxExpParameter.Value = maxExp;
        dbCommand.Parameters.Add(maxExpParameter);

        IDbDataParameter currentTimeParameter = dbCommand.CreateParameter();
        currentTimeParameter.ParameterName = "@currentTime";
        currentTimeParameter.Value = currentTime;
        dbCommand.Parameters.Add(currentTimeParameter);

        IDbDataParameter currentCoinsParameter = dbCommand.CreateParameter();
        currentCoinsParameter.ParameterName = "@currentCoins";
        currentCoinsParameter.Value = currentCoins;
        dbCommand.Parameters.Add(currentCoinsParameter);

        IDbDataParameter currentBlueiteParamter = dbCommand.CreateParameter();
        currentBlueiteParamter.ParameterName = "@currentBlueite";
        currentBlueiteParamter.Value = currentBlueite;
        dbCommand.Parameters.Add(currentBlueiteParamter);

        IDbDataParameter currentGreeniteParameter = dbCommand.CreateParameter();
        currentGreeniteParameter.ParameterName = "@currentGreenite";
        currentGreeniteParameter.Value = currentGreenite;
        dbCommand.Parameters.Add(currentGreeniteParameter);

        IDbDataParameter shieldParameter = dbCommand.CreateParameter();
        shieldParameter.ParameterName = "@shield";
        shieldParameter.Value = defaultShield;
        dbCommand.Parameters.Add(shieldParameter);

        IDbDataParameter mapStyleParameter = dbCommand.CreateParameter();
        mapStyleParameter.ParameterName = "@mapStyle";
        mapStyleParameter.Value = mapStyle;
        dbCommand.Parameters.Add(mapStyleParameter);

        dbCommand.ExecuteNonQuery();
        dbConnection.Close();

    }

    //NOT USED
    public void updateUser(int id, string newName)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE users SET Username = '@newName' WHERE ID = @id)";

        IDbDataParameter nameParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@newName";
        nameParam.Value = newName;
        dbCommand.Parameters.Add(nameParam);

        IDbDataParameter idParam = dbCommand.CreateParameter();
        nameParam.ParameterName = "@id";
        nameParam.Value = id;
        dbCommand.Parameters.Add(idParam);

        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void deleteGame(int id)
    {
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "DELETE FROM gameDataa WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void readGame(int id)
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM gameDataa WHERE UID = " + id;
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            sceneinfo.currentMap = reader.GetInt32(reader.GetOrdinal("Map"));
            sceneinfo.movementSpeed = reader.GetFloat(reader.GetOrdinal("MovementSpd"));
            sceneinfo.attackCd = reader.GetFloat(reader.GetOrdinal("AtkSpd"));
            sceneinfo.health = reader.GetInt32(reader.GetOrdinal("CurrentHP"));
            sceneinfo.maxHealth = reader.GetInt32(reader.GetOrdinal("MaxHP"));
            sceneinfo.atkDmg = reader.GetInt32(reader.GetOrdinal("atkDmg"));
            sceneinfo.atkLimit = reader.GetInt32(reader.GetOrdinal("atkLimit"));
            sceneinfo.boxWidth = reader.GetFloat(reader.GetOrdinal("BoxWidth"));
            sceneinfo.boxHeight = reader.GetFloat(reader.GetOrdinal("BoxHeight"));
            sceneinfo.currentExp = reader.GetInt32(reader.GetOrdinal("CurrentExp"));
            sceneinfo.maxExp = reader.GetInt32(reader.GetOrdinal("MaxExp"));
            sceneinfo.currentTime = reader.GetFloat(reader.GetOrdinal("CurrentTime"));
            sceneinfo.current_aftercoins = reader.GetInt32(reader.GetOrdinal("currentCoins"));
            sceneinfo.currentBlueite = reader.GetInt32(reader.GetOrdinal("currentBlueite"));
            sceneinfo.currentGreenite = reader.GetInt32(reader.GetOrdinal("currentGreenite"));
            sceneinfo.shield = reader.GetInt32(reader.GetOrdinal("Shield"));
            sceneinfo.currentMapStyle = reader.GetString(reader.GetOrdinal("mapStyle"));

        }

        if(sceneinfo.currentMap == 1)
        {
            SceneManager.LoadScene("Game Screen");
        } else if (sceneinfo.currentMap == 2)
        {
            SceneManager.LoadScene("Map 2");
        } else if (sceneinfo.currentMap == 3)
        {
            SceneManager.LoadScene("Map 3");
        }

        reader.Close();
        dbConnection.Close();
    }


    public void count()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT COUNT(UID) FROM gameDataa;";
        IDataReader reader = dbCommand.ExecuteReader();

        rowCount = 0;
        while (reader.Read())
        {
            rowCount = reader.GetInt32(0);
        }

        reader.Close();
        dbConnection.Close();
    }

    public void checkGame1()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM gameDataa WHERE UID = 1;";
        IDataReader reader = dbCommand.ExecuteReader();

        rowCount = 0;
        while (reader.Read())
        {
            game1Uid = reader.GetInt32(reader.GetOrdinal("UID"));
            
        }

        Debug.Log("Game 1 UID" + game1Uid);

        reader.Close();
        dbConnection.Close();
    }

    public void checkGame2()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM gameDataa WHERE UID = 2;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            game2Uid = reader.GetInt32(reader.GetOrdinal("UID"));
        }
        Debug.Log("Game 2 UID" + game2Uid);
        

        reader.Close();
        dbConnection.Close();
    }

    public void checkGame3()
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT * FROM gameDataa WHERE UID = 3;";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            game3Uid = reader.GetInt32(reader.GetOrdinal("UID"));
            
        }
        Debug.Log("Game 3 UID" + game3Uid);
        reader.Close();
        dbConnection.Close();
    }

    public void checkData(int id)
    {
        connection = "URI=file:" + Application.persistentDataPath + "/userData.db";
        IDbConnection dbConnection = new SqliteConnection(connection);
        IDbCommand dbCommand;

        // Retrieve and display data
        dbConnection.Open();
        dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "SELECT currentCoins, CurrentTime FROM gameDataa WHERE UID ="+ id+";";
        IDataReader reader = dbCommand.ExecuteReader();

        while (reader.Read())
        {
            sceneinfo.current_aftercoins = reader.GetInt32(reader.GetOrdinal("currentCoins"));
            sceneinfo.currentTime = reader.GetFloat(reader.GetOrdinal("CurrentTime"));
        }
        Debug.Log("Game 3 UID" + game3Uid);
        reader.Close();
        dbConnection.Close();
    }

    /*public void updateGame(int id)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameData SET Map = " +  + " WHERE ID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }
    */
    public void updateMovement(int id, float newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET MovementSpd = " + newValue +" WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateAtkSpd(int id, float newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET AtkSpd = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateHP(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET CurrentHP = " + newValue+ " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateMaxHP(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET MaxHP = " + newValue+" WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateDmg(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET atkDmg = " + newValue +" WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateLimit(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET atkLimit = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateWidth(int id, float newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET BoxWidth = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateHeight(int id, float newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET BoxHeight = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateMap(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET Map = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateCurrentExp(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET currentExp = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateMaxExp(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET maxExp = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateCurrentTime(int id, float newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET currentTime = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateCoins(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET currentCoins = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateBlueite(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET currentBlueite = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }

    public void updateGreenite(int id, int newValue)
    {
        //movement speed
        IDbConnection dbConnection = new SqliteConnection(connection);
        dbConnection.Open();
        IDbCommand dbCommand = dbConnection.CreateCommand();
        dbCommand.CommandText = "UPDATE gameDataa SET currentGreenite = " + newValue + " WHERE UID = " + id;
        dbCommand.ExecuteNonQuery();
        dbConnection.Close();
    }




}
