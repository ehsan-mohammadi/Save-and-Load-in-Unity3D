using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using System;

public class GameController : MonoBehaviour {

    private int score = 0;
    private int highscore = 0;

    public Text txtScore;
    public Text txtHighscore;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}

    public void SetScore(int point)
    {
        score += point;
        txtScore.text = score.ToString();

        if (score > highscore)
        {
            highscore = score;
            txtHighscore.text = highscore.ToString();
        }
    }

    public void SetInfo(GameInfo info)
    {
        highscore = info.highscore;
        txtHighscore.text = highscore.ToString();

        score = info.score;
        txtScore.text = score.ToString();

        Vector3 playerPos = new Vector3(info.x,info.y,info.z);
        GameObject.Find("Player").transform.position = playerPos;
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highscore;
    }
}

[Serializable]
public class GameInfo
{
    public int highscore;
    public int score;
    public float x;
    public float y;
    public float z;

    public GameInfo(int _HighScore, int _Score, Vector3 _PlayerPos)
    {
        highscore = _HighScore;
        score = _Score;
        x = _PlayerPos.x;
        y = _PlayerPos.y;
        z = _PlayerPos.z;
    }
}
