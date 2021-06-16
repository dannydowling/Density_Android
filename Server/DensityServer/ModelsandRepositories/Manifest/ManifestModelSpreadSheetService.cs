using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.Manifest
{
    public class ManifestModelSpreadSheetService
    {
        private HttpClient _httpClient { get; set; }

        public ManifestModelSpreadSheetService(HttpClient httpClient)
        { _httpClient = httpClient; }

        public async Task ClearCellInSpreadsheet(string fileName, string sheetName, string addressName)
        {
            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                  Where(c => c.CellReference == addressName).FirstOrDefault();

                theCell.CellValue.Text = "";

                return;
            }
        }

        public async Task<string> ReplaceCellValueAsync(string fileName, string sheetName, string addressName, string newValue)
        {
            // Retrieve the value of a cell, given a file name, sheet name, 
            // and address name.
            OpenXmlElement value = null;

            using (SpreadsheetDocument document =
                SpreadsheetDocument.Open(fileName, false))
            {
                WorkbookPart wbPart = document.WorkbookPart;
                Sheet theSheet = wbPart.Workbook.Descendants<Sheet>().
                  Where(s => s.Name == sheetName).FirstOrDefault();

                if (theSheet == null)
                {
                    throw new ArgumentException("sheetName");
                }

                WorksheetPart wsPart = (WorksheetPart)(wbPart.GetPartById(theSheet.Id));

                Cell theCell = wsPart.Worksheet.Descendants<Cell>().
                  Where(c => c.CellReference == addressName).FirstOrDefault();


                // The cell will contain a string reference and not the actual value in the cell.
                // I'm hoping that the Sum function will still calculate a total, referencing the string.
                theCell.CellValue.Text = newValue;

                var manifestJson =
                new StringContent(JsonSerializer.Serialize(document), Encoding.UTF8, "application/json");

                await _httpClient.PatchAsync($"/manifests/{0}", manifestJson);
                return value.ToString();
            }

        }
    }
}
