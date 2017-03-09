using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 打飞机游戏.Properties;//导入命名空间
using System.Drawing;
using System.Windows.Forms;

namespace 打飞机游戏
{
    /// <summary>
    /// 
    /// </summary>
    class PlaneHero:PlaneFather
    {
        //导入玩家飞机的图片，存储在字段中
        private static Image hero = Resources.hero1;//此处已经将hero初始化，所以在类里面使用时应该加static修饰


        /// <summary>
        /// 可以将声明的玩家飞机字段传递给构造方法，但要加static，是因为非静态的成员要用对象引用，此处还没创建对象，所以加static
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="life"></param>
        /// <param name="speed"></param>
        /// <param name="dir"></param>
        public PlaneHero(int x,int y,int life,int speed,Direction dir):base(x,y,hero,life,speed,dir)
        {}

        //重写GameObject类中的抽象方法Draw
        public override void Draw(Graphics g)
        {
            g.DrawImage(hero, this.X, this.Y,this.Width/2,this.Height/2);//有很多重载方法
        }

        internal void MouseMove(MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }

        public void Fire()
        {
            //初始化子弹对象
            SingleObject.GetSingle().AddGameObject(new ZiDanHero(this, 10, 1));
        }
    }
}
