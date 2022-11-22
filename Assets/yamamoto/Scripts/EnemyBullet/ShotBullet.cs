using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{

    enum ShotType//�e�̎��
    {
        NONE = 0,
        NOMAL,          //�ꔭ�Âe�𔭎˂���
        AIM,            // �v���C���[��_��
        DIFFUSION,      //360�x�g�U
    }

    [System.Serializable]
    struct ShotData//�e�̃f�[�^
    {
        [Header("���˃t���[�����i�e�̔��ˊԊu�j")]
        public int frame;
        [Header("�e�̔��˃^�C�v�I��")]
        public ShotType type;
        [Header("�e�v���n�u�������Ă���")]
        public Bullet bullet;
        [SerializeField, Header("�e�𔭎˂����")]
        public int bullet_count;
    }

    // �V���b�g�f�[�^�̏�����
    [SerializeField] 
    ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null,bullet_count = 1};

    GameObject player = null;       // �v���C���[�I�u�W�F�N�g
    int shotFrame = 0;              // �t���[��

    private int count = 0;//�e�̐����񐔂��J�E���g

    bool g_stop=false;//�e�̐������~�߂�

    // Start is called before the first frame update
    void Start()
    {
        // �Ǐ]�e�ݒ�̎��A�v���C���[�I�u�W�F�N�g���擾����
        switch (shotData.type)
        {
            case ShotType.AIM:
                player = GameObject.Find("Player");
                break;
        }

        Shot();
    }

    // Update is called once per frame
    void Update()
    {
        if(!g_stop)
        Shot();
    }

    // �V���b�g�����i�����Update�ȂǂŌĂԁj
    void Shot()
    {
        ++shotFrame;
        if (shotFrame > shotData.frame)
        {
            switch (shotData.type)
            {
                //1���Â���
                case ShotType.NOMAL:
                    {
                        Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );
                        bullet.SetMoveVec(transform.position*-1);
                    }
                    break;
                // �v���C���[��_��
                case ShotType.AIM:
                    {
                        if (player == null) { break; }
                        Bullet bullet = (Bullet)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet.SetMoveVec(player.transform.position - transform.position);
                    }
                    break;

                // 360�x������12������ 
                case ShotType.DIFFUSION:
                    {

                        Bullet bullet = (Bullet)Instantiate(
                         shotData.bullet,
                         transform.position,
                         Quaternion.identity
                          );

                        //�e�U�e���o��
                        for (int i = 30; i < 360; i += 30)
                        {
                            Debug.Log("�o��");
                            bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                            bullet.SetMoveVec(Quaternion.AngleAxis(i, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        }

                        count++;

                        if(count == shotData.bullet_count)
                        {
                            Debug.Log("????");
                            g_stop = true;
                            break;
                        }

                    }
                    break;
            }

            shotFrame = 0;
        }

       
    }
}
