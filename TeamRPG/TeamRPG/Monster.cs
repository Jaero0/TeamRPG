using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TeamRPG;
using static System.Net.Mime.MediaTypeNames;

namespace TeamRPG
{
    public class Monsters
    {
        public static StringBuilder sb = new StringBuilder(); //빠른출력을 위해 사용

        public static List<CharacterBase> monstersList;

        //==================전투===============================
        public Monsters()
        {
            monstersList = new List<CharacterBase>();
        }

        public static List<CharacterBase> GetMonstersList() //다른클래스에서 몬스터클래스를 사용하기위한 반환값
        {
            return monstersList;
        }
        public static void sbClear()
        {
            Console.WriteLine(sb);
            sb.Clear();
        }

        public void AddMonster2List(CharacterBase _Monster)
        {
            monstersList.Add(_Monster);
        }

        public static void FightInfo() //전투메서드
        {
            Console.Clear();

            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[전투]");

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} ");
                    sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.SetCursorPosition(3 + (i * 27), 7);
                    Console.WriteLine(sb);
                    sb.Clear();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(3 + (i * 27), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }

            }
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            // ---------- Song Mp 추가 ---------------
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            sbClear();



            Console.SetCursorPosition(2, 23);
            Console.WriteLine(" [1] 공격 ");
            // ---------- Song 스킬추가 ---------------
            Console.SetCursorPosition(24, 23);
            Console.WriteLine(" [2] 스킬 ");
            // ---------- Song ---------------
            Console.SetCursorPosition(48, 23);
            Console.WriteLine(" [0] 도망가기 ");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");

            int input = Utility.CheckValidInput(0, 2);
            if (input == 1)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("공격 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleNormal();
            }
            // ---------- Song 스킬 창 추가---------------
            else if (input == 2)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("스킬 창으로 이동합니다.");
                Thread.Sleep(300);
                BattleSkill();
            }
            // ---------- Song ---------------
            else if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                MainProgram.DisplayGameIntro();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Console.WriteLine();
                Thread.Sleep(300);
                FightInfo();
            }
        }

        public static void BattleNormal() // 스킬을 사용하지 않은 기본 공격
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(32, 2);
            Console.WriteLine("[기본 공격]");

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    sb.Append($"[{i + 1}] ");
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} ");
                    sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.SetCursorPosition(2 + (i * 27), 7);
                    Console.WriteLine(sb);
                    sb.Clear();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(2 + (i * 27), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"[{i + 1}] ");
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }

            }

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            // ---------- Song Mp 추가 ---------------
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            sbClear();

            Console.SetCursorPosition(2, 23);
            Console.WriteLine(" [0] 돌아가기 ");
            Console.SetCursorPosition(3, 27);
            Console.Write("대상을 입력해주세요: ");

            int input = Utility.CheckValidInput(0, monstersList.Count);

            if (input == 0)
            {
                // 스킬 선택으로 마음을 바꿀수 있다 생각해서 수정했습니다. -문현우
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("선택화면으로 돌아갑니다.");
                Thread.Sleep(500);
                FightInfo();
            }
            else if (1 <= input && input <= monstersList.Count)
            {
                PlayerAttack(input, CharacterBase.CalculateDamage(MainProgram.player.Atk));
                PlayerPhase();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("잘못된 입력입니다.");
            }
        }

        // --------------------------------------------------------------------------
        public static void PlayerPhase() // 플레이어 페이즈
        {
            if (CheckAllMonstersDefeated())
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(35, 2);
                Console.WriteLine("[결과]");
                Console.SetCursorPosition(30, 6);
                Console.WriteLine("Victory!");
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오");
                Console.ReadLine();
                MainProgram.DisplayGameIntro();
            }
            else
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(2, 23);
                Console.WriteLine(" 적 차례");
                Console.SetCursorPosition(3, 27);
                Console.Write("아무키를 눌러 적 차례로 진입하십시오");
                Console.ReadKey();
                EnemyPhase();

            }
        }

        // 플레이어 공격 메서드 구현
        public static void PlayerAttack(int selected, int damage)
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[공격]");
            if (monstersList[selected - 1].CurrentHp > 0)
            {
                // 치명타 기능
                // --송명근 UI 부분 추가--
                bool isCrit = false;
                int space = 0;
                Random rand = new Random();
                int criticalEvasionCheck = rand.Next(20);
                if (criticalEvasionCheck <= 3)
                {
                    damage *= 2;
                    isCrit = true;
                    space = 2;
                }

                // 회피할 경우 공격 스킵
                if (criticalEvasionCheck > 17)
                {
                    Console.SetCursorPosition(3, 10);
                    Console.WriteLine($"{monstersList[selected - 1].Name}이 공격을 회피했습니다!");
                    Console.SetCursorPosition(3, 12);
                    Console.WriteLine($"Hp {monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp}");
                }
                else
                {
                    if (isCrit == true)
                    {
                        Console.SetCursorPosition(3, 7);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("치명타가 터졌습니다!");
                        Console.ResetColor();
                    }
                    Console.SetCursorPosition(3, 7 + space);
                    Console.WriteLine($"{MainProgram.player.Name} 의 공격!\n");
                    Console.SetCursorPosition(3, 9 + space);
                    Console.WriteLine($"Lv.{monstersList[selected - 1].Lv} ");
                    Console.SetCursorPosition(3, 11 + space);
                    Console.Write($"{monstersList[selected - 1].Name} 을(를) 맞췄습니다. ");
                    Console.WriteLine($"[데미지 : {damage} ]");
                    Console.SetCursorPosition(3, 13 + space);
                    Console.WriteLine($"Lv.{monstersList[selected - 1].Lv} {monstersList[selected - 1].Name}\n");
                    //Console.Clear();
                    if (monstersList[selected - 1].CurrentHp - damage <= 0)
                    {
                        Console.SetCursorPosition(3, 15 + space);
                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].IsDead}");
                        monstersList[selected - 1].CurrentHp = 0;
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 15 + space);
                        Console.WriteLine($"{monstersList[selected - 1].CurrentHp} -> {monstersList[selected - 1].CurrentHp -= damage}");
                    }
                }
                // --송명근 -- 화면이 바로 전환되지 않고 적에게 준 피해 화면 표시 후 다음 화면 전환
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("아무키를 눌러 다음화면으로 가십시오.");
                Console.ReadLine();
            }
            else
            {
                // 이미 죽은 적을 선택 했으므로, 다른 적을 선택하게 선택 화면으로 돌아갑니다. - 문현우
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("이미 죽은 적입니다. 다른 적을 선택하세요.");
                Thread.Sleep(500);
                FightInfo();
            }
        }

        // --- Song 스킬을 이용한 전투 추가 ---
        public static void BattleSkill() // 스킬을 사용하여 전투
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[스킬]");

            for (int i = 0; i < monstersList.Count; i++)
            {
                if (monstersList[i].CurrentHp > 0)
                {
                    sb.Append($"[{i + 1}] ");
                    sb.Append($"Lv.{monstersList[i].Lv} ");
                    sb.Append($"{monstersList[i].Name} ");
                    sb.Append($"HP {monstersList[i].CurrentHp}" + "\n");
                    Console.SetCursorPosition(3 + (i * 27), 7);
                    Console.WriteLine(sb);
                    sb.Clear();
                }
                else if (monstersList[i].CurrentHp <= 0)
                {
                    Console.SetCursorPosition(3 + (i * 27), 7);
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write($"Lv.{monstersList[i].Lv} ");
                    Console.Write($"{monstersList[i].Name} ");
                    Console.WriteLine($"{monstersList[i].IsDead} \n");
                    Console.ResetColor();
                }

            }

            Console.SetCursorPosition(3, 10);
            Console.WriteLine("[내 정보]");

            Console.SetCursorPosition(3, 12);
            sb.Append($"Lv.{MainProgram.player.Lv} ");
            sbClear();
            Console.SetCursorPosition(3, 14);
            sb.Append($"{MainProgram.player.Name} {MainProgram.player.Job}");
            sbClear();
            Console.SetCursorPosition(3, 16);
            sb.Append($"HP {MainProgram.player.CurrentHp} / {MainProgram.player.Hp}");
            sbClear();
            // ---------- Song Mp 추가 ---------------
            Console.SetCursorPosition(3, 18);
            sb.Append($"MP {MainProgram.player.CurrentMp} / {MainProgram.player.Mp}");
            // ---------- Song ---------------
            sbClear();

            Console.SetCursorPosition(1, 22);
            Console.WriteLine(" [0] 돌아가기 ");

            for (int i = 0; i < MainProgram.player.skills.Count; i++)
            {
                Console.SetCursorPosition(2, 23 + i);
                Console.Write($"[{i + 1}] {MainProgram.player.skills[i].Name} | MP {MainProgram.player.skills[i].MpConsume} ");
                Console.WriteLine($"| {MainProgram.player.skills[i].Description}");
            }

            Console.SetCursorPosition(3, 27);
            Console.Write("스킬을 입력해주세요: ");
            int input = Utility.CheckValidInput(0, MainProgram.player.skills.Count);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("선택화면으로 돌아갑니다.");
                Thread.Sleep(500);
                FightInfo();
            }
            else if (1 <= input && input <= MainProgram.player.skills.Count)
            {
                // 스킬 사용 후
                PlayerSkill(input);
                PlayerPhase();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.Write("올바른 스킬을 입력해주세요: ");
                Thread.Sleep(500);
                BattleSkill();
            }
        }

        // 스킬 실행 메서드
        public static void PlayerSkill(int selected)
        {
            if (MainProgram.player.CurrentMp < MainProgram.player.skills[selected - 1].MpConsume)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("마나가 부족합니다.    ");
                Console.SetCursorPosition(3, 28);
                Console.WriteLine("아무 키나 눌러 돌아가기");
                Console.ReadLine();
                FightInfo();
            }
            else if (MainProgram.player.skills[selected - 1].Name == "알파 스트라이크")
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("알파 스트라이크를 시전할 대상을 선택해주세요");
                SelectMonster(MainProgram.player.Atk * 2);
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "더블 스트라이크")
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("더블 스트라이크 시전!");
                List<int> temp = new List<int>();
                for (int i = 0; i < monstersList.Count; i++)
                {
                    if (monstersList[i].CurrentHp != 0)
                    {
                        temp.Add(i);
                    }
                }
                if (temp.Count == 1)
                {
                    PlayerAttack(temp[0] + 1, MainProgram.player.Atk);
                }
                else if (temp.Count == 2)
                {
                    PlayerAttack(temp[0] + 1, MainProgram.player.Atk);
                    PlayerAttack(temp[1] + 1, MainProgram.player.Atk);
                }
                else if (temp.Count > 2)
                {
                    Random rand = new Random();
                    int firstTarget = rand.Next(1, temp.Count);
                    int secondTarget = rand.Next(1, temp.Count - 1);
                    if (firstTarget <= secondTarget) // 중복 제거
                    {
                        secondTarget += 1;
                    }
                    PlayerAttack(temp[firstTarget - 1] + 1, MainProgram.player.Atk);
                    PlayerAttack(temp[secondTarget - 1] + 1, MainProgram.player.Atk);
                }
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "썬더 볼트")
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("썬더 볼트 시전!");
                for (int i = 0; i < monstersList.Count; i++)
                {
                    if (monstersList[i].CurrentHp != 0)
                    {
                        PlayerAttack(i + 1, MainProgram.player.Atk);
                    }
                }
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
            else if (MainProgram.player.skills[selected - 1].Name == "힐")
            {
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(3, 10);
                Console.WriteLine("힐 시전!");
                Console.SetCursorPosition(3, 12);
                Console.Write($"Hp {MainProgram.player.CurrentHp}");
                MainProgram.player.CurrentHp += 30;
                if (MainProgram.player.CurrentHp > MainProgram.player.Hp)
                {
                    MainProgram.player.CurrentHp = MainProgram.player.Hp;
                }
                Console.WriteLine($" -> {MainProgram.player.CurrentHp}");
                // 마나 소모
                MainProgram.player.CurrentMp -= MainProgram.player.skills[selected - 1].MpConsume;
            }
        }

        public static void EnemyPhase() //적 공격패턴
        {

            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[몬스터 턴]");



            if (MainProgram.player.CurrentHp > 0)
            {
                for (int i = 0; i < monstersList.Count; i++)
                {
                    int saveCurrentHp = 0; // 플레이어 currentHp를 저장하기 위한 변수
                    if (monstersList[i].CurrentHp <= 0)
                    {
                        continue;
                    }
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(35, 2);
                    Console.Write("[ 몬스터 턴 ]");
                    Console.ResetColor();

                    int monsDmg = CharacterBase.CalculateDamage(monstersList[i].Atk);
                    Console.SetCursorPosition(3, 9);
                    Console.WriteLine($"Lv.{monstersList[i].Lv} ");
                    Console.SetCursorPosition(3, 11);
                    Console.WriteLine($"{monstersList[i].Name} 의 공격\n\n");
                    Console.SetCursorPosition(3, 13);
                    Console.WriteLine($"{MainProgram.player.Name}을 맞췄습니다. [데미지 : {monsDmg}]");
                    Console.SetCursorPosition(3, 15);
                    Console.WriteLine($"Lv.{MainProgram.player.Lv} {MainProgram.player.Name}\n");

                    saveCurrentHp = MainProgram.player.CurrentHp;
                    MainProgram.player.CurrentHp -= monsDmg;
                    if (MainProgram.player.CurrentHp <= 0)
                    {
                        Console.SetCursorPosition(30, 7);
                        Console.WriteLine($"HP {saveCurrentHp} -> 0");
                        Console.Clear();
                        UI.DisplayGameUI();
                        Console.SetCursorPosition(35, 2);
                        Console.WriteLine("[사망]");
                        Console.SetCursorPosition(30, 9);
                        Console.WriteLine("Game Over...");
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("아무키를 눌러 메인화면으로 되돌아 가십시오.");
                        Console.ReadLine();
                        Environment.Exit(0);
                        //캐릭터생성부로 돌아가는 함수();
                    }
                    else
                    {
                        Console.SetCursorPosition(3, 17);
                        Console.WriteLine($"HP {saveCurrentHp} -> {MainProgram.player.CurrentHp}");
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("다음");
                        Console.WriteLine();
                        Console.ReadKey();
                        Console.Clear();
                    }


                }
                Console.Clear();
                UI.DisplayGameUI();
                Console.SetCursorPosition(32, 2);
                Console.WriteLine("[플레이어 턴]");
                Console.SetCursorPosition(3, 27);
                Console.Write("아무키를 눌러 플레이어 차례로 진입하십시오");
                Console.ReadKey();
                FightInfo();

            }
        }

        public static bool CheckAllMonstersDefeated() //몬스터가 모두 죽었는지 판별하는 함수
        {
            foreach (CharacterBase monster in monstersList)
            {
                if (monster.CurrentHp > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SelectMonster(int damage)
        {
            Console.SetCursorPosition(3, 28);
            int input = Utility.CheckValidInput(0, monstersList.Count);
            if (1 <= input && input <= monstersList.Count)
            {
                PlayerAttack(input, damage);
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("잘못된 입력입니다! 올바른 대상을 선택해주세요.");
                Thread.Sleep(300);
                BattleSkill();
            }
        }
    }
    //-----------------------------------------------------
}