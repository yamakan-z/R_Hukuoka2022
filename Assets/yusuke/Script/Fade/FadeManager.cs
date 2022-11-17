using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour
{
    public bool isFadeout = false;
    public bool isFadeIn = false;
    float speed = 0.02f;
    Image fadepanel;
    float red, green, blue, alpha;
    GameObject player;
    public GameObject Text;

    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("SD_unitychan_humanoid");
        fadepanel = GetComponent<Image>();
        green = fadepanel.color.g;
        blue = fadepanel.color.b;
        alpha = fadepanel.color.a;
        isFadeIn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isFadeout)
        {
            Fadeout();
        }
        if(isFadeIn)
        {
            StartFadeIn();
        }
    }

    void Fadeout()
    {
        alpha += speed;
        fadepanel.color = new Color(red, green, blue, alpha);
        if(alpha>=1)
        {
            isFadeout = false;
            this.player.transform.position = new Vector3(3, 0, 22);
            isFadeIn = true;
            Text.SetActive(false);
        }
    }

    void StartFadeIn()
    {
        alpha -= speed;
        fadepanel.color = new Color(red, green, blue, alpha);
        if(alpha<=0)
        {
            isFadeIn = false;
        }
    }
}
