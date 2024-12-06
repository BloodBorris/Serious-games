using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    public Image lungs;
    public List<Sprite> brainSprites = new List<Sprite>();
    public List<Sprite> lungSprites = new List<Sprite>();

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
        else if (QTracker == 1)
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
        else if (QTracker == 3)
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

            question.text = "That is correct you convince your classmate that vaping may be worse than they thought helping them and you stay away from vaping press yes or no to continue";
        }
        else if (QTracker == 8)
        {
            QTracker += 1;

            question.text = "Your teacher is offering an extra class to help students who are strugling but it would interupt the time you use to work out do you go";
        }
        else if (QTracker == 9)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "During the class your teacher tells you that the particles you inhale while vaping can cause inflammation to your lungs, leading to severe lung damage.";
        }
        else if (QTracker == 10)
        {
            QTracker += 1;

            question.text = "You want to play games with your friends but playing this long could effect your physical health";
        }
        else if (QTracker == 11)
        {
            QTracker += 1;
            changeHealth("Social", num);
            question.text = "You need to wright a paper with your group do you talk with your friends instead of focusing on the project";
        }
        else if (QTracker == 12)
        {
            QTracker += 1;
            changeHealth("Social", num);
            question.text = "";
        }
        else if (QTracker == 13)
        {
            QTracker += 1;
            changeHealth("Vaping", num);
            question.text = "You tell them yes and they look it up to find no proof of inflamation to the heart in vaping resulting in them vaping and convincing you to do the same";
        }
        else if (QTracker == 14)
        {
            QTracker += 1;

            question.text = "You want to talk to your parents about what is stressing you out in school but that would mean you dont have time to go on the bike ride you wanted do you talk to them";
        }
        else if (QTracker == 15)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "Your parents say they want to talk to you about vaping they tell you Nicotine releases dopamine to the brain, causing mood-altering effects temporarily. Inhaled smoke delivers dopamine within 20 seconds of inhaling, making it highly addictive, comparable to other addictive substances like opioids or cocaine.";
        }
        else if (QTracker == 16)
        {
            QTracker += 1;

            question.text = "Your friends want to play a game of Warhammer to hang out but that would interupt you watching a recorded lecture do you play the game with them";
        }
        else if (QTracker == 17)
        {
            QTracker += 1;
            changeHealth("Social", num);
            question.text = "You are going to the movies with your friends some want to take the bus so you can talk more but others want to bike to get some exercise do you go on the bus";
        }
        else if (QTracker == 18)
        {
            QTracker += 1;
            changeHealth("social", num);
            question.text = "You end up getting a free vape from a friend and you think of using it but you remember you parents saying that vaping can cause temporary mood changing effects due to dopamine but you wonder is this true";
        }
        else if (QTracker == 19)
        {
            QTracker += 1;
            changeHealth("Correct", num);
            question.text = "You remember right and knowing this information convinces you not to use it press yes or no to continue";
        }
        else if (QTracker == 20)
        {
            QTracker += 1;

            question.text = "During health class you are offered the option of more study time or going outside to work out do you take the study time";
        }
        else if (QTracker == 21)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "During your studying for your final health exam you read that certain disposable vapes and E-cigarettes utilize nicotine salts, which do not produce smoke or vapour after inhaling. This can cause the product to be even more addictive. press yes or no to continue";
        }
        else if (QTracker == 22)
        {
            QTracker += 1;
           
            question.text = "Should you keep studying for this exam instead of hanging out with your friends for a break";
        }
        else if (QTracker == 23)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "You get the chance to take a class with a bunch of your friends when signing up for classes however you can also take a PE class you are exited for that your friends are not in do you take the class with friends";
        }
        else if (QTracker == 24)
        {
            QTracker += 1;
            changeHealth("Social", num);
            question.text = "You are stressed during the last bit of cram studying for your exams they offer you a vape to help calm your nerves and they say it is not adictive as it uses nicotine salts to not produces smoke so it is not addictive is this true";
        }
        else if (QTracker == 25)
        {
            QTracker += 1;
            changeHealth("Vape", num);
            question.text = "You trust their knowledge and end up getting convinced to vape since it is not addicitve which turns out not to be true in fact it is the opposite due to the smelling salts hit yes or no to continue";
        }
        else if (QTracker >= 26)
        {
            SceneManager.LoadScene("Win");
        }





        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
            
            
        }
        ImageUpdate();
        CheckIfLost();
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
        else if (QTracker == 8)
        {
            QTracker += 1;

            question.text = "Your teacher is offering an extra class to help students who are strugling but it would interupt the time you use to work out do you go";
        }
        else if (QTracker == 9)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "During your work out you hear from a fitness instructor teaching some other students near by The particles you inhale while vaping can cause inflammation to your lungs, leading to severe lung damage";
        }
        else if (QTracker == 10)
        {
            QTracker += 1;

            question.text = "You want to play games with your friends but playing this long could effect your physical health";
        }
        else if (QTracker == 11)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "You need to wright a paper with your group do you talk with your friends instead of focusing on the project";
        }
        else if (QTracker == 12)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "Your friend is thinking of vaping and wants you to join them but before you do they ask if it is true that vaping can cause inflamation to the heart causing damage to it";
        }
        else if (QTracker == 13)
        {
            QTracker += 1;
            changeHealth("Correct", num);
            question.text = "You tell them no it is in fact the lungs that can be inflamed by vaping causing damage your knowledge convinces your friend that they should not vape";
        }
        else if (QTracker == 14)
        {
            QTracker += 1;

            question.text = "You want to talk to your parents about what is stressing you out in school but that would mean you dont have time to go on the bike ride you wanted do you talk to them";
        }
        else if (QTracker == 15)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "Your parents say they want to talk to you about vaping they tell you Nicotine releases dopamine to the brain, causing mood-altering effects temporarily. Inhaled smoke delivers dopamine within 20 seconds of inhaling, making it highly addictive, comparable to other addictive substances like opioids or cocaine.";
        }
        else if (QTracker == 16)
        {
            QTracker += 1;

            question.text = "Your friends want to play a game of Warhammer to hang out but that would interupt you watching a recorded lecture do you play the game with them";
        }
        else if (QTracker == 17)
        {
            QTracker += 1;
            changeHealth("Mental", num);
            question.text = "You are going to the movies with your friends some want to take the bus so you can talk more but others want to bike to get some exercise do you go on the bus";
        }
        else if (QTracker == 18)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "You end up getting a free vape from a friend and you think of using it but you remember you parents saying that vaping can cause temporary mood changing effects due to dopamine but you wonder is this true";
        }
        else if (QTracker == 19)
        {
            QTracker += 1;
            changeHealth("Vape", num);
            question.text = "You remember wrong and due to not thinking there will be any adverse effects end up vaping hit yes or no to continue";
        }
        else if (QTracker == 20)
        {
            QTracker += 1;
            
            question.text = "During health class you are offered the option of more study time or going outside to work out do you take the study time";
        }
        else if (QTracker == 21)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "During your studying for your final health exam you read that certain disposable vapes and E-cigarettes utilize nicotine salts, which do not produce smoke or vapour after inhaling. This can cause the product to be even more addictive. press yes or no to continue";
        }
        else if (QTracker == 22)
        {
            QTracker += 1;

            question.text = "Should you keep studying for this exam instead of hanging out with your friends for a break";
        }
        else if (QTracker == 23)
        {
            QTracker += 1;
            changeHealth("Social", num);
            question.text = "You get the chance to take a class with a bunch of your friends when signing up for classes however you can also take a PE class you are exited for that your friends are not in do you take the class with friends";
        }
        else if (QTracker == 24)
        {
            QTracker += 1;
            changeHealth("Physical", num);
            question.text = "You are stressed during the last bit of cram studying for your exams they offer you a vape to help calm your nerves and they say it is not adictive as it uses nicotine salts to not produces smoke so it is not addictive is this true";
        }
        else if (QTracker == 25)
        {
            QTracker += 1;
            changeHealth("Correct", num);
            question.text = "You remember that nicotine salts can actually cause the product to be even more addictive you tell your friend this to convince them that both you and they should not vape";
        }
        else if (QTracker >= 26)
        {

            SceneManager.LoadScene("Win");
        }



        if (hasSmoked)
        {
            SmokeAmount += num;
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
           
        }
        ImageUpdate();
        CheckIfLost();
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

        if (PhpAmount >= 8)
        {
            lungs.sprite = lungSprites[0];

        }
        else if (PhpAmount < 8 && PhpAmount >= 6)
        {
            lungs.sprite = lungSprites[1];
        }
        else if (PhpAmount < 6 && PhpAmount >= 4)
        {
            lungs.sprite = lungSprites[2];
        }
        else if (PhpAmount < 4 && PhpAmount >= 2)
        {
            lungs.sprite = lungSprites[3];
        }
        else if (PhpAmount < 2 && PhpAmount >= 0)
        {
            lungs.sprite = lungSprites[4];
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
                ShpAmount += 2;
                ShpAmount = Mathf.Clamp(ShpAmount, 0, 10);
                SHPbar.fillAmount = ShpAmount / 10;
            }


            if (PhpAmount < 10)
            {
                PhpAmount += 2;
                PhpAmount = Mathf.Clamp(PhpAmount, 0, 10);
                PHPbar.fillAmount = PhpAmount / 10;
            }

            if (MhpAmount < 10)
            {
                MhpAmount += 2;
                MhpAmount = Mathf.Clamp(MhpAmount, 0, 10);
                MHPbar.fillAmount = MhpAmount / 10;
            }

            SmokeAmount -= 10;
            if(SmokeAmount > 10)
            {
                SmokeAmount = 10;
            }
            SmokeAmount = Mathf.Clamp(SmokeAmount, 0, 10);
            Smokebar.fillAmount = SmokeAmount / 10;
        }

        if(PhpAmount > 10)
        {
            PhpAmount = 10;
        }
        if (MhpAmount > 10)
        {
            MhpAmount = 10;
        }
        if (ShpAmount > 10)
        {
            ShpAmount = 10;
        }
        if (SmokeAmount < 0)
        {
            SmokeAmount = 0;
        }

    }

    void CheckIfLost()
    {

        if (PhpAmount == 0 || MhpAmount == 0 || ShpAmount == 0 || SmokeAmount == 10)
        {
            SceneManager.LoadScene("Loss");
        }
       
   
   
    }
}
