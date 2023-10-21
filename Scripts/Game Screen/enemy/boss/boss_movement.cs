using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_movement : MonoBehaviour
{

    public Animator bossMovement;
    private bool isIdle = false;
    public bool flip;
    Transform player;
    [SerializeField] public float movement_speed;
    private float currentPos = 1.0f;
    public boss_attack bossatk;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerInSight());
        //bossMovement.SetTrigger("willStomp");
        if (PlayerInSight() == false)
        {
            try
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, 130 * Time.deltaTime);
            } catch
            {
                //DO NOTHING OR STOP MOVING
            }
        }

        bossMovement.SetBool("isWalking", currentPos != transform.position.x);
        currentPos = transform.position.x;

        
        //enemy_animation.SetBool("walk", true);

        Vector3 scale = transform.localScale;
        try
        {
            if (player.transform.position.x > transform.position.x)
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);

            }
            transform.localScale = scale;
        } catch
        {
            //DO NOTHING
        }
    }

    public bool PlayerInSight()
    {
        LayerMask layerMask = LayerMask.GetMask("Character");

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(bossatk.detectionWidth, bossatk.detectionHeight), 0f, Vector2.zero, Mathf.Infinity, layerMask);
        Debug.Log(hits);
        if (hits.Length > 0)
        {
            return true; // Player is in sight
        }

        return false;
    }

    public void willStomp()
    {
        bossMovement.SetTrigger("willStomp");
    }
}
