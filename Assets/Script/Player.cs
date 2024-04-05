using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PLayer : MonoBehaviour
{
    [SerializeField][Range(1, 5)] private int Vida;

    [SerializeField][Range(1, 10)] private int speed;

    [SerializeField][Range(1, 20)] private int JumpForce;

    [SerializeField] private bool PodePular, DobleJump;

    Rigidbody2D rig;

    SpriteRenderer SR;

    CircleCollider2D circle;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Inicio de Jogo");
        rig = GetComponent<Rigidbody2D>();
        circle = GetComponent<CircleCollider2D>();
        SR = GetComponent<SpriteRenderer>();
        PodePular = false;
        DobleJump = false;

    }

    // Update is called once per frame
    void Update()
    {
        Movi();
        Jump();
        Morte();
    }
    void Movi()
    {
        rig.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rig.velocity.y);

    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!PodePular)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                DobleJump = true;
            }
            else
            {
                if (DobleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                    DobleJump = false;
                }
            }
        }
    }
    void Morte()
    {
        if (Vida == 0)
        {
            Debug.Log("Morreu");
           Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Espinho"))
        {
            Debug.Log("Perdeu Vida");
            Vida = Vida - 1;
        }

        if (colisao.gameObject.CompareTag("V2"))
        {
             Vida = 0;
        }

        if (colisao.gameObject.CompareTag("Plataforma"))
        {
            PodePular = false;
        }
    }

    private void OnCollisionExit2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Plataforma"))
        {
            PodePular = true;
        }
    }
}
