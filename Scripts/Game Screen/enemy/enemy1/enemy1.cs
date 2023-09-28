using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy1 : MonoBehaviour
{

    Transform player;
    public float movement_speed;
    // Start is called before the first frame update
    void Start()
    {
        player = FindAnyObjectByType<character_movement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movement_speed * Time.deltaTime);
    }
}
