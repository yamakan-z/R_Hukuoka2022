using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{

    [SerializeField, Header("���̐�")]
    List<GameObject> Legs;

    [SerializeField, Header("�o�����������_���Ɍ��߂�ϐ�")]
    private int randnum;

    public  bool randstop;//�����_�����������f

    public bool legreturned;//�����߂��Ă���

    bool a=true;

    [Header("�����o���Ԋu����")]
    public int legTime;


    enum LegAttckType
    {
        NONE = 0,
        RANDOM,
        CONTINUE,
    }

    [System.Serializable]
    struct LegData//���̃f�[�^
    {
        [Header("���̍U���^�C�v�I��")]
        public LegAttckType type;
    }

    [SerializeField]
    LegData legData = new LegData
    { type = LegAttckType.NONE };

    //�����_���ɐ�������
    public void RandNumCreate()
    {
        randnum = Random.Range(0, 3);
        //a = true;
        randstop = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        randstop = false;
        legreturned = true;
    }

    // Update is called once per frame
    void Update()
    {
        //legData = new LegData
        //{ type = LegAttckType.CONTINUE };

        //���U���f�[�^���̏���
        switch(legData.type)
        {
            case LegAttckType.RANDOM:
                {
                    if(!randstop)
                    {
                        RandNumCreate();
                        Debug.Log("seisei");
                    }

                    if (legreturned)
                    {

                        Debug.Log("�͂��Ă邩");
                        Legs[randnum].GetComponent<Leg>().legdown = true;

                        legreturned = false;
                    }
                }
                break;
        }
    }

    public void LegTurned()
    {
        Legs[randnum].GetComponent<Leg>().phase = 1;
        if (a)
        {
            Debug.Log("���������������������ӂ�������");
            randstop = false;
           // legreturned = false;
            a = false;
        }


        Debug.Log("�n�b�s�[");
    }
}
