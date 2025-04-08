using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Ironbreaker.Toolkit.UnityExtensions.UIExtensions
{
    public static class GraphicExtensions
    {
        public static Coroutine FadeIn(this Graphic graphic, float duration, System.Action callback = null, bool useUnscaledTime = true)
        { 
            return graphic.StartCoroutine(FadeGraphic(graphic, duration, 1, callback, useUnscaledTime));
        }

        public static Coroutine FadeOut(this Graphic graphic, float duration, System.Action callback = null, bool useUnscaledTime = true)
        {
            return graphic.StartCoroutine(FadeGraphic(graphic, duration, 0, callback, useUnscaledTime));
        }

        static IEnumerator FadeGraphic(Graphic graphic, float duration, int direction, System.Action callback, bool useUnscaledTime)
        {
            if (graphic == null)
            {
                Debug.LogWarning("The given Graphic instance is null.");
                yield break;
            }

            float timer = 0f;
            Color startColor = graphic.color;
            Color targetColor = startColor;

            targetColor.a = direction == 1 ? 1f : 0f;

            while (timer < 1f)
            {
                if (useUnscaledTime)
                    timer += Time.unscaledDeltaTime / duration;
                else
                    timer += Time.deltaTime / duration;

                graphic.color = Color.Lerp(startColor, targetColor, timer);

                yield return null;
            }

            callback?.Invoke();
        }
    }

    //public static class ImageExtensions
    //{
    //    public static Coroutine FadeIn(this Image image, float duration, System.Action callback = null)
    //    {
    //        return image.StartCoroutine(FadeImage(image, duration, 1, callback));
    //    }

    //    public static Coroutine FadeOut(this Image image, MonoBehaviour caller, float duration, System.Action callback = null)
    //    {
    //        return caller.StartCoroutine(FadeImage(image, duration, 0, callback));
    //    }

    //    static IEnumerator FadeImage(Image image, float duration, int direction, System.Action callback)
    //    {
    //        float timer = 0f;
    //        Color startColor, targetColor;

    //        startColor = image.color;
    //        targetColor = startColor;

    //        targetColor.a = direction == 1 ? 1f : 0f;

    //        while (timer < 1f)
    //        {
    //            timer += Time.unscaledDeltaTime / duration;

    //            image.color = Color.Lerp(startColor, targetColor, timer);

    //            yield return null;
    //        }

    //        callback?.Invoke();
    //    }
    //}

    public static class CanvasGroupExtensions
    {
        public static Coroutine FadeIn(this CanvasGroup canvas, MonoBehaviour caller, float duration, System.Action callback = null, bool useUnscaledTime = true)
        {
            if (caller == null)
            {
                Debug.LogWarning("The given caller is null.");
                return null;
            }

            return caller.StartCoroutine(FadeImage(canvas, duration, 1, callback, useUnscaledTime));
        }

        public static Coroutine FadeOut(this CanvasGroup canvas, MonoBehaviour caller, float duration, System.Action callback = null, bool useUnscaledTime = true)
        {
            if (caller == null)
            {
                Debug.LogWarning("The given caller is null.");
                return null;
            }

            return caller.StartCoroutine(FadeImage(canvas, duration, 0, callback, useUnscaledTime));
        }

        static IEnumerator FadeImage(CanvasGroup canvas, float duration, int direction, System.Action callback, bool useUnscaledTime)
        {
            if (canvas == null)
            {
                Debug.LogWarning("The given CanvasGroup instance is null.");
                yield break;
            }

            float timer = 0f;
            float startAlpha, targetAlpha;

            startAlpha = canvas.alpha;

            targetAlpha = (direction == 1) ? 1f : 0f;

            while (timer < 1f)
            {
                if (useUnscaledTime)
                    timer += Time.unscaledDeltaTime / duration;
                else
                    timer += Time.deltaTime / duration;

                canvas.alpha = Mathf.Lerp(startAlpha, targetAlpha, timer);

                yield return null;
            }

            callback?.Invoke();
        }
    }
}
