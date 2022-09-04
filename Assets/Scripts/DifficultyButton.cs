using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);//when clicked, execute setdifficulty
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty(){
        Debug.Log(button.gameObject.name);
        gameManager.StartGame(difficulty);
    }
}
