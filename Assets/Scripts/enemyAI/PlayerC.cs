using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerC : MonoBehaviour
{
    public static PlayerC Instance;

    public float speed = 5f;
    public GameObject bulletPre;
    Rigidbody2D rb;
    Animator anim;

    private void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 v2 = new Vector2(h, v);
        rb.MovePosition((Vector2)transform.position + v2 * speed * Time.deltaTime);

        // 设置不归零，使方向停留在UP、Right、Down、Left状态
        if (v2.magnitude > 0f)
        {
            anim.SetFloat("InputX", h);
            anim.SetFloat("InputY", v);
            anim.SetBool("isWalking", true);
        }else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Attack ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 pos = transform.position;
            Vector2 direction = (mousePos - pos).normalized;
            //GameObject bullet = Instantiate(bulletPre, pos, Quaternion.identity);
            GameObject bullet = ObjectPool.Instance.Get(bulletPre);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().SetSpeed(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
    }
}
