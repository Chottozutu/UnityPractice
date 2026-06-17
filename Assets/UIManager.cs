using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI hpText;

    public void UpdateHP(int currentHP)
    {
        hpText.text = "HP : " + currentHP;
    }
}