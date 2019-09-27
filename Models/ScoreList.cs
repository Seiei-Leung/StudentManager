using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ScoreList
    {
        public int id
        {
            set;
            get;
        }
        public int studentId
        {
            set;
            get;
        }

        public int cSharp
        {
            set;
            get;
        }

        public int java
        {
            set;
            get;
        }

        public DateTime updateTime
        {
            set;
            get;
        }
    }
}
