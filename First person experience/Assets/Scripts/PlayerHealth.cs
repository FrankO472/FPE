using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public float maxhealth;
    public Slider healthSlider;
    // Start is called before the first frame update
    void Start()
    {
        health = maxhealth;
        healthSlider.maxValue = maxhealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = health;
        if (health <= 0)
        {
            health = maxhealth;
            GameOver();
        }
    }


    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
