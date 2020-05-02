using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatalogMenuManager : MonoBehaviour
{
    public static bool opened = false;
    public GameObject catalogMenuUI;
    public GameObject[] buttons;
    public EffectsControl damageEffect;
    public GameObject player;
    public Text moneyLost;

    public CountdownTimer countdownTimer;
    public float countDownTimerNum;
    PlayerCombat combatStats;
    PlayerStats playerStats;
  

    public float timeAdd = 10f;
    public bool buying = true;

    void Start()
    {
        combatStats = player.GetComponent<PlayerCombat>();
        playerStats = player.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.healthNum == 5)
        {
            buttons[0].GetComponent<Button>().interactable = false;
            buttons[0].GetComponent<Image>().color = new Color(255, 255, 255, 200);
        }
        
        if (countDownTimerNum == 3)
        {
            buttons[1].GetComponent<Button>().interactable = false;
            buttons[1].GetComponent<Image>().color = new Color(255, 255, 255, 200);
        }
        if (PlayerCombat.doubleAttack)
        {
            buttons[2].GetComponent<Button>().interactable = false;
            buttons[2].GetComponent<Image>().color = new Color(255, 255, 255, 200);
        }
        if (PlayerCombat.rangeAttack)
        {
            buttons[3].GetComponent<Button>().interactable = false;
            buttons[3].GetComponent<Image>().color = new Color(255, 255, 255, 200);
        }
        if (PlayerCombat.projectileAttack)
        {
            buttons[4].GetComponent<Button>().interactable = false;
            buttons[4].GetComponent<Image>().color = new Color(255, 255, 255, 200);
        }

        if (PlayerStats.money < 300)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].GetComponent<Image>().color = new Color(0, 0, 0, 200);
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
        else if (PlayerStats.money > 300 && PlayerStats.money < 500)
        {
            for (int i = 2; i < buttons.Length; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    buttons[j].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    buttons[j].GetComponent<Button>().interactable = true;
                }
                buttons[i].GetComponent<Image>().color = new Color(0, 0, 0, 200);
                buttons[i].GetComponent<Button>().interactable = false;
            }
        }
        else if (PlayerStats.money >= 500 && PlayerStats.money < 2000)
        {
            for (int i = 2; i < 5; i++)
            {
                buttons[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                buttons[i].GetComponent<Button>().interactable = true;
            }
            buttons[buttons.Length - 1].GetComponent<Image>().color = new Color(0, 0, 0, 200);
            buttons[buttons.Length - 1].GetComponent<Button>().interactable = false;
        }
        //else if (PlayerStats.money >= 2000)
        //{
        //    //buttons[buttons.Length - 1].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        //    //buttons[buttons.Length - 1].GetComponent<Button>().interactable = true;
        //}

        if (Input.GetButtonDown("Menu") && buying == true)
        {
            Debug.Log("Menu Opened");
            player.GetComponent<PlayerCombat>().isAttacking = true;

            if (opened)
            {
                Close();
            }
            else
            {
                Open();
            }
        }
    }

    void Close()
    {
        if (PlayerCombat.doubleAttack)
        {
            StartCoroutine(damageEffect.fadeIn());
        }

        player.GetComponent<PlayerCombat>().isAttacking = false;
        catalogMenuUI.SetActive(false);
        //Time.timeScale = 1f;
        opened = false;
    }

    void Open()
    {
        catalogMenuUI.SetActive(true);
        //Time.timeScale = 0.5f;
        opened = true;

    }

    public void damage2x()
    {
        if (PlayerStats.money >= 500 && !PlayerCombat.doubleAttack)
        {
            PlayerCombat.doubleAttack = true;
            
            moneyLost.text = "-$500";
            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(500));
            //StartCoroutine(effectActive(30))
        }
    }

    public void piercing()
    {
        if (PlayerStats.money >= 500 && !PlayerCombat.rangeAttack)
        {
            PlayerCombat.rangeAttack = true;
            combatStats.attackDamage -= 10;
            moneyLost.text = "-$500";

            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(500));
        }
    }

    public void projectile()
    {
        if (PlayerStats.money >= 500 && !PlayerCombat.projectileAttack)
        {
            PlayerCombat.projectileAttack = true;

            moneyLost.text = "-$500";
            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(500));
        }
    }

    public void premium()
    {
        if (PlayerStats.money >= 2000)
        {
            Debug.Log("Premium powerup not implemented yet");

            moneyLost.text = "-$2000";
            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(2000));
        }
    }

    public void addTime()
    {
        if (PlayerStats.money >= 300 && countDownTimerNum != 3)
        {
            countDownTimerNum++;
            countdownTimer.addedTime += timeAdd;
            countdownTimer.levelTimeText.text = (countdownTimer.levelTime + countdownTimer.addedTime).ToString();

            moneyLost.text = "-$300";
            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(300));
        }
    }

    public void addHealth()
    {
        if (PlayerStats.money >= 300 && playerStats.healthNum != 5)
        {
            buttons[0].GetComponent<Button>().interactable = true;

            playerStats.healthNum++;
            playerStats.healthIcons[playerStats.healthNum - 1].SetActive(true);
            playerStats.maxHealth += 50;
            playerStats.currentHealth += 50;
            
            moneyLost.text = "-$300";
            moneyLost.color = Color.red;
            StartCoroutine(moneyRemove(300));
        }  
    }

    IEnumerator moneyRemove(int price)
    {
        PlayerStats.money -= price;
        yield return new WaitForSeconds(0.2f);
        moneyLost.text = "";  
    }

    IEnumerator doubleActive(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        PlayerCombat.doubleAttack = false;
    }

    IEnumerator rangeActive(float activeTime)
    {
        yield return new WaitForSeconds(activeTime);
        PlayerCombat.rangeAttack = false;
    }
}
