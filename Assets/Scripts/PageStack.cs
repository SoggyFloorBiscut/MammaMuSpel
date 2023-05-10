using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageStack : MonoBehaviour
{
    
    [SerializeField] bool right;
    //[SerializeField] GameObject PageR, PageL;
    Color col, bg = new Color(0.5f,0.2f,0.2f);
    SpriteRenderer sprite;
    int layer;
    [SerializeField] int y;
    [SerializeField] GameObject pageLogic;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        col = sprite.color;
        PageUpdate();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PageUpdate();
    }

   public void PageUpdate()
    {
        if (right == true)
        {
            layer = pageLogic.GetComponent<PageTurn>().pagesR[y];
        }
        else
        {
            layer = pageLogic.GetComponent<PageTurn>().pagesL[y];
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
