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
    private List<string> bossAttacks = new List<string>();

    [Header("Attack Damage Values")]
    [SerializeField] public int punch_dmg;
    [SerializeField] public int multipunch_dmg;
    [SerializeField] public int stomp_dmg;
    [SerializeField] public int clap_dmg;

    // Start is called before the first frame update
    void Start()
    { 
        bossAttacks.Add("Stomp");
        bossAttacks.Add("Punch");
        bossAttacks.Add("Multi Punch");
        bossAttacks.Add("Clap");
    }

    // Update is called once per frame
    void Update()
    {
        atk1Cd += Time.deltaTime;

        if (atk1Cd >= 5)
        {

            int randAtk = Random.Range(0, bossAttacks.Count);

            if (randAtk == 0)
            {
                StartCoroutine(StompoAttack());
            } else if (randAtk == 1)
            {
                StartCoroutine(punchAttack());
            } else if (randAtk == 2)
            {
                StartCoroutine(multipunchAttack());
            } else if (randAtk == 3) {
                StartCoroutine(clapAttack());
            }
            
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
                    character.GetComponent<health>().TakeDmg(stomp_dmg);
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
                character.GetComponent<health>().TakeDmg(punch_dmg);
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
                character.GetComponent<health>().TakeDmg(multipunch_dmg);
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
                character.GetComponent<health>().TakeDmg(clap_dmg);
                StopCoroutine(clapAttack());
            }
        }
    }
}
