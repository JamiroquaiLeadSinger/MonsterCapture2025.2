using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public struct ScoreData
{
    public string name;
    public int score;
}

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TMP_Text scoreText;
    public int currentScore = 0;

    public List<ScoreData> scores = new List<ScoreData>();
    public int maxScores = 10;

    public TMP_Text scorePrefab;
    public Transform scoreParent;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateGUI()
    {
        scoreText.text = "Score: " + currentScore;
    }

    [ContextMenu("Update High Score")]
    public void UpdateHighScores()
    {
        DestroyAllChildren(scoreParent);

        foreach(var score in scores)
        {
            TMP_Text text = Instantiate(scorePrefab, scoreParent);
            text.text = score.name + ": " + score.score;
        }
    }

    private void DestroyAllChildren(Transform parent)
    {
        Transform[] children = scoreParent.GetComponentsInChildren<Transform>(true);
        for (int i = children.Length - 1; i >= 0; i--)
        {
            if (children[i] == parent.transform) continue;
            if (Application.isEditor)
            {
                DestroyImmediate(children[i].gameObject);
            }
            else
            {
                Destroy(children[i].gameObject);
            }
        }
    }

    bool isDisplaying = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (isDisplaying)
            {
                DestroyAllChildren(scoreParent);
            }
            else
            {
                UpdateHighScores();
            }
            isDisplaying = !isDisplaying;
        }
    }

    [ContextMenu("Add Random Score")]
    public void AddHighScore()
    {
        int randomScore = UnityEngine.Random.Range(0, 1000);
        AddHighScore(randomScore);
    }

    public void AddHighScore(int score)
    {
        string[] possible = new[] { "GGX", "SF3", "KOF", "XRD", "SFV", "MVC", "TF2", "BOI", "UNI", "MBAACC" };
        string randomName = possible[UnityEngine.Random.Range(0, possible.Length)];
        AddHighScore(randomName, score);
    }

    public void AddHighScore(string name, int score)
    {
        // Could also use array.Sort()

        RemoveScoresPastMax();

        if (scores.Count == 0)
        {
            scores.Add(new ScoreData { name = name, score = score });
            return;
        }

        for(int i = 0; i < scores.Count; i++)
        {
            if(score > scores[i].score)
            {
                scores.Insert(i, new ScoreData() { name = name, score = score });
                if(scores.Count > maxScores)
                {
                    scores.RemoveAt(scores.Count - 1);
                }
                return;
            }
        }
    }

    void RemoveScoresPastMax()
    {
        for(int i = scores.Count - 1; i >= maxScores; i--)
        {
            scores.RemoveAt(i);
        }
    }
}
