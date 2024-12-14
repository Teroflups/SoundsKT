using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI HPText;
    [SerializeField] private int HP;
    [SerializeField] private GameObject Panel;
    void Start()
    {
        Time.timeScale = 1.0f;  
    }

    
    void Update()
    {
        if (HP <= 0)
        {
            Panel.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void TakeDamage(float damage)
    {
        HP--;
        HPText.text = HP.ToString();

    }
   
    public void ReStart()
    {
        SceneManager.LoadScene(0);
    }
    
}
