using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;//�v���C���[�̑���

    [SerializeField] private int HP = 3;//�v���C���[��HP

    // �f�t�H���g�̉摜(�m�[�_���[�W���̉摜)
    public Sprite defaultImage;
    // �f�t�H���g�̉摜(��i�K�ڃ_���[�W�̉摜�j
    public Sprite damageImage;
    // �f�t�H���g�̉摜(��i�K�ڃ_���[�W�̉摜�j
    public Sprite twosteps_damageImage;


    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    Vector2 PlayerSize;//�v���C���[�I�u�W�F�N�g�̑傫��������ϐ�

    void Start()
    {

        PlayerSize = gameObject.transform.localScale; //�����݂̑傫������

        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        //--------------�ړ�����----------------------------
        Vector2 position = transform.position;

        if (Input.GetKey("left"))
        {
            position.x -= speed;
        }
        if (Input.GetKey("right"))
        {
            position.x += speed;
        }
        if (Input.GetKey("up"))
        {
            position.y += speed;
        }
        if (Input.GetKey("down"))
        {
            position.y -= speed;
        }

        transform.position = position;

        //-----------------------------------------------------

       
    }


    //�����蔻��̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Debug.Log("�ǂƐڐG�����I");
        }

        else if (collision.collider.tag == "Enemy")
        {
            Debug.Log("�G�ƐڐG�����I");

            Damage();//�_���[�W������
        }
    }

    //�����蔻��i�g���K�[�j
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("�G�ƐڐG�����I");

            Damage();//�_���[�W������
        }
    }

    /// <summary>
    /// �_���[�W����
    /// </summary>
    public void Damage()
    {
        if (HP == 3)
        {
            //�摜�ύX
            sr.sprite = damageImage;

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//�ύX����傫����ݒ�

            gameObject.transform.localScale = PlayerSize; //�傫���ύX

            HP--;//�_���[�W
        }
        else if (HP == 2)
        {
            //�摜�ύX
            sr.sprite = twosteps_damageImage;

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//�ύX����傫����ݒ�

            gameObject.transform.localScale = PlayerSize; //�傫���ύX


            HP--;
        }
        else if (HP == 1)
        {
            HP--;
            Debug.Log("��");
        }
    }


}

