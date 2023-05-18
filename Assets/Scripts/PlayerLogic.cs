using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float timer, OGspeed;
    [SerializeField] float speed;
    bool canMove, crough, disco = false;
    GameObject Carry = null;
    Vector3 direction, ogScale;
    [SerializeField] GameObject pageLogic;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        OGspeed = speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                gameObject.transform.position += new Vector3(1, 0) * Time.deltaTime * speed;
                sprite.flipX = false;

                
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.transform.position -= new Vector3(1, 0) * Time.deltaTime * speed;
                sprite.flipX = true;
                
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            { 
                timer = 0.5f;
                direction = new Vector3(0, 2);
                speed = OGspeed;
                crough = false;
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f);
                if (Carry != null)
                {
                    if (Carry.tag == "Use")
                    {
                        Carry.transform.SetParent(null);
                        Carry.transform.position = new Vector3(Carry.transform.position.x, -1.5f);
                        Carry.transform.localScale = ogScale;
                        Carry.GetComponent<Collider2D>().enabled = true;
                        Carry.tag = "Item";
                        Carry = null;
                    }
                    else
                    {
                        Carry.tag = "Use";
                    }          
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.transform.localScale = new Vector3(0.5f, 0.2f);
                speed = OGspeed/2;
                crough = true;
                gameObject.GetComponent<Collider2D>().enabled = true;
            }
            
            if (Input.GetKey(KeyCode.G))
            {
                disco = true;
                
            }
            else
            {
                disco = false;
                sprite.color = Color.white;
            }

        }
        if (disco == true)
        {
            if (timer <= 0)
            {
                if (sprite.color == Color.white || sprite.color == Color.blue)
                {
                    sprite.color = Color.red;
                }
                else if (sprite.color == Color.red)
                {
                    sprite.color = Color.green;
                }
                else if (sprite.color == Color.green)
                {
                    sprite.color = Color.blue;
                }
                timer = 0.1f;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
        
        if (timer > 0 && disco == false)
        {
            canMove = false;
            timer -= Time.deltaTime;
            gameObject.transform.position += direction * Time.deltaTime;
        }
        else
        {
            canMove = true;
        }

        if (gameObject.transform.position.x > 8.5f)
        {
            transform.position = new Vector3(0, -7);
            pageLogic.GetComponent<TurningPage>().TurnPage(true);


        }
        else if (gameObject.transform.position.x < -8.5)
        {
            transform.position = new Vector3(0,-7);
            pageLogic.GetComponent<TurningPage>().TurnPage(false);


        }
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item") && crough == true && Carry == null)
        {
            Carry = collision.gameObject;
            ogScale = Carry.transform.localScale;
            collision.transform.position = gameObject.transform.position;
            collision.transform.position += new Vector3(0, 0.2f);
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.transform.SetParent(gameObject.transform);
            
            Carry.transform.localScale -= new Vector3(0, Carry.transform.localScale.y/2);

           
        }
    }


}
