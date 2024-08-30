using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class CPato : MonoBehaviour
{

  
    public Transform GroundCheck;
    public Rigidbody2D rb;
    public LayerMask GroundLayer;

    private float horizontal;
    private float speed = 8;
    private float jumpingPower = 14.5f;

    private bool isFacingRight = true;



    public bool JJ = false;

    //VAR PARA DEIXAR OU NÃO O PLAYER MEXER-SE
    public bool On = false;
    public bool Cut = false;
    public float Fase = 1;
    public float Out = 1;

    public float FH1 = 1;
    public float FH2 = 1;
    public float FH3 = 1;

    public GameObject Cut1;
    public GameObject Cut2;
    public GameObject Cut3;

    public GameObject Con;
    public GameObject Square;
    public GameObject f1;
    public GameObject f2;
    public GameObject f3;
    public GameObject f4;



    //VARS DE SOM
    public AudioSource somSalto;
    public AudioSource somKick;
    public AudioSource somQuack;
    public AudioSource somMorte;
    public AudioSource somRise;


    //VARS PARA CONFIRMAR SE O SOM TOCOU
    public bool saltoTocou = false;
    public bool kickTocou = false;
    public bool quacktocou = false;




    public bool vivo = true;

    public GameObject SpritePlayer;
    //Cam

    public CinemachineVirtualCamera CM;

    //Transforms

    public Transform Dead;
    public Transform Enemy;

    public bool walkOff = false;

    TypeOutScript tp;
    public GameObject TP;

    public GameObject Txtx;


    void Start()
    {

        tp = TP.GetComponent<TypeOutScript>();

        Invoke("SXS", 11);
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {



        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        if (!isFacingRight && horizontal > 0f)
        {

            Flip();

        } else if (isFacingRight && horizontal < 0f)
        {

            Flip();

        }





        // Movement

        if (On == true)
        {
            if (Keyboard.current.eKey.isPressed)
            {
                SpritePlayer.GetComponent<Animator>().SetBool("IsKicking", true);
                SpritePlayer.GetComponent<Animator>().Play("pato_kick");
                
                if (kickTocou == false)
                {

                    somKick.Play();
                    kickTocou = true;
                    Invoke("WaitShit", 1);
                }


            }
            else if (Keyboard.current.spaceKey.isPressed)
            {

                SpritePlayer.GetComponent<Animator>().SetBool("IsJumping", true);
                SpritePlayer.GetComponent<Animator>().Play("pato_jumping");
               

                if (saltoTocou == false)
                {

                    somSalto.Play();
                    saltoTocou = true;
                    Invoke("WaitShit", 1);
                }


            }
            else if (Keyboard.current.qKey.isPressed)
            {

                SpritePlayer.GetComponent<Animator>().SetBool("IsQuacking", true);
                SpritePlayer.GetComponent<Animator>().Play("pato_quack");
                somQuack.Play();


                if (quacktocou == false)
                {

                    somQuack.Play();
                    quacktocou = true;
                    Invoke("WaitShit", 1);
                }



            } else
            {
                SpritePlayer.GetComponent<Animator>().SetBool("IsKicking", false);
                SpritePlayer.GetComponent<Animator>().SetBool("IsJumping", false);
                SpritePlayer.GetComponent<Animator>().SetBool("IsQuacking", false);
            }


        }
        //Jump uwu


        if (JJ)
        {

            if (Keyboard.current.qKey.isPressed)
            {

                if (Cut)
                {
                    switch (Fase)
                    {
                        case 1:
                            switch (FH1)
                            {
                                case 1:

                                    tp.FinalText = "So you want milk ey? Do I have horns on my head?";
                                    tp.Star();


                                    FH1++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 2:

                                    tp.FinalText = "Mate I am a pig, not a cow! I don’t have milk!";
                                    tp.Star();

                                    FH1++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 3:

                                    tp.FinalText = "Isn’t it weird already that I work at a grocery shop?";
                                    tp.Star();

                                    FH1++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 4:

                                    tp.FinalText = "I saw the frog had some milk, keep going!";
                                    tp.Star();

                                    Cut1.gameObject.SetActive(false);

                                    Cut = false;
                                    Fase = 2;
                                    On = true;



                                    break;
                            }
                            break;
                        case 2:

                            switch (FH2)
                            {
                                case 1:

                                    tp.FinalText = "I have no milk, my fellow duck";
                                    tp.Star();

                                    FH2++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 2:
                                    tp.FinalText = "I did see the frog headed that way and he had some";
                                    tp.Star();

                                    FH2++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 3:
                                    tp.FinalText = "After you get it, make sure you come back with your kids!";
                                    tp.Star();

                                    FH2++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;

                                case 4:
                                    tp.FinalText = "We haven’t had many visitors since those kids went miss-";
                                    tp.Star();

                                    FH2++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;

                                case 5:
                                    tp.FinalText = "Forget I just said that.";
                                    tp.Star();

                                    Cut2.gameObject.SetActive(false);
                                    Debug.Log("Hello World");
                                    Cut = false;
                                    Fase = 3;
                                    On = true;



                                    break;
                            }
                            break;

                        case 3:

                            switch (FH3)
                            {
                                case 1:

                                    tp.FinalText = "??";
                                    tp.Star();

                                    FH3++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 2:

                                    tp.FinalText = "You want this bag of milk?";
                                    tp.Star();

                                    FH3++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 3:

                                    tp.FinalText = "But it’s for my kids";
                                    tp.Star();

                                    FH3++;
                                    Cut = false;
                                    Invoke("Wait", 2);
                                    break;
                                case 4:

                                    tp.FinalText = "Oh no…";
                                    tp.Star();

                                    Cut3.gameObject.SetActive(false);
                                    Debug.Log("Hello World");
                                    Cut = false;
                                    Fase = 4;


                                    break;
                            }
                            break;

                    }
                }
            }
        }

        if (Fase == 4)
        {
            switch (Out)
            {
                case 1:
                    Square.SetActive(true);
                    Con.SetActive(true);
                    break;
                case 2:

                    f1.SetActive(true);
                    break;
                case 3:
                    f1.SetActive(false);
                    f2.SetActive(true);
                    break;
                case 4:
                    f2.SetActive(false);
                    f3.SetActive(true);
                    break;

                case 5:

                    f3.SetActive(false);
                    f4.SetActive(true);
                    Con.SetActive(false);
                    break;


            }


            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                Out++;
            }


        }

    }






    private bool IsGrounded()
    {

        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);

    }

    private void Flip()
    {

        isFacingRight = !isFacingRight;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

    }

    public void Move(InputAction.CallbackContext context)
    {

        horizontal = context.ReadValue<Vector2>().x;


    }

    public void Jump(InputAction.CallbackContext context)
    {

        if (context.performed && IsGrounded())
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);

        }

        if (context.canceled && rb.velocity.y > 0f)
        {

            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

        }

    }






    public void WalkOffTimer()
    {
        walkOff = false;
    }

    public void Wait()
    {
        Cut = true;
    }

    public void WaitShit()
    {
        saltoTocou = false;
        kickTocou = false;
        quacktocou = false;
    }
    public void SXS()
    {
        somRise.Play();
        CM.m_Follow = this.gameObject.transform;
        On = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":

                JJ = true;
                break;

            case "Dumb":

                JJ = true;
                break;

            case "Box":
                JJ = true;
                break;

            case "Trash":

                Destroy(collision.gameObject);
                Invoke("Died", 0.1f);
                vivo = false;

                break;


        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.gameObject.tag)
        {

            case "Fall":

                vivo = false;
                Invoke("Died", 0.1f);

                break;

            case "H1":

                Txtx.gameObject.transform.position = new Vector3(204.48f, 0, 0);
                tp.FinalText = "Oinc, Hello there!";
                tp.Star();
                Cut = true;
                On = false;

                break;


            case "H2":

                Txtx.gameObject.transform.position = new Vector3(474.21f, 0.3f, 0);
                tp.FinalText = "Ho ho ho";
                tp.Star();
                Cut = true;
                On = false;

                break;


            case "H3":

                Txtx.gameObject.transform.position = new Vector3(861.14f, -1.83f, 0);
                tp.FinalText = "Oh!";
                tp.Star();
                Cut = true;
                On = false;

                break;



        }
    }

    public void Died()
    {

        somMorte.Play();

        vivo = true;

        switch (Fase)
        {

            case 1:
                this.gameObject.transform.position = new Vector3(21f, 0f, 0f);
                break;
            case 2:
                this.gameObject.transform.position = new Vector3(212f, 0f, 0f);
                break;
            case 3:
                this.gameObject.transform.position = new Vector3(484f, 0f, 0f);
                break;


        }

    }
    
}
