using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using 打飞机游戏.Properties;
using System.Windows.Forms;

namespace 打飞机游戏
{
    class ZiDanHero:ZiDanFather
    {
        private static Image ZDhero=Resources.bullet1;

        /// <summary>
        /// 构造函数初始化
        /// </summary>
        /// <param name="pf"></param>
        /// <param name="speed"></param>
        /// <param name="power"></param>
        public ZiDanHero(PlaneFather pf,int speed, int power)
            : base(pf,ZDhero,speed,power){}

        internal void MouseMove(MouseEventArgs e)
        {
            this.X = e.X;
            this.Y = e.Y;
        }

    }
}
