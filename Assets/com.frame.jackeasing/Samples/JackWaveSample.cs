using UnityEngine;

namespace JackEasing {

    public class JackWaveSample : MonoBehaviour {

        GameObject cur;

        [SerializeField] float frequency;
        [SerializeField] float amplitude;
        [SerializeField] float phase;
        [SerializeField] float duaraion;

        LineRenderer line;
        int verticesCount = 100;

        float time;

        void Awake() {

            line = transform.root.GetComponentInChildren<LineRenderer>();
            line.positionCount = verticesCount;

            cur = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            cur.name = "cur";
            cur.transform.position = new Vector3(0f, 0f, 0f);
            cur.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

        }

        void Update() {

            time += Time.deltaTime;
            float timePercent = time / duaraion;

            float valuePercent = WaveHelper.SinWaveReduction(time, duaraion, amplitude, frequency, phase);

            var pos = new Vector3(time, valuePercent, 0f);
            cur.transform.position = pos;

            int index = (int)(timePercent * verticesCount);
            if (index < verticesCount) {
                line.SetPosition(index, pos);
            }

            if (timePercent > 1) {
                time = 0;
            }

        }

    }

}