using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    float velocity;
    float amplitude;
    Vector3 pos;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        velocity = 2.0f;
        amplitude = 1.0f;
        pos = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float changeX = amplitude * Mathf.Sin(Time.time * velocity);
        Vector3 change = new Vector3(changeX, 0, 0);
        float direction = (changeX > 0)? 1 : -1;
        //Modificacion de la posicion del Game Object
        transform.position = pos + change;
        transform.localScale = new Vector3(direction*Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        animator.SetFloat("Speed", Mathf.Abs(velocity));
    }
}
