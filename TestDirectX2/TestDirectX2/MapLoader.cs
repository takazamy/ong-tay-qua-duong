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
        private DxInitGraphics _graphics;
        public string soundKey = "";
        private int _condition = 0;
        public List<List<Enemy>> _enemyListCodition;
        public int Condition
        {
            get { return _condition; }
           
        }

        private List<Enemy> _enemies;
        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

        private List<int> _conditionList;

        public List<int> ConditionList
        {
            get { return _conditionList; }
            set { _conditionList = value; }
        }

        public MapLoader(DxInitGraphics graphics)
        {
            _graphics = graphics;
        }
        public void LoadMap(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);

            _enemies = new List<Enemy>();
            _conditionList = new List<int>();
            _enemyListCodition = new List<List<Enemy>>();

            XmlNodeList sounds = doc.SelectNodes("//Sound");
            foreach (XmlNode sound in sounds)
            {
                soundKey = sound.Attributes["key"].Value;
            }
           
            XmlNodeList maps = doc.SelectNodes("//Events");
            foreach (XmlNode map in maps)
            {
                List<Enemy> enemies = new List<Enemy>();
                _condition = int.Parse(map.Attributes["x"].Value);
                foreach (XmlNode _event in map.ChildNodes)
                {
                    
                    // x="300" y="600" hp="10" dmg="10" power ="10" direction ="1"
                    int x = int.Parse(_event.Attributes["x"].Value);
                    int y = int.Parse(_event.Attributes["y"].Value);
                    int hp = int.Parse(_event.Attributes["hp"].Value);
                    int dmg = int.Parse(_event.Attributes["dmg"].Value);
                    int power = int.Parse(_event.Attributes["power"].Value);
                    int direction = int.Parse(_event.Attributes["direction"].Value);
                    Enemy _enemy = new Enemy(x, y, hp, dmg, power, 5, new Core.DxInitSprite("Assets/walk.png", _graphics.GraphicsDevice, 104, 150), direction);
                    enemies.Add(_enemy);
                }
                _enemyListCodition.Add(enemies);
                enemies = null;
                _conditionList.Add(_condition);
            }
        }
    }
}
