using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamRPG;
using System.Text.Json;

namespace TeamRPG
{
    internal class MainProgram
    {
        public static Character player;
        //by doham : Jobs Data Dictionary
        public static Dictionary<string, Character> JobsDic = new Dictionary<string, Character>();
        static string getName = "";
        public static bool isCreate = false; // 죽으면 false;
        //---------

        public static Monsters monsters;
        public static List<CharacterBase> monstersList; //Monsters Class의 monsterList가져옴

        public static Minion minion;
        public static CanonMinion canonMinion;
        public static VoidMinion voidMinion;

        

        static void Main(string[] args)
        {
            // ----- 김형수 -----
            // 획득한 경험치. earned;획득한
            long earnedExp = 0;
            // -----


            Utility.LoadGameData();
            DisplayGameIntro();
        }

        public static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            //player = new Character("Chad", "전사", 1, 10, 5, 100, 1500, "Dead", 50);
            //by doham
            JobsDic.Add("전사", new Character("Chad", "전사", 1, 10, 5, 100, 1500, "Dead", 50));
            JobsDic.Add("마법사", new Character("Deliki", "마법사", 1, 8, 3, 80, 1500, "Dead", 80));

            // -------송명근 스킬 추가 방식 ----------//
            // 나중에 캐릭터 생성 구현 시 if (전사) { player에 전사 스킬 추가 }
            // else if (마법사) { player에 마법사 스킬 추가 }
            // 지금은 편의상 전사이므로 있는 스킬 2개 추가

            //// 전사
            //player.AddSkill(SkillList.alphaStrike);
            //player.AddSkill(SkillList.doubleStrike);

            // 마법사
            //player.AddSkill(SkillList.thunderVolt);
            //player.AddSkill(SkillList.heal);

            // 아이템 정보 세팅



            //-------------------------------------
        }


        public static void DisplayCreateCharacter()
        {
            Console.Clear();
            UI.DisplayGameUI();
            //------박도현 캐릭터 생성 / 직업 선택----------
            //
            //이름을 적어주세요. (아무것도 없을 경우 디폴트)
            //이름을 적지 않는경우 안넘어가게 만들 수도 있음.
            /* Console.SetCursorPosition(3, 23);
             Console.WriteLine("당신의 이름은 무엇인가요? ");
             Console.SetCursorPosition(3, 27);*/
           
            bool check = true;
            do
            {
                if (getName == null || getName == "")
                {
                    Console.SetCursorPosition(3, 23);
                    Console.WriteLine("당신의 이름은 무엇인가요? ");
                    Console.SetCursorPosition(3, 27);
                    getName = Console.ReadLine();
                }
                else
                {
                    check = false;
                }
            } while (check);

            //게임오버 게임 캐릭터 생성..

            //선택한 이름 보여주기

            Console.SetCursorPosition(3, 27);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);

            Console.SetCursorPosition(3, 23);
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);
            Console.SetCursorPosition(3, 23);
            Console.WriteLine($"당신은 {getName} 이군요.");
            Thread.Sleep(2000);

            DisplayGetJob();


        }

        public static void DisplayGetJob()
        {
            //직업을 선택해주세요.
            Console.SetCursorPosition(3, 27);
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(3, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth / 2));
            Console.SetCursorPosition(3, currentLineCursor - 1);

            Console.SetCursorPosition(3, 23);
            Console.WriteLine("당신의 직업을 선택해주세요. 전사 [1] | 마법사 [2] ");
            Console.SetCursorPosition(3, 27);
            int input = Utility.CheckValidInput(1, 2);
            if (input == 1)//전사
            {
                player = new Character(JobsDic["전사"].Name, JobsDic["전사"].Job, JobsDic["전사"].Lv, JobsDic["전사"].Atk, JobsDic["전사"].Def, JobsDic["전사"].Hp, JobsDic["전사"].Gold, JobsDic["전사"].IsDead, JobsDic["전사"].Mp);
                player.AddSkill(SkillList.alphaStrike);
                player.AddSkill(SkillList.doubleStrike);
            }
            else if (input == 2)//마법사
            {
                player = new Character(JobsDic["마법사"].Name, JobsDic["마법사"].Job, JobsDic["마법사"].Lv, JobsDic["마법사"].Atk, JobsDic["마법사"].Def, JobsDic["마법사"].Hp, JobsDic["마법사"].Gold, JobsDic["마법사"].IsDead, JobsDic["마법사"].Mp);
                player.AddSkill(SkillList.thunderVolt);
                player.AddSkill(SkillList.heal);
            }
            else
            {
                DisplayGetJob();
            }
            player.Name = getName;
            isCreate = true;
            Console.Clear();
            UI.DisplayGameUI();


            //캐릭터 생성 끝.
        }

        public static void DisplayGameIntro()
        {
            Console.Clear();

            //------정재호 몬스터/ 몬스터 리스트 정보세팅----------
            // 이름, 레벨,공격,체력            
            monsters = new Monsters();
            int monsterCount = 3; // 나중 stage 구현 시 증가 가능
            for (int i = 0; i < monsterCount; i++)
            {
                Random rand = new Random();
                int temp = rand.Next(1, 4);
                if (temp == 1)
                {
                    monsters.AddMonster2List(new Minion("미니언", 5, 15, 2, "Dead"));
                }
                else if (temp == 2)
                {
                    monsters.AddMonster2List(new CanonMinion("대포미니언", 8, 25, 5, "Dead"));
                }
                else if (temp == 3)
                {
                    monsters.AddMonster2List(new VoidMinion("공허충", 9, 10, 3, "Dead"));
                }
            }
            //minion = new Minion("미니언", 5, 15, 2, "Dead");
            //canonMinion = new CanonMinion("대포미니언", 8, 25, 5, "Dead");
            //voidMinion = new VoidMinion("공허충", 9, 10, 3, "Dead");

            //monsters.AddMonster2List(minion);
            //monsters.AddMonster2List(canonMinion);
            //monsters.AddMonster2List(voidMinion);

            monstersList = Monsters.GetMonstersList();
            //for (int i = 0; i < monstersList.Count; i++) //몬스터 체력 초기화
            //{
            //    monstersList[i].CurrentHp = monstersList[i].Hp;
            //}
            UI.DisplayGameUI();
            if(isCreate == false)
            { DisplayCreateCharacter(); }
            
            UI.DIsplayGameTitle();

            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("게임 종료 ");
            Console.SetCursorPosition(24, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [1] ");
            Console.ResetColor();
            Console.Write("상태보기 ");
            Console.SetCursorPosition(48, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [2] ");
            Console.ResetColor();
            Console.Write("전투 ");
            Console.SetCursorPosition(68, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [3] ");
            Console.ResetColor();
            Console.Write("여관 ");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");
            int input = Utility.CheckValidInput(1, 3);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("TEAM RPG를 종료합니다.");
                Thread.Sleep(300);
                Environment.Exit(0);
            }
            else if (input == 1)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("상태창으로 이동합니다.");
                Thread.Sleep(300);
                DisplayMyInfo();
            }
            //--------------정재호 전투추가--------------
            else if (input == 2)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("던전으로 이동합니다.");
                Thread.Sleep(300);
                Monsters.FightInfo();
            }
            //---------------------------------------------
            else if (input == 3)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("여관으로 이동합니다.");
                Thread.Sleep(300);
                GetRestInfo();
                
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요.");
                Thread.Sleep(500);
                DisplayGameIntro();
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();

            UI.DisplayGameUI();
            Console.SetCursorPosition(32, 2);
            Console.WriteLine("[상태보기]");
            Console.SetCursorPosition(24, 6);
            Console.WriteLine("캐릭터의 정보를 표시합니다.");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("나가기");
            Console.SetCursorPosition(6, 7);
            Console.Write($"Lv.{player.Lv}");
            Console.SetCursorPosition(6, 9);
            Console.ForegroundColor= ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($" {player.Name} ");
            Console.ResetColor();
            Console.SetCursorPosition(15, 9);
            Console.Write($"({player.Job})");
            Console.SetCursorPosition(6, 11);
            Console.WriteLine($"공격력 : {player.Atk}");
            Console.SetCursorPosition(6, 13);
            Console.WriteLine($"방어력 : {player.Def}");
            Console.SetCursorPosition(6, 15);
            Console.WriteLine($"체력 : {player.CurrentHp} / {player.Hp}");
            Console.SetCursorPosition(6, 17);
            Console.WriteLine($"마나 : {player.CurrentMp} / {player.Mp}");
            Console.SetCursorPosition(6, 19);
            Console.WriteLine($"Gold : {player.Gold} G");

            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");
            int input = Utility.CheckValidInput(0, 0);

            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }
        //--------------문현우 저장 추가--------------
        static void GetRestInfo()
        {
            Console.Clear();
            UI.DisplayGameUI();
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("[여관]");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("휴식을 취할 경우, 500G를 사용하여 체력과 마나를 50 회복합니다."); // 골드 사용
            Console.SetCursorPosition(17, 9);
            Console.WriteLine("또한, 현재 플레이어 데이터가 저장됩니다.");
            Console.SetCursorPosition(6, 11);
            Console.Write($"Lv.{player.Lv}");
            Console.SetCursorPosition(6, 13);
            Console.WriteLine($"{player.Name}({player.Job})");
            Console.SetCursorPosition(6, 15);
            Console.WriteLine($"체력 : {player.CurrentHp} / {player.Hp}");
            Console.SetCursorPosition(6, 17);
            Console.WriteLine($"마나 : {player.CurrentMp} / {player.Mp}");
            Console.SetCursorPosition(6, 19);
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.SetCursorPosition(2, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [0] ");
            Console.ResetColor();
            Console.Write("나가기");
            Console.SetCursorPosition(24, 23);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [1] ");
            Console.ResetColor();
            Console.Write("휴식 취하기(500G)");
            Console.SetCursorPosition(3, 27);
            Console.Write("숫자를 입력해주세요: ");

            int input = Utility.CheckValidInput(0, 1);
            if (input == 0)
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("메인화면으로 돌아갑니다..");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
            else if (input == 1)
            {
                // -- 송명근 -- 골드 충분한지 확인
                if (player.Gold < 500)
                {
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("[여관]");
                    Console.SetCursorPosition(3, 10);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("골드가 부족합니다!");
                    Console.ResetColor();
                    Console.SetCursorPosition(3, 12);
                    Console.WriteLine("아무 키를 눌러 돌아가기");
                    Console.ReadLine();
                    GetRestInfo();
                }
                else
                {
                    Console.Clear();
                    UI.DisplayGameUI();
                    Console.SetCursorPosition(3, 27);
                    Console.WriteLine("휴식을 취합니다..");
                    Console.SetCursorPosition(3, 10);
                    Console.Write($"Gold {player.Gold} -> {player.Gold -= 500}"); // 골드 회수
                    Console.SetCursorPosition(3, 12);
                    Console.Write($"Hp {player.CurrentHp}");
                    player.CurrentHp += 50;

                    if (player.CurrentHp > player.Hp)
                    {
                        player.CurrentHp = player.Hp;
                    }
                    Console.WriteLine($" -> {player.CurrentHp}");

                    Console.SetCursorPosition(3, 14);
                    Console.Write($"Mp {player.CurrentMp}");
                    player.CurrentMp += 50;
                    if (player.CurrentMp > player.Mp)
                    {
                        player.CurrentMp = player.Mp;
                    }
                    Console.WriteLine($" -> {player.CurrentMp}");
                    Console.SetCursorPosition(3, 14);
                    Thread.Sleep(500);
                    Utility.SaveGameData();
                    Console.SetCursorPosition(3, 27);
                    Console.WriteLine("저장이 완료되었습니다.");
                    Thread.Sleep(500);
                    DisplayGameIntro();
                }
            }
            else
            {
                Console.SetCursorPosition(3, 27);
                Console.WriteLine("숫자를 다시 입력하세요");
                Thread.Sleep(300);
                DisplayGameIntro();
            }
        }
        //----------------------------
    }
}