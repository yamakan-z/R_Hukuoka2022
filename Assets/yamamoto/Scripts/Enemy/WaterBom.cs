using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBom : MonoBehaviour
{

    [System.Serializable]
    struct ShotData//�e�̃f�[�^
    {
        [Header("���˃t���[�����i�e�̔��ˊԊu�j")]
        public int frame;
        [Header("�e�v���n�u�������Ă���")]
        public Bullet bullet;
        [SerializeField, Header("�e�𔭎˂����")]
        public int bullet_count;
    }

    [SerializeField, Header("�����_�����ˊJ�n����")]
    private float r_time;

    // �V���b�g�f�[�^�̏�����
    [SerializeField]
    ShotData shotData = new ShotData { frame = 60,bullet = null, bullet_count = 1 };

    int shotFrame = 0;              // �t���[��

    private int count = 0;//�e�̐����񐔂��J�E���g

    bool g_stop = false;//�e�̐������~�߂�

    [SerializeField] private AudioSource audio;

    [SerializeField] private AudioClip se;

    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    bool one;//��x�������ʉ�

    private bool isAudioEnd;

    //�����_���ɒe���ˎ��Ԃ����߂�
    public void RandNumCreate()
    {
        r_time = Random.Range(1, 3);
    }

    // Start is called before the first frame update
    void Start()
    {
        RandNumCreate();
        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        sr = gameObject.GetComponent<SpriteRenderer>();

        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!g_stop)
            Shot();
    }

    void Shot()
    {
        //Rigidbody���擾
        var rb = GetComponent<Rigidbody>();

        r_time -= Time.deltaTime;

        ++shotFrame;
        if (r_time<0)
        {
           
            if (shotFrame > shotData.frame)
            {
                Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );

                //�e�U�e���o��
                for (int i = 30; i < 360; i += 30)
                {
                    //FreezePositionY���I���ɂ���
                    rb.constraints = RigidbodyConstraints.FreezePositionY;
                    sr.sprite = null;//�����D�̉摜�������Ȃ��悤�ɂ���
                   
                    if(!one)
                    {
                        Debug.Log("�o��");
                        audio.Play();//�������ʉ�
                        isAudioEnd = true;
                        one = true;
                    }
                    
                    bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                    bullet.SetMoveVec(Quaternion.AngleAxis(i, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                }

                count++;

                if(shotData.bullet_count==1)
                {
                    g_stop = true;//�����Ő������~�߂�
                    Invoke("Delete", 1.0f);//��b��Ƀe�L�X�g��\��
                }
                else if (count == shotData.bullet_count)
                {
                    Debug.Log("????");
                    Destroy(this.gameObject);//�e���o���؂�����폜

                    //g_stop = true;
                }
                shotFrame = 0;
            }
        }

        

       
    }

    void Delete()
    {
        Destroy(this.gameObject);//�e���o���؂�����폜
    }
}
