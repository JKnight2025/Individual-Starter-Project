using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpForce = 5f;
    public Text EmeraldsText;
    public Text WinText;
    public Text AnnouncementText;
    public float timeLeft = 10f;
    public Text countdownText;
    public AudioClip audioClip;
    public AudioClip audioClipOne;
    public AudioClip audioClipTwo;
    public AudioClip audioClipThree;
    private AudioSource audioSource;
    private Rigidbody2D rb;
    public int Emeralds = 5;
   
    
     void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        SetEmeraldsText();
        WinText.text = "";
        AnnouncementText.text = "Collect 5 Emeralds";
        Invoke("DisableText", 2f);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.right * -moveSpeed * Time.deltaTime;
        }
       
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        void Jump()
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        timeLeft -= Time.deltaTime;
        countdownText.text = (timeLeft).ToString("0");
        if (timeLeft < 0)
        {
            countdownText.text = "Time's Up!";
            audioSource.Stop();
            WinText.text = "You Lose!";
            audioSource.clip = audioClipThree;
            audioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive(false);
            Emeralds = Emeralds + 1;
            SetEmeraldsText();
            audioSource.clip = audioClipOne;
            audioSource.Play();
            if (Emeralds >= 5)
            {
                WinText.text = "You Win!";
                // Play Win music
                // audioSource.Stop();
                audioSource.clip = audioClipTwo;
                audioSource.Play();
            }
        }

    }

    void SetEmeraldsText()
    {
        EmeraldsText.text = "Emeralds " + Emeralds.ToString();
    }

    void DisableText()
    {
        AnnouncementText.enabled = false;
        audioSource.Stop();
    }
}
    
