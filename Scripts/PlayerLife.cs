using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public int checkpointIndex = 0;
    private bool reachedCheckpoint = false;
    private bool isAlive = true;
    [SerializeField]
    private GameObject[] checkpoints;
    [SerializeField]
    private float deathHeight = -5f;
    [SerializeField]
    private AudioSource deathSoundEffect;
    [SerializeField]
    private AudioSource checkpointSoundEffect;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        if (checkpoints.Length > 0)
        {
            foreach (GameObject checkpoint in checkpoints)
            {
                checkpoint.SetActive(false);
            }
            checkpoints[0].SetActive(true);
        }
    }

    private void Update()
    {
        if (this.gameObject.transform.position.y < deathHeight && isAlive)
        {
            Die();
            isAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) checkpointSoundEffect.Play();
            reachedCheckpoint = true;
            if (checkpointIndex < checkpoints.Length)
            {
                checkpoints[checkpointIndex].SetActive(false);
                checkpointIndex++;
                checkpoints[checkpointIndex].SetActive(true);
            }
        }
    }

    private void Die()
    {
        if (PlayerPrefs.GetInt("soundEffects") == 1) deathSoundEffect.Play();
        anim.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLevel()
    {
        if (reachedCheckpoint)
        {
            transform.position = checkpoints[checkpointIndex - 1].transform.position;
            rb.bodyType = RigidbodyType2D.Dynamic;
            anim.SetTrigger("respawn");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        isAlive = true;
    }
}
