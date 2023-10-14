using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    public GameObject CoinSpawner;
    public Movement PMovement;
    public Rigidbody rb;
    public Animator anim;
    public GameObject WinOverlay;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    public void OnTriggerEnter(Collider collision)
    {
        if(collision.GetComponent<BoxCollider>().CompareTag("Finish"))
            {
            CoinSpawner.SetActive(false);
            PMovement.enabled = false;
            anim.SetBool("Run", false);
            anim.SetBool("Win", true);
        }
    }

    public void FixedUpdate()
    {
       
    }

    public void ShowUIAfterWinAnimation()
    {
        WinOverlay.SetActive(true);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


}
