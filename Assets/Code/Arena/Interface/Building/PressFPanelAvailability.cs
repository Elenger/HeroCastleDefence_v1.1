using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFPanelAvailability : MonoBehaviour
{
    [SerializeField] private float _distanceToShow;
    [SerializeField] private GameObject _pressFPanel;
    [SerializeField] private ShopPanelShow _shopPanelShow;
    private bool _shopInTarget = false;
    private Vector3 _characterPosition;

    public void ShowPressFPanel(bool shopInTarget, Vector3 characterPosition = new Vector3())
    {
        _shopInTarget = shopInTarget;
        _characterPosition = characterPosition;

        if (!shopInTarget) HidePressFPanel();
    }

    private void Update()
    {
        if (_shopInTarget)
        {
            float distanceDifference = Vector3.Distance(_characterPosition, transform.position);
            if (distanceDifference <= _distanceToShow)
            {
                _pressFPanel.SetActive(true);
                _shopPanelShow.SetPressFPanelShown(true);
            }
            else
            {
                HidePressFPanel();
            }
        }
    }

    private void HidePressFPanel()
    {
        _pressFPanel.SetActive(false);
        _shopPanelShow.SetPressFPanelShown(false);
    }
}
