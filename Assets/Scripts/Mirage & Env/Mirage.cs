using UnityEngine;

public class Mirage : MonoBehaviour
{
    //[SerializeField] private float _externalRadius; // Mirage Appears when player enters
    [SerializeField] private float _internalRadius; // Mirage Disappears when player enters

    public LayerMask whatIsPlayer;

    [SerializeField] private GameObject mirageObject; // Forest, Arctic, etc

    private bool _itAppeared = false;

    private void Update()
    {
        //if (Physics.CheckSphere(transform.position, _externalRadius, whatIsPlayer))
        //{
            if (Physics.CheckSphere(transform.position, _internalRadius, whatIsPlayer))
            {
                //RemovesMirage();
                ShowMirage();
            }
            else
            {
                //ShowMirage();
                RemovesMirage();
            }
        //}
    }

    private void ShowMirage()
    {
        _itAppeared = true;
        mirageObject.SetActive(true);
    }

    private void RemovesMirage()
    {
        mirageObject.SetActive(false);
        if(_itAppeared)
            Destroy(gameObject);
    }
}
