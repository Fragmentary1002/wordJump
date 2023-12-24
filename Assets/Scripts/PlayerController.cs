// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class PlayerController : MonoBehaviour
// {
//     public GameObject life1, life2, life3;
//     public int life = 3;
//     public int jumpforce;
//     public LayerMask ground;//获取地面信息
//     public Collider2D coll;
//     [Space]
//     public int Max_HP ;
//     public int HP ;
//     public bool play_ing_flag=false;
//     // public bool play_ground_flag=false;
//     public int duration=2;
//     [Space]
//     public static PlayerController Instance;
//     [Space]
//     private Rigidbody2D rb;
//     private Animator anim;

// //     // Start is called before the first frame update
//     void Start()
//     {
//         Instance = this;
//         rb = GetComponent<Rigidbody2D>();
//         anim = GetComponent<Animator>();
//         HP=Max_HP;
//     }

//     void FixedUpdate()
//     {
//         // SwitchAnim();
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         //碰到敌人的时候
//         if(collision.gameObject.tag == "Enemy")
//         {   
//             //  int layer = LayerMask.NameToLayer("Ground");
//             AnimatorStateInfo stateinfo = anim.GetCurrentAnimatorStateInfo(0);
//             play_ing_flag = stateinfo.IsName("Fall");
//             //如果是下落状态
//             if (play_ing_flag==true)
//             {
//                 //敌人才会消失
//                 Debug.Log("fall");
//                 Destroy(collision.gameObject);
//                 //踩完后垫着敌人小跳一下
//                 // rb.velocity = new Vector2(rb.velocity.x, jumpforce * Time.deltaTime);
//                 // anim.SetBool("isJumping", true);
//                 play_ing_flag=false;
//             }
//             // 否则，如果在左侧碰到敌人
//             // else if(transform.position.x < collision.transform.position.x)
//             // {
//             //     //向左反弹
//             //     rb.velocity = new Vector2(-6, rb.velocity.y);
//             //     // anim.SetBool("isHurt", true);
//             //     HP=HP-1;
//             //     // Invoke(nameof(MethodName), duration);

//             // }
//             // //右侧同理
//             // else if (transform.position.x > collision.transform.position.x)
//             // {
//             //     // anim.SetBool("isHurt", true);
//             //     //向右反弹
//             //     rb.velocity = new Vector2(6, rb.velocity.y);
//             //     HP=HP-1;
//             //     // Invoke(nameof(MethodName), duration);
//             // }
//             else {
//                 Instantiate(GameObject.Find("bloodEffect"),new Vector3(transform.position.x, transform.position.y, transform.position.z),new Quaternion(0,0,0,0));
//                 StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 5f));
//                 life--;
//                 Life();
//             }
//         }
        
        
//         }
// public void Life (){
//         if (life == 3)
//         {
//             life3.SetActive(true);
//             life2.SetActive(true); 
//             life1.SetActive(true);
//         }
//         if(life==2)
//         {
//             life3.SetActive(false); 
//             life2.SetActive(true); 
//             life1.SetActive(true);
//         }
//         if(life==1)
//         {
//             life3.SetActive(false); life2.SetActive(false); life1.SetActive(true);
//         }
//         if(life<1)
//         {
//             life3.SetActive(false); life2.SetActive(false); life1.SetActive(false);
//         }
//     }
// }

