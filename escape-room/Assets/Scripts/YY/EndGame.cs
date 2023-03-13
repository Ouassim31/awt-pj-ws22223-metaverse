using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            GameLogic.instance.EndGame();
            Cursor.lockState = CursorLockMode.Confined;
            GameLogic.instance.Player.SetActive(false);
            print("”Œœ∑Ω· ¯");
        }
    }

}
