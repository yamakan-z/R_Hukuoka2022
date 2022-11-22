using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{

    enum ShotType//弾の種類
    {
        NONE = 0,
        NOMAL,          //一発づつ弾を発射する
        AIM,            // プレイヤーを狙う
        DIFFUSION,      //360度拡散
    }

    [System.Serializable]
    struct ShotData//弾のデータ
    {
        [Header("発射フレーム数（弾の発射間隔）")]
        public int frame;
        [Header("弾の発射タイプ選択")]
        public ShotType type;
        [Header("弾プレハブを持ってくる")]
        public Bullet bullet;
        [SerializeField, Header("弾を発射する回数")]
        public int bullet_count;
    }

    // ショットデータの初期化
    [SerializeField] 
    ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null,bullet_count = 1};

    GameObject player = null;       // プレイヤーオブジェクト
    int shotFrame = 0;              // フレーム

    private int count = 0;//弾の生成回数をカウント

    bool g_stop=false;//弾の生成を止める

    // Start is called before the first frame update
    void Start()
    {
        // 追従弾設定の時、プレイヤーオブジェクトを取得する
        switch (shotData.type)
        {
            case ShotType.AIM:
                player = GameObject.Find("Player");
                break;
        }

        Shot();
    }

    // Update is called once per frame
    void Update()
    {
        if(!g_stop)
        Shot();
    }

    // ショット処理（これをUpdateなどで呼ぶ）
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                //1発づつ撃つ
                case ShotType.NOMAL:
                    {
                        Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );
                        bullet.SetMoveVec(transform.position*-1);
                    }
                    break;
                // プレイヤーを狙う
                case ShotType.AIM:
                    {
                        if (player == null) { break; }
                        Bullet bullet = (Bullet)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet.SetMoveVec(player.transform.position - transform.position);
                    }
                    break;

                // 360度方向の12発撃つ 
                case ShotType.DIFFUSION:
                    {

                        Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );

                        //各散弾を出す
                        for (int i = 30; i < 360; i += 30)
                        {
                            Debug.Log("出す");
                            bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                            bullet.SetMoveVec(Quaternion.AngleAxis(i, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        }

                        count++;

                        if(count == shotData.bullet_count)
                        {
                            Debug.Log("????");
                            g_stop = true;
                            break;
                        }

                    }
                    break;
            }

            shotFrame = 0;
        }

       
    }
}
