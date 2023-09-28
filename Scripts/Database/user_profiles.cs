using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;

public class user_profiles : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string dbName = "URI=file:" + Application.persistentDataPath + "/users.db";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
