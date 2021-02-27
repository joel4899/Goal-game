using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Player : MonoBehaviour
{ 
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float padding = 0.7f;

    [SerializeField] GameObject goalPrefab;

    [SerializeField] float FootballshootingTime = 2f;



    float xMin, xMax, yMin, yMax;

    Coroutine fireCoroutine;

    bool coroutineStarted = false;

    void Start()
    {
        SetUpMoveBoundaries();
    }


    void Update()
    {
        Move();
        Fire();
    }

 
    private IEnumerator FireContinuously()
    {
        while (true) 
        {
    
            GameObject football = Instantiate(goalPrefab, transform.position, Quaternion.identity);
            football.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 15f);

            yield return new WaitForSeconds(FootballshootingTime);

        }
    }
     

    private void Fire()
    {
    
        if (Input.GetButtonDown("Fire1"))
        {
            if (!coroutineStarted)
            {
                fireCoroutine = StartCoroutine(FireContinuously());
                coroutineStarted = true;
            }
        }

   
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCoroutine);
            coroutineStarted = false;
        }
    }

   
    private void SetUpMoveBoundaries()
    {
        
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;


        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }


    private void Move()
    {
    
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed ; 
        var newXPos = transform.position.x + deltaX;
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);


        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        var newYPos = transform.position.y + deltaY;
        newYPos = Mathf.Clamp(newYPos, yMin, yMax);

        this.transform.position = new Vector2(newXPos, newYPos);

        
            
    }

   

}
