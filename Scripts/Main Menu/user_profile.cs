using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class user_profile : MonoBehaviour
{
    public sceneInfo sceneinfo;
    public void toGameScreen()
    {
        sceneinfo.retry();
        SceneManager.LoadScene("Game Screen");
    }
}
