using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLeg : MonoBehaviour
{
    [SerializeField, Header("足のリジッドボディ")]
    public Rigidbody2D rb;

    [SerializeField, Header("足マネージャー")]
    private GameObject LegManager;

    private bool legback;//足を戻す

    // Start is called before the first frame update
    void Start()
    {
        LegManager = GameObject.Find("LegManager");//足マネージャーを探して取得
    }

    // Update is called once per frame
    void Update()
    {
        //足を戻す
        if(legback)
        {
            transform.Translate(Vector2.up * 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            //下の壁に当たったらそこに停止する
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("下壁");

            // コルーチンの起動
            StartCoroutine(ReturnLeg());
        }

        if (collision.gameObject.tag == "DeleteArea")
        {
            // Debug.Log("削除エリアと接触した！");
            LegManager.GetComponent<LegGenerationlocation>().LegCreate();
            Destroy(this.gameObject);//足削除
        }
    }


    IEnumerator ReturnLeg()
    {
        //待つ
        yield return new WaitForSeconds(1.5f);
        legback = true;
    }
}
