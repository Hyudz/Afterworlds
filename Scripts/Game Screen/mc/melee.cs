using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    private float currentCd;
    public sceneInfo sceneinfo;
    [SerializeField] public float animCd;
    public Animator meleeAnimation;
    public RuntimeAnimatorController[] skins;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        switch (sceneinfo.currentSkin)
        {
            case "Common Skin 1":
                meleeAnimation.runtimeAnimatorController = skins[0];
                break;
            case "Common Skin 2":
                meleeAnimation.runtimeAnimatorController = skins[1];
                break;
            case "Common Skin 3":
                meleeAnimation.runtimeAnimatorController = skins[2];
                break;
            case "Epic Skin 1":
                meleeAnimation.runtimeAnimatorController = skins[3];
                break;
            case "Epic Skin 2":
                meleeAnimation.runtimeAnimatorController = skins[4];
                break;
            case "Legendary Skin":
                meleeAnimation.runtimeAnimatorController = skins[5];
                break;
            default:
                meleeAnimation.runtimeAnimatorController = skins[6];
                break;
        }
        currentCd += Time.deltaTime;
        if (currentCd >= animCd)
        {
            meleeAnimation.SetTrigger("attack_melee");
            currentCd = 0.0f;
        }
    }

}
