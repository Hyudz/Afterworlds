using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_movement : MonoBehaviour
{
    public FixedJoystick Joystick;
    Rigidbody2D character;
    Vector2 movement;
    public Animator character_animation;
    float horizontal_movement;
    float vertical_movement;
    public Levelup_system levelup;
    public sceneInfo sceneinfo;

    public void Start()
    {
        character = GetComponent<Rigidbody2D>();
        character_animation = GetComponent<Animator>();
        Time.timeScale = 1.0f;
    }

    public void FixedUpdate()
    {
        movement.x = Joystick.Horizontal;
        movement.y = Joystick.Vertical;

        //movement_Speed += levelup.movementSpeed;

        character.MovePosition(character.position + movement * sceneinfo.movementSpeed * Time.deltaTime);
        horizontal_movement = movement.x;
        character.velocity = new Vector2 (horizontal_movement * sceneinfo.movementSpeed, character.velocity.y);
        character_animation.SetBool("run", Joystick.Horizontal != 0);

        // Move right
        if (horizontal_movement > 0.01f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
        // Move left
        else if (horizontal_movement < -0.01f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        }
    }
}
