using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 打飞机游戏
{
    /// <summary>
    /// 单例：我们创建了BG类，GO类，但还没有跟窗体联系起来所以运行并不能看到，为了使窗体不直接跟这些类
    /// 发生关系，我们设计一个中间单例类来做对接
    /// </summary>
    class SingleObject
    {
        /// <summary>
        /// 单例设计模式
        /// </summary>
       
        private SingleObject(){}//构造函数私有化
        private static SingleObject _singleobject = null;//全局唯一对象

        public static SingleObject GetSingle()//提供一个静态函数用于返回一个唯一的对象
        {
            if (_singleobject == null)
                _singleobject = new SingleObject();
                return _singleobject;
        }
        //单例设计完成


        
        /// <summary>
        /// 用属性存储背景对象
        /// </summary>
        public BackGround BG
        {
            get;
            set;
        }

        /// <summary>
        /// 属性存储玩家飞机
        /// </summary>
        public PlaneHero Hero
        {
            get;
            set;
        }
        //public PlaneEnemy Enemy
        //{
        //    get;
        //    set;
        //}

        //此处注意，我开始的想法是：对于敌人飞机，我也用一个属性存储，然后写三个初始化敌人飞机
        //语句，每次调用AddGameObject的时候，都将传递进来的对象赋值给属性Enemy，再继续后续操作
        //结果发现只能绘制出一个对象来，才知道错了，是因为，一个属性只能存储一个对象，当你再
        //次创建对象调AddGameObject的时候，第一个属性Enemy其实已经被替换了，所以只能绘制出你
        //最后一个创建的那个对象。
        //那么，为了绘制出同一类型（敌机）的三个不同飞机（0,1,2），我们用一个集合来存储，你调
        //一次add函数，我就将此对象放进集合中，进行后续绘制操作，再调，就放进集合的第二个位置
        //马上又进行绘制操作，依次类推。。。


        //声明一个集合对象来存储玩家子弹
       public List<ZiDanHero> listHeroZiDan = new List<ZiDanHero>();

        //声明一个集合对象来存储敌人飞机对象
       public List<PlaneEnemy> listPlaneEnemy = new List<PlaneEnemy>();
      
        /// <summary>
        /// 将创建的游戏对象（背景）添加到窗体中
        /// </summary>
        /// <param name="go"></param>
        public void AddGameObject(GameObject go)//不确定要把谁添加到窗体中，所以用父类
        {
            if (go is BackGround)
                this.BG = (BackGround)go;//此处是把背景对象添加到窗体中，所以转换为子类对象
            else if (go is PlaneHero)
                this.Hero = (PlaneHero)go;
            else if (go is ZiDanHero)//将子弹对象添加到游戏当中
                listHeroZiDan.Add((ZiDanHero)go);
            else if (go is PlaneEnemy)
              listPlaneEnemy.Add((PlaneEnemy)go);
            //else if (go is PlaneEnemy)//错误写法！
            //    this.Enemy = (PlaneEnemy)go;
        }

        //绘制背景图像和其他对象
        public void DrawGameobject(Graphics g)//这只是在单例中实现了绘制函数，还要在窗体中调用这个函数进行绘制
        {
            this.BG.Draw(g);//绘制背景图像
            this.Hero.Draw(g);//绘制玩家飞机
            for(int i=0;i<listHeroZiDan.Count;i++)//这不是绘制一个对象了，而是将子弹都封装成一个集合，然后再进行绘制
            {
                this.listHeroZiDan[i].Draw(g);
            }
            //绘制三种不同的敌人飞机
            for(int i=0;i<listPlaneEnemy.Count;i++)
            {
                this.listPlaneEnemy[i].Draw(g);
            }
           // this.Enemy.Draw(g);错误写法！忽略了属性被最后初始化那个对象替代的情况
        }

        //public void MoveGameObject()
        //{
        //    for (int i = 0; i < 10; i++)
        //        listPlaneEnemy[i].Move();
        //}


       //不同飞机销毁的条件不同，我们将条件设置在外面，这个方法只负责销毁,销毁就是从集合中移除
        public void RemoveGameObject(GameObject go)
       {
           if (go is PlaneEnemy)
               listPlaneEnemy.Remove(go as PlaneEnemy);
           else if (go is ZiDanHero)
               listHeroZiDan.Remove(go as ZiDanHero);
       }
    }
}
