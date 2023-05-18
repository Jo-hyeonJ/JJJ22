using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Text.RegularExpressions;

namespace JJJ22
{
    internal class Program
    {

        public static void GetMiddle(List<int> list)
        {
            if (1 != list.Count % 2)
            {
                list.Sort();
                int middle = list.Count / 2;
                Console.WriteLine("정렬 된 배열 중앙의 값 : {0}", list[middle]);
            }
            else
            {
                Console.WriteLine("홀수 배열만 수용 가능합니다.");
            }
        }

        public static void Clamp(int num, int add)
        {
            Console.WriteLine($"숫자{num}에 {add}를 더한다.(최소 1 / 최대 20)");
            num = Math.Clamp(num + add, 1, 20);
            Console.WriteLine($"num의 값은 : {num}");

        }

        public static void RemoveVowel(string word)
        {
            Stopwatch stop = new Stopwatch();

            stop.Start();
            var result = word.Where(c => c != 'a' && c != 'i' && c != 'u' && c != 'e' && c != 'o' && !Char.IsWhiteSpace(c));
            
            Console.WriteLine(stop.ElapsedMilliseconds);

            // Regex이용 (이용법은 검색)
            stop.Start();

            Regex.Replace(word, @"a|i|o|e|u|", string.Empty);
            Console.WriteLine(stop.ElapsedTicks);

            // Linq 이용
            // string.Contains(string|char) : bool
            // 문자열 안에 문자 혹은 문자열이 포함 되어있는가?
            stop.Start();

            string except = "aeiou";
            string.Concat(word.Where(c=> !except.Contains(c)));
            Console.WriteLine(stop.ElapsedMilliseconds);
        }

        public static int Discount(int value)
        {
            // 비싼 순서로 조건문을 쓴다면 조건문은 위에서 아래로 절차식으로 내려가기에 and 연산을 사용할 필요가 없다.
            if (value >= 100000 && value < 300000)
            {
                Console.WriteLine("할인율 : 5%");

                return (int)(value / 5);
            }
            else if (value >= 300000 && value < 500000)
            {
                Console.WriteLine("할인율 : 10%");

                return (int)(value / 10);
            }
            else if (value >= 500000)
            {
                Console.WriteLine("할인율 : 20%");
                return (int)(value / 20);
            }
            else
            {
                Console.WriteLine("할인율 : 0%");

                return value;
            }
        }
        public static int[] ExtractLength(string[] strs)
        {
            int[] result = new int[strs.Length];
            for (int i = 0; i < strs.Length; i++)
            {
                result[i] = strs[i].Length;
            }

            return result;
        }

        public static int ContainsString(string strA, string strB)
        {
            var c = strA.Contains(strB);

            if (c)
                return 1;
            else
                return 2;

        }


        static void Main(string[] args)
        {
            /*
            // 정렬 후 중앙 인덱스 구하기
            List<int> list = new List<int>();
            list.Add(3);
            list.Add(1);
            list.Add(2);
            list.Add(5);
            list.Add(4);
            list.Add(7);
            list.Add(6);

            GetMiddle(list);


            // 올림, 반올림, 내림 Math.Ceiling / Math.Round / Math.Floor
            // 제곱 Pow(값, 제곱값)

            // Math.Clamp (최소, 최대 제한)
            // 최소와 최대 값을 제한한다.
            Clamp(17, 30);
            Clamp(23, 2);
            Clamp(37, 0);
            Clamp(-7, 22);

            string bus = "bus";
            string nice = "nice to meet you";
            RemoveVowel(bus);
            RemoveVowel(nice);
*/

            // Q. 10만원 이상 5%, 30만원 이상 10%, 50만원 이상 20% 할인된 가격을 리턴

            while (false)
            {
                string input = Console.ReadLine();
                bool check = false;

                int.TryParse(input, out int value);

                Console.WriteLine(Discount(value));
            }

            // Q. 문자열 배열의 각 요소의 길이를 int형 배열로 반환

            string[] BBB = { "black", "cow", "dude" };

            Console.WriteLine(string.Join(",",ExtractLength(BBB)));

            // Q. 문자열 A와 B가 주어졌을 때 B가 A에 포함되면 1, 아니면 2를 반환

            Console.WriteLine(ContainsString("ABC", "A"));
            Console.WriteLine(ContainsString("ABC", "D"));

        }
    }
}