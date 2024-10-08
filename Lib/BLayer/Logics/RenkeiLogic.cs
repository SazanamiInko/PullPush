﻿using BLayer.DataModels;
using Common;
using Interfaces.DataModel;

namespace BLayer.Logics
{
    /// <summary>
    /// 外部連携ロジック
    /// </summary>
    public class RenkeiLogic : BaseLogic
    {

        /// <summary>
        /// 三井住友銀行のダウンロードファイルを読み込むAPI
        /// </summary>
        /// <returns></returns>
        public List<IPullPush> LoadMituiFile()
        {
            DateTime buf = new DateTime();
            List<IPullPush> ret = new List<IPullPush>();
         
            bool headerflg=true;

            try
            {
                //三井住友銀行ファイルを読み込む
                var lines = File.ReadAllLines(Consts.Paths.MITUIFILE);
                //読みだした内容全件行う
                foreach (string line in lines)
                {
                    string work= line.Replace("\"","");
                    if (headerflg)
                    {
                        headerflg = false;
                        continue;
                    }

                    //CSVを分解する
                    var records = work.Split(",");
                    //入れ物を用意する
                    PullPushDataModel data = new PullPushDataModel();
                    
                    //年月日を分解する
                    buf = Util.convertStrToDateTime(records[Consts.FL.MITUI.DATE]);
                    //年月日
                    data.Year = buf.Year;
                    data.Month = buf.Month;
                    data.Day = buf.Day;
                    //お引出し
                    data.Pull = string.IsNullOrEmpty(records[Consts.FL.MITUI.PULL]) ? 0 : Convert.ToInt64(records[Consts.FL.MITUI.PULL]);
                    //お預入れ
                    data.Push = string.IsNullOrEmpty(records[Consts.FL.MITUI.PUSH]) ? 0 : Convert.ToInt64(records[Consts.FL.MITUI.PUSH]);
                    //取引内容
                    data.Content= records[Consts.FL.MITUI.CONTENT];

                    //メモ
                    data.Memo = records[Consts.FL.MITUI.MEMO];
                    //ラベル
                    data.Label = records[Consts.FL.MITUI.LABEL];
                    //銀行から来たデータ
                    data.FromBank = Consts.Kbn.FromBankKbn.FromBank;
                    //銀行
                    data.Bank = Consts.Kbn.Bank.MITUI;

                    //リストに登録する
                    ret.Add(data);
                }           
            }
            catch
            {

                throw;
            }

            return ret;
        }

        /// <summary>
        /// UFJ銀行のダウンロードファイルを読み込むAPI
        /// </summary>
        /// <returns></returns>
        public List<IPullPush> LoadUFJFile()
        {
            DateTime buf = new DateTime();
            List<IPullPush> ret = new List<IPullPush>();


            //UFJ銀行ファイルを読み込む
            var lines = File.ReadAllLines(Consts.Paths.UFJFILE);

            bool headerflg = true;
            try
            {
                foreach (string line in lines)
                {

                    
                    if (headerflg)
                    {
                        headerflg = false;
                        continue;
                    }

                    string work = line.Replace(",", "")
                                      .Replace("\"\"", ",")
                                      .Replace("\"","");


                    //CSVを分解する
                    var records = work.Split(",");
                    //入れ物を用意する
                    PullPushDataModel data = new PullPushDataModel();

                    //年月日を分解する
                    buf = Util.convertStrToDateTime(records[Consts.FL.UFJ.DATE]);
                    //年月日
                    data.Year = buf.Year;
                    data.Month = buf.Month;
                    data.Day = buf.Day;


                    //お引出し
                    data.Pull = string.IsNullOrEmpty(records[Consts.FL.UFJ.PULL]) ? 0 : Convert.ToInt64(records[Consts.FL.UFJ.PULL]);
                    //お預入れ
                    data.Push = string.IsNullOrEmpty(records[Consts.FL.UFJ.PUSH]) ? 0 : Convert.ToInt64(records[Consts.FL.UFJ.PUSH]);
                    //取引内容
                    data.Content = records[Consts.FL.UFJ.CONTENT];

                    //メモ
                    data.Memo = records[Consts.FL.UFJ.MEMO];

                    //銀行から来たデータ
                    data.FromBank = Consts.Kbn.FromBankKbn.FromBank;
                    //銀行
                    data.Bank = Consts.Kbn.Bank.UFJ;

                    ret.Add(data);
                }
            }
            catch
            {

                throw;
            }

            return ret;
        }
    } 
}
