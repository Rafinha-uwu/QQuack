using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject mutedIcon;
    public GameObject soundIcon;

    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject t2;
    public GameObject t3;
    public GameObject Con;
    public GameObject Play;
    public GameObject Exp;

    public AudioSource buttonSound;



    public bool muted = false;

    public float num = 1;

    public void Mute()
    {

        if (muted == false)
        {

            soundIcon.SetActive(false);
            mutedIcon.SetActive(true);

            this.GetComponent<AudioSource>().Stop();

            muted = true;

        }
        else
        {

            mutedIcon.SetActive(false);
            soundIcon.SetActive(true);

            this.GetComponent<AudioSource>().Play();

            muted = false;

        }

    }

    public void StartGame()
    {
        switch (num)
        {
            case 1:
                Play.SetActive(false);
                Exp.SetActive(false);
                Con.SetActive(true);
                break;
            case 2:

                p1.SetActive(false);

                p2.SetActive(true);
                t2.SetActive(true);
                break;
            case 3:

                p2.SetActive(false);
                t2.SetActive(false);

                p3.SetActive(true);
                t3.SetActive(true);
                break;
            case 4:

                SceneManager.LoadScene("Main stuff");

                break;

        }



    }

    public void QuitGame()
    {

        Application.Quit();

    }

    public void Continue()
    {

        num++;

    }

    public void ButtonSound()
    {

        buttonSound.Play();

    }

}
