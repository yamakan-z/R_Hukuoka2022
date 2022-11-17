using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{

    enum ShotType//弾の種類
    {
        NONE = 0,
        AIM,            // プレイヤーを狙う
        THREE_WAY,      // ３方向
    }

    [System.Serializable]
    struct ShotData//弾のデータ
    {
        public int frame;
        public ShotType type;
        public Bullet bullet;
    }

    // ショットデータの初期化
    [SerializeField] 
    ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

    GameObject player = null;       // プレイヤーオブジェクト
    int shotFrame = 0;              // フレーム


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
    }

    // Update is called once per frame
    void Update()
    {
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

                // ３方向
                case ShotType.THREE_WAY:
                    {
                        Bullet bullet = (Bullet)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                    }
                    break;
            }

            shotFrame = 0;
        }

       
    }
}
