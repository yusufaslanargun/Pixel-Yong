using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{  
    private int applesCollected = 0;
    private int bananasCollected = 0;
    private int cherriesCollected = 0;
    private int kiwisCollected = 0;
    private int melonsCollected = 0;
    private int orangesCollected = 0;
    private int pineapplesCollected = 0;
    private int strawberriesCollected = 0;
    private int fruitsCollected = 0;

    [SerializeField]
    private AudioSource itemCollectSound;

    [SerializeField]
    private Text collectiblesText;

    private void Awake()
    {
        collectiblesText.text = "Fruits: " + fruitsCollected;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            applesCollected++;
        }
        else if (collision.gameObject.CompareTag("Banana"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            bananasCollected++;
        }
        else if (collision.gameObject.CompareTag("Cherry"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            cherriesCollected++;
        }
        else if (collision.gameObject.CompareTag("Kiwi"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            kiwisCollected++;
        }
        else if (collision.gameObject.CompareTag("Melon"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            melonsCollected++;
        }
        else if (collision.gameObject.CompareTag("Orange"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            orangesCollected++;
        }
        else if (collision.gameObject.CompareTag("Pineapple"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            pineapplesCollected++;
        }
        else if (collision.gameObject.CompareTag("Strawberry"))
        {
            if (PlayerPrefs.GetInt("soundEffects") == 1) itemCollectSound.Play();
            Destroy(collision.gameObject);
            strawberriesCollected++;
        }
        fruitsCollected = applesCollected + bananasCollected + cherriesCollected + kiwisCollected + melonsCollected + orangesCollected + pineapplesCollected + strawberriesCollected;
        if(collectiblesText != null) collectiblesText.text = "Fruits: " + fruitsCollected;
    }
}
