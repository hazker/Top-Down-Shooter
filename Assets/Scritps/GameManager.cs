using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform humanSpawn;
    public Transform cpuSpawn;

    public HumanController human;
    public CPUController cpu;

    public Text text;

    public static GameManager instance;
    public Texture2D sprite;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }
        NewGame();
        Cursor.SetCursor(sprite, Vector2.zero, CursorMode.Auto);
    }

    public void NewGame()
    {
        AllowToMove(false);
        foreach (var item in GameObject.FindGameObjectsWithTag("Bullet"))
        {
            Destroy(item);
        }
        StartCoroutine(CountDownToNewGame());
        human.transform.position = humanSpawn.position;
        cpu.transform.position = cpuSpawn.position;
    }

    void AllowToMove(bool b)
    {
        cpu.MovSpeed(b);
        human.canMove = b;
        
    }

    IEnumerator CountDownToNewGame()
    {
        for (int i = 3; i > 0; i--)
        {
            text.text = "Game will start in " + i;
            yield return new WaitForSecondsRealtime(1f);
        }
        text.text = "";
        AllowToMove(true);
    }
}
