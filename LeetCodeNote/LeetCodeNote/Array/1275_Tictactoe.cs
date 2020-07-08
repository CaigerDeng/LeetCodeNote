using System.Collections.Generic;
using System.Net.Security;

namespace LeetCodeNote.Array
{
    /// <summary>
    /// 1275. 找出井字棋的获胜者
    /// https://leetcode-cn.com/problems/find-winner-on-a-tic-tac-toe-game/
    /// </summary>

    public class Solution_1275
    {
        // method 0
        public string Tictactoe_0(int[][] moves)
        {
            List<List<int>> winList = new List<List<int>>();
            winList.Add(new List<int> { 0, 1, 2 });
            winList.Add(new List<int> { 3, 4, 5 });
            winList.Add(new List<int> { 6, 7, 8 });
            winList.Add(new List<int> { 0, 3, 6 });
            winList.Add(new List<int> { 1, 4, 7 });
            winList.Add(new List<int> { 2, 5, 8 });
            winList.Add(new List<int> { 0, 4, 8 });
            winList.Add(new List<int> { 2, 4, 6 });

            List<int> aList = new List<int>();
            List<int> bList = new List<int>();
            for (int i = 0; i < moves.Length; i++)
            {
                int x = moves[i][0];
                int y = moves[i][1];
                int pos = x * 3 + y;
                List<int> chooseList = (i % 2 == 0) ? aList : bList;
                chooseList.Add(pos);
                // 每一步都要检测是否有赢家，因为题目允许比赛提前结束
                if (CheckWin(chooseList, winList))
                {
                    return (chooseList == aList) ? "A" : "B";
                }
            }
            return (moves.Length < 9) ? "Pending" : "Draw";

        }

        private bool CheckWin(List<int> check, List<List<int>> wins)
        {
            foreach (List<int> win in wins)
            {
                bool canWin = true;
                foreach (int pos in win)
                {
                    if (!check.Contains(pos))
                    {
                        canWin = false;
                    }
                }
                if (canWin)
                {
                    return true;
                }
            }
            return false;
        }

    }


}