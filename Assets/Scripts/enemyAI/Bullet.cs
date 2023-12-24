using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb;

    float speed = 8f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetSpeed(Vector2 direction)
    {
        rb.velocity = direction * speed;
        StartCoroutine(DestroyObj(3f));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            ObjectPool.Instance.Push (gameObject);
        }
    }

    IEnumerator DestroyObj(float time)
    {
        yield return new WaitForSeconds(time);

        //Destroy(gameObject);
        ObjectPool.Instance.Push (gameObject);
    }
}
