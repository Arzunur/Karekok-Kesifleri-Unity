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
        //fadePanel Oyna butonuna basýlmasýný engelliyordu onun için böyle bir kod bloðu yazdýk.
        fadePanel.SetActive(true);
        fadePanel.GetComponent<CanvasGroup>().alpha= 1;
        fadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(IlkAyariYap);//OnComplete(IlkAyariYap)belirtilen animasyonun tamamlandýðýnda hangi fonksiyonun çaðrýlacaðý belirtilir.

        //oyun baþladýðýnda butonlar ekranda gözükmeyecek
        if (startBtn != null) //startBtn ekranda varsa, boþ deilse 
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
        aciklamaText.text = "Alttaki panelden resimleri sürükleyerek istediðiniz resme týklayýp kök deðerini öðrenebilirsiniz.";
        fadePanel.SetActive(false);

        Ses(alistirmaClip);

        ButonlariAc(); //Fade açýldýðý zmn butonlarý görünür yapacak 
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
            GameObject kokiciItem= Instantiate(kokiciPrefab,content);//Instantiate bir prefab nesnesini sahnede oluþturmayý saðlar.

            kokiciItem.GetComponent<KokIciBtnManager>().btnNo = i;//týklanýldýðýnda bize kaçýncý sýrada olduðunu söylüyor.

            kokiciItem.transform.GetChild(3).GetComponent<Image>().sprite = kokiciResimler[i]; //GetChild(3)  3.elemana ulaþ yani PREFABS'da kokiciImage 3.elemandýr,enaltcerceve ise 1.eleman 


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
        if(clip)//clip yüklendiyse
        {
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position,1f); //PlayClipAtPoint=bir nok. clipi çal
        }
    }
}
