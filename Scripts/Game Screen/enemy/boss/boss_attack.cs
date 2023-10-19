using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_attack : MonoBehaviour
{
    public Animator punch;
    public Animator multiPunch;
    public Animator stomp;
    public Animator clap;
    public Animator clap1;
    public boss_movement boss_Movement;
    public bool inRange = false;
    public float detectionWidth;
    [SerializeField] private LayerMask playerLayer;
    public float detectionHeight;

    public float atk1Cd;
    public Transform handClap;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }

    // Update is called once per frame
    void Update()
    {
        atk1Cd += Time.deltaTime;

        /*if (PlayerInSight())
        {
            Debug.Log("this is working");
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                //enemy_animation.SetTrigger("attack");
                character_health.GetComponent<health>().TakeDmg(damage);
            }
        } */

        if (atk1Cd >= 5)
        {
            //StartCoroutine(StompoAttack());
            //StartCoroutine(punchAttack());
            //StartCoroutine(multipunchAttack());
            StartCoroutine(clapAttack());
        }

    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 gizmoPos;
        if (transform.localScale.x > 0) // Boss is facing right
        {
            gizmoPos = new Vector3(transform.position.x - 80, transform.position.y, transform.position.z);
        }
        else // Boss is facing left
        {
            gizmoPos = new Vector3(transform.position.x + 80, transform.position.y, transform.position.z);
        }

        Gizmos.DrawWireCube(gizmoPos, new Vector3(detectionWidth, detectionHeight, 0f));
    }

    private IEnumerator StompoAttack()
    {
        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(transform.position, new Vector2(detectionWidth, detectionHeight), playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
                if (character.CompareTag("Character"))
                {
                    atk1Cd = 0.0f;
                    boss_Movement.willStomp();
                    stomp.SetTrigger("stomp");
                    yield return new WaitForSeconds(0.5f);
                    character.GetComponent<health>().TakeDmg(0);
                StopCoroutine(StompoAttack());
                }
        }
    }

    private IEnumerator punchAttack()
    {
        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(transform.position, new Vector2(detectionWidth, detectionHeight), playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
            if (character.CompareTag("Character"))
            {
                atk1Cd = 0.0f;
                punch.SetTrigger("punch");
                yield return new WaitForSeconds(0.5f);
                character.GetComponent<health>().TakeDmg(0);
                StopCoroutine(punchAttack());
            }
        }
    }

    private IEnumerator multipunchAttack()
    {
        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(transform.position, new Vector2(detectionWidth, detectionHeight), playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
            if (character.CompareTag("Character"))
            {
                atk1Cd = 0.0f;
                multiPunch.SetTrigger("multiPunch");
                yield return new WaitForSeconds(0.5f);
                character.GetComponent<health>().TakeDmg(0);
                StopCoroutine(multipunchAttack());
            }
        }
    }

    private IEnumerator clapAttack()
    {
        Collider2D[] hitCharacter = Physics2D.OverlapBoxAll(transform.position, new Vector2(detectionWidth, detectionHeight), playerLayer);

        foreach (Collider2D character in hitCharacter)
        {
            if (character.CompareTag("Character"))
            {
                atk1Cd = 0.0f;
                clap.SetTrigger("clap");

                yield return new WaitForSeconds(0.55f);
                handClap.position = character.transform.position;
                clap1.SetTrigger("clap1");

                yield return new WaitForSeconds(0.55f);
                character.GetComponent<health>().TakeDmg(0);
                StopCoroutine(clapAttack());
            }
        }
    }
}
