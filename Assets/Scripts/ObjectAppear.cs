using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectAppear : MonoBehaviour
{
    [SerializeField] GameObject PageLogic;
    int y;
    float timer;
    Vector3 ogPos, ogScale;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        ogPos = gameObject.transform.position;
        ogScale = gameObject.transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PageLogic.GetComponent<TurningPage>().update == true)
        {
            print("moving");
            gameObject.transform.position += new Vector3(0,y*PageLogic.GetComponent<TurningPage>().x);
            y = 0;
            sprite.color = Color.clear;
        }
        else
        {
            sprite.color = Color.white;
            
            
            
            y = 10;
        }
        timer = PageLogic.GetComponent<TurningPage>().timer;
        if (timer > 0)
        {
            
            if (timer < 0.5f)
            {
                sprite.color = Color.clear;
            }
            else
            {
                sprite.color = new Color(0, 0, 0, (timer / 4) - 0.3f);
            }




        }
        
    }

    
}
