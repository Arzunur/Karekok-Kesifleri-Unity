using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KokIciBtnManager : MonoBehaviour
{
    //Prefabs içindeki resmi deðiþtirme 

    [SerializeField] private Image kokiciImage;


    public int btnNo;

    GameLevel gameLevel;
    private void Awake()
    {
        gameLevel=Object.FindObjectOfType<GameLevel>();
    }

    public void ButonaTiklandi()
    {
        //Debug.Log(kokiciImage.sprite.name);//sprite nesnesinin adýný alýr.
        gameLevel.KokDisiResmiGoster(btnNo);

    }
}
