using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource hurtAudio;
    [SerializeField] private AudioSource walkAudio;
    public GameObject life1, life2, life3;
    public int life = 3;
    public int jumpforce;
    public LayerMask ground;//获取地面信息
    public Collider2D coll;
    [Space]
    public int Max_HP;
    public int HP;
    public bool play_ing_flag = false;
    // public bool play_ground_flag=false;
    public int duration = 2;
    [Space]
    bool hurtable = true;
    [SerializeField] private int hurtDamage = 1;
    [SerializeField] private float unhitableTime = 0.5f;
    [Space]
    public static PlayerController Instance;
    [Space]
    private Rigidbody2D rb;
    private Animator anim;

    //     // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        HP = Max_HP;
    }

    void FixedUpdate()
    {
        // SwitchAnim();
    }

    public void Hurt(int damage)
    {
        if (!hurtable)
            return;

        StartCoroutine(hurtCD());

        HP -= damage;
        hurtAudio.Play();
        Instantiate(GameObject.Find("bloodEffect"), new Vector3(transform.position.x, transform.position.y, transform.position.z), new Quaternion(0, 0, 0, 0));
        StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 5f));
        Life();
        if(HP <= 0)
        {
            death();
        }
    }

    private void death()
    {
        EndUI.Instance.Death();
    }

    public void HitWrong()
    {
        Hurt(hurtDamage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //碰到敌人的时候
        if (collision.gameObject.tag == "Enemy")
        {
            Hurt(hurtDamage);
        }
    }

    public void WalkAudio()
    {
        if(!walkAudio.isPlaying)
            walkAudio.Play();
    }

    private IEnumerator hurtCD()
    {
        hurtable = false;
        yield return new WaitForSeconds(unhitableTime);
        hurtable = true;
    }

    public void Life()
    {
        if (HP == 3)
        {
            life3.SetActive(true);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        if (HP == 2)
        {
            life3.SetActive(false);
            life2.SetActive(true);
            life1.SetActive(true);
        }
        if (HP == 1)
        {
            life3.SetActive(false); life2.SetActive(false); life1.SetActive(true);
        }
        if (HP < 1)
        {
            life3.SetActive(false); life2.SetActive(false); life1.SetActive(false);
        }
    }
}

