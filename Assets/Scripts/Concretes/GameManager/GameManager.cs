using BallBlastReplika.Combats;
using BallBlastReplika.Controllers;
using BallBlastReplika.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    public event Action<int> OnScoreChanged;
    public event Action<int> OnMoneyChanged;
    [SerializeField] int score;
    [SerializeField] public int money, increseMoney, fireRateUpdateMoney, moneyUpdateMoney;
    [SerializeField] GameObject panel;
    public PcInputController pcInput;
    private void Awake()
    {
        SingletonThisGameObject();
    }
    private void Start()
    {
        score = 0;
        increseMoney = 1;
        fireRateUpdateMoney = 200;
        moneyUpdateMoney = 100;
        pcInput = new PcInputController();
    }
    private void Update()
    {
        if(pcInput._inputT)
        {
            if (panel.activeSelf != true)
            {
                panel.SetActive(true);
            }
            else
            {
                panel.SetActive(false);
            }
        }
        if(pcInput._inputR)
        {
            SceneManager.LoadScene(0);
        }
    }
    private void SingletonThisGameObject()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void IncreaseScore()
    {
        score += 10;
        OnScoreChanged?.Invoke(score);
    }
    public void IncreaseMoney()
    {
        money += increseMoney;
        OnMoneyChanged?.Invoke(money);
    }

    public void FireRateUpdate()
    {
        if (money >= fireRateUpdateMoney)
        {
            Shoot shoot = GameObject.FindWithTag("Player").GetComponent<Shoot>();
            shoot.delayProjectile -= 0.01f;
            money -= fireRateUpdateMoney;
            fireRateUpdateMoney += fireRateUpdateMoney % 120;
            UpgradeText ut = gameObject.GetComponent<UpgradeText>();
            ut.MoneyUpdate();
        }
    }
    public void EarnMoneyUpdate()
    {
        if (money >= moneyUpdateMoney)
        {
            increseMoney += 2;
            money -= moneyUpdateMoney;
            moneyUpdateMoney += moneyUpdateMoney % 110;
            UpgradeText ut = gameObject.GetComponent<UpgradeText>();
            ut.MoneyUpdate();
        }
    }
    public void OfflineEarnMoney()
    {
        //
    }
    public void CreateRandomProperty()
    {
        //
    }
}
