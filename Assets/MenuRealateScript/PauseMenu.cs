using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
     int press = 0;
     [SerializeField] GameObject cam;
     [SerializeField]  CinemachineFreeLook camera;
     [SerializeField]  Slider sens;
     public TMP_Text sensText;
     Cannon can;

    // Start is called before the first frame update
    void Start()
    {
       menu.SetActive(false);
       sens.value = 5;
       Cursor.lockState = CursorLockMode.Locked;
       can = FindObjectOfType<Cannon>();
    }

    // Update is called once per frame
    void Update()
    {
       MenuPress(); 
       camera.m_XAxis.m_MaxSpeed = sens.value;
       sensText.text = sens.value.ToString();  
    }


    public void MenuPress()
    {
       

        if (Input.GetKeyDown(KeyCode.Escape))
        {
             press++;
             
        if(press > 1)
        {
            press = 0;
        }

        }

        if(press == 1)
        {
            menu.SetActive(true);
            Time.timeScale = 0;
            cam.SetActive(false); 
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None; 
        }
        else
        {
          menu.SetActive(false);
          Time.timeScale = 1;
          cam.SetActive(true);
          Cursor.visible = false;
          Cursor.lockState = CursorLockMode.Locked;
        }
        
    }


    
    public void ResatrtLevel(){
        SceneManager.LoadScene(1);
    }

    public void Countinue()
    {
        press = 0;
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void Challenge(){
        SceneManager.LoadScene(2);
    }

    
}
