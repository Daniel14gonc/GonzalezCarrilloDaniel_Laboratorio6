using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rb;
    private Animator animator;
    private float force;
    private bool kill = false;
    public GameObject panel;
    public SpriteRenderer sprite;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        force = 7.2f;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (rb)
        {
            if (Input.GetKeyDown(KeyCode.Space) && (Mathf.Abs(rb.velocity.y) <= 0.05f))
            {
                Sounds.playJump();
                rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            }
            bool isJumping = (Mathf.Abs(rb.velocity.y) <= 0.05f) ? false : true;
            animator.SetBool("isJumping", isJumping);
            if (isJumping)

                animator.SetFloat("Speed", 0);
        }
        
    }

    private void FixedUpdate()
    {
        if (rb)
        {
            float move = Input.GetAxis("Horizontal");
            if(move<0)
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            else
                transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            rb.AddForce(new Vector2(move * 6, 0));
            animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
            
        }
            
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("KillArea"))
        {
            Sounds.playDie();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            if (ScoreManager.getScore() >= 2)
            {
                Sounds.playEnemyDeath();
                panel.SetActive(false);
                Destroy(collision.gameObject);
            }
            else
            {
                Sounds.playDie();
                Destroy(gameObject);
            }
        }
        else if (collision.CompareTag("PowerUp"))
        {

            Sounds.playBoost();
            ScoreManager.setScore(ScoreManager.getScore() + 1);
            Destroy(collision.gameObject);
            if (ScoreManager.getScore() == 2 && !kill)
            {
                sprite.color = Color.green;
                panel.SetActive(true);
                Sounds.playFinishHim();
                kill = true;
            }
        }
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(10.0f);
    }
}
