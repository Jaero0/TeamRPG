using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    // -----------Song-----------
    // 스킬 구현
    public class Skill
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int MpConsume { get; set; }

        public Skill(string name, string description, int mpConsume)
        {
            Name = name;
            Description = description;
            MpConsume = mpConsume;
        }
    }

}