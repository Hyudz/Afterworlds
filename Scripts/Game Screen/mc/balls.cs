using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private BoxCollider2D collider;
    private float direction;
    //private Animator projectile;

    private void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        //projectile = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MainCamera"))
        {
            // Do nothing when hitting camera bounds
            return;
        }

        hit = true;
        Debug.Log("hit:" + collision.name);
        collider.enabled = false;

        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<enemy_health>().TakeDmg(2);
        } else
        {
            //DO NOTHING
        }
        //projectile.SetTrigger("explode");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        collider.enabled = true;

        /*  float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
        */

        float newDirection = Mathf.Abs(transform.localScale.x) * _direction;

        transform.localScale = new Vector3(newDirection, transform.localScale.y, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
