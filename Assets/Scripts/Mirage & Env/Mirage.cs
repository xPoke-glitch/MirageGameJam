using UnityEngine;

public class Mirage : MonoBehaviour
{
    public float Radius; 

    public LayerMask whatIsPlayer;

    [SerializeField] private GameObject mirageObject; // Forest, Arctic, etc

    private bool _itAppeared = false;

    private void Update()
    {
        if (Physics.CheckSphere(transform.position, Radius, whatIsPlayer))
            ShowMirage();
        else
            RemovesMirage();
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
