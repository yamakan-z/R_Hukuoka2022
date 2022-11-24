using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField,Header("足のリジッドボディ")]
    public Rigidbody2D rb;

    public Transform target;//足のTransformを持ってくる

    Vector2 legpos;//足の初期位置を入れる

    private float speed;//足のスピード

    public bool a;

    public bool b;

    public bool c;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;
        //FreezePositionYをオンにする
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;

        legpos = target.transform.localPosition;//足の初期位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(legpos.y);
       if(a)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            Vector2 force = new Vector2(0.0f, -0.5f);//力を設定
            rb.AddForce(force, ForceMode2D.Force);  //力を加える
        }

       if(b)
        {
            a = false;
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

       if(c)
        {
            b = false;
            if(target.transform.position.y < legpos.y)
            {
                target.transform.position = new Vector2(legpos.x, legpos.y + speed);
            }
            
           // target.position = Vector2.MoveTowards(legpos, target.position, speed);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Debug.Log("下壁");
            b = true;
        }
    }
}
