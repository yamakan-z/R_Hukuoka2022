using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunMove : MonoBehaviour
{
    [SerializeField, Header("�ړ���")]
    private float move;

    private Vector2 pos;//���S�C�̍��W

    private Vector2 gunspot_pos;//���S�n�_�̍��W

    [SerializeField]
    private bool movelock;//�㉺�ړ������Ȃ�

    [Header("���S�C�̈ʒu")]
    public bool left;

    public bool right;

    public bool back;

    public GameObject Gunspot;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;

        gunspot_pos = Gunspot.transform.position;

        movelock = true;

        left = false;

        right = false;
    }


    // Update is called once per frame
    void Update()
    {
       
        //�}�b�v�̒��SY�F2
        if(!movelock)
        {
            transform.position = new Vector2(pos.x, Mathf.Sin(Time.time) * move + pos.y);
        }
        else
        {
            //���S�C�����̎�
            if( left && transform.localPosition.y < 2.0f)
            {
                transform.Translate(Vector2.up * 0.05f);
            }
            //�E�̎�
            else if (right && transform.localPosition.y > 2.0f)
            {
                //Debug.Log("�Ƃ܂�");
                transform.Translate(Vector2.up * -0.05f);
            }


        }
    }

    //�����蔻��i�g���K�[�j
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.gameObject.tag == "Gunspot")
        {
            Invoke("movestart", 2.0f);
            Debug.Log("�ڐG�����I");
        }
    }

    //�ړ��J�n
    void movestart()
    {
        Debug.Log("kaisi");
        pos = gunspot_pos;
        //movelock = false;
    }

}
