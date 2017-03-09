using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 打飞机游戏.Properties;

namespace 打飞机游戏
{
    class PlaneEnemy:PlaneFather
    {
        private static Image img1 = Resources.enemy0;
        private static Image img2 = Resources.enemy1;//如果不导入命名空间，则应该写成:打飞机游戏.Properties.Resources.enemy1;
        private static Image img3 = Resources.enemy2;

        /// <summary>
        /// 因为每一架飞机大小，生命值，速度都不一样，所以声明一个标示来标记当前飞机是什么飞机
        /// 用属性来标示0，1，2
        /// </summary>

        public int EnemyType
        {
            get;
            set;
        }
        Random r = new Random();

        //根据飞机的类型，返回对应的值
        public static Image GetImage(int type)//静态函数只能访问静态成员,构造函数要访问
        {
            switch(type)
            {
                case 0: { return img1; }
                case 1: { return img2; }
                case 2: { return img3; }
            }
            return null;
        }

        //返回速度
        public static int  GetSpeed(int type)
        {
            switch(type)
            {
                case 0: return 5;
                case 1: return 6;
                case 2: return 7;
            }
            return 0;
        }

        //返回生命值
        public static int GetLife(int type)
        {
             switch(type)
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 3;
            }
            return 0;
        }

        public PlaneEnemy(int x, int y, int life, int speed,int type)
            : base(x, y, GetImage(type), GetLife(type), GetSpeed(type),Direction.Down)
        {
            this.EnemyType = type;
        }
        /// <summary>
        /// 重写父类的Draw函数
        /// </summary>
        /// <param name="g"></param>
         public override void Draw(Graphics g)
        {
            this.Move();//画出飞机之后，就让飞机开始移动
            //可以这样写？g.DrawImage(GetImage(this.EnemyType), this.X, this.Y, this.Width / 2, this.Height / 2);
            switch(this.EnemyType)
            {
                case 0:
                    g.DrawImage(img1, this.X, this.Y, this.Width / 2, this.Height / 2);break;
                case 1:
                    g.DrawImage(img2,this.X, this.Y, this.Width / 2, this.Height / 2);break;
                case 2:
                    g.DrawImage(img3,this.X, this.Y, this.Width / 2, this.Height / 2);break;
            }
         }

         public override void Move()
         {
             switch (Dir)
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

             if (this.X <= 0)
             {
                 this.X = 0;
             }
             if (this.X >= 400)
             {
                 this.X = 400;
             }
             if (this.Y <= 0)
             {
                 this.Y = 0;
             }
             if (this.Y > 700)//应该销毁敌机对象
             { 
                // this.Y = 1000;
                 //同时 当敌人飞机离开窗体的时候 我们应该销毁当前敌人飞机
                 SingleObject.GetSingle().RemoveGameObject(this);//this表示当前当前对象
             }

             //对于小飞机，我可以允许它带有一点晃动的特性
             if(this.EnemyType==0)
             {
                 //MoveReturn();
                 if (this.X >= 0 && this.X <= 150)
                 {
                     //表示当前的小飞机在左边的范围内
                     //增加当前飞机的X值
                     this.X += r.Next(0, 30);
                     this.X -= r.Next(0, 30);//加这一句是为了产生晃动
                 }
                 else
                 {
                     this.X -= r.Next(0, 20);
                     this.X += r.Next(0, 30);
                 }
             }

         }
        void MoveReturn()
         {
             if (this.X >= 0 && this.X <= 150)
             {
                 //表示当前的小飞机在左边的范围内
                 //增加当前飞机的X值
                 this.X += r.Next(0, 30);
                 this.X -= r.Next(0, 30);
             }
         }
    }
}
