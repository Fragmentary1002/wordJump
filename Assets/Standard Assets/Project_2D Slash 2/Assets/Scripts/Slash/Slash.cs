using UnityEngine;

public abstract class Slash : MonoBehaviour
{
    [SerializeField] private float attackDamage;
    [SerializeField] private AudioSource hitAudio;
    public int id;

    public void EndAttack()
    {
        gameObject.SetActive(false);
    }

    protected abstract void effect(Enemy enemy);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("We have Hitted the Enemy!");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            hitAudio.Play();
            if (enemy.TakenDamage(attackDamage, id))
            {
                effect(enemy);
            }

            #region 击退效果 反方向移动，从角色中心点「当前位置」向敌人位置方向「目标点」移动
            Vector2 difference = other.transform.position - transform.position;
            other.transform.position = new Vector2(other.transform.position.x + difference.x / 2,
                                                   other.transform.position.y + difference.y / 2);
            #endregion
        }
    }
}
