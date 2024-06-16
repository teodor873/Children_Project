using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Children
{
    public class ChildInfo : Child, IPrint
    {
        private int ageMeasure;
        private int height;
        private float weight;

        public float Weight
        {
            get { return weight; }
            set {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value");
                }
                weight = value; 
            }
        }

        public int Height
        {
            get { return height; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value");
                }
                height = value;
            }
        }

        public int AgeMeasure
        {
            get { return ageMeasure; }
            set 
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value");
                }
                ageMeasure = value; 
            }
        }

        public ChildInfo(string name, string egn, string gender, int _ageMeasure, int _hight, float _weight) : base(name, egn, gender)
        {
            this.AgeMeasure = _ageMeasure;
            this.Height = _hight;
            this.Weight = _weight;
        }

        public override double GetHeight(List<ChildInfo> child)
        {
            double averageHeight = child.Average(x => x.Height);
            return averageHeight;
        }

        public string Print()
        {
            return $"Child {this.Name} is {this.Gender}, EGN - {this.Egn}"
                 + $", age when last time measured: {this.AgeMeasure}, hight: {this.Height}, weight: {this.Weight}";
        }

        public override string ReturnName()
        {
            return this.Name;
        }

    }
}
