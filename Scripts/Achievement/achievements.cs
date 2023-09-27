using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class achievements : MonoBehaviour
{

    [SerializeReference] private TextMeshProUGUI description;
    [SerializeReference] private TextMeshProUGUI achievement_name;
    [SerializeReference] private button achievement11_button;
    public void backButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void achievment1()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment2()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment3()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment4()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment5()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment6()
    {
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment7()
    {
        locked();
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment8()
    {
        locked();
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment9()
    {
        locked();
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment10()
    {
        locked();
        description.text = "Die in the game for the first time";
        achievement_name.text = "SHINEEEEEE!";
    }

    public void achievment11()
    {
        Debug.Log(achievement11_button.GetComponentInParent<button>().GetComponentInChildren<TextMeshPro>());
        
    }

    public void achievment12()
    {
        if (locked() == false) {
            description.text = "Kill 10000000 enemy.";
            achievement_name.text = "Overkill";
        }
        
    }

    public bool locked()
    {
        if (achievement_name.text == "?")
        {
            description.text = "Locked";
            achievement_name.text = "Interact more to unlock this achievement";
            return true;
        } else
        {
            return false;
        }
    }
}
