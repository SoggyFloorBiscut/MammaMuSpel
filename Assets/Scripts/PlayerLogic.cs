using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float timer, OGspeed;
    [SerializeField] float speed;
    bool canMove, disco = false;

    Vector3 direction;
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
                gameObject.transform.localScale = new Vector3(0.5f, 0.5f);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                gameObject.transform.localScale = new Vector3(0.5f, 0.2f);
                speed = OGspeed/2;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.transform.SetParent(gameObject.transform);
            collision.transform.position = gameObject.transform.position += new Vector3(0,1);

        }
    }
    

}
