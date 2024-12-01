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
    public Image brain;
    public List<Sprite> brainSprites = new List<Sprite>();

    // Start is called before the first frame update
    void Start()
    {
        question.text = "Your friend shows up and says you should vape not smoking could hurt your social life do you accept";
        SmokeAmount = 0;
        Smokebar.fillAmount = SmokeAmount / 10;
        
    }

    public void Yes(float num)
    {
        if (QTracker == 0)
        {
            hasSmoked = true;
            question.text = "You have a test coming up should you study";
            QTracker += 1;
        }
        else if(QTracker == 1)
        {
            changeHealth("Mental", num);
            question.text = "Your friends ask if you want to go to the mall with them do you accept";
            QTracker += 1;
        }
        else if (QTracker == 2)
        {
            changeHealth("Social", num);
            question.text = "You have a lot of energy today do you go for a run";
            QTracker += 1;
        }
        else if(QTracker == 3)
        {
            changeHealth("Physical", num);
            QTracker += 1;
            question.text = "One day in class your teacher tells you Vapes and other E-Cigarette products contain acrolein, a herbicide mainly used to kill weeds make sure to remeber this press yes or no to continue";
        }
        else if (QTracker == 4)
        {
            QTracker += 1;
            question.text = "You want to go out to hang out with friends but you should be studying do you go outside instead of studying";
        }
        else if (QTracker == 5)
        {
            changeHealth("Social", num);
            QTracker += 1;

            question.text = "You want to join a sport but that would cut into the time you have for your social life do you sign up";
        }
        else if (QTracker == 6)
        {

            changeHealth("Physical", num);
            QTracker += 1;

            question.text = "Your classmate offers you a vape saying there is nothing harmful in them but you remember there is a commonly used pesticide often used in vapes is this true";
        }
        else if (QTracker == 7)
        {
            changeHealth("Correct", num);

            QTracker += 1;

            question.text = "That is correct you convince your classmate that vaping may be worse than they thought helping them and you stay away from vaping";
        }




        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
            
            
        }
        ImageUpdate();
    }

    public void No(float num)
    {
        if(QTracker == 0)
        {
            question.text = "You have a test coming up should you study";
            hasSmoked = false;

            ShpAmount -= 2;
            SHPbar.fillAmount = ShpAmount / 10;
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

            question.text = "Your friends ask if you want to go to the mall with them do you accept";
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

            question.text = "You have a lot of energy today do you go for a run";
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

            question.text = "One day in class your teacher tells you Vapes and other E-Cigarette products contain acrolein, a herbicide mainly used to kill weeds make sure to remeber this press yes or no to continue";
            QTracker += 1;
        }
        else if (QTracker == 4)
        {

            QTracker += 1;
            question.text = "You want to go out to hang out with friends but you should be studying do you go outside instead of studying";
        }
        else if (QTracker == 5)
        {
            changeHealth("Mental", num);
            QTracker += 1;

            question.text = "You want to join a sport but that would cut into the time you have for your social life do you sign up";
        }
        else if (QTracker == 6)
        {
            changeHealth("Social", num);
            QTracker += 1;

            question.text = "Your classmate offers you a vape saying there is nothing harmful in them but you remember there is a commonly used pesticide often used in vapes is this true";
        }
        else if (QTracker == 7)
        {
            changeHealth("Vape", num);
            QTracker += 1;

            question.text = "That is incorect you end up getting pressured into vaping due to you not remembering if there are pesticides in a vape";
        }

        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
           
        }
        ImageUpdate();
    }

    private void ImageUpdate()
    {
        if(MhpAmount >= 8)
        {
            brain.sprite = brainSprites[0];

        }
        else if(MhpAmount < 8 && MhpAmount >= 6) 
        {
            brain.sprite = brainSprites[1];
        }
        else if (MhpAmount < 6 && MhpAmount >= 4)
        {
            brain.sprite = brainSprites[2];
        }
        else if (MhpAmount < 4 && MhpAmount >= 2)
        {
            brain.sprite = brainSprites[3];
        }
        else if (MhpAmount < 2 && MhpAmount >= 0)
        {
            brain.sprite = brainSprites[4];
        }


    }

    void changeHealth(string PSM, float num)
    {
        if (PSM == "Social")
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
        }
        else if (PSM == "Mental")
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
        }
        else if (PSM == "Physical")
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
        }
        else if(PSM == "Vape")
        {
            hasSmoked = true;

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
        }
        else if (PSM == "Correct")
        {
          

            if (ShpAmount < 10)
            {
                ShpAmount += num;
                ShpAmount = Mathf.Clamp(ShpAmount, 0, 10);
                SHPbar.fillAmount = ShpAmount / 10;
            }


            if (PhpAmount < 10)
            {
                PhpAmount += num;
                PhpAmount = Mathf.Clamp(PhpAmount, 0, 10);
                PHPbar.fillAmount = PhpAmount / 10;
            }

            if (MhpAmount < 10)
            {
                MhpAmount += num;
                MhpAmount = Mathf.Clamp(MhpAmount, 0, 10);
                MHPbar.fillAmount = MhpAmount / 10;
            }

            SmokeAmount -= 5;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
        }

    }
}
