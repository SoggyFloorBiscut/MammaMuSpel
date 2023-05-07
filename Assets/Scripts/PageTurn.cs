using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    float timer = 0;
    public float movespeed, turnspeed;
    [SerializeField] GameObject player;
    Vector3 originPos, originScale;
    [SerializeField] SpriteRenderer[] pagesR = new SpriteRenderer[4];
    [SerializeField] SpriteRenderer[] pagesL = new SpriteRenderer[4];
    Color[] layers = new Color[4];
    Color bg;
    int OnPage = 0;

    
    private void Awake()
    {
        colorSet();
        originPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y,0);
        originScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y,1);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0)
        {
            gameObject.transform.localScale -= new Vector3(turnspeed, 0, 0) * Time.deltaTime;
            gameObject.transform.position -= new Vector3(movespeed, 0, 0) * Time.deltaTime;
            timer -= Time.deltaTime;
        }
        else
        {
            gameObject.transform.position = originPos;
            gameObject.transform.localScale = originScale;
            
        
            if (player.transform.position.x > 0)
            {
                player.transform.position = new Vector3(-8, 0, 0);
                pagesR[3 - OnPage].color = bg;
                pagesL[OnPage].color = layers[OnPage];


            }
            else if (player.transform.position.x < 0)
            {
                player.transform.position = new Vector3(8, 0, 0);
                
            }
            OnPage++;
            GetComponent<PageTurn>().enabled = false;
        }
    }
    private void OnEnable()
    {
        timer = 3;
        gameObject.transform.position -= new Vector3(0, 10, 0);
    }

    private void colorSet()
    {
        float x = 0.8f;
        for (int i = 0; i < layers.Length; i++)
        {
            layers[i] = new Color(x, x, x, 1);
            x -= 0.15f;
        }
        bg = new Color(0.5f, 0.2f, 0.2f, 1);
        
    }

    
    
}
