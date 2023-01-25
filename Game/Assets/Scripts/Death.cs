using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Death : MonoBehaviour
{
    private WaterLevel waterLevel;
    [SerializeField] GameObject DeathScreen;
    [SerializeField] TextMeshProUGUI DeathTextUI;
    [SerializeField] string[] DeathTextList;

    void Start()
    {
        waterLevel = GetComponent<WaterLevel>();
    }

    void Update()
    {
       if (waterLevel.waterAmount <= 0)
        {
            GameObject.Find("Player").GetComponent<PlayerMovement>().isdead = true;
            DeathScreen.SetActive(true);
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.E) && DeathScreen.activeSelf)
        {
            transform.position = new Vector2(0, 0);
            DeathScreen.SetActive(false);
            DeathTextUI.text = DeathTextList[ Random.Range(0, DeathTextList.Length)];
            Time.timeScale = 1;
            waterLevel.waterAmount = 100;
            GameObject.Find("Player").GetComponent<PlayerMovement>().isdead = false;
        }
    }
}
