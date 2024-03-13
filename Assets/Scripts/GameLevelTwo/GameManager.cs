using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Sprite[] kokiciResimler;

    [SerializeField]
    private Sprite[] kokdisiResimler;

    [SerializeField]
    private Image morKokDisiresim, maviKokDisiresim, griKokDisiresim;

    [SerializeField]
    private Image sariKokDisiresim, pembeKokDisiresim, yesilKokDisiresim;

    [SerializeField]
    private Image ustKokiciResim, altKokiciResim;

    [SerializeField]
    private Transform sorularDaire;

    [SerializeField]
    private Transform sagDemir, solDemir;

    [SerializeField]
    private GameObject trueIcon, falseIcon,dogruYanlisObj;

    [SerializeField]
    private TextMeshProUGUI dogruText, yanlisText,puanText;

    [SerializeField]
    private GameObject bonusObj;

    [SerializeField]
    private AudioClip baslangicClip;

    [SerializeField]
    private AudioClip daireSes,barKapanisSes;

    int hangiSoru;
    bool daireUsttemi;
    bool daireDonsunmu; //doðru yapýnca daire tam dönecek,yanlýþ yapýnca iki hakký olacak 
    string butondakiResim;
    int kacinciYanlis = 0;
    public int dogruAdet, yanlisAdet;
    public int toplamPuan, puanArtisi;
    int bonus;// Art arda 5 kere doðru yaparsa bonus puan 
    bool butonaBasilsinmi; //bu deðiþken 2 kere yanlýþ yaptýýmýzda 3.kez basýldýðýnda direkt doðru sayýya ekliyor bunu düzeltmek için.


    Vector3 solBarBirinciYer= new Vector3(-255,88,0);//solDemirin baþ. bulunduðu koordinat 
    Vector3 solBarIkinciYer = new Vector3(-165, 88, 0); //1 kere yanlýþ yaptýðýnda gelecek olan kpnum 
    Vector3 solBarUcuncuYer = new Vector3(-106, 88, 0); //2 kere yanlýþ yaptýðýnda demirler kapanýr
    Vector3 sagBarBirinciYer = new Vector3(255, 88, 0);
    Vector3 sagBarIkinciYer = new Vector3(165, 88, 0); 
    Vector3 sagBarUcuncuYer = new Vector3(113, 88, 0); 




    void Start()
    {
        daireUsttemi = true;
        daireDonsunmu= true;
        butonaBasilsinmi = true;

        dogruAdet = 0;
        yanlisAdet= 0;
        toplamPuan = 0;
        puanArtisi = 0;
        bonus = 0;  
        puanText.text = toplamPuan.ToString();

        Ses(baslangicClip);

        ResimleriYerlestir();
    }
    void ResimleriYerlestir()
    {
        hangiSoru = Random.Range(0,kokdisiResimler.Length-3);

        int rastgeleDeger = Random.Range(0, 100);
        
        if(daireUsttemi) //daire üstte olduðunda 
        {
            if(rastgeleDeger<=33)
            {
                morKokDisiresim.sprite = kokdisiResimler[hangiSoru];//rastgele deðer  33'den küçükse doðru cevap Mor dairede yazýlý olacak 
                maviKokDisiresim.sprite = kokdisiResimler[hangiSoru + 1];//bir sonraki dizinin elemaný gelecek 
                griKokDisiresim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else if(rastgeleDeger <= 66)
            {
                morKokDisiresim.sprite = kokdisiResimler[hangiSoru + 1];
                maviKokDisiresim.sprite = kokdisiResimler[hangiSoru];
                griKokDisiresim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else
            {
                morKokDisiresim.sprite = kokdisiResimler[hangiSoru + 1];
                maviKokDisiresim.sprite = kokdisiResimler[hangiSoru + 2];
                griKokDisiresim.sprite = kokdisiResimler[hangiSoru ];
            }
           
        }
        else //daire aþaðýda olduðunda 
        {
            if (rastgeleDeger <= 33)
            {
                sariKokDisiresim.sprite = kokdisiResimler[hangiSoru];
                pembeKokDisiresim.sprite = kokdisiResimler[hangiSoru];
                yesilKokDisiresim.sprite = kokdisiResimler[hangiSoru];
            }
            else if (rastgeleDeger <= 66)
            {
                sariKokDisiresim.sprite = kokdisiResimler[hangiSoru + 1];
                pembeKokDisiresim.sprite = kokdisiResimler[hangiSoru];
                yesilKokDisiresim.sprite = kokdisiResimler[hangiSoru + 2];
            }
            else
            {
                sariKokDisiresim.sprite = kokdisiResimler[hangiSoru + 1];
                pembeKokDisiresim.sprite = kokdisiResimler[hangiSoru + 2];
                yesilKokDisiresim.sprite = kokdisiResimler[hangiSoru];
            }
        }
        if(daireUsttemi)//soru kýsmý 
        {
            ustKokiciResim.sprite = kokiciResimler[hangiSoru];
        }
        else
        {
            altKokiciResim.sprite = kokiciResimler[hangiSoru];
        }

        daireUsttemi = !daireUsttemi;
    }
  

    public void ButonaBasildi()
    {
        butondakiResim= UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;

        if(butonaBasilsinmi) //true
        {
            butonaBasilsinmi = false;
            SonucuKontrolEt();
        }
       
    }
    
    void SonucuKontrolEt()
    {
            if (butondakiResim == kokdisiResimler[hangiSoru].name)    //dogru
        {
            dogruAdet++;
            bonus++;
            dogruText.text = dogruAdet.ToString();
            DogruYanlisIcon(true);
            DaireyiCevir();

            if(bonus>=5 && bonus<=9)
            {
                puanArtisi += 30;
                BonusScaleOn();
            }
            else
            {
                puanArtisi += 20;
            }
            if(bonus>9)
            {
                bonus= 0;
                BonusScaleOff();

            }
        }
        else
        {
            BonusScaleOff();
            yanlisAdet++;
            bonus = 0;
            yanlisText.text=yanlisAdet.ToString();
            DogruYanlisIcon(false);
            kacinciYanlis++;
            BarlariKapat(kacinciYanlis);
            puanArtisi -= 10;
        }
       
        toplamPuan += puanArtisi;

        if(toplamPuan<=0)
        {
            toplamPuan= 0;
        }
        puanArtisi = 0;
        puanText.text=toplamPuan.ToString();
    }

     void DaireyiCevir() //Doðru seçeneði seçtiðinde çarký 180 derece döndürme iþlemi yapar 
    {
        if(daireDonsunmu)
        {
            daireDonsunmu = false;

            kacinciYanlis = 0; //2 kere yanlýþ yaptýktan sonra demirleri kaldýrma iþlemi 
            solDemir.DOLocalMove(solBarBirinciYer, 0.2f);
            sagDemir.DOLocalMove(sagBarBirinciYer, 0.2f);

            Ses(daireSes);

            ResimleriYerlestir();
            sorularDaire.DORotate(sorularDaire.rotation.eulerAngles + new Vector3(0, 0, 180),0.5f).OnComplete(DaireDonsunmuTrueYap);
            /*OnComplete(tamamlandýðýnda): Nesneyi belirli bir açýda döndürmek için DOTween kullanýyorsanýz ve dönme tamamlandýðýnda baþka bir iþlem yapmak istiyorsak kullanýlýr.
             Genellikle dönme, ölçekleme, konum deðiþtirme) tamamlandýðýnda tetiklenecek ek iþlevleri tanýmlamak için kullanýlýr.*/
        }
    }
    void DaireDonsunmuTrueYap()
    {
        butonaBasilsinmi = true;
        daireDonsunmu = true;
    }
    void BarlariKapat(int kacinciYanlis)
    {
        Ses(barKapanisSes);
        if(kacinciYanlis==1)
        {
            butonaBasilsinmi = true;
            solDemir.DOLocalMove(solBarIkinciYer, 0.2f);
            sagDemir.DOLocalMove(sagBarIkinciYer, 0.2f);
        }

        else if(kacinciYanlis==2)
        {
            solDemir.DOLocalMove(solBarUcuncuYer, 0.2f);
            sagDemir.DOLocalMove(sagBarUcuncuYer, 0.2f).OnComplete(BarKapanisiniBekle); //2 kere yanlýþ yapýldýktan sonra diðer soruya geçiþi için OnComplete metotu 
        }

    }

    void BarKapanisiniBekle()
    {
        daireDonsunmu = true;
        Invoke("DaireyiCevir",1f);
    }
    void DogruYanlisIcon(bool dogrumu)
    {
        dogruYanlisObj.GetComponent<CanvasGroup>().alpha = 0; //Alpha deðeri ilk bas 0 görünmez
        if(dogrumu) //dogruysa
        {
            trueIcon.SetActive(true);
            falseIcon.SetActive(false);
        }
        else
        {
            trueIcon.SetActive(false);
            falseIcon.SetActive(true);
        }
        dogruYanlisObj.GetComponent<CanvasGroup>().DOFade(1,0.5f).OnComplete(TrueFalseAlpha);
    }

    private void TrueFalseAlpha()
    {
        dogruYanlisObj.GetComponent<CanvasGroup>().DOFade(0, 0.5f).OnComplete(TrueFalseAlpha);
    }

    void BonusScaleOn()//Scale deðerini aç 
    {
        bonusObj.transform.DOScale(Vector3.one,0.3f).SetEase(Ease.OutElastic);
    }
    void BonusScaleOff()
    {
        bonusObj.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InElastic);
    }
    public void GeriDon()
    {
        SceneManager.LoadScene("GameLevel");
    }
    void Ses(AudioClip clip)
    {
        if (clip)//clip yüklendiyse
        {
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f); //PlayClipAtPoint=bir nok. clipi çal
        }
    }
}
