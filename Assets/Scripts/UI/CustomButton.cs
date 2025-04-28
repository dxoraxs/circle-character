using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CircleCharacter.Constants.UI
{
    public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerClickHandler
    {
        public event Action OnPointerDownEvent;
        public event Action OnPointerUpEvent;
        public event Action OnPointerClickEvent;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPointerDownEvent?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnPointerUpEvent?.Invoke();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnPointerClickEvent?.Invoke();
        }
    }
}