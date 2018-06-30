using UnityEngine;
using System.Collections;

namespace Solider {
    public class GravityAnimation : MonoBehaviour {
        public bool isReverseX = false;
        public bool isReverseY = false;

        public float maxX;
        public float minX;
        public float maxY;
        public float minY;

        public float change = 0.01f;

        public float speed = 0.3f;

        //上一次的值
        Vector3 lastAttitude = Vector3.zero;

        //平均值
        float meanX;
        float meanY;

        void Start() {
            meanX = (maxX - minX) / speed;
            meanY = (maxY - minY) / speed;
            Input.gyro.enabled = true;
        } // end Start

        // Update is called once per frame
        void Update() {
            //获取姿势
            Vector3 attitude = new Vector3(Input.gyro.attitude.x, Input.gyro.attitude.y, 0);

            //安全范围内 - 1之1
            attitude.x = Mathf.Clamp(attitude.x, -1f, 1f);
            attitude.y = Mathf.Clamp(attitude.y, -1f, 1f);


            float x = transform.localPosition.x;
            float y = transform.localPosition.y;


            //如果每帧变化不大 则使用上帧的值   防止抖动;
            if (System.Math.Abs(lastAttitude.x - attitude.x) >= change) {
                //这帧的偏移量
                float direction = attitude.x - lastAttitude.x;
                //偏移量对于的实际坐标位移
                float Position = direction * meanX;

                if (isReverseX) {
                    x = Mathf.Clamp(transform.localPosition.x + Position, minX, maxX);
                } else {
                    x = Mathf.Clamp(transform.localPosition.x - Position, minX, maxX);
                } // end if
            } // end if

            //如果每帧变化不大 则使用上帧的值   防止抖动;
            if (System.Math.Abs(lastAttitude.y - attitude.y) >= change) {
                //这帧的偏移量
                float direction = attitude.y - lastAttitude.y;
                //偏移量对于的实际坐标位移
                float Position = direction * meanY;

                if (isReverseY) {
                    y = Mathf.Clamp(transform.localPosition.y + Position, minY, maxY);
                } else {
                    y = Mathf.Clamp(transform.localPosition.y - Position, minY, maxY);
                } // end if
            } // end if
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
            //保存值
            lastAttitude = attitude;
        } // end Update
    } // end class GravityAnimation
} // end namespace Solider 