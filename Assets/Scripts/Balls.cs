using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Balls : MonoBehaviour
{
    private Rigidbody2D rb;

    public bool hit = false;
    public float speed = 4f;


    bool Alive = true;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Alive == true)
        {
            this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }


        if (Keyboard.current.eKey.isPressed)
        {
            hit = true;
        }
        else { hit = false; }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {
            case "Kick":
                if (hit)
                {
                    Alive = false;
                    Invoke("voa", 2);
                }
                break;

            case "Fall":

                Destroy(this.gameObject);

                break;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Box" || collision.gameObject.tag == "Dumb" || collision.gameObject.tag == "Trash")
        {
            if (speed == 4) { speed = -4f; this.gameObject.GetComponentInChildren<Animator>().Play("lixo"); }
            else { speed = 4; this.gameObject.GetComponentInChildren<Animator>().Play("lixo 1"); }
        }



    }

    private void voa()
    {
        Destroy(this.gameObject);
    }
}
