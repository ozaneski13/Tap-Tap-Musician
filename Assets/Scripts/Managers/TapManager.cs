using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour
{
    [Header("Controllers")]
    [SerializeField] private MusicalPointController _musicalPointController = null;

    private List<float> _taps = null;

    private int _tapsPerSecond = 0;
    public int TapsPerSecond => _tapsPerSecond;

    private void Start()
    {
        _taps = new List<float>();

        StartCoroutine(TapLogger());
    }

    private void Update()
    {
        CalculateTaps();
    }

    private void CalculateTaps()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Ended)
            {
                _taps.Add(Time.timeSinceLevelLoad);

                _musicalPointController.ActiveGainsFromTap();
            }
        }

        for (int i = 0; i < _taps.Count; i++)
        {
            if (_taps[i] <= Time.timeSinceLevelLoad - 1)
            {
                _taps.RemoveAt(i);
            }
        }

        _tapsPerSecond = _taps.Count;
    }

    private IEnumerator TapLogger()
    {
        while(true)
        {
            Debug.Log("Taps per second: " + _tapsPerSecond);

            yield return new WaitForSeconds(1f);
        }
    }
}