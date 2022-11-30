using UnityEngine;

namespace JackEasing.Sample {

    public class JackBezierSample : MonoBehaviour {

        public GameObject p0;
        public GameObject p1;
        public GameObject p2;
        public GameObject p3;

        public GameObject cur;

        LineRenderer line;
        int verticesCount = 100;

        float time;
        float duaraion;

        void Awake() {

            line = GetComponentInChildren<LineRenderer>();
            line.positionCount = verticesCount;

            p0 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            p0.name = "p0";
            p0.transform.position = new Vector3(0f, 0f, 0f);
            p0.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            p1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            p1.name = "p1";
            p1.transform.position = new Vector3(0f, 0f, 0f);
            p1.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            p2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            p2.name = "p2";
            p2.transform.position = new Vector3(1f, 1f, 0f);
            p2.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            p3 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            p3.name = "p3";
            p3.transform.position = new Vector3(1f, 1f, 0f);
            p3.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            cur = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cur.name = "cur";
            cur.transform.position = new Vector3(0f, 0f, 0f);
            cur.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            duaraion = 2f;

        }

        void Update() {

            time += Time.deltaTime;

            float timePercent = time / duaraion;
            if (timePercent > 1) {
                timePercent = 1;
            }

            float x = BezierHelper.CubicBezier(timePercent, p0.transform.position.x, p1.transform.position.x, p2.transform.position.x, p3.transform.position.x);
            float y = BezierHelper.CubicBezier(timePercent, p0.transform.position.y, p1.transform.position.y, p2.transform.position.y, p3.transform.position.y);
            var pos = new Vector3(x, y, 0f);
            cur.transform.position = pos;

            int index = (int)(verticesCount * timePercent);
            if (index >= verticesCount) {
                index = verticesCount - 1;
            }
            line.SetPosition(index, pos);

            // cur.transform.position = CubicBezierHelper.CubicBezier(timePercent, p0.transform.position, p1.transform.position, p2.transform.position, p3.transform.position);

            if (time > duaraion) {
                time = 0;
            }

        }

    }

}