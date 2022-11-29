using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{

    [SerializeField, Header("足の数")]
    List<GameObject> Legs;

    [SerializeField, Header("出す足をランダムに決める変数")]
    private int randnum;

    public  bool randstop;//ランダム数生成中断

    public bool legreturned;//足が戻ってきた

    bool a=true;

    [Header("足を出す間隔時間")]
    public int legTime;


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
        randnum = Random.Range(0, 3);
        //a = true;
        randstop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        randstop = false;
        legreturned = true;
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
                    if(!randstop)
                    {
                        RandNumCreate();
                        Debug.Log("seisei");
                    }

                    if (legreturned)
                    {

                        Debug.Log("届いてるか");
                        Legs[randnum].GetComponent<Leg>().legdown = true;

                        legreturned = false;
                    }
                }
                break;
        }
    }

    public void LegTurned()
    {
        Legs[randnum].GetComponent<Leg>().phase = 1;
        if (a)
        {
            Debug.Log("くぁｗせｄｒｆｔｇｙふじこｌｐ");
            randstop = false;
           // legreturned = false;
            a = false;
        }


        Debug.Log("ハッピー");
    }
}
