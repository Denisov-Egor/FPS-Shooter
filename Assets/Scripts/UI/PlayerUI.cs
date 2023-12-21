using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI promtTexst;

    public void UpdateText(string promMessege)
    {
        promtTexst.text = promMessege;
    }
}
