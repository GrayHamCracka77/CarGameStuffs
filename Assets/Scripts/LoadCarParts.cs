using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCarParts : MonoBehaviour
{

    public Transform _carRoot;
    public Transform _defaultCarBody;
    public Transform _defaultWeapon;

    public List<Transform> _possibleWeapons;
    public List<Transform> _possibleCarBody;

    private Transform currentBody;
    private int bodyIndex;

    void Start()
    {
        bodyIndex = 0;
        currentBody = Instantiate(_defaultCarBody, _carRoot);
        Instantiate(_defaultWeapon, _carRoot);
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
        bodyIndex++;
        if (bodyIndex == int.MaxValue)
        {
            bodyIndex = bodyIndex % _possibleCarBody.Count;
        }

        ReplaceCarBody();
    }

    public void PrevCarBody()
    {
        if (bodyIndex == 0)
        {
            bodyIndex = _possibleCarBody.Count;
        }

        bodyIndex--;

        ReplaceCarBody();
    }

    private void ReplaceCarBody()
    {
        Transform nextBody = _possibleCarBody[bodyIndex % _possibleCarBody.Count];

        Destroy(currentBody.gameObject);
        currentBody = Instantiate(nextBody, currentBody.position, currentBody.rotation, _carRoot);
    }
}
