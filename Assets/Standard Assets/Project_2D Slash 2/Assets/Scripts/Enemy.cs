using UnityEngine;
using System.Collections.Generic;

public class Enemy : MonoBehaviour, IPrototype
{
    static Dictionary<char, Sprite> CharactorSprite; // 字符对应的Sprite字典
    [SerializeField] private SpriteRenderer charRenderer; // 字符渲染对象
    public char Character { get; private set; }
    [SerializeField] private float moveSpeed;
    private Transform target;
    [SerializeField] private float maxHp;
    public float hp;

    [Header("Hurt")]
    private SpriteRenderer sp;
    public float hurtLength;//MARKER 效果持续多久
    private float hurtCounter;//MARKER 相当于计数器

    private void Start()
    {
        LoadCharactorSprite();
        hp = maxHp;
        // target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        // FollowPlayer();

        // hurtCounter -= Time.deltaTime;
        // if (hurtCounter <= 0)
        //     sp.material.SetFloat("_FlashAmount", 0);
    }
    //去功能
    private void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    public bool TakenDamage(float _amount, int slashId)
    {
        if (!WordManager.Instance.isTarget(Character, slashId))
        {
            Debug.Log($"Not char {Character}!");
            PlayerController.Instance.HitWrong();
            return false;
        }

        Debug.Log($"Enemy {Character} hurt!");
        hp -= _amount;
        HurtShader();
        if (hp <= 0)
        {
            EnemyManager.Instance.KillEnemy(this);
            return true;
        }

        return false;
    }

    public void Death()
    {
        Debug.Log($"Enemy {Character} Death!");
        // WordManager.Instance.NextChar(Character);
        Destroy(gameObject);
    }

    private void HurtShader()
    {
        sp.material.SetFloat("_FlashAmount", 1);
        hurtCounter = hurtLength;
    }


    /// <summary>
    /// 克隆敌人对象
    /// </summary>
    /// <param name="Character">标识字符</param>
    /// <returns></returns>
    public GameObject Clone(char Character)
    {
        return Clone(Character, true);
    }
    /// <summary>
    /// 克隆敌人对象
    /// </summary>
    /// <param name="Character">标识字符</param>
    /// <param name="active">默认激活状态</param>
    /// <returns></returns>
    public GameObject Clone(char Character, bool active)
    {
        LoadCharactorSprite();
        GameObject obj = Instantiate<GameObject>(this.gameObject);
        obj.GetComponent<Enemy>().Character = Character;
        obj.GetComponent<Enemy>().charRenderer.sprite = CharactorSprite[Character];
        EnemyManager.Instance.AddEnemy(obj.GetComponent<Enemy>());
        obj.SetActive(active);
        return obj;
    }

    /// <summary>
    /// 加载字符资源
    /// </summary>
    /// <returns></returns>
    static void LoadCharactorSprite()
    {
        if (CharactorSprite != null) // 仅初始化一次
            return;

        CharactorSprite = new Dictionary<char, Sprite>();
        for (char c = 'A'; c <= 'Z'; c++)
        {
            CharactorSprite[c] = Resources.Load<Sprite>("CharacterImages/" + c);
            if (CharactorSprite[c] == null)
            {
                Debug.LogError("无法加载图片");
            }
        }
        return;
    }
}

/// <summary>
/// 原型模式，克隆自身
/// </summary>
public interface IPrototype
{
    GameObject Clone(char Character);
    GameObject Clone(char Character, bool active);
}