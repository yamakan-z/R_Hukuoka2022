using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] float moveSpeed = 3.0f;                   // �ړ��l
    [SerializeField] Vector3 moveVec = new Vector3(-1, 0, 0);  // �ړ�����

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

    //�ړ�����
    public void SetMoveVec(Vector3 _vec)
    {
        moveVec = _vec.normalized;//���K��
    }

    //�����蔻��i�g���K�[�j
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("�v���C���[�ƐڐG�����I");
            Destroy(this.gameObject);//�e�폜
        }

        if (collision.gameObject.tag == "DeleteArea")
        {
           // Debug.Log("�폜�G���A�ƐڐG�����I");
            Destroy(this.gameObject);//�e�폜
        }
    }

}
