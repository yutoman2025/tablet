using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace tc_staff_draw
{
    /// <summary>
    /// OuDiaSecondとのデータ変換に関するクラス
    /// </summary>
    public class StaffDataConv
    {
        /// <summary>
        /// OuDiaSecondから出力したCSVデータを読み込む
        /// </summary>
        static public string[][] LoadCsv(string filename)
        {
            FileStream fs;
            StreamReader sr;
            string csv = "";

            try
            {
                fs = File.OpenRead(filename);
                sr = new StreamReader(fs);
                csv = sr.ReadToEnd();
                fs.Close();
            }
            catch (FileNotFoundException ex)
            {
                string msg = "CSVファイル \'" + filename + "\' の読み込みに失敗しました。\n\n";
                MessageBox.Show(msg + ex.Message);
                return null;
            }

            // OuDiaSecondで出力したcsvを行列(mtcsv[][])に変換
            csv = csv.Replace("\r\n", "\n");
            string[] temp = csv.Split('\n');
            string[][] mtcsv = new string[temp.Length][];
            for (int i = 0; i < temp.Length; i++)
            {
                mtcsv[i] = temp[i].Split(',');
            }

            // スタフとして有効な部分をmtdata[][]にコピー
            const int invalid_start = 4; // 最初の4行は無視
            const int invalid_end = 1; // 最後の1行は無視
            int valid_rows = mtcsv.Length - invalid_start - invalid_end;
            int valid_columns =  mtcsv[invalid_start + 1].Length;
            string[][] mtdata = new string[valid_rows][];
            for (int i = 0; i < valid_rows; i++)
            {
                mtdata[i] = new string[valid_columns];
                for (int j = 0; j < valid_columns; j++)
                {
                    mtdata[i][j] = mtcsv[i + invalid_start][j];
                }
            }

            return mtdata;
        }

        /// <summary>
        /// 指定した列車番号のスタフ情報を抽出する
        /// </summary>
        /// <param name="csv_data">CSVから取り込んだデータ</param>
        /// <param name="staff_data">変換したスタフデータ</param>
        /// <param name="train_number">列車番号</param>
        /// <returns>-1: 指定した列車車両が無い</returns>
        /// <returns>-2: CSVデータがない</returns>
        static public int ConvStaffData(string[][]csv_data, ref StaffData staff_data, string train_number)
        {
            if (csv_data == null) return -2;

            List<string[]> data;

            // パッチ処理
            Patch_CorrStartingStationLabel(ref csv_data);
            Patch_TrainTypeTest(ref csv_data);

            // 列車番号の検索・抽出
            if (ExtractTrain(csv_data, out data, train_number) == 0) return -1;

            // 同一列車が複数列ある場合は1列に統合
            CombSameTrain(data);

            // StaffDataへの変換
            ConvMain(data, ref staff_data, train_number);

            return 0;
        }

        /// <summary>
        /// 「始発駅」が「終着駅」というラベルで出力されるOuDiaのバグ？を修正するパッチ
        /// </summary>
        static private void Patch_CorrStartingStationLabel(ref string[][] csv_data)
        {
            int count = 0;        // 「終着駅」ラベルが何個存在するか
            int first_index = -1; // 「終着駅」ラベルが出現する最初の行

            for(int i = 0; i < csv_data.Length; i++)
            {
                if (csv_data[i][0] == "終着駅")
                {
                    if(first_index < 0)
                    {
                        first_index = i;
                    }
                    count++;
                }
            }

            if(count == 2)
            {
                if(csv_data[first_index + 1][0] == "始発駅作業")
                {
                    csv_data[first_index][0] = "始発駅";
                }
            }
        }

        /// <summary>
        /// 種別「試転」を「回送」に変更する
        /// </summary>
        static private void Patch_TrainTypeTest(ref string[][] csv_data)
        {
            int row = SearchIndexRow(csv_data, "列車種別");

            for(int i = 0; i < csv_data[row].Length; i++)
            {
                if (csv_data[row][i] == "試転")
                {
                    csv_data[row][i] = "回送";
                }
            }
        }

        /// <summary>
        /// 複数列ある列車の情報を1列に統合する
        /// </summary>
        static private void CombSameTrain(List<string[]> data)
        {
            if(data.Count <= 3) return;
         
            // 左 ← (上書き) ← 右
            for(int delete_col = data.Count - 1; delete_col > 2; delete_col--)
            {
                // 始発駅と終着駅の統合処理
                int row_start_station = Array.IndexOf(data[0], "始発駅");
                int row_term_station = Array.IndexOf(data[0], "終着駅");

                if (data[delete_col - 1][row_start_station] != data[delete_col][row_start_station])
                {   // 始発駅が違う

                    if(data[delete_col - 1][row_term_station] == data[delete_col][row_start_station])
                    {  　//  左の終着駅が右の始発駅と同じ

                        if(data[delete_col][row_term_station] != "江原信")
                        {   // 右の終着駅が江原信ではない (江原信は終着駅にならない)

                            // 右の終着駅で上書き
                            data[delete_col - 1][row_term_station] = data[delete_col][row_term_station];
                            data[delete_col - 1][row_term_station + 1] = "";
                            data[delete_col - 1][row_term_station + 2] = "";
                        }
                    }
                }

                // 「終着駅作業」の次の次の行から下へ1セルずつ
                for (int row = Array.IndexOf(data[0], "終着駅作業") + 2; row < data[delete_col].Length; row++)
                {
                    bool over_write = true;
                    
                    if(data[delete_col][row] == "")
                    {   // 空白を上書きしない
                        over_write = false;
                    }
                    else if(data[delete_col- 1][row] != "")
                    {   // 既に値があるセルに上書きしない
                        over_write = false;
                    }

                    if(over_write)
                    {
                        // 右のタイムテーブルを上書き
                        data[delete_col - 1][row] = data[delete_col][row];
                    }
                }
                data.RemoveAt(delete_col);
            }
        }

        /// <summary>
        /// 該当する列車番号の列を抽出する
        /// </summary>
        static private int ExtractTrain(string[][] csv_data, out List<string[]> data, string train_number)
        {
            int count = 0;
            data = new List<string[]>();

            int row = SearchIndexRow(csv_data, "列車番号");

            data.Add(ExtractColumn(csv_data, 0));
            data.Add(ExtractColumn(csv_data, 1));

            for (int i = 0; i < csv_data[row].Length; i++)
            {
                if (csv_data[row][i] == train_number)
                {
                    data.Add(ExtractColumn(csv_data, i));
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 2次元配列から指定した列を1次元配列で取り出す
        /// </summary>
        static private string[] ExtractColumn(string[][] csv_data, int col)
        {
            string[] array = new string[csv_data.Length];

            for(int i = 0; i < array.Length; i++)
            {
                array[i] = csv_data[i][col];
            }

            return array;
        }

        /// <summary>
        /// StaffDataへの変換
        /// </summary>
        static private void ConvMain(List<string[]> data, ref StaffData staff_data, string train_number)
        {
            int row;

            // ------------- 種別の生成 -------------
            staff_data.TrainType = data[2][Array.IndexOf(data[0], "列車種別")];

            // ----------- タイトルの生成 -----------
            staff_data.Titles = new string[5]
            {
                DecideReshaku(train_number),
                "　　列車番号　　" + data[2][Array.IndexOf(data[0], "列車番号")],
                "　　　　種別　　" + staff_data.TrainType,
                "　　　　行先　　" + data[2][Array.IndexOf(data[0], "終着駅")],
                "　　　　備考",
            };

            // -------- タイムテーブルの生成 --------
            staff_data.TimeTables = new List<StaffData.TimeTable>();
            StaffData.TimeTable element = new StaffData.TimeTable();

            // 始発駅作業で入換がある場合、タイムテーブルの最初に設定
            row = Array.IndexOf(data[0], "始発駅作業");
            if(row >= 0)
            {
                if (data[2][row] == "出区")
                {
                    element.ArrivalTime = new string[3] { "", "入", "換" };
                    element.Supplement2 = "入換開始: " + ConvTime(data[2][row + 1]);
                }
            }

            // 終着駅作業の次の次の行から検索を開始する
            row = Array.IndexOf(data[0], "終着駅作業") + 2;
            string previous_label = "";

            for (; row < data[0].Length; row++)
            {
                string station = data[0][row];
                string label = data[1][row];
                string value = data[2][row];

                // 時刻も番線も無い欄はスキップ
                if (value == "") continue;

                // 駅名が変化したときステート変化
                // (駅名がない場合は次の情報(改行)なので更新しない)
                if ((element.Station != station) && (station != ""))
                {
                    // 初めての停車駅・通過駅でなければ蓄積した情報を登録する
                    if (element.Station != "")
                    {
                        // 到着時刻、出発時刻が空のときは空白を登録
                        // (すでに空白があるときは登録しない）
                        if (IsTimeNull(element.ArrivalTime) && IsTimeNull(element.DepatureTime))
                        {
                            element.Station = "";
                            element.Stop = false;
                            if (staff_data.TimeTables.Last().Station != "")
                            {
                                staff_data.TimeTables.Add(element);
                            }
                        }
                        else
                        {
                            // 通過駅の場合は駅名をカッコでくくる
                            if (element.Stop == false)
                            {
                                element.Station = "(" + element.Station + ")";
                            }
                            staff_data.TimeTables.Add(element);
                        }
                        element = new StaffData.TimeTable();
                    }
                    element.Station = station;
                }

                // なんの要素か判断して詰める
                if (label == "番線")
                {
                    element.Supplement1 = value;
                }
                else if (label == "着")
                {
                    if (value == " ﾚ")
                    {
                        element.Stop = false;
                        //element.ArrivalTime = new string[3]{ " ﾚ", "", ""};
                    }
                    else
                    {
                        element.ArrivalTime = ConvHMS(value);
                    }
                }
                else if (label == "発")
                {
                    if (value == " ﾚ")
                    {
                        element.Stop = false;
                        //element.DepatureTime = new string[3] { "", "", "" };
                    }
                    else
                    {
                        element.DepatureTime = ConvHMS(value);
                    }
                }
                else if (label.Length >= 3  && label.Substring(0, 3) == "前作業")
                {
                    // '換'の場合は到着時刻に"入""換"を挿入
                    // さらに右側に"入換開始："を挿入
                    if (value[0] == '換')
                    {
                        element.ArrivalTime = new string[3] { "", "入", "換" };
                        element.Supplement2 = "入換開始: ";
                    }
                }
                else if (label.Length >= 3 && label.Substring(0, 3) == "後作業")
                {
                    // '換'の場合は出発時刻に"入""換"を挿入
                    // さらに右側に"入換開始："を挿入
                    if (value[0] == '換')
                    {
                        element.DepatureTime = new string[3] { "", "入", "換" };
                        element.Supplement2_2 = "入換開始: ";
                    }
                }
                else
                {
                    // 時間の場合は"00:00:00"フォーマットに変換
                    if (IsTime(value))
                    {
                        value = ConvTime(value);
                    }

                    if (previous_label.Substring(0, 3) == "前作業")
                    {
                        element.Supplement2 += value;
                    }
                    else if (previous_label.Substring(0, 3) == "後作業")
                    {
                        element.Supplement2_2 += value;
                    }
                }

                previous_label = label;
            }

            // 最後の要素をテーブルに追加
            staff_data.TimeTables.Add(element);

            // ------------- タイムテーブルのフォーマット -------------

            // 時が前の駅と同じ場合は空白にする(終着駅を除く)
            string h = staff_data.TimeTables[0].DepatureTime[0];
            for (int i = 1; i < staff_data.TimeTables.Count - 1; i++)
            {
                if (staff_data.TimeTables[i].ArrivalTime[0] != "")
                {
                    if (staff_data.TimeTables[i].ArrivalTime[0] == h)
                    {
                        staff_data.TimeTables[i].ArrivalTime[0] = "";
                    }
                    else
                    {
                        h = staff_data.TimeTables[i].ArrivalTime[0];
                    }
                }

                if (staff_data.TimeTables[i].DepatureTime[0] != "")
                {
                    if (staff_data.TimeTables[i].DepatureTime[0] == h)
                    {
                        staff_data.TimeTables[i].DepatureTime[0] = "";
                    }
                    else
                    {
                        h = staff_data.TimeTables[i].DepatureTime[0];
                    }
                }
            }

        }

        /// <summary>
        /// 列番から列車区を判定
        /// </summary>
        static private string DecideReshaku(string train_number)
        {
            if(train_number.Length < 0)
            {
                return "";
            }
            else
            {
                if (train_number[train_number.Length-1] == 'A')
                {
                    return "駒野列車区";
                }
                else
                {
                    return "大道寺列車区";
                }
            }
        }

        /// <summary>
        /// 時間（時分秒の配列）が空かの判定
        /// </summary>
        static private bool IsTimeNull(string[] time)
        {
            bool ret = true;
            if(time.Length == 3)
            {
                for(int i=0; i<3; i++)
                {
                    if (time[i] != "") 
                    {
                        ret = false;
                        break;
                    }
                }
            }
            return ret;
        }

        /// <summary>
        /// 列車番号から数字部分だけを取り出す
        /// </summary>
        static private int Number(string s)
        {
            string digits = Regex.Match(s, @"\d+").Value;
            return Convert.ToInt32(digits);
        }

        /// <summary>
        /// 6桁の数字かを判定
        /// </summary>
        static private bool IsTime(string s)
        {
            return Regex.IsMatch(s, @"^\d{6}$");
        }

        /// <summary>
        /// 6桁の数字を00:00:00フォーマットに変換
        /// </summary>
        static private string ConvTime(string s)
        {
            string ret = s.Substring(0, 2);
            ret += ":" + s.Substring(2, 2);
            ret += ":" + s.Substring(4, 2);
            return ret;
        }

        /// <summary>
        /// 6桁の数字を時分秒の配列に変換
        /// </summary>
        static private string[] ConvHMS(string time)
        {
            string[] ret = new string[3];

            if (time.Length < 6) return ret;
            
            ret[0] = time.Substring(0, 2);
            ret[1] = time.Substring(2, 2);
            ret[2] = time.Substring(4, 2);

            return ret;
        }

        /// <summary>
        /// 指定した要素名がある行インデックスを返す（駅名等を探す用）
        /// </summary>
        /// <param name="name">要素名</param>
        /// <returns></returns>
        static private int SearchIndexRow(string[][] mtdata, string name)
        {
            int ret = -1;
            for (int i = 0; i < mtdata.Length; i++)
            {
                if (mtdata[i][0] == name)
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// 指定した行から、指定した要素名がある列インデックスを返す（列車番号を探す用）
        /// </summary>
        /// <param name="name">要素名</param>
        /// <returns></returns>
        static private int SearchIndexCol(string[][] mtdata, int row, string name)
        {
            int ret = -1;
            for (int i = 0; i < mtdata[0].Length; i++)
            {
                if (mtdata[row][i] == name)
                {
                    ret = i;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// 配列をCSVで保存する
        /// </summary>
        static private void SaveCsv(string[][] data, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
            for(int i = 0; i < data.Length; i++)
            {
                string str = "";
                for(int j = 0; j < data[i].Length; j++)
                {
                    str += data[i][j] + ",";
                }
                sw.WriteLine(str);
            }
            sw.Close();
        }

        /// <summary>
        /// 配列をCSVで保存する
        /// </summary>
        static private void SaveCsv(List<string[]> data, string filename)
        {
            StreamWriter sw = new StreamWriter(filename, false, Encoding.UTF8);
            for (int i = 0; i < data[0].Length; i++)
            {
                string str = "";
                for (int j = 0; j < data.Count; j++)
                {
                    str += data[j][i] + ",";
                }
                sw.WriteLine(str);
            }
            sw.Close();
        }
    }
}
