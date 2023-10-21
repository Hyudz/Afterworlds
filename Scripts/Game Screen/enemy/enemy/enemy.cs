using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{

    Transform player;
    //private Transform character;
    public float movement_speed;
    public Animator enemy_animation;
    public bool flip;
    // Start is called before the first frame update
    void Start()
    {

        //grab references
        player = FindAnyObjectByType<character_movement>().transform;
        enemy_animation = GetComponent<Animator>();
        //character = FindAnyObjectByType<character_movement>();
    }

    // Update is called once per frame
    void Update()
    {

        //eto yung sa movement ng enemies

        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movement_speed * Time.deltaTime);
        } else
        {
            //stop moving
        }
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
        }
        catch
        {
            //DO NOTHING
        }

    }

}
