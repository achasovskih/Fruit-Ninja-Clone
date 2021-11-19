using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject pause;
    public AudioClip[] sliceSounds;
    public AudioClip gameOverSound;
    private AudioSource audioSourse;
    public int score;
    public int highscore;

    private void Start()
    {
        audioSourse = GetComponent<AudioSource>();
        Time.timeScale = 1f;
        pause.SetActive(false);
        GetHighscore();
    }

    public void IncreaseScore(int addedPoints)
    {
        score += addedPoints;

        scoreText.text = score.ToString();

        spawner.DifficultyCheck();

        if (score > highscore)
        {
            PlayerPrefs.SetInt("Highscore", score);
            highScoreText.text = "Best: " + score.ToString();
        }
    }

    public void OnBombHit()
    {
        Time.timeScale = 0;
        pause.SetActive(true);
        audioSourse.PlayOneShot(gameOverSound);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void GetHighscore()
    {
        highscore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "Best: " + highscore.ToString();
    }

    public void PlaySliceSound()
    {
        audioSourse.PlayOneShot(sliceSounds[Random.Range(0, sliceSounds.Length)]);
    }

    public void DeleteScore()
    {
        PlayerPrefs.DeleteAll();
    }

}
