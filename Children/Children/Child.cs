using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Children
{
    public abstract class Child
    {
        protected string Name { get; set; }
        protected string Egn { get; set; }
        protected string Gender { get; set; }


        public Child(string _name, string _egn, string _gender)
        {
            this.Name = _name;
            this.Egn = _egn;
            this.Gender = _gender;
        }

        abstract public double GetHeight(List<ChildInfo> children);

        abstract public string ReturnName();
    }
}
