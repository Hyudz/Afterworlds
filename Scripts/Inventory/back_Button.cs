using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class back_Button : MonoBehaviour
{
    public void back_button()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
