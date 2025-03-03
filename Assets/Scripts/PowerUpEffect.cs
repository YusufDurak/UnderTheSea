using UnityEngine;
using System.Collections;

public class PowerUpEffect : MonoBehaviour
{
    private Coroutine shieldCoroutine;
    private Coroutine doubleScoreCoroutine;
    private Coroutine rageCoroutine;

    public void StartShieldEffect()
    {
        if (shieldCoroutine != null)
        {
            StopCoroutine(shieldCoroutine);
        }
        shieldCoroutine = StartCoroutine(ShieldEffect());
    }

    public void StartDoubleScoreEffect(float duration)
    {
        if (doubleScoreCoroutine != null)
        {
            StopCoroutine(doubleScoreCoroutine);
        }
        doubleScoreCoroutine = StartCoroutine(DoubleScoreEffect(duration));
    }

    public void StartRageEffect(float duration)
    {
        if (rageCoroutine != null)
        {
            StopCoroutine(rageCoroutine);
        }
        rageCoroutine = StartCoroutine(RageEffect(duration));
    }

    private IEnumerator ShieldEffect()
    {
        // Tek seferlik kalkan efekti
        gameObject.layer = LayerMask.NameToLayer("Shielded");
        yield return new WaitForSeconds(0.1f);
        gameObject.layer = LayerMask.NameToLayer("whale");
        Debug.Log("Kalkan efekti bitti");
    }

    private IEnumerator DoubleScoreEffect(float duration)
    {
        GameManager.Instance.scoreMultiplier = 2;
        yield return new WaitForSeconds(duration);
        GameManager.Instance.scoreMultiplier = 1;
        Debug.Log("2x skor efekti bitti");
    }

    private IEnumerator RageEffect(float duration)
    {
        gameObject.layer = LayerMask.NameToLayer("Invincible");
        yield return new WaitForSeconds(duration);
        gameObject.layer = LayerMask.NameToLayer("whale");
        Debug.Log("Rage efekti bitti");
    }
} 