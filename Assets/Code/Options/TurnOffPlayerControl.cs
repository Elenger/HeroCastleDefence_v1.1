using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffPlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;
    private Dictionary<GameObject, bool> _dictionaryPanels = new Dictionary<GameObject, bool>();
    public List<GameObject> charactersArray;
    private GameObject _character;
    private int _amountActivePanels;
    //private Movement componentMovement;
    private ShootingMechanics componentShootingMechanics;

    void Start()
    {
        foreach (GameObject panel in _panels)
        {
            _dictionaryPanels.Add(panel, false);
            Debug.Log(_dictionaryPanels);
        }
    }

    void Update()
    {
        foreach (GameObject character in charactersArray)
        {
            if (character.GetComponent<PhotonView>().IsMine)
            {
               // componentMovement = character.GetComponent<Movement>();
                componentShootingMechanics = character.GetComponentInChildren<ShootingMechanics>();
            }
        }

        foreach (KeyValuePair<GameObject, bool> panel in _dictionaryPanels)
        {
            if (_dictionaryPanels[panel.Key] != panel.Key.active)
            {
                _dictionaryPanels[panel.Key] = panel.Key.active;
            }           
        }


        foreach (KeyValuePair<GameObject, bool> panel in _dictionaryPanels)
        {
            if (panel.Value)
            {
           //     componentMovement.enabled = false;
                componentShootingMechanics.enabled = false;
            }
            else
            {
          //      componentMovement.enabled = true;
                componentShootingMechanics.enabled = true;
            }
        }
    }
}
