using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject slash1;
    [SerializeField] private GameObject slash2;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack(slash1);
            StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 1f));
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Attack(slash2);
            StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 1f));
        }
    }

    private void Attack(GameObject slash)
    {
        slash.SetActive(true);

        //Mouse Direction = mouse Pos - current player pos 鼠标位置「目标点位置」-当前位置「人物所在位置」
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
