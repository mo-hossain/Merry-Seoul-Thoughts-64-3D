﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BubberDucky : MonoBehaviour {

	private GameObject mikeMan;
    public Rigidbody2D rB;
	public float enemySpeed = 1.7f;
    public int xMoveDirection;
	public int yMoveDirection = 1;
	public float mikeRaycast = .2f;
	public Rigidbody projectile;

    void Start()
    {
        rB = gameObject.GetComponent<Rigidbody2D>();
        InvokeRepeating("JumpMikeJump", 1.0f, 1.3f);
    }

    void JumpMikeJump()
    {
       	gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 700);
		gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 500);
    }


    // Update is called once per frame
    void Update () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0) * enemySpeed;
	}

    void OnCollisionEnter(Collision collision)
  {
      if (collision.gameObject.tag == "Obstacle")
      {
          
      }
  }
}

