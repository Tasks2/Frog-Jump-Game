using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFrog : MonoBehaviour
{

    public int TotalScore;

    [SerializeField]
    GameObject SmokeEffect;
    [SerializeField]
    GameObject WaterEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        TotalScore = PlayerPrefs.GetInt("Score", 0);
        TotalScore++;

        PlayerPrefs.SetInt("Score", TotalScore);
        PlayerPrefs.Save();

        Debug.Log("Score" + TotalScore.ToString());

        Destroy(gameObject);
        //the prefab, the position of the instatiate prefab, rotation of instantiated prefab
        Instantiate(SmokeEffect, transform.position, Quaternion.identity);
    }
    private void OnCollisionEnter2D(Collision2D collision)

    {
        if(collision.gameObject.tag == "lake")
        {
            Destroy(gameObject);

            Instantiate(WaterEffect, transform.position, Quaternion.identity);
        }
        
    }

}
