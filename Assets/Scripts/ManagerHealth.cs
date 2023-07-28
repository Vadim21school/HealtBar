using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(Slider))]
public class ManagerHealth : MonoBehaviour
{
    private Slider _healthBar;
    private float _amountHealth = 10f;
    private float _minAmountOfHealth = 0f;
    private float _currentValue;

    [SerializeField] private TextMeshProUGUI _amountHealthText;

    private void Start()
    {
        _healthBar = GetComponent<Slider>();
        _healthBar.value = _minAmountOfHealth;
    }

    public void IncreaseHealth()
    {
        _currentValue = _healthBar.value + _amountHealth;

        if (_healthBar.value < 100)
        {
            StartCoroutine(ChangeSliderValue());
        }
    }

    public void ReduceHealth()
    {
        if (_healthBar.value > 0)
        {
            _healthBar.value -= _amountHealth;
            _amountHealthText.text = Convert.ToString(Convert.ToInt32(_amountHealthText.text) - _amountHealth);
        }
    }

    private IEnumerator ChangeSliderValue()
    {
        WaitForSeconds delayTime = new WaitForSeconds(0.1f);

        while (_healthBar.value < _currentValue)
        {

            _healthBar.value = Mathf.MoveTowards(_healthBar.value, _currentValue, 5f);

            yield return delayTime;
        }

        _amountHealthText.text = Convert.ToString(_healthBar.value);
    }
}
