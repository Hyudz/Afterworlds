using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balls : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private CircleCollider2D collider;
    private float direction;
    private Animator projectile;

    private void Awake()
    {
        collider = GetComponent<CircleCollider2D>();
        projectile = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        collider.enabled = false;
        projectile.SetTrigger("hit");
    }

    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        collider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
