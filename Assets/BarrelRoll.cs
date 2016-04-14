﻿using UnityEngine;
using System.Collections;

public class BarrelRoll : MonoBehaviour {

    private PlayerController player;
    Rigidbody2D rb2d;
    public float rollSpeed;
    public float moveSpeed;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        rb2d.velocity = new Vector2(-moveSpeed, 0);

        if (transform.position.x < -100)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(1);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //player.TakeDamage(-1);
        }
    }
}