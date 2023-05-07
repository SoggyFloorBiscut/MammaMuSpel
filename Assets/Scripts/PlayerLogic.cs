using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    float timer;
    bool canMove;
    Vector3 direction;
    [SerializeField] GameObject pageL, pageR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = new Vector3(4, 0, 0);
                timer = 0.5f;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = new Vector3(-4, 0, 0);
                timer = 0.5f;
            }
        }
        
        if (timer > 0)
        {
            canMove = false;
            timer -= Time.deltaTime;
            gameObject.transform.position += direction * Time.deltaTime;
        }
        else
        {
            if (gameObject.transform.position.x > 8.5f)
            {
                pageR.GetComponent<PageTurn>().enabled = true;
            }
            else if (gameObject.transform.position.x < -8.5)
            {
                pageL.GetComponent<PageTurn>().enabled = true;
            }
            else
            {
                canMove = true;
            }
            
        }
    }
}
