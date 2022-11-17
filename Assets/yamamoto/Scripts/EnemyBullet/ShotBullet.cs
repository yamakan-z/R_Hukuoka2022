using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotBullet : MonoBehaviour
{

    enum ShotType//�e�̎��
    {
        NONE = 0,
        AIM,            // �v���C���[��_��
        THREE_WAY,      // �R����
    }

    [System.Serializable]
    struct ShotData//�e�̃f�[�^
    {
        public int frame;
        public ShotType type;
        public Bullet bullet;
    }

    // �V���b�g�f�[�^�̏�����
    [SerializeField] 
    ShotData shotData = new ShotData { frame = 60, type = ShotType.NONE, bullet = null };

    GameObject player = null;       // �v���C���[�I�u�W�F�N�g
    int shotFrame = 0;              // �t���[��


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
    }

    // Update is called once per frame
    void Update()
    {
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

                // �R����
                case ShotType.THREE_WAY:
                    {
                        Bullet bullet = (Bullet)Instantiate(
                            shotData.bullet,
                            transform.position,
                            Quaternion.identity
                        );
                        bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                        bullet = (Bullet)Instantiate(shotData.bullet, transform.position, Quaternion.identity);
                        bullet.SetMoveVec(Quaternion.AngleAxis(-15, new Vector3(0, 0, 1)) * new Vector3(-1, 0, 0));
                    }
                    break;
            }

            shotFrame = 0;
        }

       
    }
}
