using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    public GameObject[] Doors;
    public int ReadyIndex;

    public GameObject Player;
    public static GameLogic instance;
    public int Keys;
    public GameObject EndGamePanel;
    private void Awake()
    {
        instance = this;
        ReadyIndex = 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        Doors[ReadyIndex].GetComponent<DoorsControll>().IsReady = true;
        ReadyIndex++;
    }
    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        if (!Player.gameObject.activeInHierarchy)
        {
            return;
        }
       else if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Screen.width/2, Screen.height/2,100)), out hit);
            if (hit.collider != null)
            {
                print(hit.collider);
                if (hit.collider.tag == "Question")
                {
                    hit.collider.GetComponent<Questions>().OpenQuestion();
                }
                if (hit.collider.tag == "Door")
                {
                    hit.collider.GetComponent<DoorsControll>().OpenTheDoor();
                }
            }
        }
        
        
    }
    /// <summary>
    /// 游戏结束
    /// </summary>
    public void EndGame()
    {
        EndGamePanel.SetActive(true);
        EndGamePanel.transform.GetChild(0).GetComponent<Button>().onClick.AddListener(QuitGame);
    }
    /// <summary>
    /// 重新开始
    /// </summary>
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
