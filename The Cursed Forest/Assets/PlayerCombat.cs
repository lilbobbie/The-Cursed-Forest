using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject arrowPrefab;
    Vector2 movement;

    public AudioClip shootingSound;

    public bool isShooting = false;
    public float timeBetweenShots = 2.6f;
    public bool allowButtonHold = true;
    public bool allowInvoke = true;
    public bool shooting;
    public Image reloadBar;
    private float timer = 0f;

    private void Start()
    {
        reloadBar.fillAmount = 0;
    }

    private void Update()
    {
        MyInput();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");  
        
        if(isShooting && !allowInvoke)
        {
            timer = timeBetweenShots;
            timer -= Time.deltaTime;
            float fraction = timer / timeBetweenShots;
            reloadBar.fillAmount += fraction / timeBetweenShots * Time.deltaTime;
        }
        else
        {
            timer = 0;
            reloadBar.fillAmount = 0;
        }
    }

    private void MyInput()
    {
        //Check if allowed to hold down button and take corresponding input
        if (allowButtonHold)
        {
            shooting = Input.GetButton("Fire1");
        }
        else
        {
            shooting = Input.GetButtonDown("Fire1");
        }        

        //Shooting
        if (shooting && !isShooting && GameManager.Instance.GetGameState() != GameState.Pause && GameManager.Instance.GetGameState() != GameState.Victory)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        isShooting = true;
        if (movement.x == 0 && movement.y < 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shootingSound);
            animator.SetTrigger("Attack");
            Instantiate(arrowPrefab, firePointDown.position, firePointDown.rotation);
            if (allowInvoke)
            {
                allowInvoke = false;
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        if (movement.x == 0 && movement.y > 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shootingSound);
            animator.SetTrigger("Attack");
            Instantiate(arrowPrefab, firePointUp.position, firePointUp.rotation);
            if (allowInvoke)
            {
                allowInvoke = false;
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        if (movement.x < 0 && movement.y == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shootingSound);
            animator.SetTrigger("Attack");
            Instantiate(arrowPrefab, firePointLeft.position, firePointLeft.rotation);
            if (allowInvoke)
            {
                allowInvoke = false;
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        if (movement.x > 0 && movement.y == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shootingSound);
            animator.SetTrigger("Attack");
            Instantiate(arrowPrefab, firePointRight.position, firePointRight.rotation);
            if (allowInvoke)
            {
                allowInvoke = false;
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        if (movement.x == 0 && movement.y == 0)
        {
            GetComponent<AudioSource>().PlayOneShot(shootingSound);
            animator.SetTrigger("Attack");
            Instantiate(arrowPrefab, firePointDown.position, firePointDown.rotation);
            if (allowInvoke)
            {
                allowInvoke = false;
                Invoke("ResetShot", timeBetweenShots);
            }
        }
        if(allowInvoke == true)
        {
            isShooting = false;
        }
    }
    void ResetShot()
    {
        allowInvoke = true;
        isShooting = false;
    }
}
