using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class script_pato_animacoes : MonoBehaviour
{

    public Animator animator;
    public GameObject movementGOB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("Speed", Mathf.Abs(movementGOB.GetComponent<CPato>().rb.velocity.x));

    }
}
