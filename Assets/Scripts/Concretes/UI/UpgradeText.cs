using BallBlastReplika.Combats;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallBlastReplika.UI
{
    public class UpgradeText : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _fireRate;
        [SerializeField] TextMeshProUGUI _moneyEarn;
        [SerializeField] TextMeshProUGUI _offlineEarn;
        [SerializeField] TextMeshProUGUI _randomProperty;
        [SerializeField] TextMeshProUGUI _fireRateCoastText;
        [SerializeField] TextMeshProUGUI _moneyUpdayeCoastText;
        [SerializeField] TextMeshProUGUI _moneyText;
        private void Start()
        {
            Shoot shoot = GameObject.FindWithTag("Player").GetComponent<Shoot>();
            _fireRate.text = shoot.delayProjectile.ToString();

            _moneyEarn.text = GameManager.Instance.increseMoney.ToString();

            _fireRateCoastText.text = GameManager.Instance.fireRateUpdateMoney.ToString();
            _moneyUpdayeCoastText.text=GameManager.Instance.moneyUpdateMoney.ToString();
        }
        private void Update()
        {
            Shoot shoot = GameObject.FindWithTag("Player").GetComponent<Shoot>();
            _fireRate.text = shoot.delayProjectile.ToString();

            _moneyEarn.text = GameManager.Instance.increseMoney.ToString();


            _fireRateCoastText.text = GameManager.Instance.fireRateUpdateMoney.ToString();
            _moneyUpdayeCoastText.text = GameManager.Instance.moneyUpdateMoney.ToString();
        }
        public void MoneyUpdate()
        {
            _moneyText.text = GameManager.Instance.money.ToString();
        }
    }

}