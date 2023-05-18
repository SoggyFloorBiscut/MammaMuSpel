using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageStack : MonoBehaviour
{
    
    public bool right;
    //[SerializeField] GameObject PageR, PageL;
    Color col, bg = new Color(0.5f,0.2f,0.2f);
    SpriteRenderer sprite;
    int layer;
    public int y;
    [SerializeField] GameObject pageLogic;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = sprite.color;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pageLogic.GetComponent<TurningPage>().update == true)
        {
            PageUpdate();
            print("update");
        }
        
    }

   public void PageUpdate()
    {
        if (right == true)
        {
            layer = pageLogic.GetComponent<TurningPage>().pagesR[y];
        }
        else
        {
            layer = pageLogic.GetComponent<TurningPage>().pagesL[y];
        }


        if (layer > 0)
        {
            sprite.color = col;
        }
        else
        {
            sprite.color = bg;
        }
    }
    
    
}
