using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Club : IIdentificable
    {
        public virtual int Id { get; private set; }
        public virtual string Latitude { get; set; }
        public virtual string Longitude { get; set; }
        public virtual string Name { get; set; }
        public virtual Logo Logo { get; set; }

        private IList<Team> teams;

        public virtual IList<Team> Teams
        {
            get { return this.teams ?? (this.teams = new List<Team>()); }
            protected set { this.teams = value; }
        }
    }
}
