using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public AttackBelow[] m_enemyPrefabs; //�G�̃v���n�u���Ǘ�����z��
    public float m_interval; //�o���Ԋu

    private float m_timer; //�o���^�C�~���O���Ǘ�����^�C�}�[

    //���t���[���Ăяo�����֐�
    private void Upadate()
    {
        //�o���^�C�~���O���Ǘ�����^�C�}�[���X�V����
        m_timer += Time.deltaTime;

        //�܂��G���o������^�C�~���O�ł͂Ȃ��ꍇ
        //���̃t���[���̏����͂����ŏI����
        if (m_timer < m_interval) return;

        //�o���^�C�~���O���Ǘ�����^�C�}�[�����Z�b�g����
        m_timer = 0;

        //�o������G�������_���Ɍ��肷��
        var enemyIndex = Random.Range(0, m_enemyPrefabs.Length);

        //�o������G�̃v���n�u��z�񂩂�擾����
        var enemyPrefab = m_enemyPrefabs[enemyIndex];

        //�G�̃Q�[���I�u�W�F�N�g�𐶐�����
        var enemy = Instantiate(enemyPrefab);

        //�G����ʊO�̂ǂ̈ʒu�ɏo�������邩�����_���Ɍ��肷��
        var respawnType = (RESPAWN_TYPE)Random.Range(
            0, (int)RESPAWN_TYPE.SIZEOF);

        //�G������������
        enemy.Init(respawnType);
    }
}
