using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    //public GameObject Wood;

    [SerializeField]
    [Tooltip("生成するGameObject")]
    private GameObject createPrefab;
    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    //経過時間
    private float time;

    private void Update()
    {
        //Instantiate(Wood);

        //前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        //約3秒おきにランダムに生成されるようにする
        if(time>2.0f)
        {
            for (int i = 0; i < 4; i++)
            {
                //rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                //rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                //GameObjectを上記で決まったランダムな場所に生成
                Instantiate(createPrefab, new Vector2(x, y), createPrefab.transform.rotation);

            }

            //経過時間リセット
            time = 0f;
        }
    }
}
