using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI myScore;
    // Start is called before the first frame update
    void Start()
    {
        myScore = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string temp = GameManager._shared.score.ToString() + "\n" + GameManager._shared.highscore.ToString();
        myScore.text = temp;
    }
}
