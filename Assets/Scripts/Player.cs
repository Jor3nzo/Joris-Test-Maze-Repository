using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject spawnPoint;
    public float speed;

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

}
