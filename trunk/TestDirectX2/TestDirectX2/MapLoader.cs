using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using TestDirectX2.Core;

namespace TestDirectX2
{
    public class MapLoader
    {
        //private int _height;
        //public int MapHeight
        //{
        //    get { return _height; }
        //}

        private int _condition = 0;

        public int Condition
        {
            get { return _condition; }
           
        }

        private List<Enemy> _enemies;
        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        public void LoadMap(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            _enemies = new List<Enemy>();

            XmlNodeList maps = doc.SelectNodes("//map");
            foreach (XmlNode map in maps)
            {
                _condition = int.Parse(map.Attributes["x"].Value);
                foreach (XmlNode _event in map.ChildNodes)
                {
                   
                    int x = int.Parse(_event.Attributes["x"].Value);
                    int y = int.Parse(_event.Attributes["y"].Value);
                    
                    int type = int.Parse(_event.Attributes["type"].Value);
                   // DxInitSprite tempSprite = new DxInitSprite("Assets/walk.png"
                    //Enemy e = new Enemy(x, y, 10, 10, 10, 5, "Assets/walk.png", -1);

                    //switch (type)
                    //{
                    //    case 1:
                    //        e.Position = new System.Drawing.Point(x, y);
                    //        break;
                    //    case 2:
                    //        e.Position = new System.Drawing.Point(x1, y1);
                    //        break;
                    //}

                   // _enemies.Add(e);
                }
            }
        }
    }
}
