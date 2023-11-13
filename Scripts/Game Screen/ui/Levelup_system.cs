using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Levelup_system : MonoBehaviour
{
    [Header("Upgraded Stats")]
    [SerializeField] public float movementSpeed;
    [SerializeField] public float attackSpeed;
    [SerializeField] public int hp;
    [SerializeField] public int damage;
    [SerializeField] public int limit;
    [SerializeField] public float attackRange;
    [SerializeField] public float boxWidth;
    [SerializeField] public float boxHeight;

    [Header("Stats References")]
    public health player_health;
    public Canvas levelupSystem;
    public melee meleeAnim;
    public sceneInfo sceneinfo;
    public GameObject meleeSize;

    [Header("UI References")]
    public Canvas UI;
    public Canvas game_Timer;
    public Canvas characterStats;

    [Header("Text References")]
    public TextMeshProUGUI buff1_text;
    public TextMeshProUGUI buff2_text;
    public TextMeshProUGUI buff3_text;

    [Header("Button References")]
    public Button buff1_btn;
    public Button buff2_btn;
    public Button buff3_btn;
    public Image[] buffImages;
    public Sprite[] buffSprites;

    int buff1, buff2, buff3;
    string chosen_buff1, chosen_buff2, chosen_buff3;

    List<string> buffList = new List<string>();
    List<string> chosenBuffs = new List<string>();

    public void forButton1()
    {
        string buffText = buff1_text.GetComponent<TextMeshProUGUI>().text;
        choosenBuff(buffText);
    }

    public void forButton2()
    {
        string buffText = buff2_text.GetComponent<TextMeshProUGUI>().text;
        choosenBuff(buffText);
    }

    public void forButton3()
    {
        string buffText = buff3_text.GetComponent<TextMeshProUGUI>().text;
        choosenBuff(buffText);
    }

    public void choosenBuff(string buff)
    {
        if (buff == "Movement Speed")
        {
            sceneinfo.movementSpeed += movementSpeed;
        } else if (buff == "HP increase")
        {
            player_health.addHealth(hp);
        } else if (buff == "HP restoration")
        {
            player_health.restoreHealth();
        } else if (buff == "Additional Damage")
        {
            sceneinfo.atkDmg += damage;
        } else if (buff == "Attack Speed")
        {
            sceneinfo.attackCd -= attackSpeed;
            meleeAnim.animCd -= attackSpeed;
        } else if (buff == "Increase cleaving range")
        {
            sceneinfo.atkLimit += limit;
            sceneinfo.boxWidth += boxWidth;
            sceneinfo.boxHeight += boxHeight;
            Vector3 scaleChange;

            scaleChange = new Vector3(0.2f, 0.2f,0.2f);
            meleeSize.transform.localScale += scaleChange;
            sceneinfo.scaleSize += scaleChange;
            Debug.Log("Im cute");
        } else
        {
            Debug.Log("NO BUFF WAS APPLIED");
        }

        chosenBuffs.Clear();
        show();
    }

    public void Start()
    {
        buffList.Add("Movement Speed");
        buffList.Add("HP increase");
        buffList.Add("HP restoration");
        buffList.Add("Additional Damage");
        buffList.Add("Attack Speed");
        buffList.Add("Increase cleaving range");
        enabled = false;
    }

    public void choose()
    {
        buff1 = Random.Range(0, buffList.Count);
        buff2 = Random.Range(0, buffList.Count);
        buff3 = Random.Range(0, buffList.Count);

        if (chosenBuffs.Contains(buffList[buff1]) == false)
        {
            chosenBuffs.Add(buffList[buff1]);
        } else
        {
            while (chosenBuffs.Contains(buffList[buff1]) != false)
            {
                buff1 = Random.Range(0, buffList.Count);
                if (chosenBuffs.Contains(buffList[buff1]) == false)
                {
                    chosenBuffs.Add(buffList[buff1]);
                    break;
                }
            } 
        }

        //BUFF 2 ====================================================================

        if (chosenBuffs.Contains(buffList[buff2]) == false)
        {
            chosenBuffs.Add(buffList[buff2]);
        }
        else
        {
            while (chosenBuffs.Contains(buffList[buff2]) != false)
            {
                buff2 = Random.Range(0, buffList.Count);
                if (chosenBuffs.Contains(buffList[buff2]) == false)
                {
                    chosenBuffs.Add(buffList[buff2]);

                    break;
                }
            } 
        }

        //BUFF 3 ====================================================================

        
        if (chosenBuffs.Contains(buffList[buff3]) == false)
        {
            chosenBuffs.Add(buffList[buff3]);
        }
        else
        {
            while (chosenBuffs.Contains(buffList[buff3]) != false)
            {
                buff3 = Random.Range(0, buffList.Count);
                if (chosenBuffs.Contains(buffList[buff3]) == false)
                {
                    chosenBuffs.Add(buffList[buff3]);

                    
                    break;
                }
            } 
        }

        if (chosenBuffs[0] == "Movement Speed")
        {
            buffImages[0].sprite = buffSprites[0];
        }
        else if (chosenBuffs[0] == "HP increase")
        {
            buffImages[0].sprite = buffSprites[1];
        }
        else if (chosenBuffs[0] == "HP restoration")
        {
            buffImages[0].sprite = buffSprites[2];
        }
        else if (chosenBuffs[0] == "Additional Damage")
        {
            buffImages[0].sprite = buffSprites[3];
        }
        else if (chosenBuffs[0] == "Attack Speed")
        {
            buffImages[0].sprite = buffSprites[4];
        }
        else if (chosenBuffs[0] == "Increase cleaving range")
        {
            buffImages[0].sprite = buffSprites[5];
        }

        //BUTTON 2

        if (chosenBuffs[1] == "Movement Speed")
        {
            buffImages[1].sprite = buffSprites[0];
        }
        else if (chosenBuffs[1] == "HP increase")
        {
            buffImages[1].sprite = buffSprites[1];
        }
        else if (chosenBuffs[1] == "HP restoration")
        {
            buffImages[1].sprite = buffSprites[2];
        }
        else if (chosenBuffs[1] == "Additional Damage")
        {
            buffImages[1].sprite = buffSprites[3];
        }
        else if (chosenBuffs[1] == "Attack Speed")
        {
            buffImages[1].sprite = buffSprites[4];
        }
        else if (chosenBuffs[1] == "Increase cleaving range")
        {
            buffImages[1].sprite = buffSprites[5];
        }

        //BUTTON 3

        if (chosenBuffs[2] == "Movement Speed")
        {
            buffImages[2].sprite = buffSprites[0];
        }
        else if (chosenBuffs[2] == "HP increase")
        {
            buffImages[2].sprite = buffSprites[1];
        }
        else if (chosenBuffs[2] == "HP restoration")
        {
            buffImages[2].sprite = buffSprites[2];
        }
        else if (chosenBuffs[2] == "Additional Damage")
        {
            buffImages[2].sprite = buffSprites[3];
        }
        else if (chosenBuffs[2] == "Attack Speed")
        {
            buffImages[2].sprite = buffSprites[4];
        }
        else if (chosenBuffs[2] == "Increase cleaving range")
        {
            buffImages[2].sprite = buffSprites[5];
        }

        buff1_text.SetText(chosenBuffs[0]);
        buff2_text.SetText(chosenBuffs[1]);
        buff3_text.SetText(chosenBuffs[2]);

        Time.timeScale = 0;
    }
    public void show()
    {
        UI.enabled = true;
        game_Timer.enabled = true;
        characterStats.enabled = true;

        Time.timeScale = 1.0f;
        levelupSystem.enabled = false;
    }

    public void hide()
    {
        UI.enabled = false;
        game_Timer.enabled = false;
        characterStats.enabled = false; 
    }

    public void Update()
    {
        Debug.Log("Hi");
        for (int i=0; i >= chosenBuffs.Count; i++)
        {
            Debug.Log(chosenBuffs[i]);
        }
        
    }


}
