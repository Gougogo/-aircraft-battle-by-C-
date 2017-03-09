using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 打飞机游戏.Properties;//虽然导入游戏资源，但还要引用命名空间，才可以书写代码

namespace 打飞机游戏
{
    class BackGround:GameObject
    {
        //将导入的背景图片绘制到窗体上
        private static Image imgBG = Resources.background;//用一个字段将要绘制的图片引用储存起来

        //构造函数调用父类构造函数
      public  BackGround(int x,int y,int speed):base(x,y,imgBG.Width,imgBG.Height,speed,0,Direction.Down)//注意哪些是需要从外界传入的就需要设置参数
        {

        }

        /// <summary>
        /// 绘制背景 
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
            this.Y += this.Speed;
            if(this.Y==0)
            {
                this.Y = -850;
            }
            g.DrawImage(imgBG, this.X, this.Y);
        }
    }
}
