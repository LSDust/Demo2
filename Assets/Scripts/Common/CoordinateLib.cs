using System;
using Godot;

namespace Library
{
    public static class CoordinateLib
    {
        public const float Sqrt3 = 1.7320508f;//Mathf.Sqrt(3);

        /// <summary>
        /// 斜角坐标转换为直角坐标，高度Y无关
        /// </summary>
        /// <param name="v60">斜角坐标</param>
        /// <returns></returns>
        public static Vector2 Maping60To90(Vector3I v60)
        {
            if (v60.Y != 0)
            {
                GD.Print("Maping60To90,坐标高度不为0");
            }
            // float X_90 = (v60.X - v60.Z) / 2f;
            // float Z_90 = (v60.X + v60.Z) * Sqrt3 / 2f;
            // return new Vector3(X_90, 0, Z_90);
            return Maping60To90(v60.X, v60.Z);
        }

        /// <summary>
        /// 直角坐标转换为斜角坐标的线性映射
        /// </summary>
        /// <param name="X_60">基底X的倍数</param>
        /// <param name="Z_60">基底Z的倍数</param>
        /// <returns></returns>
        public static Vector2 Maping60To90(int X_60, int Z_60)
        {
            float X_90 = (X_60 - Z_60) / 2f;
            float Z_90 = (X_60 + Z_60) * Sqrt3 / 2f;
            return new Vector2(X_90, Z_90);
        }

        /// <summary>
        /// 二维向量中间插入高度Y的值
        /// </summary>
        /// <param name="v2"></param>
        /// <param name="y">高度</param>
        /// <returns></returns>
        public static Vector3 Vector2ToVector3(Vector2 v2, float y)
        {
            return new Vector3(v2.X, y, v2.Y);
        }
    }
}
