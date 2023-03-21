using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FillButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    [Tooltip("Hold duration in seconds")] [Range(0.3f, 5f)] [SerializeField]
    private float fillDuration = 0.5f;

    [SerializeField] private Image fillImage; // Reference to the progress bar image component

    private float _fillAmount; // The current fill amount of the progress bar
    private float _timer;
    private Coroutine _fillingRoutine;

    public event Action ButtonPressed;
    public event Action ButtonReleased;
    public event Action ButtonFilled;

    public void OnPointerDown(PointerEventData eventData)
    {
        StartFilling();
        ButtonPressed?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StopFilling();
        ResetProgress();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopFilling();
        ResetProgress();
    }

    private void StartFilling()
    {
        if (_fillingRoutine == null)
            _fillingRoutine = StartCoroutine(FillRoutine());
    }

    private void StopFilling()
    {
        if (_fillingRoutine != null)
        {
            StopCoroutine(_fillingRoutine);
            _fillingRoutine = null;
        }
    }

    private IEnumerator FillRoutine()
    {
        while (_timer < fillDuration)
        {
            _timer += Time.deltaTime;
            _fillAmount = _timer / fillDuration;
            fillImage.fillAmount = _fillAmount;
            yield return null;
        }

        fillImage.fillAmount = 1f; // Set the progress bar to full value
        ButtonFilled?.Invoke();
    }

    private void ResetProgress()
    {
        _timer = 0;
        fillImage.fillAmount = 0f;
        ButtonReleased?.Invoke();
    }
}