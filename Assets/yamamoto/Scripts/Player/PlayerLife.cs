using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    //�v���C���[���C�t�i�\���p�j
    // �f�t�H���g�̉摜
    public Sprite defaultImage;
    //�_���[�W���󂯂��Ƃ��̃��C�t
    public Sprite damageImage;

    [Header("�v���C���[�X�N���v�g")]
    public Player player;

    [Header("���C�t�ԍ�")]
    public bool one;

    public bool two;

    public bool three;

    // �摜�`��p�̃R���|�[�l���g
    public Image image;
   
    // Start is called before the first frame update
    void Start()
    {
        // Sprite��SpriteRenderer�R���|�[�l���g���擾
        image = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.HP == 2)
        {
            if(three)
            {
                //�摜�ύX
                image.sprite = damageImage;
            }
           
        }
        else if(player.HP == 1)
        {
            if (two)
            {
                //�摜�ύX
                image.sprite = damageImage;
            }
        }
        else if (player.HP == 0)
        {
            if (one)
            {
                //�摜�ύX
                image.sprite = damageImage;
            }
        }
    }
}
