using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameTimer : MonoBehaviour
{

    [SerializeField] public float currentTime;
    public TextMeshProUGUI currentTimeText;
    int textTime;
    public bool startCount = false;
    public gameOverScreen gameOver;

    // Update is called once per frame

    private void Start()
    {
        startCount = false;
    }
    void Update()
    {
        if (startCount == true && gameOver.gameIsOver != true)
        {
            currentTime -= Time.deltaTime;
            textTime = (int) currentTime;
            currentTimeText.SetText(textTime.ToString());
            if (currentTime <= 0)
            {
                SceneManager.LoadScene("Main Menu");
                //ASCEND TO NEXT WORLD
            }
        }
        
    }
}
