using UnityEngine;
using DG.Tweening;

public class RedFlash : MonoBehaviour
{
    public static RedFlash instance;
    static SpriteRenderer sprite;

    private void Start()
    {
        instance = this;
        sprite = GetComponent<SpriteRenderer>();
    }

    public static void Flash()
    {
        sprite.color = Color.red;
        DOTween.To(() => sprite.color, x => sprite.color = x, new Color(1f, 0f, 0f, 0f), .1f);
    }
}
