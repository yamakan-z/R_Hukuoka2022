using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBom : MonoBehaviour
{

    [System.Serializable]
    struct ShotData//弾のデータ
    {
        [Header("発射フレーム数（弾の発射間隔）")]
        public int frame;
        [Header("弾プレハブを持ってくる")]
        public Bullet bullet;
        [SerializeField, Header("弾を発射する回数")]
        public int bullet_count;
    }

    [SerializeField, Header("ランダム発射開始時間")]
    private float r_time;

    // ショットデータの初期化
    [SerializeField]
    ShotData shotData = new ShotData { frame = 60,bullet = null, bullet_count = 1 };

    int shotFrame = 0;              // フレーム

    private int count = 0;//弾の生成回数をカウント

    bool g_stop = false;//弾の生成を止める



    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    //ランダムに弾発射時間を決める
    public void RandNumCreate()
    {
        r_time = Random.Range(1, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandNumCreate();
        // SpriteのSpriteRendererコンポーネントを取得
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!g_stop)
            Shot();
    }

    void Shot()
    {
        //Rigidbodyを取得
        var rb = GetComponent<Rigidbody>();

        r_time -= Time.deltaTime;

        ++shotFrame;
        if (r_time<0)
        {
           
            if (shotFrame > shotData.frame)
            {
                Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );

                //各散弾を出す
                for (int i = 30; i < 360; i += 30)
                {
                    //FreezePositionYをオンにする
                    rb.constraints = RigidbodyConstraints.FreezePositionY;
                    sr.sprite = null;//水風船の画像を見えないようにする
                    Debug.Log("出す");
                    bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                    bullet.SetMoveVec(Quaternion.AngleAxis(i, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                }

                count++;

                if (count == shotData.bullet_count)
                {
                    Debug.Log("????");
                    Destroy(this.gameObject);//弾を出し切ったら削除
                    //g_stop = true;
                }
                shotFrame = 0;
            }
        }

        

       
    }
}
