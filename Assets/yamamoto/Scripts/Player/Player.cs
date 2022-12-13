using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;//プレイヤーの速さ

    public int HP = 3;//プレイヤーのHP

    // デフォルトの画像(ノーダメージ時の画像)
    public Sprite defaultImage;
    // デフォルトの画像(一段階目ダメージの画像）
    public Sprite damageImage;
    // デフォルトの画像(二段階目ダメージの画像）
    public Sprite twosteps_damageImage;

    public CountTime countTime;//時間カウントスクリプト

    //ダメージを受けたときの処理
    private bool isDamage;
    
    // 画像描画用のコンポーネント
    SpriteRenderer sr;

    Vector2 PlayerSize;//プレイヤーオブジェクトの大きさを入れる変数

    void Start()
    {

        PlayerSize = gameObject.transform.localScale; //◆現在の大きさを代入

        // SpriteのSpriteRendererコンポーネントを取得
        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        if(isDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 15));//点滅の速さ
            sr.color = new Color(1f, 1f, 1f, level);//プレイヤーを点滅
        }
      
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
    }

    //当たり判定（トリガー）
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.gameObject.tag == "Enemy"&&!isDamage)//無敵処理中は通さない
        {
            Debug.Log("敵と接触した！");

            isDamage = true;

            StartCoroutine(Damage());//ダメージ処理へ
        }
    }

    /// <summary>
    /// ダメージ処理
    /// </summary>
    public IEnumerator Damage()
    {
        if (HP == 3)
        {
            //画像変更
            sr.sprite = damageImage;

            GetComponent<AudioSource>().Play();//足音を鳴らす

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//変更する大きさを設定

            gameObject.transform.localScale = PlayerSize; //大きさ変更

            HP--;//ダメージ
        }
        else if (HP == 2)
        {
            //anim.Stop();

            //画像変更
            sr.sprite = twosteps_damageImage;

            GetComponent<AudioSource>().Play();//足音を鳴らす

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//変更する大きさを設定

            gameObject.transform.localScale = PlayerSize; //大きさ変更


            HP--;
        }
        else if (HP == 1)
        {
            HP--;

            PlayerPrefs.SetFloat("TEST", countTime.countup);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Result");
            Debug.Log("死");
        }

        //無敵処理
        yield return new WaitForSeconds(2.0f);

        // 通常状態に戻す
        isDamage = false;
        sr.color = new Color(1f, 1f, 1f, 1f);

    }
}

