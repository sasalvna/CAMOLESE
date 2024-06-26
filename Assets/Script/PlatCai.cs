using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatCai : MonoBehaviour
{
    Rigidbody2D rig;

    public float delay = 5f;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    IEnumerator Queda()
    {
        yield return new WaitForSeconds(0.5f);
        rig.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, delay);
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Queda");
        }
    }
}
