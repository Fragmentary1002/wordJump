using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosInfo
{
    public int x;
    public int y;
    public int type;
    public void SetInfo(int x, int y ,int type)
    {
        this.x = x;
        this.y = y;
        this.type = type;
    }
}

public class MapC : MonoBehaviour
{
    public GameObject superWallPre, wallPre;
    // 地图：0为空，1为超级墙，2为墙
    int[,] map;
    List<PosInfo> nullPosList = new List<PosInfo>();
    private GameObject mapNode = null;
    public void Init(int x, int y)
    {
        map = new int[x, y];
        CreateMap();
        //CreateRandomPre(wallPre, 10);
    }

    void CreateMap()
    {
        int x = map.GetLength(0);
        int y = map.GetLength(1);
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                if(i == 0 || j == 0 || i == x-1 || j == y - 1)
                {
                    CreatePre(superWallPre, new Vector2(i, j));
                    map[i, j] = 1;
                }else
                {
                    if(i == 1 && j == 1)
                    {
                        continue;
                    }
                    map[i, j] = 0;
                    PosInfo info = new PosInfo();
                    info.SetInfo(i, j, 2);
                    nullPosList.Add(info);
                }
            }
        }
    }

    void CreatePre(GameObject pre, Vector2 pos)
    {
        if(mapNode == null)
        {
            mapNode = new GameObject("Map");
        }
        GameObject obj = Instantiate(pre, pos,Quaternion.identity, mapNode.transform);
        obj.name = pos.x + "_" + pos.y;
    }

    void CreateRandomPre(GameObject pre,int num)
    {
        for (int i = 0; i < num; i++)
        {
            int index = Random.Range(0, nullPosList.Count);
            PosInfo info = nullPosList[index];
            CreatePre(pre, new Vector2(info.x, info.y));
            map[info.x, info.y] = info.type;
            nullPosList.RemoveAt(index);
        }
    }

    public Vector2 GetNullPos()
    {
        int index = Random.Range(0, nullPosList.Count);
        PosInfo info = nullPosList[index];
        return new Vector2(info.x, info.y);
    }
}
