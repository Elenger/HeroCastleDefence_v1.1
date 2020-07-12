using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInfo : MonoBehaviour
{
    [SerializeField] private ShopHighlight _shopHighlight;
    [SerializeField] private ShopAimCharacter _shopAimCharacter;
    [SerializeField] private PressFPanelAvailability _pressFPanelAvailability;
    private bool _shopInTarget = false;
    public int shopId;

    public void SetShopInTarget(bool shopInTarget, Vector3 characterPosition = new Vector3(), CharacterAutoAim characterAutoAim = null)
    {
        _shopInTarget = shopInTarget;
        if (_shopInTarget)
        {
            _shopHighlight.ShopInTarget(shopInTarget);
            _shopAimCharacter.CharacterAim(characterAutoAim);
            _pressFPanelAvailability.ShowPressFPanel(shopInTarget, characterPosition);
        }
        else
        {
            _shopHighlight.ShopInTarget(shopInTarget);
            _pressFPanelAvailability.ShowPressFPanel(shopInTarget);
        }
    }
}
