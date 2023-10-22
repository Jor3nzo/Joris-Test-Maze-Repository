using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnPoint;
    public float speed;
    public GameObject jumpscareImage;
    public AudioSource jumpscareSound;


    void Start()
    {
        Cursor.visible = false;
        jumpscareSound = GetComponent<AudioSource>();
    }

        void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        var finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {


        if (collision.gameObject.name.Contains("Wall"))
        {
            transform.position = spawnPoint.transform.position;

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Jumpscare"))
        {
            jumpscareImage.SetActive(true);
            Time.timeScale = 0;
            jumpscareSound.Play();
        }
    }
}


