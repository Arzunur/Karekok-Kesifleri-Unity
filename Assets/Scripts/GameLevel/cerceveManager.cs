using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cerceveManager : MonoBehaviour
{
    //Çerçeve rengini deðiþtirmek. kokiciPrefab'ýn

    
    private Image cerceveRengi;

    int randomDeger;
    Color color;

    void Start()
    {
        cerceveRengi=GetComponent<Image>();
        RengiDegistir();
    }

    private void RengiDegistir()
    {
        randomDeger = Random.Range(0,76);
        if(randomDeger<=5)
        {

            color = Color.green;
        }
        else if (randomDeger <= 15)
        {
            color = Color.gray;
        }
        else if (randomDeger <= 25)
        {

            color = Color.red;
        }
        else if (randomDeger <= 35)
        {

            color = Color.black;
        }
        else if (randomDeger <= 45)
        {

            color = Color.yellow;
        }
        else if (randomDeger <= 55)
        {

            color = Color.cyan;
        }
        else if (randomDeger <= 65)
        {

            color = Color.magenta;
        }
       
        else
        {

            color = Color.green;
        }

        if(cerceveRengi!=null)
        {
           
            cerceveRengi.color = color;
        }

    }
}
