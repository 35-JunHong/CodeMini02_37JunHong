using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float speed = 5.0f;
    Rigidbody playerRb;

    public GameObject movingCube;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);


        if (col == 1)
        {
            FollowCube();
        }

        PlayerJump();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("StartCube"))
        {

        }

        if (collision.gameObject.CompareTag("MovingCube"))
        {
            col = 1;
        }

    }

    void FollowCube()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, movingCube.transform.position.z);
    }

    void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);
        }
    }
}
