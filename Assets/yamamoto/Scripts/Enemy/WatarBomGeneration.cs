using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatarBomGeneration : MonoBehaviour
{
    [SerializeField,Header("生成する水風船")]
    private GameObject[] CreateWaterBom;

    [SerializeField]
    [Tooltip("生成する範囲A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("生成する範囲B")]
    private Transform rangeB;

    // 経過時間
    private float time;

    [SerializeField]
    private int waterbom_level;//水爆弾の弾レベル(レベルが上昇すると弾数の多い水爆弾も生成される）

    [SerializeField]
    private float gimmick_time;//ギミック発動時間

    [SerializeField, Header("水風船が生成される時間")]
    private float g_time;

    [SerializeField]
    private int rand;//ランダムに生成する水爆弾の種類を選ぶ

    private bool randstop;//ランダム生成中止

    private bool stop;//一回だけの処理

    public void randnum()
    {
        //水風船レベルに応じて出す数を変化させる
        if(waterbom_level == 2)
        {
            rand = Random.Range(0, 2);
        }
        else if(waterbom_level == 3)
        {
            rand = Random.Range(0, 3);
        }
        randstop = true;
    }

    //生成時間を変更する
    public void GenerationTime()
    {
        //一定時間経過すると水風船の生成速度変更
        if (gimmick_time > 30.0f && !stop)
        {
            g_time = g_time / 2;
            stop = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        waterbom_level = 1;
        randstop = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 前フレームからの時間を加算していく
        time = time + Time.deltaTime;

        //ギミック発動タイムも加算していく
        gimmick_time = gimmick_time + Time.deltaTime;

        GenerationTime();//生成時間を変更する

        //時間経過で水風船レベル上昇
        //レベル1→レベル2
        if (gimmick_time > 10.0f)
        {
            waterbom_level = 2;
        }
        //レベル2→レベル3
        if (gimmick_time > 20.0f && waterbom_level == 2)
        {
            waterbom_level = 3;
        }

       // Debug.Log(gimmick_time);

        // 設定した時間ごとにランダムに生成されるようにする。
        if (time > g_time)
        {
            if(waterbom_level == 1)
            {
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(CreateWaterBom[0], new Vector2(x, y), CreateWaterBom[0].transform.rotation);
                // 経過時間リセット
                time = 0f;
            }
            else if (waterbom_level > 1)
            {
               // Debug.Log("ss");
                if(!randstop)
                {
                    randnum();//ランダム数字生成
                }
                
                // rangeAとrangeBのx座標の範囲内でランダムな数値を作成
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeAとrangeBのy座標の範囲内でランダムな数値を作成
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                // GameObjectを上記で決まったランダムな場所に生成
                Instantiate(CreateWaterBom[rand], new Vector2(x, y), CreateWaterBom[rand].transform.rotation);

                // 経過時間リセット
                time = 0f;
                //ランダム中止処理解除
                randstop = false;
            }



        }
    }
}
