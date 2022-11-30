using UnityEngine;

namespace JackEasing {

    // Attentions:
    // 1. duration must be greater than 0
    // 2. duration must greater than passed time
    public static class EasingHelper {

        public static float Ease1D(EasingType type, float passTime, float duration, float startValue, float endValue) {
            float timePercent = passTime / duration;
            if (timePercent > 1) {
                timePercent = 1;
            }
            float valuePercent = GetValuePercent(type, timePercent);
            return startValue + (endValue - startValue) * valuePercent;
        }

        public static Vector2 Ease2D(EasingType type, float passTime, float duration, Vector2 startValue, Vector2 endValue) {
            float timePercent = passTime / duration;
            if (timePercent > 1) {
                timePercent = 1;
            }
            float valuePercent = GetValuePercent(type, timePercent);
            return startValue + (endValue - startValue) * valuePercent;
        }

        public static Vector3 Ease3D(EasingType type, float passTime, float duration, Vector3 startValue, Vector3 endValue) {
            float timePercent = passTime / duration;
            if (timePercent > 1) {
                timePercent = 1;
            }
            float valuePercent = GetValuePercent(type, timePercent);
            return startValue + (endValue - startValue) * valuePercent;
        }

        static float GetValuePercent(EasingType type, float timePercent) {
            float valuePercent;
            switch (type) {
                case EasingType.Linear: valuePercent = FunctionHelper.EaseLinear(timePercent); break;
                case EasingType.InQuad: valuePercent = FunctionHelper.EaseInQuad(timePercent); break;
                case EasingType.OutQuad: valuePercent = FunctionHelper.EaseOutQuad(timePercent); break;
                case EasingType.InOutQuad: valuePercent = FunctionHelper.EaseInOutQuad(timePercent); break;
                case EasingType.InCubic: valuePercent = FunctionHelper.EaseInCubic(timePercent); break;
                case EasingType.OutCubic: valuePercent = FunctionHelper.EaseOutCubic(timePercent); break;
                case EasingType.InOutCubic: valuePercent = FunctionHelper.EaseInOutCubic(timePercent); break;
                case EasingType.InQuart: valuePercent = FunctionHelper.EaseInQuart(timePercent); break;
                case EasingType.OutQuart: valuePercent = FunctionHelper.EaseOutQuart(timePercent); break;
                case EasingType.InOutQuart: valuePercent = FunctionHelper.EaseInOutQuart(timePercent); break;
                case EasingType.InQuint: valuePercent = FunctionHelper.EaseInQuint(timePercent); break;
                case EasingType.OutQuint: valuePercent = FunctionHelper.EaseOutQuint(timePercent); break;
                case EasingType.InOutQuint: valuePercent = FunctionHelper.EaseInOutQuint(timePercent); break;
                case EasingType.InSine: valuePercent = FunctionHelper.EaseInSine(timePercent); break;
                case EasingType.OutSine: valuePercent = FunctionHelper.EaseOutSine(timePercent); break;
                case EasingType.InOutSine: valuePercent = FunctionHelper.EaseInOutSine(timePercent); break;
                case EasingType.InExpo: valuePercent = FunctionHelper.EaseInExpo(timePercent); break;
                case EasingType.OutExpo: valuePercent = FunctionHelper.EaseOutExpo(timePercent); break;
                case EasingType.InOutExpo: valuePercent = FunctionHelper.EaseInOutExpo(timePercent); break;
                case EasingType.InCirc: valuePercent = FunctionHelper.EaseInCirc(timePercent); break;
                case EasingType.OutCirc: valuePercent = FunctionHelper.EaseOutCirc(timePercent); break;
                case EasingType.InOutCirc: valuePercent = FunctionHelper.EaseInOutCirc(timePercent); break;
                case EasingType.InElastic: valuePercent = FunctionHelper.EaseInElastic(timePercent); break;
                case EasingType.OutElastic: valuePercent = FunctionHelper.EaseOutElastic(timePercent); break;
                case EasingType.InOutElastic: valuePercent = FunctionHelper.EaseInOutElastic(timePercent); break;
                case EasingType.InBack: valuePercent = FunctionHelper.EaseInBack(timePercent); break;
                case EasingType.OutBack: valuePercent = FunctionHelper.EaseOutBack(timePercent); break;
                case EasingType.InOutBack: valuePercent = FunctionHelper.EaseInOutBack(timePercent); break;
                case EasingType.InBounce: valuePercent = FunctionHelper.EaseInBounce(timePercent); break;
                case EasingType.OutBounce: valuePercent = FunctionHelper.EaseOutBounce(timePercent); break;
                case EasingType.InOutBounce: valuePercent = FunctionHelper.EaseInOutBounce(timePercent); break;
                default: throw new System.ArgumentException("Invalid EasingType" + type.ToString());
            }
            return valuePercent;
        }

    }

}