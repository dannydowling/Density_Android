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

        public int manifestState { get; set; }

        public bool ready { get; set; }
        public bool changes_pending { get; set; }
        public bool read_only { get; set; }
        public bool write_only { get; set; }
        public bool final { get; set; }      
    }
    public enum StateEnum
    {
        ready,
        changes_pending,
        read_only,
        write_only,
        final
    }
}
