using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;


public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject hakkimizdaPanel;
    bool panelAcikmi; //bool panelAcikmi=false dmk 

    private void Start()
    {
        panelAcikmi = false;
    }
    public void OyunaBasla()
    {
        SceneManager.LoadScene("GameLevel");
    }
    public void HakkimizdaPaneliniAc()
    {
        if(!panelAcikmi) //panek açýk deðilse 
        {
            hakkimizdaPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
        }
        else
        {
            hakkimizdaPanel.GetComponent<CanvasGroup>().DOFade(0, 0.5f);
        }
        panelAcikmi=!panelAcikmi;//true iae false, false ise true döndürüyor
    }
    public void OyundanCik()
    {
        Application.Quit();
    }
}
