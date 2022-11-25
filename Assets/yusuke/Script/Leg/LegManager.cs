using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{

    [SerializeField, Header("足の数")]
    List<GameObject> Legs;

    [SerializeField, Header("出す足をランダムに決める変数")]
    private int randnum;

    enum LegAttckType
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
        randnum = Random.Range(1, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        //RandNumCreate();
    }

    // Update is called once per frame
    void Update()
    {
        //legData = new LegData
        //{ type = LegAttckType.CONTINUE };

        //足攻撃データ毎の処理
        switch(legData.type)
        {
            case LegAttckType.RANDOM:
                {
                    RandNumCreate();
                }
                break;
        }
    }
}
