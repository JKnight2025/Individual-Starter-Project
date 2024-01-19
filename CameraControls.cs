using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CameraControls : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    // public float timeLeft = 10f;

    // public Text countdownText;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Turn off code
        //timeLeft -= Time.deltaTime;
        //countdownText.text = (timeLeft).ToString("0");
        //if (timeLeft < 0)
        //{
            //countdownText.text = "Time's Up!";
            //audioSource.Stop();
        //}
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
