using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Children
{
    public class Girl:ChildInfo, IPrint
    {

        public Girl(string name, string egn, string gender, int ageMeasure, int hight, float weight) : base(name, egn, gender, ageMeasure, hight, weight)
        {
        }

        public string Print()
        {
            return $"Child {this.Name} is {this.Gender}, EGN - {this.Egn}"
                + $", age when last time measured: {this.AgeMeasure}, hight: {this.Height}, weight: {this.Weight}";

        }

    }
}
