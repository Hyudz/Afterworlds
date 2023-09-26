using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void toMainMenu()
    {
        /* METHOD TO ENTER THE NEW SCENE (GAME) 
         * EXPLAINED: IT GETS THE ACTIVE SCENE 0 (DEPENDS ON THE BUILD)
         * THEN LATER ON LOADS THE NEXT SCENE ON THE BUILD LINEUP (0 + 1 = 1 OFCOURSE)
         * SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         */
        SceneManager.LoadScene("Main Menu");
    }
}
