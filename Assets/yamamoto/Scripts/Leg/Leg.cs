using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField,Header("足のリジッドボディ")]
    public Rigidbody2D rb;

    public Transform target;//足のTransformを持ってくる

    Vector2 legpos;//足の初期位置を入れる

    private float backleg_speed;//足の戻るスピード

    public bool legdown;//足を下す

    public bool legground;//足が地面についた

    // Start is called before the first frame update
    void Start()
    {
      
        backleg_speed = 0.1f;

        //FreezePositionYをオンにする
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
       

        legpos = target.transform.localPosition;//足の初期位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(legpos.y);
        //Debug.Log("x"+legpos.x);

        if (legdown)
        {
            rb.constraints = RigidbodyConstraints2D.None;
           
            Vector2 force = new Vector2(0.0f, -0.5f);//力を設定
            rb.AddForce(force, ForceMode2D.Force);  //力を加える
        }

       if(legground)
        {
            legdown = false;
           
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;

            // コルーチンの起動
            StartCoroutine(ReturnLeg());
        }

       
    }

    //降りてきた足を戻す
    IEnumerator ReturnLeg()
    {
        // 3秒間待つ
        yield return new WaitForSeconds(1.5f);

        legground = false;

        if (target.transform.position.y < legpos.y)
        {
            target.transform.localPosition = Vector2.MoveTowards(target.transform.localPosition, legpos, backleg_speed);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Debug.Log("下壁");
            legground = true;
        }
    }
}
