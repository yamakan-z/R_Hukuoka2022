using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullet : MonoBehaviour
{
    public GameObject WoodPrefab;

    private float time; //経過時間

    private void Start()
    {
        
    }

    private void Update()
    {
        //前フレームからの時間を加算
        time = time + Time.deltaTime;

        if (time > 2.0f)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Instantiate(WoodPrefab, new Vector3(i * 1.2f, 0.5f, j * 1.2f), Quaternion.identity);
                }
            }

            //経過時間リセット
            time = 0f;
        }
    }
}
