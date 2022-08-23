using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    public GameObject mainUI;
    public bool isOpen;


    #region Singleton
    public static UIController instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    void Start()
    {
        isOpen = false;
    }

    void Update()
    {
        if (isOpen == false)
        {

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainUI.SetActive(true);
                isOpen = true;
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                mainUI.SetActive(false);
                isOpen = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
        }
    }






}
