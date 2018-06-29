using UnityEngine;
using System.Collections;

public class GravityAnimation : MonoBehaviour
{
    Transform target;

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
   
    void Start()
    {
        if (target == null)
        {
            target = this.transform;
        }

        Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            return;
        }


        //获取姿势
        Vector3 attitude = new Vector3(Input.gyro.attitude.x, Input.gyro.attitude.y, 0);


        //安全范围内 - 1之1
        attitude.x = Tool(attitude.x, 1, -1);
        attitude.y = Tool(attitude.y, 1, -1);




        float x = target.localPosition.x;
        float y = target.localPosition.y;




        //如果每帧变化不大 则使用上帧的值   防止抖动;
        if (System.Math.Abs(lastAttitude.x - attitude.x) >= change)
        {
            //这帧的偏移量
            float direction = attitude.x - lastAttitude.x;

            meanX = (maxX - minX) / speed;

            //偏移量对于的实际坐标位移
            float Position = direction * meanX;


            if (isReverseX)
            {
                x = Tool(target.localPosition.x + Position, maxX, minX);
            }
            else
            {
                x = Tool(target.localPosition.x - Position, maxX, minX);
            }
        }



        //如果每帧变化不大 则使用上帧的值   防止抖动;
        if (System.Math.Abs(lastAttitude.y - attitude.y) >= change)
        {
            //这帧的偏移量
            float direction = attitude.y - lastAttitude.y;


            meanY = (maxY - minY) / speed;
            //偏移量对于的实际坐标位移
            float Position = direction * meanY;

            if (isReverseY)
            {
                y = Tool(target.localPosition.y + Position, maxY, minY);
            }
            else
            {
                y = Tool(target.localPosition.y - Position, maxY, minY);
            }
        }




        target.localPosition = new Vector3(x, y, target.localPosition.z);

        //保存值
        lastAttitude = attitude;

    }





    //使第origin的值在界限之内
    float Tool(float origin, float max, float min)
    {
        float retrun = origin;

        if (retrun >= max)
        {
            retrun = max;
        }
        else if (retrun <= min)
        {
            retrun = min;
        }

        return retrun;
    }


}
