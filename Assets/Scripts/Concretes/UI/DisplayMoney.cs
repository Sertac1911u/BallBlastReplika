using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BallBlastReplika.UI
{
    public class DisplayMoney : MonoBehaviour
    {
        TextMeshProUGUI _moneyText;

        private void Awake()
        {
            _moneyText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            GameManager.Instance.OnMoneyChanged += HandleMoneyChange;
            HandleMoneyChange();
        }
        private void OnDisable()
        {
            GameManager.Instance.OnMoneyChanged -= HandleMoneyChange;
        }
        private void HandleMoneyChange(int money = 0)
        {
            _moneyText.text = $"{money}";
        }
    }

}