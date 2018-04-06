using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public int maxScore = 3;
    private bool preventInput = false;
    private bool end;
    public float speed;
    int hit = 0;
    public int speedLevel = 1;
    Rigidbody rb;
    AudioSource p1Audio;
    AudioSource p2Audio;
    AudioSource ballAudio;
    AudioSource[] audioSources;
    GameObject startText;
    GameObject score;
    GameObject scoresMessage;
    Text scoresText;

    // Use this for initialization
    void Start () {
        speed = 0;
        end = false;
        rb = GetComponent<Rigidbody>();
        audioSources = GetComponents<AudioSource>();
        p1Audio = audioSources[0];
        p2Audio = audioSources[1];
        ballAudio = audioSources[2];
        startText = GameObject.Find("start_text");
        score = GameObject.Find("score");
        scoresMessage = GameObject.Find("scores_message");
        scoresText = scoresMessage.GetComponentInChildren<Text>();
        scoresMessage.SetActive(false);
    }

    void NewGame()
    {
        scoresMessage.SetActive(false);
        score.GetComponent<Score>().ResetScore();
        StartCoroutine(ReloadGame(1));
    }
    
    void Reset()
    {
        speed = 0;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        startText.SetActive(true);
    }

    void Init()
    {
        startText.SetActive(false);
        speed = 10.0f;
        rb.velocity = new Vector3(speed, 0.0f, 0.0f);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKey(KeyCode.Space) && speed == 0 && !preventInput)
        {
            if (end) NewGame();
            else Init();
        }
    }

    void OnCollisionEnter (Collision collision)
    {
        if (collision.gameObject.name == "wall")
        {
            ballAudio.Play();
        }
        else if (collision.gameObject.name == "wall_center")
        {
            ballAudio.Play();
        }
        else if (collision.gameObject.name == "player1") 
        {
            p1Audio.Play();
            hit++;

            float z = Hitpart(transform.position, collision.transform.position);
            Vector3 vec = new Vector3(speed, 0.0f, z*4).normalized;
            rb.velocity = vec * speed;
            
            if (hit != 0 && hit % 2 == 0)
            {
                speed += 1.0f;
                speedLevel++;
            }
        }
        else if (collision.gameObject.name == "player2")
        {
            p2Audio.Play();
            hit++;

            float z = Hitpart(transform.position, collision.transform.position);
            Vector3 vec = new Vector3(-speed, 0.0f, z*4).normalized;
            rb.velocity = vec * speed;

            if (hit != 0 && hit % 2 == 0)
            {
                speed += 1.0f;
                speedLevel++;
            }
        }
        else if (collision.gameObject.name == "wall_back_1")
        {
            score.GetComponent<Score>().IncreaseScore(2);
            if (score.GetComponent<Score>().GetScore(2) == maxScore)
            {
                EndGame(2);
            }
            else
            {
                StartCoroutine(ShowMessage("L'IA a marqué !", 1));
                Reset();
            }
        }
        else if (collision.gameObject.name == "wall_back_2")
        {
            score.GetComponent<Score>().IncreaseScore(1);
            if (score.GetComponent<Score>().GetScore(1) == maxScore)
            {
                EndGame(1);
            }
            else
            {
                StartCoroutine(ShowMessage("Vous avez marqué !", 1));
                Reset();
            }
        }

    }

    private void EndGame(int player)
    {
        end = true;
        Reset();
        String msg = player == 1 ? "Bravo ! Vous avez remporté la partie !" : "L'IA remporte la partie ! Vous êtes nul !";
        msg += "\nEspace pour nouvelle partie";
        ShowVictory(msg);
    }

    float Hitpart(Vector3 ballPosition, Vector3 paddlePosition)
    {
        return (ballPosition.z - paddlePosition.z);
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        preventInput = true;
        scoresText.text = message;
        scoresMessage.SetActive(true);
        yield return new WaitForSeconds(delay);
        scoresMessage.SetActive(false);
        preventInput = false;
    }
    private IEnumerator ReloadGame(int delay)
    {
        yield return new WaitForSeconds(delay);
        end = false;
    }


    private void ShowVictory(string message)
    {
        scoresText.text = message;
        scoresMessage.SetActive(true);
    }

}
