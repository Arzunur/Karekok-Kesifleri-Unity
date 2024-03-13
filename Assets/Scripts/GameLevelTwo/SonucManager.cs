using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class SonucManager : MonoBehaviour
{
    [SerializeField] private GameObject sonucImage;
    [SerializeField] private TextMeshProUGUI dogruText,yanlisText,puanText;
    [SerializeField] GameObject puanObj, sureObj, dogruYanlisObj, geriDonObj, soruObj,bonusObj;//sonuc paneli ekrana geldiðinde yok olmasý gerekn obj.

    private void OnEnable()
    {
        sonucImage.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.OutBack);
        sonucImage.GetComponent<CanvasGroup>().DOFade(1,0.5f);
        EkraniTemizle();
    }

    void Start()
    {
        
    }

    public void SonuclariYazdir(int dogruAdet,int yanlisAdet,int toplamPuan)
    {
        dogruText.text=dogruAdet.ToString()+" DOÐRU";
        yanlisText.text = yanlisAdet.ToString() + " YANLIÞ";
        puanText.text = toplamPuan.ToString() + " PUAN";
    }
    void EkraniTemizle()
    {
        puanObj.SetActive(false);
        sureObj.SetActive(false);
        dogruYanlisObj.SetActive(false);
        geriDonObj.SetActive(false);
        soruObj.SetActive(false);
        bonusObj.SetActive(false);

    }
    public void YenidenOyna()
    {
        SceneManager.LoadScene("GameLevelTwo");
    }
}
