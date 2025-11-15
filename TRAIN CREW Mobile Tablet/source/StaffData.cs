using System.Collections.Generic;

namespace tc_staff_draw
{
    /// <summary>
    /// スタフの内容に関する構造体
    /// </summary>
    public partial struct StaffData
    {
        /// <summary>
        /// （左上）タイトル欄に表示するテキスト
        /// </summary>
        public string[] Titles;

        /// <summary>
        /// （右上）種別欄に表示するテキスト
        /// </summary>
        public string TrainType;

        /// <summary>
        /// （下側）タイムテーブル欄に表示するテキストに関するの構造体
        /// </summary>
        public class TimeTable
        {
            /// <summary>
            /// （左から1番目）駅名
            /// </summary>
            public string Station  = "";

            /// <summary>
            /// （左から2,3,4番目）到着時刻
            /// </summary>
            public string[] ArrivalTime = new string[3] { "", "", "" };

            /// <summary>
            /// （左から2,3,4番目）出発時刻
            /// </summary>
            public string[] DepatureTime = new string[3] { "", "", "" };

            /// <summary>
            /// （左から5番目）番線等
            /// </summary>
            public string Supplement1 = "";

            /// <summary>
            /// （一番右）入替開始時刻等
            /// </summary>
            public string Supplement2 = "";

            /// <summary>
            /// （一番右）入替開始時刻等(2行目)
            /// </summary>
            public string Supplement2_2 = "";

            /// <summary>
            /// 停車駅を表すフラグ
            /// </summary>
            public bool Stop = true;
        }
        /// <summary>
        /// （下側）タイムテーブル欄に表示するテキスト
        /// </summary>
        public List<TimeTable> TimeTables;

        public bool IsNull()
        {
            if (Titles == null) return true;
            else if (TrainType == null) return true;
            else if (TimeTables == null) return true;
            else return false;
        }
    }
}