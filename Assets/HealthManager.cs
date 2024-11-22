using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image PHPbar;
    public Image MHPbar;
    public Image SHPbar;
    public Image Smokebar;
    public float PhpAmount = 10;
    public float MhpAmount = 10;
    public float ShpAmount = 10;
    public float SmokeAmount = 0;
    float QTracker = 0;
    public Text question;
    bool hasSmoked = false;

    // Start is called before the first frame update
    void Start()
    {
        question.text = "Do you want to vape";
        SmokeAmount = 0;
        Smokebar.fillAmount = SmokeAmount / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Yes(float num)
    {
        if (QTracker == 0)
        {
            hasSmoked = true;
            question.text = "Increase mental hp";
            QTracker += 1;
        }
        else if(QTracker == 1)
        {
            if (MhpAmount < 10)
            {
                MhpAmount += num;
                MhpAmount = Mathf.Clamp(MhpAmount, 0, 10);
                MHPbar.fillAmount = MhpAmount / 10;
            }
                        
            PhpAmount -= num;
            PHPbar.fillAmount = PhpAmount / 10;

            ShpAmount -= num;
            SHPbar.fillAmount = ShpAmount / 10;

            question.text = "Increase social hp";
            QTracker += 1;
        }
        else if (QTracker == 2)
        {
            if (ShpAmount < 10)
            {
                ShpAmount += num;
                ShpAmount = Mathf.Clamp(ShpAmount, 0, 10);
                SHPbar.fillAmount = ShpAmount / 10;
            }

            PhpAmount -= num;
            PHPbar.fillAmount = PhpAmount / 10;

            MhpAmount -= num;
            MHPbar.fillAmount = MhpAmount / 10;

            question.text = "Increase Physical hp";
            QTracker += 1;
        }
        else if(QTracker == 3)
        {
            if (PhpAmount < 10)
            {
                PhpAmount += num;
                PhpAmount = Mathf.Clamp(PhpAmount, 0, 10);
                PHPbar.fillAmount = PhpAmount / 10;
            }

            ShpAmount -= num;
            SHPbar.fillAmount = ShpAmount / 10;

            MhpAmount -= num;
            MHPbar.fillAmount = MhpAmount / 10;

            QTracker += 1;
            question.text = "Demo is done";
        }
        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
            
            
        }

    }

    public void No(float num)
    {
        if(QTracker == 0)
        {
            question.text = "Increase mental hp";
            hasSmoked = false;
            QTracker += 1;
        }
        else if (QTracker == 1)
        {
            MhpAmount -= num;
            MHPbar.fillAmount = MhpAmount / 10;

            PhpAmount -= num;
            PHPbar.fillAmount = PhpAmount / 10;

            ShpAmount -= num;
            SHPbar.fillAmount = ShpAmount / 10;

            question.text = "Increase social hp";
            QTracker += 1;
        }
        else if (QTracker == 2)
        {
            MhpAmount -= num;
            MHPbar.fillAmount = MhpAmount / 10;

            PhpAmount -= num;
            PHPbar.fillAmount = PhpAmount / 10;

            ShpAmount -= num;
            SHPbar.fillAmount = ShpAmount / 10;

            question.text = "Increase Physical hp";
            QTracker += 1;
        }
        else if(QTracker == 3)
        {
            ShpAmount -= num;
            SHPbar.fillAmount = ShpAmount / 10;

            MhpAmount -= num;
            MHPbar.fillAmount = MhpAmount / 10;

            PhpAmount -= num;
            PHPbar.fillAmount = PhpAmount / 10;

            question.text = "Demo is done";
            QTracker += 1;
        }
        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
           
        }

    }
}
