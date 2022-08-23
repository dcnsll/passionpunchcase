using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion

    public TextMeshProUGUI shotsMadeText;
    public bool isBig;
    public bool isRed;
    public bool isBang;

    void Start()
    {
        isBig = false;
    }
    void Update()
    {
        shotsMadeText.text = Shotgun.instance.shotsMade.ToString();
    }

    public void ScaleBigger()
    {
        isBig = true;

    }

    public void ScaleNormal()
    {

        isBig = false;
    }

    public void ColorRed()
    {
        isRed = true;

    }

    public void ColorWhite()
    {
        isRed = false;
    }

    public void BulletBomb()
    {

        isBang = true;
    }

    public void BulletNoBomb()
    {
        isBang = false;
    }

}
