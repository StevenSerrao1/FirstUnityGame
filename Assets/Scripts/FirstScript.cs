using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstScript : MonoBehaviour
{
    // [SerializeField] can be used to make a private variable visible in the Unity editor
    [SerializeField] private float _speed = 8.0f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.13f;
    [SerializeField] private float _canFire = -1.0f;
    [SerializeField] private int _lives = 3;
    
    
    // Start is called before the first frame update
    void Start()
    {

        // Take the current position and initiate it at (0, 0, 0)
        transform.position = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        // Method for movement
        CalculateMovement();

        // method for cooldown system of firing
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

        Debug.Log("You have: " + _lives + "lives left");
    }

    void CalculateMovement()
    {
        // Read keys to determine movement

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // GOING UP AND DOWN AND LEFT AND RIGHT

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);

        // Setting vertical movement bounds for the player

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.2f, 1.1f), 0);

        // The code below allows for player wrapping! When moving far enough left/right, the player pops out on the opposite x-axis!

        if (transform.position.x >= 13.5f)
        {
            transform.position = new Vector3(-13.4f, transform.position.y, 0);
        }
        else if (transform.position.x <= -13.5f)
        {
            transform.position = new Vector3(13.4f, transform.position.y, 0);
        }
    }

    void FireLaser()
    {
       _canFire = Time.time + _fireRate;
       Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.9f, 0), Quaternion.identity);
    }

    public void Damage()
    {
        this._lives--;
        if (this._lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
