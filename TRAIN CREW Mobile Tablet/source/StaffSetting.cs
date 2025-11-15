using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace tc_staff_draw
{
    /// <summary>
    /// スタフ設定を管理するためのクラス
    /// </summary>
    public partial class StaffSetting
    {
        public string[] OuDiaCsv;
        public string ThemeFile;

        [XmlIgnore]
        public StaffTheme Theme = new StaffTheme();
        [XmlIgnore]
        public bool init = false;

        public StaffSetting() { }

        public StaffSetting(string filename)
        {
            XmlSerializer serializer;
            StreamReader reader;

            // StaffSetting.xml の読み取り
            try 
            {
                serializer = new XmlSerializer(typeof(StaffSetting));
                reader = new StreamReader(filename);
                StaffSetting setting = (StaffSetting)serializer.Deserialize(reader);
                reader.Close();

                if(setting.OuDiaCsv == null || setting.OuDiaCsv.Length <= 0)
                {
                    throw new Exception("パラメータ \'OuDiaCsv\' が null でした。");
                }

                if (setting.ThemeFile == null)
                {
                    throw new Exception("パラメータ \'ThemeFile\' が null でした。");
                }

                OuDiaCsv = setting.OuDiaCsv;
                ThemeFile = setting.ThemeFile;

            }
            catch (Exception ex) 
            {
                string msg = "設定ファイル \'" + filename + "\' の読み込みに失敗しました。\n\n";
                MessageBox.Show(msg + ex.Message);
                return;
            }

            init = true;

            // StaffThemeに記載されたテーマファイルを読み取り
            try
            {
                serializer = new XmlSerializer(typeof(StaffTheme));
                reader = new StreamReader(ThemeFile);
                Theme = (StaffTheme) serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                string msg = "テーマファイル \'" + ThemeFile + "\' の読み込みに失敗しました。\n\n";
                MessageBox.Show(msg + ex.Message);
                return;
            }

        }

    }

}
