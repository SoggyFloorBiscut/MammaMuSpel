using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageStackGenerator : MonoBehaviour
{
    public int Pageamount;
    float timer;
    [SerializeField] GameObject pageLogic;
    [SerializeField] GameObject PagePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 1; i < Pageamount +2; i++)
        {
            float x = i;
            if (i == Pageamount +1)
            {
                var LastLayerR = Instantiate(PagePrefab, new Vector3(8 + x / 10, 0, -10 + i), Quaternion.identity, pageLogic.transform);
                LastLayerR.GetComponent<SpriteRenderer>().color = new Color(0.5f,0.2f,0.2f,1);
                LastLayerR.GetComponent<PageStack>().enabled = false;
                var LastLayerL = Instantiate(PagePrefab, new Vector3(-8 - x / 10, 0, -10 + i), Quaternion.identity, pageLogic.transform);
                LastLayerL.GetComponent<SpriteRenderer>().color = new Color(0.5f, 0.2f, 0.2f, 1);
                LastLayerL.GetComponent<PageStack>().enabled = false;
            }
            else
            {
                var NewpageR = Instantiate(PagePrefab, new Vector3(8 + x / 10, 0, -10 + i), Quaternion.identity, pageLogic.transform);
                NewpageR.name = "under page R " + i;
                NewpageR.GetComponent<SpriteRenderer>().color = new Color(1 - x / 10, 1 - x / 10, 1 - x / 10, 1);
                NewpageR.GetComponent<PageStack>().y = i - 1;
                NewpageR.GetComponent<PageStack>().right = true;

                var NewpageL = Instantiate(PagePrefab, new Vector3(-8 - x / 10, 0, -10 + i), Quaternion.identity, pageLogic.transform);
                NewpageL.name = "under page L " + i;
                NewpageL.GetComponent<SpriteRenderer>().color = new Color(1 - x / 10, 1 - x / 10, 1 - x / 10, 1);
                NewpageL.GetComponent<PageStack>().y = i - 1;
                NewpageL.GetComponent<PageStack>().right = false;
            }
            
        }
        
        timer = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            pageLogic.GetComponent<TurningPage>().update = true;
            timer--;
        }
        else if (timer == 0)
        {
            pageLogic.GetComponent<TurningPage>().update = false;
            timer = -1;
        } 
       
    }
}
