using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    public Color aqua;
    public Color yellow;
    public Color pink;
    public Color purple;
    public string currentColor;
    public float jumpForce = 3f;
    public Text score;
    private int scoreValue;
    public GameObject[] circle;
    public GameObject colorChanger;
    

    void Start()
    {
        scoreValue = 0;
        score.text = scoreValue.ToString();
        RandomBallColor();
        
    }

    
    void Update()
    {
        
        //Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Score")
        {
            scoreValue += 50;
            score.text = scoreValue.ToString();
            int randomCircle = Random.Range(0, 2);
            Instantiate(circle[randomCircle], new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z),transform.rotation);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ColorChanger")
        {
            RandomBallColor();
            Destroy(collision.gameObject);
            Instantiate(colorChanger, new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z), transform.rotation);
            return;
        }
        if (collision.gameObject.tag != currentColor && collision.gameObject.tag != "Score" && collision.gameObject.tag != "ColorChanger")  
        {
            SceneManager.LoadScene(0);
          //Destroy(gameObject);
        }
        
        
        
    }
    void RandomBallColor()
    {
        int randomNumber = Random.Range(0, 4);
        
        switch (randomNumber)
        {
            case 0 : currentColor = "Aqua";
                GetComponent<SpriteRenderer>().color = aqua;
                break;
            case 1:
                currentColor = "Yellow";
                GetComponent<SpriteRenderer>().color = yellow;
                break;
            case 2:
                currentColor = "Pink";
                GetComponent<SpriteRenderer>().color = pink;
                break;
            case 3:
                currentColor = "Purple";
                GetComponent<SpriteRenderer>().color = purple;
                break;
        }
    }
    
    
}
