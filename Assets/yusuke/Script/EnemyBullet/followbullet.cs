//í«è]
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followbullet : MonoBehaviour
{

    public GameObject player;//ÉvÉåÉCÉÑÅ[ÇéùÇ¡ÇƒÇ≠ÇÈ

    public GameObject BulletShot;

    [SerializeField]
    private float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(player.transform);
        StartCoroutine("Shot");
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        //Vector2 diff = (player.gameObject.transform.position - this.transform.position);
        //this.transform.rotation = Quaternion.FromToRotation(Vector2.up, diff);
    }


    IEnumerator Shot()
    {
        while (true)
        {
            var shot = Instantiate(BulletShot, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody2D>().velocity = transform.forward.normalized * bulletSpeed;
            yield return new WaitForSeconds(1.0f);
        }
    }
}

