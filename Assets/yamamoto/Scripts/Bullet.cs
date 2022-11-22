using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3.0f;                   // 移動値
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);  // 移動方向

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float add_move = moveSpeed * Time.deltaTime;
        transform.Translate(moveVec * add_move);
    }

    public void SetMoveSpeed(float _speed)
    {
        moveSpeed = _speed;
    }

    //移動方向
    public void SetMoveVec(Vector3 _vec)
    {
        moveVec = _vec.normalized;//正規化
    }

    //当たり判定（トリガー）
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("プレイヤーと接触した！");
            Destroy(this.gameObject);//弾削除
        }

        if (collision.gameObject.tag == "DeleteArea")
        {
           // Debug.Log("削除エリアと接触した！");
            Destroy(this.gameObject);//弾削除
        }
    }

}
