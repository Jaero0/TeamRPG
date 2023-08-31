using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TeamRPG;

namespace TeamRPG
{
    public class Utility
    {
        public static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();
                try
                {
                    // ------문현우 try catch----------------
                    // 입력된 문자열을 정수로 변환 -> t, 정수 값 -> ret
                    // 실패 -> f , FormatException 발생.
                    bool parseSuccess = int.TryParse(input, out var ret);
                    if (!parseSuccess)
                    {
                        Console.SetCursorPosition(3, 27);
                        Console.WriteLine("숫자를 입력해주세요:         "); // 오류 메시지 표시 후 공백 문자로 덮어쓰기
                        Console.SetCursorPosition(24, 27);
                        continue; // 다시 입력 받기 위해 반복문 처음으로 돌아감
                    }
                    return ret;
                }
                catch (FormatException ex)
                {
                    // try에서 발생한 오류를 catch 블록에서 처리.
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
        }
        //--------------문현우 Save & Load 추가--------------
        public static void SaveGameData()
        {
            // 파일 이름 설정 _playerData.json
            string fileName = "_playerData.json";
            // 파일 저장 경로 설정
            string userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            // 파일 저장 경로 + 파일 이름 C:\Users\XXXX\Documents\_playerData.json) 
            string filePath = Path.Combine(userDocumentsFolder, fileName);
            // Json 형식 정렬
            var options = new JsonSerializerOptions { WriteIndented = true };
            // Json 직렬화
            string playersData = JsonSerializer.Serialize(MainProgram.player, options);
            // 유니코드 -> 한글 변환
            playersData = Regex.Unescape(playersData);
            // 파일 생성
            File.WriteAllText(filePath, playersData);
        }

        public static void LoadGameData()
        {
            string fimeName = "_playerData.json";
            string userDocumentsFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(userDocumentsFolder, fimeName);
            if(File.Exists(filePath))
            {
                MainProgram.isCreate = true;
                string playerJson = File.ReadAllText(filePath);
                playerJson = Regex.Unescape(playerJson);
                Character loadedCharacter = JsonSerializer.Deserialize<Character>(playerJson);
                MainProgram.player = loadedCharacter;
            }
            else
            {
                // 추후 게임 데이터 설정화면 생기면 이동.
                Console.WriteLine("데이터가 없습니다.");
                Thread.Sleep(500);
                MainProgram.GameDataSetting();
            }
        }
        //----------------------------
    }
}