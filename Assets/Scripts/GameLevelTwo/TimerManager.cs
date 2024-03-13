using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI timerText;

    [SerializeField]
    private GameObject sonucPanel;

    [SerializeField]
    private AudioClip bitis;

    int kalanSure;
    bool sureSaysinmi;

    GameManager gameManager;
    SonucManager sonucManager;

    private void Awake()
    {
        gameManager=Object.FindObjectOfType<GameManager>();
        // SonucManager'a Awake'den ulaþýrsam,SonucManager sonucPanelinin içerisinde ve sonucPaneli'de Aktif olmadýðý için SonucManager'a ulaþamayýz.
    }

    void Start()
    {
        kalanSure = 90;
        sureSaysinmi=true;

        StartCoroutine(SureTimerRoutine());
    }

    IEnumerator SureTimerRoutine()
    {
        while(sureSaysinmi)//true
        {
            yield return new WaitForSeconds(1f);
            if(kalanSure<10)
            {
                timerText.text="0" + kalanSure.ToString();
                timerText.color = Color.red;
            }
            else
            {
                timerText.text=kalanSure.ToString();
            }

            if(kalanSure<=0)
            {
                sureSaysinmi=false;
                timerText.text = "";
                sonucPanel.SetActive(true);

                Ses(bitis);

                if(sonucPanel!=null)//sonucPanel açýldýys(aktifse)
                {
                    sonucManager=Object.FindObjectOfType<SonucManager>();
                    sonucManager.SonuclariYazdir(gameManager.dogruAdet, gameManager.yanlisAdet, gameManager.toplamPuan);
                }

            }
            kalanSure--;
        }
    }
    void Ses(AudioClip clip)
    {
        if (clip)//clip yüklendiyse
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f); //PlayClipAtPoint=bir nok. clipi çal
        }
    }

}
