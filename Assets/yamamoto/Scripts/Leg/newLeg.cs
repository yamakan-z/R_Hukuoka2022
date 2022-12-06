using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newLeg : MonoBehaviour
{
    [SerializeField, Header("���̃��W�b�h�{�f�B")]
    public Rigidbody2D rb;

    [SerializeField, Header("���}�l�[�W���[")]
    private GameObject LegManager;

    private bool legback;//����߂�

    // Start is called before the first frame update
    void Start()
    {
        LegManager = GameObject.Find("LegManager");//���}�l�[�W���[��T���Ď擾
    }

    // Update is called once per frame
    void Update()
    {
        //����߂�
        if(legback)
        {
            transform.Translate(Vector2.up * 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DownWall")
        {
            //���̕ǂɓ��������炻���ɒ�~����
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            Debug.Log("����");

            // �R���[�`���̋N��
            StartCoroutine(ReturnLeg());
        }

        if (collision.gameObject.tag == "DeleteArea")
        {
            // Debug.Log("�폜�G���A�ƐڐG�����I");
            LegManager.GetComponent<LegGenerationlocation>().LegCreate();
            Destroy(this.gameObject);//���폜
        }
    }


    IEnumerator ReturnLeg()
    {
        //�҂�
        yield return new WaitForSeconds(1.5f);
        legback = true;
    }
}
