using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class CSVManager
{

    static public string directory;
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[14] {
        "conditionName",
        "HeadAngularVelocityx",
        "HeadAngularVelocityy",
        "HeadAngularVelocityz",
        "bodyVelocitx",
        "bodyVelocity",
        "bodyVelocitz",
        "bodyOrientationx",
        "bodyOrientationy",
        "bodyOrientationz",
        "headOrientationx",
        "headOrientationy",
        "headOrientationz",
        "collisioncount"
    };
    private static string timeStampHeader = "time stamp";

    #region Interactions

    public static void AppendToReport(string[] strings)
    {
        VerifyDirectory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];
            }
            finalString += reportSeparator + GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport()
    {
        VerifyDirectory();
        
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += reportHeaders[i];
            }
            finalString += reportSeparator + timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    #endregion


    #region Operations

   public static void VerifyDirectory()
    {
        string dir = GetDirectoryPath();
        //Debug.Log(dir);
        directory = dir;
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }

    public static void VerifyFile()
    {
        string file = GetFilePath();
        if (!File.Exists(file))
        {
            CreateReport();
        }
    }

    #endregion


    #region Queries

    static string GetDirectoryPath()
    {
     // return $"/mnt/sdcard/" + reportDirectoryName;
      return Application.dataPath + "/" + reportDirectoryName;
        //

    }

    static string GetFilePath()
    {
        return GetDirectoryPath() + "/" + reportFileName + System.DateTime.Now.ToString("MM_dd_yyyy")+ ".csv";
    }

    static string GetTimeStamp()
    {
        return System.DateTime.UtcNow.ToString();
    }

    #endregion

}
