using OfficeOpenXml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ExcelParse : MonoBehaviour
{
    ArrayList list = new ArrayList();
    // Start is called before the first frame update
    void Start()
    {
        //CreateExcel();
        LoadExcel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            System.Random rd = new System.Random();
            print(list[rd.Next(0, list.Count)]);
        }
    }
    void CreateExcel()
    {
        string OutPutDir = Application.dataPath + "/MyExcel.xls";
        FileInfo newFile = new FileInfo(OutPutDir);
        if (newFile.Exists)
        {
            newFile.Delete();
            newFile = new FileInfo(OutPutDir);
        }//如果已有则删除
        using (ExcelPackage package = new ExcelPackage(newFile))
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("第一个Sheet");
            workSheet.Cells[1, 1].Value = "序号";
            workSheet.Cells[1, 2].Value = "姓名";
            workSheet.Cells[1, 3].Value = "电话";
            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "张三";
            workSheet.Cells[2, 3].Value = "15826313047";
            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "李四";
            workSheet.Cells[3, 3].Value = "15826313048";
            package.Save();
        }
        AssetDatabase.Refresh();
    }
    void LoadExcel()
    {        
        string OutPutDir = Application.dataPath + "/nick2.xlsx";
        print("来了");
        using (ExcelPackage package = new ExcelPackage(new FileStream(OutPutDir, FileMode.Open, FileAccess.Read)))
        {
            print(package.Workbook.Worksheets.Count);
            for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
            {

                ExcelWorksheet sheet = package.Workbook.Worksheets[i];
                for (int j = sheet.Dimension.Start.Column, k = sheet.Dimension.End.Column; j <= k; j++)
                {
                    for (int m = sheet.Dimension.Start.Row, n = sheet.Dimension.End.Row; m <= n; m++)
                    {
                        string value = sheet.GetValue(m, j).ToString();
                        if (value != null)
                            list.Add(value);
                    }
                }
            }
        }
    }
}
