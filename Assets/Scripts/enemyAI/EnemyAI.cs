using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// https://www.bilibili.com/video/BV1Yd4y1c7kG/?spm_id_from=333.880.my_history.page.click&vd_source=d19e47552f1614194f0d0b0662850083
public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;

    public float speed = 1;
    Vector2 direction = Vector2.zero;

    const float defaultDirectionTime = 3f;
    public float directionTime = defaultDirectionTime;

    const float defaultChangeDirectionTime = 0.2f;
    public float changeDirectionTime = 0.2f;

    const float defaultAttackedTime = 3f;
    public float attackedTime = 0f;

    Vector2 playerPos;
    public float range = 3f;
    public float distance = 0f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        SetRandomDirection();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        // if(collision.gameObject.CompareTag("Wall") && changeDirectionTime <= 0)
        if( collision.gameObject.layer==LayerMask.NameToLayer("Wall")&&changeDirectionTime <= 0)
        {
            direction = -direction;
            changeDirectionTime = defaultChangeDirectionTime;
        }
    }

    // private void OnTriggerEnter2D(Collider2D collision)
    // {
    //     if (collision.CompareTag("Bullet"))
    //     {
    //         attackedTime = defaultAttackedTime;
    //     }
    // }

    void SetRandomDirection ()
    {
        direction = Utils.GetRandomVector();
    }

    private void FixedUpdate()
    {
        GetDistance();
        // SetAnim();
        if (distance <= range || attackedTime > 0)
        {
            FollowPlayer();
        }
        else
        {
            Walk();
        }

        if (changeDirectionTime > 0)
        {
            changeDirectionTime -= Time.deltaTime;
        }
    }

    void GetDistance()
    {
        if (PlayerController.Instance != null)
        {
            GameObject player = PlayerController.Instance.gameObject;
            playerPos = player.transform.position;
            distance = (playerPos - (Vector2)transform.position).magnitude;
        }
    }

    // void SetAnim ()
    // {
    //     if (direction.magnitude > 0f)
    //     {
    //         anim.SetFloat("InputX", direction.x);
    //         anim.SetFloat("InputY", direction.y);
    //         anim.SetBool("isWalking", true);
    //     }
    //     else
    //     {
    //         anim.SetBool("isWalking", false);
    //     }
    // }

    void FollowPlayer ()
    {
        // Debug.log('FollowPlayer');
        if (attackedTime > 0)
        {
            attackedTime -= Time.deltaTime;
        }
        direction = (playerPos - (Vector2)transform.position).normalized;
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    void Walk()
    {
        if (directionTime > 0)
        {
            directionTime -= Time.deltaTime;
        }
        else
        {
            SetRandomDirection();
            directionTime = defaultDirectionTime;
        }
        rb.MovePosition((Vector2)transform.position + direction * speed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + (Vector3)direction);
    }
}
