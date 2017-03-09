using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 打飞机游戏
{
    /// <summary>
    /// 一个类的父类是抽象类，则应该实现父类中所有的抽象方法，
    /// 但我们恰恰不能实现Draw方法，因为玩家飞机和敌人飞机不一样，
    /// 所以也应该把这个类声明为抽象类。
    /// </summary>
    abstract class PlaneFather : GameObject
    {
        //声明一个存储飞机图片的字段
        private Image plane;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="img"></param>
        /// <param name="life"></param>
        /// <param name="speed"></param>
        /// <param name="dir"></param>
        public PlaneFather(int x,int y,Image img,int life,int speed,Direction dir)
            :base(x,y,img.Width,img.Height,speed,life,dir)
        {
            this.plane = img;
        }


    }
}
