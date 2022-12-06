using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    [SerializeField,Header("���̃��W�b�h�{�f�B")]
    public Rigidbody2D rb;

    public Transform target;//����Transform�������Ă���

    Vector2 legpos;//���̏����ʒu������

    private float backleg_speed;//���̖߂�X�s�[�h

    public bool legdown;//��������

    public bool legground;//�����n�ʂɂ���

   // public bool legreturned;//���������ʒu�ɖ߂��Ă���

    [SerializeField]
    public int phase = 1;//���A�N�V�����t�F�[�Y

    public LegManager legManager;//���b�O�}�l�[�W���[

    // Start is called before the first frame update
    void Start()
    {
      
        backleg_speed = 0.1f;

        legManager.GetComponent<LegManager>();

        //legreturned = false;

        //FreezePositionY���I���ɂ���
        //rb.constraints = RigidbodyConstraints2D.FreezePositionY;
       

        legpos = target.transform.localPosition;//���̏����ʒu���擾
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
                    //rb.constraints = RigidbodyConstraints2D.None;//���W�b�h�{�f�B�̃t���[�Y����

                    Vector2 force = new Vector2(0.0f, -0.5f);//�͂�ݒ�
                    rb.AddForce(force, ForceMode2D.Force);  //�͂�������

                    phase++;
                }
                break;
            case 2:
                if (legground)
                {
                    legdown = false;

                    rb.constraints = RigidbodyConstraints2D.FreezePositionY;

                    // �R���[�`���̋N��
                    StartCoroutine(ReturnLeg());

                    //phase++;
                }
                break;
            case 3:
                //Debug.Log("��������");
                legManager.LegTurned();
               // phase = 0;
                break;

        }
    }

    //�~��Ă�������߂�
    IEnumerator ReturnLeg()
    {
        Debug.Log("������������");
        // 3�b�ԑ҂�
        yield return new WaitForSeconds(1.5f);

        legground = false;

        if (target.transform.position.y < legpos.y)
        {
            target.transform.localPosition = Vector2.MoveTowards(target.transform.localPosition, legpos, backleg_speed);

            if(target.transform.localPosition.y == legpos.y && !legManager.legreturned)
            {
                Debug.Log("uuuuuuuuuu");
                //legManager.legreturned = true;
                //FreezePositionY���I���ɂ���
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                 phase = 3;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            Debug.Log("����");
            legground = true;
        }
    }

}
