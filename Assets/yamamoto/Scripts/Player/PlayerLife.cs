using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //プレイヤーライフ（表示用）
    // デフォルトの画像
    public Sprite defaultImage;
    //ダメージを受けたときのライフ
    public Sprite damageImage;

    [Header("プレイヤースクリプト")]
    public Player player;

    [Header("ライフ番号")]
    public bool one;

    public bool two;

    public bool three;

    // 画像描画用のコンポーネント
    public Image image;
   
    // Start is called before the first frame update
    void Start()
    {
        // SpriteのSpriteRendererコンポーネントを取得
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.HP == 2)
        {
            if(three)
            {
                //画像変更
                image.sprite = damageImage;
            }
           
        }
        else if(player.HP == 1)
        {
            if (two)
            {
                //画像変更
                image.sprite = damageImage;
            }
        }
        else if (player.HP == 0)
        {
            if (one)
            {
                //画像変更
                image.sprite = damageImage;
            }
        }
    }
}
