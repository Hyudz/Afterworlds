using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    private float currentCd;
    public sceneInfo sceneinfo;
    [SerializeField] public float animCd;
    public Animator meleeAnimation;
    public RuntimeAnimatorController cs1;
    public RuntimeAnimatorController cs2;
    public RuntimeAnimatorController cs3;
    public RuntimeAnimatorController es1;
    public RuntimeAnimatorController es2;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {

        switch (sceneinfo.currentSkin)
        {
            case "Common Skin 1":
                meleeAnimation.runtimeAnimatorController = cs1;
                break;
            case "Common Skin 2":
                meleeAnimation.runtimeAnimatorController = cs2;
                break;
            case "Common Skin 3":
                meleeAnimation.runtimeAnimatorController = cs3;
                break;
            case "Epic Skin 1":
                meleeAnimation.runtimeAnimatorController = es1;
                break;
            case "Epic Skin 2":
                meleeAnimation.runtimeAnimatorController = es2;
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
