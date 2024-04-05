using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rig;
    [SerializeField] private int speed;
    public int jumpForce;
    bool PodePular = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Movi();
        Jump();

    }
    void Movi()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && PodePular == true)
        {
            rig.velocity = Vector2.up * jumpForce;
            PodePular = false;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Chao")
        {
            PodePular = true;
        }
        else
        {
            PodePular = false;
        }

        if (collision.gameObject.tag == "plataforma")
        {
            PodePular = true;
        }
        else
        {

        }


    }













}
