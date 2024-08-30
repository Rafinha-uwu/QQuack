using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class CKick : MonoBehaviour
{

    private Rigidbody2D rb;
    public bool hit = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
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
            case "Box":
                if (hit == true)
                {
                    col.gameObject.transform.Find("Box").gameObject.SetActive(false);
                    col.gameObject.transform.Find("Broken").gameObject.SetActive(true);
                    col.gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }

                break;

            case "Trash":


                rb = col.GetComponent<Rigidbody2D>();

                if (hit == true)
                {



                    // Calculate the direction away from the player
                    Vector2 direction = transform.position - col.transform.position;

                    // Set the launch force for the player collision (adjust as needed)
                    float launchForcePlayer = 20f;
                    
                    float angleInRadians = Mathf.Deg2Rad * 45.0f;

                    Vector2 launchDirection = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

                    // Apply the force to launch the object away in a 45-degree angle
                    if (this.gameObject.transform.position.x > col.gameObject.transform.position.x)
                    {
                        launchDirection = new Vector2(-Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));


                    }

                    rb.AddForce(launchDirection * launchForcePlayer, ForceMode2D.Impulse);
                }
                break;
        }
    }
}
