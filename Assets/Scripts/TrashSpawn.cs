using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{
    CPato cTr;
    public GameObject CTr;

    public GameObject Trash;

    // Start is called before the first frame update
    void Start()
    {
        cTr = CTr.GetComponent<CPato>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cTr.vivo == false)
        {
            Debug.Log("hehe");
            this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            float X = 10f;
            Instantiate(Trash, transform.position + new Vector3(X, 0, 0), transform.rotation);
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
