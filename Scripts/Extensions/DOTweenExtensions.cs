namespace TheOneStudio.DuckBase.Scripts.Extensions
{
    using DG.Tweening;
    using DG.Tweening.Core;
    using DG.Tweening.Plugins.Options;
    using TMPro;

    public static class DOTweenExtensions
    {
        public static TweenerCore<int, int, NoOptions> DOCounter(this TMP_Text target, int fromValue, int endValue, float duration, string prefix = null, string suffix = null)
        {
            var v = fromValue;
            var t = DOTween.To(() => v, x =>
            {
                v           = x;
                target.text = $"{prefix}{v}{suffix}";
            }, endValue, duration);
            t.SetTarget(target);

            return t;
        }
    }
}