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

   // public bool legreturned;//足が初期位置に戻ってきた

    [SerializeField]
    public int phase = 1;//足アクションフェーズ

    public LegManager legManager;//レッグマネージャー

    // Start is called before the first frame update
    void Start()
    {
      
        backleg_speed = 0.1f;

        legManager.GetComponent<LegManager>();

        //legreturned = false;

        //FreezePositionYをオンにする
        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
       

        legpos = target.transform.localPosition;//足の初期位置を取得
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(legpos.y);
        //Debug.Log("x"+legpos.x);

        switch(phase)
        {
            case 1:
                if (legdown)
                {
                    //rb.constraints = RigidbodyConstraints2D.None;//リジッドボディのフリーズ解除

                    Vector2 force = new Vector2(0.0f, -0.5f);//力を設定
                    rb.AddForce(force, ForceMode2D.Force);  //力を加える

                    phase++;
                }
                break;
            case 2:
                if (legground)
                {
                    legdown = false;

                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;

                    // コルーチンの起動
                    StartCoroutine(ReturnLeg());

                    //phase++;
                }
                break;
            case 3:
                //Debug.Log("あｗｗｗ");
                legManager.LegTurned();
               // phase = 0;
                break;

        }
    }

    //降りてきた足を戻す
    IEnumerator ReturnLeg()
    {
        Debug.Log("ああああああ");
        // 3秒間待つ
        yield return new WaitForSeconds(1.5f);

        legground = false;

        if (target.transform.position.y < legpos.y)
        {
            target.transform.localPosition = Vector2.MoveTowards(target.transform.localPosition, legpos, backleg_speed);

            if(target.transform.localPosition.y == legpos.y && !legManager.legreturned)
            {
                Debug.Log("uuuuuuuuuu");
                //legManager.legreturned = true;
                //FreezePositionYをオンにする
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                 phase = 3;
            }
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
