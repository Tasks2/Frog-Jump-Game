using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Spawn : MonoBehaviour
{
    [SerializeField]
    GameObject Frog;

    [SerializeField]
    TextMeshProUGUI scoreText;

    public int TotalScore;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(spawningFrog());
    }

    // Update is called once per frame
    void Update()
    {
        TotalScore = PlayerPrefs.GetInt("Score", 0);
        scoreText.text = "Score: " + TotalScore.ToString();
    }


    IEnumerator spawningFrog()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.8f);

            // Get the screen bounds in world coordinates
            Vector2 screenBottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
            Vector2 screenTopRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

            // Generate a random number between the bottom-left and top-right corners of the screen
            float posX = Random.Range(screenBottomLeft.x, screenTopRight.x);
            float posY = Random.Range(screenBottomLeft.y, screenTopRight.y);

            // Store the random position in a Vector2
            Vector2 spawnPosition = new Vector2(posX, posY);

            // Instantiate the frog in the generated position
            Instantiate(Frog, spawnPosition, Quaternion.identity);
        }
    }



}
