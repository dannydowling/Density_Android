using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DensityServer.ModelsandRepositories.Manifest
{
    interface IManifestModelSpreadSheetService
    {
        Task UpdateManifestModel(ManifestModel manifest, WorksheetPart newWorkSheet);
    }
}
