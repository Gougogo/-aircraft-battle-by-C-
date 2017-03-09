using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 打飞机游戏
{
    /// <summary>
    /// 所有游戏对象的父类，设计这样一个父类是为了封装子类共有的成员或属性，所有游戏对象
    /// 在游戏中都有X,Y,height,width。子弹打到飞机，自己的飞机被敌机打到都有碰撞检测，双方飞机
    /// 都有生命值,敌机，玩家机都在场景中移动等，还要区分开哪些应该定义成虚方法，哪些是抽象方法
    /// </summary>
   abstract class GameObject//类的成员函数又抽象的，所以该类也应该是抽象类
    {
        /// <summary>
        /// 碰撞检测需要用到X,Y,Width,Height参数
        /// </summary>
      public enum Direction 
        {
            Up,Down,Right,Left
        }
        public int X
        {
            get;
            set;
        }
        public int Y
        {
            get;
            set;
        }
        public int Width
        {
            set;
            get;
        }
        public int Height
        {
            set;
            get;
        }
        public int Speed
        {
            set;
            get;
        }
        public int Life
        {
            set;
            get;
        }
        public Direction Dir
        {
            set;
            get;
        }
        
        //构造函数
     public GameObject(int x,int y,int width,int height,int speed,int life,Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.Life = life;
            this.Speed = speed;
            this.Dir = dir;
        }

      /// <summary>
        ///每一个对象通过G++将自己绘制到窗体的方式都不一样，所以父类应该提供一个抽象方法，
        // 让子类自己去实现相应的绘制方法
      /// </summary>
      /// <param name="g"></param>
        public abstract void Draw(Graphics g);

        
        /// <summary>
        ///提供一个碰撞检测的方法，返回一个矩形对象
        /// </summary>
        /// <returns></returns>
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this.Width, this.Height);
        }
        /// <summary>
        /// Move方法对于敌机，玩家机，有共性，也有不同的地方，所以定义为虚方法,也可以为每个对象定义
        /// 不同名字的Move方法，但是这样程序显得繁杂，那么可以先为这些对象定义一个共有的父类，在父类中
        /// 声明Move方法为虚函数，从而让子类去实现不同功能
        /// </summary>
        public virtual void Move()
        {
            switch(Dir)
            {
                case Direction.Up:
                    this.Y -= this.Speed;
                    break;
                case Direction.Down:
                    this.Y += this.Speed;
                    break;
                case Direction.Left:
                    this.Width -= this.Speed;
                    break;
                case Direction.Right:
                    this.Height += this.Speed;
                    break;
            }

            //移动结束之后，判断飞机与窗体之间的关系，敌机会重写此方法不管
            if (this.X < 0)
                this.X = 0;
            if (this.X > 480)
                this.X = 400;
            if (this.Y <= 0)
                this.Y = 0;
            if (this.Y >= 720)
                this.Y = 720;
        }
        
    }
}
