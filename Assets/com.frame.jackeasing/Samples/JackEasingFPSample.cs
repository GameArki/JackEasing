using UnityEngine;
using FixMath.NET;

namespace JackEasing.Sample {

    public class JackEasingFPSample : MonoBehaviour {

        FP64 time;
        FP64 duaraion = 5;
        float wait;

        GameObject ease1d;
        GameObject ease2d;
        GameObject ease3d;

        FP64 f_start;
        FP64 f_end;

        FPVector2 v2_start;
        FPVector2 v2_end;

        FPVector3 v3_start;
        FPVector3 v3_end;

        int curType;

        void Awake() {

            FP64 target = 5;

            ease1d = GameObject.Find("Ease1D");
            f_start = FP64.ToFP64(ease1d.transform.position.x);
            f_end = FP64.ToFP64(ease1d.transform.position.x + target.AsFloat());

            ease2d = GameObject.Find("Ease2D");
            v2_start = ease2d.transform.position.ToFPVector2();
            v2_end = (ease2d.transform.position + new FPVector3(target, target, 0).ToVector3()).ToFPVector2();

            ease3d = GameObject.Find("Ease3D");
            v3_start = ease3d.transform.position.ToFPVector3();
            v3_end = (ease3d.transform.position + new FPVector3(target, target, target).ToVector3()).ToFPVector3();

            curType = (int)EasingType.InBounce;

        }

        void OnGUI() {
            GUILayout.Label("Current: " + ((EasingType)curType).ToString());
        }

        void Update() {

            if (wait > 0f) {
                wait -= Time.deltaTime;
                return;
            }

            time += FP64.ToFP64(Time.deltaTime);

            if (time > duaraion) {
                time = 0;
                curType += 1;
                if (curType > (int)EasingType.InOutBounce) {
                    curType = (int)EasingType.Linear;
                }
                wait = 0;
            }

            EasingType easingType = (EasingType)curType;
            Ease1D(easingType);
            Ease2D(easingType);
            Ease3D(easingType);

        }

        void Ease1D(EasingType easingType) {
            FP64 value1d = 0;
            value1d = FPEasingHelper.Ease1D(easingType, time, duaraion, f_start, f_end);
            FPVector3 tar = new FPVector3(value1d, FP64.ToFP64(ease1d.transform.position.y), FP64.ToFP64(ease1d.transform.position.z));
            ease1d.transform.position = tar.ToVector3();
        }

        void Ease2D(EasingType easingType) {
            FPVector2 value2d = FPVector2.Zero;
            value2d = FPEasingHelper.Ease2D(easingType, time, duaraion, v2_start, v2_end);
            FPVector3 tar = new FPVector3(value2d.x, value2d.y, FP64.ToFP64(ease2d.transform.position.z));
            ease2d.transform.position = tar.ToVector3();
        }

        void Ease3D(EasingType easingType) {
            FPVector3 value3d = FPVector3.Zero;
            value3d = FPEasingHelper.Ease3D(easingType, time, duaraion, v3_start, v3_end);
            ease3d.transform.position = value3d.ToVector3();
        }

    }

    public static class VectorExtention {

        public static FPVector2 ToFPVector2(this Vector2 v) {
            return new FPVector2(FP64.ToFP64(v.x), FP64.ToFP64(v.y));
        }

        public static FPVector2 ToFPVector2(this Vector3 v) {
            return new FPVector2(FP64.ToFP64(v.x), FP64.ToFP64(v.y));
        }

        public static FPVector3 ToFPVector3(this Vector3 v) {
            return new FPVector3(FP64.ToFP64(v.x), FP64.ToFP64(v.y), FP64.ToFP64(v.z));
        }

        public static Vector2 ToVector2(this FPVector2 v) {
            return new Vector2((float)v.x, (float)v.y);
        }

        public static Vector2 ToVector2(this FPVector3 v) {
            return new Vector2((float)v.x, (float)v.y);
        }

        public static Vector3 ToVector3(this FPVector3 v) {
            return new Vector3((float)v.x, (float)v.y, (float)v.z);
        }
    }

}