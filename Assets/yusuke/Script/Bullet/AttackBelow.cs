using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//敵の出現位置の種類
public enum RESPAWN_TYPE
{
    DOWN, //下
    SIZEOF, //敵の出現位置の数
}

public class AttackBelow : MonoBehaviour
{
    public Vector2 m_respawnPosInside; //敵の出現位置(内側)
    public Vector2 m_respawnPosOutside; //敵の出現位置(外側)

    private Vector3 m_direction; //進行方向

    private float Speed; //速度

    public Rigidbody2D rb;

    void Start()
    {
        
    }

    private void Update()
    {
        Vector2 force = new Vector2(0.0f, 8.5f);
        rb.AddForce(force, ForceMode2D.Force);

        //真っ直ぐ移動する
        transform.localPosition += m_direction * Speed;
    }

    //敵が出現するときに初期化する関数
    public void Init(RESPAWN_TYPE respawnType)
    {
        var pos = Vector3.zero;

        //指定された出現位置の種類に応じて
        //出現位置と進行方向を決定する
        switch(respawnType)
        {
            //出現位置が下の場合
            case RESPAWN_TYPE.DOWN:
                pos.x = Random.Range(
                    -m_respawnPosInside.x, m_respawnPosInside.x);
                pos.y = m_respawnPosOutside.y;
                m_direction = Vector2.up;
                break;
        }

        //位置を反映する
        transform.localPosition = pos;
    }
}
