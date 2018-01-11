using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarParts : MonoBehaviour {

    public Transform _carRoot;
    public Transform _defaultCarBody;
    public Transform _defaultWeapon;

    public List<Transform> _alternativeWeapons;

	void Start () {
        Instantiate(_defaultCarBody, _carRoot);
        Instantiate(_defaultWeapon, _carRoot);
	}
	
	void Update () {
	}
}
