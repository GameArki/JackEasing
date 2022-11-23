using UnityEngine;

namespace JackEasing.Sample {

    public class JackEasingSample : MonoBehaviour {

        float time;
        float duaraion = .1f;
        float wait;

        GameObject ease1d;
        GameObject ease2d;
        GameObject ease3d;

        float f_start;
        float f_end;

        Vector2 v2_start;
        Vector2 v2_end;

        Vector3 v3_start;
        Vector3 v3_end;

        int curType;

        void Awake() {

            float target = 5f;

            ease1d = GameObject.Find("Ease1D");
            f_start = ease1d.transform.position.x;
            f_end = ease1d.transform.position.x + target;

            ease2d = GameObject.Find("Ease2D");
            v2_start = ease2d.transform.position;
            v2_end = ease2d.transform.position + new Vector3(target, target, 0f);

            ease3d = GameObject.Find("Ease3D");
            v3_start = ease3d.transform.position;
            v3_end = ease3d.transform.position + new Vector3(target, target, target);

            curType = (int)EasingType.Linear;

        }

        void OnGUI() {
            GUILayout.Label("Current: " + ((EasingType)curType).ToString());
        }

        void Update() {

            if (wait > 0f) {
                wait -= Time.deltaTime;
                return;
            }

            time += Time.deltaTime;

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
            float value1d = 0;
            value1d = EasingHelper.Ease1D(easingType, time, duaraion, f_start, f_end);
            Vector3 tar = new Vector3(value1d, ease1d.transform.position.y, ease1d.transform.position.z);
            ease1d.transform.position = tar;
        }

        void Ease2D(EasingType easingType) {
            Vector2 value2d = Vector2.zero;
            value2d = EasingHelper.Ease2D(easingType, time, duaraion, v2_start, v2_end);
            Vector3 tar = new Vector3(value2d.x, value2d.y, ease2d.transform.position.z);
            ease2d.transform.position = tar;
        }

        void Ease3D(EasingType easingType) {
            Vector3 value3d = Vector3.zero;
            value3d = EasingHelper.Ease3D(easingType, time, duaraion, v3_start, v3_end);
            ease3d.transform.position = value3d;
        }

    }

}