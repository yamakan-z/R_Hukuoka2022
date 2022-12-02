using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatarBomGeneration : MonoBehaviour
{
    [SerializeField,Header("�������鐅���D")]
    private GameObject[] CreateWaterBom;

    [SerializeField]
    [Tooltip("��������͈�A")]
    private Transform rangeA;
    [SerializeField]
    [Tooltip("��������͈�B")]
    private Transform rangeB;

    // �o�ߎ���
    private float time;

    [SerializeField]
    private int waterbom_level;//�����e�̒e���x��(���x�����㏸����ƒe���̑��������e�����������j

    [SerializeField]
    private float gimmick_time;//�M�~�b�N��������

    [SerializeField, Header("�����D����������鎞��")]
    private float g_time;

    [SerializeField]
    private int rand;//�����_���ɐ������鐅���e�̎�ނ�I��

    private bool randstop;//�����_���������~

    private bool stop;//��񂾂��̏���

    public void randnum()
    {
        //�����D���x���ɉ����ďo������ω�������
        if(waterbom_level == 2)
        {
            rand = Random.Range(0, 2);
        }
        else if(waterbom_level == 3)
        {
            rand = Random.Range(0, 3);
        }
        randstop = true;
    }

    //�������Ԃ�ύX����
    public void GenerationTime()
    {
        //��莞�Ԍo�߂���Ɛ����D�̐������x�ύX
        if (gimmick_time > 30.0f && !stop)
        {
            g_time = g_time / 2;
            stop = true;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        waterbom_level = 1;
        randstop = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // �O�t���[������̎��Ԃ����Z���Ă���
        time = time + Time.deltaTime;

        //�M�~�b�N�����^�C�������Z���Ă���
        gimmick_time = gimmick_time + Time.deltaTime;

        GenerationTime();//�������Ԃ�ύX����

        //���Ԍo�߂Ő����D���x���㏸
        //���x��1�����x��2
        if (gimmick_time > 10.0f)
        {
            waterbom_level = 2;
        }
        //���x��2�����x��3
        if (gimmick_time > 20.0f && waterbom_level == 2)
        {
            waterbom_level = 3;
        }

       // Debug.Log(gimmick_time);

        // �ݒ肵�����Ԃ��ƂɃ����_���ɐ��������悤�ɂ���B
        if (time > g_time)
        {
            if(waterbom_level == 1)
            {
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(CreateWaterBom[0], new Vector2(x, y), CreateWaterBom[0].transform.rotation);
                // �o�ߎ��ԃ��Z�b�g
                time = 0f;
            }
            else if (waterbom_level > 1)
            {
               // Debug.Log("ss");
                if(!randstop)
                {
                    randnum();//�����_����������
                }
                
                // rangeA��rangeB��x���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float x = Random.Range(rangeA.position.x, rangeB.position.x);
                // rangeA��rangeB��y���W�͈͓̔��Ń����_���Ȑ��l���쐬
                float y = Random.Range(rangeA.position.y, rangeB.position.y);

                // GameObject����L�Ō��܂��������_���ȏꏊ�ɐ���
                Instantiate(CreateWaterBom[rand], new Vector2(x, y), CreateWaterBom[rand].transform.rotation);

                // �o�ߎ��ԃ��Z�b�g
                time = 0f;
                //�����_�����~��������
                randstop = false;
            }



        }
    }
}
