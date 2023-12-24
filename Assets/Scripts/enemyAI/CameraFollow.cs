using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTf;
    // 地图尺寸
    int x, y;
    public void Init(Transform target, int x, int y)
    {
        playerTf = target;
        this.x = x;
        this.y = y;
    }
    private void OnCollisionEnter(Collision other)
    {
    
    }
    private void LateUpdate()
    {
        float x = Mathf.Lerp(transform.position.x, playerTf.position.x, 0.2f);
        float y = Mathf.Lerp(transform.position.y, playerTf.position.y, 0.2f);
        // 初始[0,0]坐标对应的屏幕坐标（单位：像素）
        Vector2 pxV2 = Camera.main.WorldToScreenPoint(new Vector2(0, 0));
        // 从初始[0,0]坐标开始，距离一整个屏幕的坐标（单位：像素）
        Vector2 screenV2 = new Vector2(Screen.width + pxV2.x, Screen.height + pxV2.y);
        // 把屏幕坐标转化为世界坐标（屏幕坐标单位是像素，不能在游戏里直接使用）
        Vector2 wpScreenV2 = Camera.main.ScreenToWorldPoint(screenV2);

        Vector3 cameraPos = new Vector3(0, 0, transform.position.z);


        // 屏幕比地图宽
        // 地图坐标从0开始计数，所以减1
        if (wpScreenV2.x > this.x - 1)
        {
            cameraPos.x = (this.x - 1) / 2f;
        }
        else
        {
            float minX = wpScreenV2.x / 2f;
            float maxX = this.x - 1 - minX;
            //cameraPos.x = x;
            cameraPos.x = Mathf.Clamp(x, minX, maxX);
        }

        // 屏幕比地图高
        if (wpScreenV2.y > this.y - 1)
        {
            cameraPos.y = (this.y - 1) / 2f;
        }
        else
        {
            float minY = wpScreenV2.y / 2f;
            float maxY = this.y - 1 - minY;
            //cameraPos.y = y;
            cameraPos.y = Mathf.Clamp(y, minY, maxY);
        }

        transform.position = cameraPos;
    }
}
