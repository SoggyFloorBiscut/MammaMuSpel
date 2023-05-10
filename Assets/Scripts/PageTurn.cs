using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageTurn : MonoBehaviour
{
    public float timer = 0;
    public float movespeed, turnspeed;
    //public int layer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject active;
    Vector3 originPosR, originScaleR, originPosL, originScaleL;
    [SerializeField] GameObject pagel, pager;
    [SerializeField] public int[] pagesR = new int[4];
    [SerializeField] public int[] pagesL = new int[4];
    Color[] layers = new Color[4];
    Color bg;
    public int OnPage = 0;
    

    
    private void Awake()
    {
        //colorSet();
        originPosR = new Vector3(pager.transform.position.x, pager.transform.position.y,0);
        originScaleR = new Vector3(pager.transform.localScale.x, pager.transform.localScale.y,1);
        originPosL = new Vector3(pagel.transform.position.x, pagel.transform.position.y, 0);
        originScaleL = new Vector3(pagel.transform.localScale.x, pagel.transform.localScale.y, 1);
        //sideCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer > 0)
        {
            print("timer on");
            active.transform.localScale -= new Vector3(turnspeed, 0, 0) * Time.deltaTime;
            active.transform.position -= new Vector3(movespeed, 0, 0) * Time.deltaTime;
            timer -= Time.deltaTime;
        }
        else if (timer > -1)
        {

            print("timer done");

            if (active == pager)
            {
                player.transform.position = new Vector3(-8, 0, 0);
                //pagesR[3 - OnPage].color = bg;
                //pagesL[OnPage].color = layers[OnPage];
                
                //layer--;

            }
            else if (active == pagel)
            {
                player.transform.position = new Vector3(8, 0, 0);
                //pagesL[3 - OnPage].color = bg;
                //pagesR[OnPage].color = layers[OnPage];
                
                //layer++;
            }
            Resetpage();
            
            timer = -2;
            
            OnPage++;
            
            //GetComponent<PageTurn>().enabled = false;
        }
    }
    private void OnEnable()
    {
        
    }

    public void TurnPage(bool rightside)
    {
        //sideCheck();
        if (rightside == true)
        {
            active = pager;
        }
        else
        {
            active = pagel;
        }
        timer = 3;
        active.transform.position -= new Vector3(0, 10, 0);
        
    }

    private void Resetpage()
    {

        print("reset");
        if (pager == active)
        {
            pager.transform.position = originPosR;
            pager.transform.localScale = originScaleR;
            Addint(pagesR, 1);
            Addint(pagesL, -1);
        }
        if (pagel == active)
        {
            pagel.transform.position = originPosL;
            pagel.transform.localScale = originScaleL;
            Addint(pagesR, -1);
            Addint(pagesL, 1);
        }
    }


    /*
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
    */
    private void sideCheck()
    {
        if (player.transform.position.x < 0)
        {
            active = pagel;
            if (movespeed < 0)
            {
                movespeed *= -1;
            }
        }
        else 
        {
            active = pager;
            if (movespeed > 0)
            {
                movespeed *= -1;
            }
        }
    }

    private void Addint(int[] ints, int x)
    {
        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] += x;
        }
    }

    
    
}
