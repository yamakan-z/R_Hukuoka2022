using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegGenerationlocation : MonoBehaviour
{

    [SerializeField, Header("足の生成場所")]
    List<GameObject> Legs;

    [SerializeField, Header("生成する足")]
    private GameObject CreateReg;

    [SerializeField, Header("出す足をランダムに決める変数")]
    private int randnum;

    [Header("足生成開始時間")]
    public float start_time;

    [SerializeField]
    private float time;//時間カウント

    private bool g_flag;//生成を確認する

    enum LegAttckType//足の攻撃方法
    {
        NONE = 0,
        RANDOM,
        CONTINUE,
    }

    [System.Serializable]
    struct LegData//足のデータ
    {
        [Header("足の攻撃タイプ選択")]
        public LegAttckType type;
    }

    [SerializeField]
    LegData legData = new LegData
    { type = LegAttckType.NONE };

    //ランダムに数字生成
    public void RandNumCreate()
    {
        randnum = Random.Range(0, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandNumCreate();
    }

    // Update is called once per frame
    void Update()
    {
        time = time + Time.deltaTime;//生成開始時間を数える

        //初回のみここで処理を行う
        if(time > start_time)
        {
            //足の生成が許可されていれば生成
            if (!g_flag)
                LegCreate();
        }
    }

    public void LegCreate()
    {
        Debug.Log("生成");
        //足攻撃データ毎の処理
        switch (legData.type)
        {
            case LegAttckType.RANDOM:
                {
                    g_flag = true;//足の出現を中断する
                    // GameObjectを上記で決まったランダムな場所に生成
                    Instantiate(CreateReg, Legs[randnum].transform.position, Quaternion.identity);
                    RandNumCreate();//出現場所の再設定
                }
                break;
        }
    }



}
