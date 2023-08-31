using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRPG
{
    public class SkillList
    {
        public static Skill alphaStrike = new Skill("알파 스트라이크", "공격력 * 2로 하나의 적을 공격합니다.", 10);
        public static Skill doubleStrike = new Skill("더블 스트라이크", "공격력 * 1로 2명의 적을 랜덤으로 공격합니다.", 15);

        public static Skill thunderVolt = new Skill("썬더 볼트", "공격력 * 1로 모든 적을 공격합니다.", 30);
        public static Skill heal = new Skill("힐", "체력을 30 회복합니다.", 20);
    }
}