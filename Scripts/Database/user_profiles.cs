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
    public user userHelp;
   
    public void joinBtn()
    {
        string name = nameField.text;
        int age = 18;

        userHelp.insertUser(name, age);
    }



    
}
