using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerScript : MonoBehaviour
{
    
    private Rigidbody2D rd2d;

    public float speed;

    public float jumpForce;

    public Text score;

    private bool facingRight = true;

    private bool isOnGround;

    public Transform groundcheck;
    
    public float checkRadius;

    public LayerMask allGround;

    private int scoreValue = 0;

    private int lives;

    public GameObject winTextObject;

    public GameObject loseTextObject;

    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();

        SetAllText();
        winTextObject.SetActive(false);

        lives = 3;
        SetAllText();
        loseTextObject.SetActive(false);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        if (facingRight == false && hozMovement > 0)
        {
            Flip();

        }

        else if (facingRight == true && hozMovement < 0)
        {
            Flip();

        }

        if (Input.GetKey("escape"))
        {
        Application.Quit();
        }
    }

void SetAllText()
{
    livesText.text = "Lives:" + lives.ToString();
        if (lives == 0)
        {
            loseTextObject.SetActive(true);
        }

    if(scoreValue == 8)
        {
            winTextObject.SetActive(true);
        }
}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);
        }

        else if (collision.collider.tag == "Enemy")
        {
            lives = lives - 1;
            SetAllText();
            Destroy(collision.collider.gameObject);
        }

        if (scoreValue == 4)
        {
            transform.position = new Vector2(95.0f,2.0f);
        }

        if (lives == 0)
        {
            Destroy(this);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground" && isOnGround)
        {
            if(Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0,jumpForce), ForceMode2D.Impulse);
            }
        }
    }

void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }
}
