using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;//プレイヤーの速さ

    [SerializeField] private int HP = 3;//プレイヤーのHP

    // デフォルトの画像(ノーダメージ時の画像)
    public Sprite defaultImage;
    // デフォルトの画像(一段階目ダメージの画像）
    public Sprite damageImage;
    // デフォルトの画像(二段階目ダメージの画像）
    public Sprite twosteps_damageImage;


    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    Vector2 PlayerSize;//プレイヤーオブジェクトの大きさを入れる変数

    void Start()
    {

        PlayerSize = gameObject.transform.localScale; //◆現在の大きさを代入

        // SpriteのSpriteRendererコンポーネントを取得
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        //--------------移動処理----------------------------
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;

        //-----------------------------------------------------

       
    }


    //当たり判定の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Debug.Log("壁と接触した！");
        }

        else if (collision.collider.tag == "Enemy")
        {
            Debug.Log("敵と接触した！");

            Damage();//ダメージ処理へ
        }
    }

    //当たり判定（トリガー）
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("敵と接触した！");

            Damage();//ダメージ処理へ
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public void Damage()
    {
        if (HP == 3)
        {
            //画像変更
            sr.sprite = damageImage;

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//変更する大きさを設定

            gameObject.transform.localScale = PlayerSize; //大きさ変更

            HP--;//ダメージ
        }
        else if (HP == 2)
        {
            //画像変更
            sr.sprite = twosteps_damageImage;

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//変更する大きさを設定

            gameObject.transform.localScale = PlayerSize; //大きさ変更


            HP--;
        }
        else if (HP == 1)
        {
            HP--;
            Debug.Log("死");
        }
    }


}

