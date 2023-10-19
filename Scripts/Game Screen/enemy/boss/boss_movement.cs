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
    public boss_attack bossAtk;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //bossMovement.SetTrigger("willStomp");

        if (PlayerInSight() == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, 130 * Time.deltaTime);
        }

        bossMovement.SetBool("isWalking", currentPos != transform.position.x);
        currentPos = transform.position.x;

        
        //enemy_animation.SetBool("walk", true);

        Vector3 scale = transform.localScale;
        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        { 
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
       
        }
        transform.localScale = scale;
    }

    public bool PlayerInSight()
    {
        LayerMask layerMask = LayerMask.GetMask("MainCamera", "Enemy");
        layerMask = ~layerMask;

        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, new Vector2(bossAtk.detectionWidth, bossAtk.detectionHeight), 0f, Vector2.zero, Mathf.Infinity, layerMask);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider != null)
            {

            }
        }
        return hits.Length > 0;
    }

    public void willStomp()
    {
        bossMovement.SetTrigger("willStomp");
    }
}
