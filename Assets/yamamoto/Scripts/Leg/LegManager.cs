using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegManager : MonoBehaviour
{

    [SerializeField, Header("���̐�")]
    List<GameObject> Legs;

    [SerializeField, Header("�o�����������_���Ɍ��߂�ϐ�")]
    private int randnum;

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
        randnum = Random.Range(1, 4);
    }

    // Start is called before the first frame update
    void Start()
    {
        //RandNumCreate();
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
                    RandNumCreate();
                }
                break;
        }
    }
}
