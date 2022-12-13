using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed;//�v���C���[�̑���

    public int HP = 3;//�v���C���[��HP

    // �f�t�H���g�̉摜(�m�[�_���[�W���̉摜)
    public Sprite defaultImage;
    // �f�t�H���g�̉摜(��i�K�ڃ_���[�W�̉摜�j
    public Sprite damageImage;
    // �f�t�H���g�̉摜(��i�K�ڃ_���[�W�̉摜�j
    public Sprite twosteps_damageImage;

    public CountTime countTime;//���ԃJ�E���g�X�N���v�g

    //�_���[�W���󂯂��Ƃ��̏���
    private bool isDamage;
    
    // �摜�`��p�̃R���|�[�l���g
    SpriteRenderer sr;

    Vector2 PlayerSize;//�v���C���[�I�u�W�F�N�g�̑傫��������ϐ�

    void Start()
    {

        PlayerSize = gameObject.transform.localScale; //�����݂̑傫������

        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        sr = gameObject.GetComponent<SpriteRenderer>();

    }

    void FixedUpdate()
    {
        if(isDamage)
        {
            float level = Mathf.Abs(Mathf.Sin(Time.time * 15));//�_�ł̑���
            sr.color = new Color(1f, 1f, 1f, level);//�v���C���[��_��
        }
      
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
    }

    //�����蔻��i�g���K�[�j
    private void OnTriggerEnter2D(Collider2D collision)//
    {
        if (collision.gameObject.tag == "Enemy"&&!isDamage)//���G�������͒ʂ��Ȃ�
        {
            Debug.Log("�G�ƐڐG�����I");

            isDamage = true;

            StartCoroutine(Damage());//�_���[�W������
        }
    }

    /// <summary>
    /// �_���[�W����
    /// </summary>
    public IEnumerator Damage()
    {
        if (HP == 3)
        {
            //�摜�ύX
            sr.sprite = damageImage;

            GetComponent<AudioSource>().Play();//������炷

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//�ύX����傫����ݒ�

            gameObject.transform.localScale = PlayerSize; //�傫���ύX

            HP--;//�_���[�W
        }
        else if (HP == 2)
        {
            //anim.Stop();

            //�摜�ύX
            sr.sprite = twosteps_damageImage;

            GetComponent<AudioSource>().Play();//������炷

            PlayerSize = new Vector2(PlayerSize.x * 0.8f, PlayerSize.y * 0.8f);//�ύX����傫����ݒ�

            gameObject.transform.localScale = PlayerSize; //�傫���ύX


            HP--;
        }
        else if (HP == 1)
        {
            HP--;

            PlayerPrefs.SetFloat("TEST", countTime.countup);
            PlayerPrefs.Save();

            SceneManager.LoadScene("Result");
            Debug.Log("��");
        }

        //���G����
        yield return new WaitForSeconds(2.0f);

        // �ʏ��Ԃɖ߂�
        isDamage = false;
        sr.color = new Color(1f, 1f, 1f, 1f);

    }
}

