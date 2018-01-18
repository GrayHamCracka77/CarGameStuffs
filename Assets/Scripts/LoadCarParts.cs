using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarParts : MonoBehaviour
{

    public Transform carRoot;
    public Transform defaultCarBody;
    public Transform defaultWeapon;

    public List<Transform> possibleWeapons;
    public List<Transform> possibleCarBody;

    private Transform _currentBody;
    private int _bodyIndex;

    void Start()
    {
        _bodyIndex = 0;
        _currentBody = Instantiate(defaultCarBody, carRoot);
        Instantiate(defaultWeapon, carRoot);
    }

    void Update()
    {

        if (Input.GetKeyDown("right"))
        {
            NextCarBody();
        }

        if (Input.GetKeyDown("left"))
        {
            PrevCarBody();
        }


    }

    public void NextCarBody()
    {
        _bodyIndex++;
        if (_bodyIndex == int.MaxValue)
        {
            _bodyIndex = _bodyIndex % possibleCarBody.Count;
        }

        ReplaceCarBody();
    }

    public void PrevCarBody()
    {
        if (_bodyIndex == 0)
        {
            _bodyIndex = possibleCarBody.Count;
        }

        _bodyIndex--;

        ReplaceCarBody();
    }

    private void ReplaceCarBody()
    {
        Transform nextBody = possibleCarBody[_bodyIndex % possibleCarBody.Count];

        Destroy(_currentBody.gameObject);
        _currentBody = Instantiate(nextBody, _currentBody.position, _currentBody.rotation, carRoot);
    }
}
