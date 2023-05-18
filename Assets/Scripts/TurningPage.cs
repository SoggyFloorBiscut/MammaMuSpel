using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurningPage : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] GameObject page, player, Generator, prefab;
    GameObject extraPage;
    SpriteRenderer pageSprite, extraSprite;
    [SerializeField] public int[] pagesR;
    [SerializeField] public int[] pagesL;

    public float movespeed, turnspeed;
    bool right, start;
    public bool update;
    bool half = false;
    public float timer;
    public int onPage = 0, maxPage = 0;
    public int x, objectvalue;
    
    void Start()
    {
        pageSprite = page.GetComponent<SpriteRenderer>();
        int pageAmount = Generator.GetComponent<PageStackGenerator>().Pageamount;
        pagesR = new int[pageAmount];
        pagesL = new int[pageAmount];
        
        for (int i = 0; i < pageAmount; i++)
        {
            pagesR[i] = pageAmount - i;
            pagesL[i] = -i;
        }
        maxPage = pageAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (start == true)
        {
            if (timer > 0)
            {
                
                page.transform.localScale -= new Vector3(turnspeed, 0, 0) * Time.deltaTime;
                page.transform.position += new Vector3(movespeed * x, 0, 0) * Time.deltaTime;
                if (timer > 1.5f)
                {
                    half = false;
                    pageSprite.sortingOrder = 0;
                }
                else
                {
                    if (half == false)
                    {
                        half = true;
                        //extraPage = Instantiate(prefab, new Vector3(4.1f, 0), Quaternion.identity, gameObject.transform);
                        pageSprite.sortingOrder = 4;
                        
                    }
                    
                }
                timer -= Time.deltaTime;
                

            }
            else
            {
                start = false;
                update = true;
                timer = 1;
                onPage -= 1 * x;
                player.transform.position = new Vector3(8 * x, -1);
                Addint(pagesR, 1 * x);
                Addint(pagesL, -1 * x);

                Reseter();
                
            }
            
            
        }
        else if (update == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                update = false;
            }
        }
    }


    public void TurnPage(bool r)
    {
        right = r;
        
        if (r == true)
        {
            if (onPage == maxPage)
            {
                player.transform.position = new Vector3(8, -1);
                print("max page");
            }
            else
            {
                timer = 3;
                page.transform.position = new Vector3(4.1f, 0);
                x = -1;
                start = true;
            }
        }
        else 
        {
            if (onPage == 0)
            {
                player.transform.position = new Vector3(-8, -1);
                print("min page");
            }
            else
            {
                timer = 3;
                page.transform.position = new Vector3(-4.1f, 0);
                x = 1;
                start = true;
            }
        }
        
        
    }

    private void Reseter()
    {
        page.transform.position = new Vector3(0, 10);
        page.transform.localScale = new Vector3(8, 10);
        pageSprite.sortingOrder = 4;

        //Destroy(extraPage);

    }

    private void Addint(int[] ints, int x)
    {
        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] += x;
        }
    }
}
