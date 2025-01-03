using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 12. 整数转罗马数字
    /// https://leetcode.cn/problems/integer-to-roman/description/?envType=study-plan-v2&amp;envId=top-interview-150
    /// </summary>

    public class Solution_12
    {

        public void Run()
        {
            int num = 58;
            string str = IntToRoman_My_0(num);
            Console.WriteLine("str:{0}", str);


        }

        // method 0 我的题解0
        // 按题意直写，没什么特别设计
        public string IntToRoman_My_0(int num)
        {
            Dictionary<int, string> dic = new Dictionary<int, string>();
            dic[1] = "I";
            dic[5] = "V";
            dic[10] = "X";
            dic[50] = "L";
            dic[100] = "C";
            dic[500] = "D";
            dic[1000] = "M";

            dic[4] = "IV";
            dic[9] = "IX";
            dic[40] = "XL";
            dic[90] = "XC";
            dic[400] = "CD";
            dic[900] = "CM";

            string str = string.Empty;

            int thousand = num / 1000;
            int hundred = num % 1000 / 100;
            int ten = num % 100 / 10;
            int one = num % 10;

            str += CheckNum(thousand, 1000, dic);
            str += CheckNum(hundred, 100, dic);
            str += CheckNum(ten, 10, dic);
            str += CheckNum(one, 1, dic);
            return str;

        }

        private string CheckNum(int num, int times, Dictionary<int, string> dic)
        {
            string res = string.Empty;
            int k = 0;
            if (num > 4)
            {
                if (num == 9)
                {
                    res += dic[9 * times];
                }
                else
                {
                    k = num - 5;
                    res += dic[5 * times] + GetSmallNum(k, dic[times]);
                }
            }
            else if (num == 4)
            {
                res += dic[4 * times];
            }
            else
            {
                res += GetSmallNum(num, dic[times]);
            }
            return res;

        }

        private string GetSmallNum(int times, string str)
        {
            string res = string.Empty;
            for (int i = 0; i < times; i++)
            {
                res += str;
            }
            return res;

        }


        // method 1-官方题解1
        // 和“我的题解0”意思一样，不过官方写的更清晰，也不另写方法出来。
        public string IntToRoman_1(int num)
        {
            // 为了配合后面的计算，valueSymbols需要从大到小顺序写
            Tuple<int, string>[] valueSymbols =
            {
                new Tuple<int, string>(1000, "M"),
                new Tuple<int, string>(900, "CM"),
                new Tuple<int, string>(500, "D"),
                new Tuple<int, string>(400, "CD"),
                new Tuple<int, string>(100, "C"),
                new Tuple<int, string>(90, "XC"),
                new Tuple<int, string>(50, "L"),
                new Tuple<int, string>(40, "XL"),
                new Tuple<int, string>(10, "X"),
                new Tuple<int, string>(9, "IX"),
                new Tuple<int, string>(5, "V"),
                new Tuple<int, string>(4, "IV"),
                new Tuple<int, string>(1, "I")
            };
            StringBuilder roman = new StringBuilder();
            foreach (Tuple<int, string> tuple in valueSymbols)
            {
                int value = tuple.Item1;
                string symbol = tuple.Item2;
                while (num >= value)
                {
                    num -= value;
                    roman.Append(symbol);
                }
                if (num == 0)
                {
                    break;
                }
            }
            return roman.ToString();

        }

        // method 2-官方题解2
        // 硬编码
        public string IntToRoman_2(int num)
        {
            // 因为可能的数字不多，直接列出所有可能
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

            StringBuilder roman = new StringBuilder();
            roman.Append(thousands[num / 1000]);
            roman.Append(hundreds[num % 1000 / 100]);
            roman.Append(tens[num % 100 / 10]);
            roman.Append(ones[num % 10]);
            return roman.ToString();

        }



    }




}
