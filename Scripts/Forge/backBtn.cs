using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backBtn : MonoBehaviour
{
    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
