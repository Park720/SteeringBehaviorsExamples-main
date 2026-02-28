using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TagPlayer : MonoBehaviour
{
    public Material it_material;

    public Material notit_material;

    public TextMeshProUGUI scoreText;
    
    public TextMeshProUGUI gameOverText;

    private float _notit_time;

    private float _timer=0;

    public float playTime = 60;

    public bool isIt = true;

    private bool playing = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playing)
        {
            return;
        }
        //track game time
        _timer += Time.deltaTime;
        if (_timer > playTime)
        {
            playing = false;
            gameOverText.enabled = true;
        }

        //track notit time
        if (!isIt)
        {
            _notit_time += Time.deltaTime;
        }

        int score = (int)_notit_time * 200;
        scoreText.text = "Score: " + score.ToString();
    }

    public void OnCollisionEnter(Collision collision)
    {
        TagOpponent other = collision.gameObject.GetComponent<TagOpponent>();
        if (other == null) //didint hit an opponent
        {
            return;
        }
        TagOpponent opponent  = other.GetComponentInChildren<TagOpponent>();
        if (other != null && isIt) // Only the person who IS "It" can tag
        {
            // I am no longer it
            isIt = false;
            GetComponent<Renderer>().material = notit_material;

            // The other person IS now it
          
            opponent.isIt = true; 
            other.GetComponent<Renderer>().material = it_material;
            
        } else if ((other!=null)&&(opponent.isIt))
        {
          
            // I am it
            isIt = true;
            GetComponent<Renderer>().material = it_material;

            // The other person IS now it
            opponent.isIt = false; 
            other.GetComponent<Renderer>().material = notit_material;
        }
    }
}
