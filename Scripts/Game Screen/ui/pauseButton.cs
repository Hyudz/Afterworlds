using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseButton : MonoBehaviour
{
    public void saveAndExit()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
