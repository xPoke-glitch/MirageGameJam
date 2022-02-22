using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Animator), typeof(BoxCollider2D))]
public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public UnityEvent OnSelect;
    public UnityEvent OnDeselect;

    private Animator _animator;
    private bool _isSelected = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!_isSelected) // Selected
        {
            bool hasPersistentTarget = false;
            for (int i = 0; i < OnSelect.GetPersistentEventCount(); i++)
            {
                if (OnSelect.GetPersistentTarget(i) != null)
                {
                    hasPersistentTarget = true;
                }
            }

            if (hasPersistentTarget)
            {
                OnSelect?.Invoke();
            }
            _animator.SetTrigger("IsSelected");
            _isSelected = true;
        }
        else // Deselected
        {
            bool hasPersistentTarget = false;
            for (int i = 0; i < OnDeselect.GetPersistentEventCount(); i++)
            {
                if (OnDeselect.GetPersistentTarget(i) != null)
                {
                    hasPersistentTarget = true;
                }
            }

            if (hasPersistentTarget)
            {
                OnDeselect?.Invoke();
            }
            _animator.SetTrigger("IsDeselected");
            _isSelected = false;
        }
      
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
