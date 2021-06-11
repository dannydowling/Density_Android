using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DensityServer.ModelsandRepositories.Manifest
{
    [Table("manifestModels", Schema = "Manifests")]
    public class ManifestModel : SpreadsheetDocument
    {
        public Guid Id { get; set; }
        public Worksheet[] workSheets { get; set; }
        public SheetData[] workSheetData { get; set; }
        public enum ManifestState
        {
            ready,
            changes_pending,
            read_only,
            write_only,
            final
        }
    }
}
