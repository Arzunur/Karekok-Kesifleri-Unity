using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Net.Http.Headers;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameLevel : MonoBehaviour
{
    [SerializeField]
    private GameObject startBtn, geriDonBtn;
    [SerializeField]
    private GameObject fadePanel;
    [SerializeField]
    private GameObject kokiciPrefab;
    [SerializeField]
    private Transform content;
    [SerializeField]
    private Sprite[] kokiciResimler;
    [SerializeField]
    private Sprite[] kokdisiResimler;
    [SerializeField]
    private Image kokdisiImage;
    [SerializeField] TextMeshProUGUI aciklamaText;
    [SerializeField]
    private AudioClip alistirmaClip;
    void Start()
    {
        aciklamaText.text = "";
        //fadePanel Oyna butonuna bas�lmas�n� engelliyordu onun i�in b�yle bir kod blo�u yazd�k.
        fadePanel.SetActive(true);
        fadePanel.GetComponent<CanvasGroup>().alpha= 1;
        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(IlkAyariYap);//OnComplete(IlkAyariYap)belirtilen animasyonun tamamland���nda hangi fonksiyonun �a�r�laca�� belirtilir.

        //oyun ba�lad���nda butonlar ekranda g�z�kmeyecek
        if (startBtn != null) //startBtn ekranda varsa, bo� deilse 
        {
            startBtn.GetComponent<RectTransform>().localScale = Vector3.zero; 
        }
        if (geriDonBtn!=null)
        {
            geriDonBtn.GetComponent<RectTransform>().localScale = Vector3.zero;

        }
        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(IlkAyariYap);
    }

    void IlkAyariYap()
    {
        aciklamaText.text = "Alttaki panelden resimleri s�r�kleyerek istedi�iniz resme t�klay�p k�k de�erini ��renebilirsiniz.";
        fadePanel.SetActive(false);

        Ses(alistirmaClip);

        ButonlariAc(); //Fade a��ld��� zmn butonlar� g�r�n�r yapacak 
        KokIciResimleriOlustur();

    }

    void ButonlariAc()
    {
        startBtn.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBounce);
        geriDonBtn.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBounce);
    }
   
    void KokIciResimleriOlustur() //prefabs olsturma 
    {
        for(int i=0;i<kokiciResimler.Length;i++)
        {
            GameObject kokiciItem= Instantiate(kokiciPrefab,content);//Instantiate bir prefab nesnesini sahnede olu�turmay� sa�lar.

            kokiciItem.GetComponent<KokIciBtnManager>().btnNo = i;//t�klan�ld���nda bize ka��nc� s�rada oldu�unu s�yl�yor.

            kokiciItem.transform.GetChild(3).GetComponent<Image>().sprite = kokiciResimler[i]; //GetChild(3)  3.elemana ula� yani PREFABS'da kokiciImage 3.elemand�r,enaltcerceve ise 1.eleman 


        }

        kokdisiImage.sprite = kokdisiResimler[0];
    }

    public void KokDisiResmiGoster(int btnNo)
    {
        kokdisiImage.sprite = kokdisiResimler[btnNo];
    }
    public void MenuLevelDon()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void OyunLevelGit()
    {
        SceneManager.LoadScene("GameLevelTwo");
    }
    void Ses(AudioClip clip)
    {
        if(clip)//clip y�klendiyse
        {
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,1f); //PlayClipAtPoint=bir nok. clipi �al
        }
    }
}
