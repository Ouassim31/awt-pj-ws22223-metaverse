using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorsControll : MonoBehaviour
{
    public GameObject OpenAnimObj;  //���Ŷ�������
    public GameObject OpenErrorPanel; //����UI
    public GameObject endKey;  //��������

    public bool IsReady;
    // Start is called before the first frame update
    void Awake()
    {
        IsReady = false;
        OpenAnimObj = this.gameObject;
        gameObject.tag = "Door";
        OpenErrorPanel.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(LockCursor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// ����
    /// </summary>
    public void OpenTheDoor()
    {
        if (GameLogic.instance.Keys!=0&&IsReady)
        {
            OpenDoorAnim();
            GameLogic.instance.Keys = 0;
            GameLogic.instance.Doors[GameLogic.instance.ReadyIndex].GetComponent<DoorsControll>().IsReady = true;
           if (GameLogic.instance.ReadyIndex<GameLogic.instance.Doors.Length-1)
            {
                GameLogic.instance.ReadyIndex++;
            }
            
        }
        else
        {
            OpenErrorPanel.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
    /// <summary>
    /// ���Ŷ���
    /// </summary>
    public void OpenDoorAnim()
    {
        OpenAnimObj.transform.GetComponent<Animator>().SetTrigger("Activate2");
        this.GetComponent<BoxCollider>().enabled = false;
    }

    /// <summary>
    /// �������
    /// </summary>
    public void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
