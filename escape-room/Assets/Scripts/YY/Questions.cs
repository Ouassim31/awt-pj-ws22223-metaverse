using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Questions : MonoBehaviour
{
    public GameObject QuestionUI;
    public GameObject GetKeyUI;
    public GameObject ErrorUI;
    public GameObject OpenDoor;
    private void Awake()
    {
    }
    // Start is called before the first frame update
    void Start()
    {
        QuestionUI.transform.Find("right").GetComponent<Button>().onClick.AddListener(AnswerRight);

        for (int i = 0; i < QuestionUI.transform.childCount; i++)
        {
            if (QuestionUI.transform.GetChild(i).name=="error")
            {
                QuestionUI.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(AnswerError);
            }
            if (QuestionUI.transform.GetChild(i).name == "try")
            {
                QuestionUI.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(TryAgain);
            }
        }
        ErrorUI.transform.GetComponent<Button>().onClick.AddListener(LockCursor);
        GetKeyUI.transform.GetComponent<Button>().onClick.AddListener(LockCursor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 开启问题
    /// </summary>
    public void OpenQuestion()
    {
        QuestionUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameLogic.instance.Player.SetActive(false);
        
    }
    /// <summary>
    /// 回答正确
    /// </summary>
    public void AnswerRight()
    {
        QuestionUI.SetActive(false);
        print("关掉");
        GameLogic.instance.Keys = 1;
        GetKeyUI.SetActive(true);
        this.GetComponent<BoxCollider>().enabled = false;
    }
    /// <summary>
    /// 回答错误
    /// </summary>
    public void AnswerError()
    {
        QuestionUI.SetActive(false);
        ErrorUI.SetActive(true);
    }
    /// <summary>
    /// 关闭面板
    /// </summary>
    public void TryAgain()
    {
        QuestionUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameLogic.instance.Player.SetActive(true);
    }
    /// <summary>
    /// 隐藏鼠标
    /// </summary>
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
