using UnityEngine;

namespace YarCustomMath
{
    public static class CustomMath
    {
        public static int RemapValue(int value, int fromLow, int fromHigh, int toLow, int toHigh)
        {
            return toLow + (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow);
        }
        
        public static float RemapValue(float value, float fromLow, float fromHigh, float toLow, float toHigh)
        {
            return toLow + (value - fromLow) * (toHigh - toLow) / (fromHigh - fromLow);
        }
    }
}
