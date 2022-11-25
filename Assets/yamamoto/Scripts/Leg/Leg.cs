using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField,Header("���̃��W�b�h�{�f�B")]
    public Rigidbody2D rb;

    public Transform target;//����Transform�������Ă���

    Vector2 legpos;//���̏����ʒu������

    private float speed;//���̃X�s�[�h

    private float backleg_speed;//���̖߂�X�s�[�h

    public bool legdown;//��������

    public bool b;

    public bool c;

    // Start is called before the first frame update
    void Start()
    {
        speed = 0.5f;

        backleg_speed = 0.1f;

        //FreezePositionY���I���ɂ���
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
       

        legpos = target.transform.localPosition;//���̏����ʒu���擾
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(legpos.y);
        //Debug.Log("x"+legpos.x);

        if (legdown)
        {
            rb.constraints = RigidbodyConstraints2D.None;
           
            Vector2 force = new Vector2(0.0f, -0.5f);//�͂�ݒ�
            rb.AddForce(force, ForceMode2D.Force);  //�͂�������
        }

       if(b)
        {
            legdown = false;
           
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        }

       if(c)
        {
            b = false;
            if(target.transform.position.y < legpos.y)
            {
                target.transform.localPosition = Vector2.MoveTowards(target.transform.localPosition,legpos, backleg_speed);
            }
            
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Debug.Log("����");
            b = true;
        }
    }
}
