
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOpenXml
{
    public class SpreadSheetHelper
    {
        public static void Make(string saveFile)
           
        {
            string column = "A";
            string[] values = new[] { "1", "2", "3" };
            if (File.Exists(saveFile))
            {
                File.Delete(saveFile);  
            }

            SpreadsheetDocument ssDoc = SpreadsheetDocument.Create(saveFile, SpreadsheetDocumentType.Workbook);

            // Add a WorkbookPart to the document
            WorkbookPart workbookPart = ssDoc.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            // Add a WorksheetPart to theWorkbookPart
            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
           // WorksheetPart worksheetPart2 = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(new SheetData());
            

            Sheets sheets = ssDoc.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());

            Sheet sheet = new Sheet()
            {
                Id = ssDoc.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 1,
                Name = "Sheet111",
               // State =SheetStateValues.VeryHidden
            };

            Sheet sheet2 = new Sheet()
            {
                Id = ssDoc.WorkbookPart.GetIdOfPart(worksheetPart),
                SheetId = 2,
                Name = "Sheet2",
              //  State = SheetStateValues.Hidden
            };

            sheets.Append(sheet);
            sheets.Append(sheet2);

            Worksheet worksheet = new Worksheet();
            SheetData sheetData = new SheetData();
            //Row row = new Row { RowIndex = 1};
           // sheetData.Append(row);

            //Cell cell1 = new Cell()
            //{
            //    CellReference = "A1",
            //    DataType = CellValues.String,
            //    CellValue = new CellValue("Cell1")
            //};
            ////row.Append(cell);

            //Row row2 = new Row { RowIndex =2 };
            //// sheetData.Append(row);

            //Cell cell2 = new Cell()
            //{
            //    CellReference = "A2",
            //    DataType = CellValues.String,
            //    CellValue = new CellValue("Cell1")
            //};

            // row.Append(cell);
            //cell2.InsertAfter(cell2, cell);
            // var cellRef = row.Elements<Cell>().Last();

            //string cellReference = "A1";
            //Cell cell2 = new Cell()
            //{
            //     CellReference = cell.CellReference,
            //    DataType = CellValues.String,
            //    CellValue = new CellValue("Cell2")
            //};

            //Cell refCell = null;
            //foreach (Cell c in row.Elements<Cell>())
            //{
            //    if (string.Compare(c.CellReference.Value, cellReference, true) > 0)
            //    {
            //        refCell = c;
            //        break;
            //    }
            //}

            //Cell newCell = new Cell() { CellReference = cellReference };
            //row.InsertBefore(newCell, refCell);


            //cell.InsertAfterSelf(cell2); 
            // row.InsertAfter(cell2, cellRef);
            // row.Append(cell2);
            //row2.Append(cell2);
          //  row.Append(cell1);
           // sheetData.Append(row);
            ///sheetData.Append(row2); 
            ///
            for(int i = 0; i < values.Length; i++)
            {
                //check if row exists
                uint rowIndex =(uint)i + 1;
                Row row = new Row { RowIndex =  rowIndex};
                var cellReference = column + rowIndex;
                Cell cell = new Cell
                {
                    CellReference = column,
                    CellValue = new CellValue(values[i].ToString()),
                    DataType = CellValues.String
                };

                row.Append(cell);
                sheetData.Append(row);
            }

            worksheet.Append(sheetData);
            worksheetPart.Worksheet = worksheet;
            // Close the document.
            ssDoc.Close();
        }
    }
}
