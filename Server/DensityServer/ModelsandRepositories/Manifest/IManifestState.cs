using DocumentFormat.OpenXml.Packaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DensityServer.ModelsandRepositories.Manifest.ManifestModel;

namespace DensityServer.ModelsandRepositories.Manifest
{
    public interface IManifestState
    {
        public ManifestModel StartNewManifest(string manifestName);
        public void FinishManifest(SpreadsheetDocument spreadSheet);
        public void queueChange(SpreadsheetDocument spreadSheet, WorksheetPart worksheet);
        public void Change_ManifestState(ManifestState manifestState);

    }


}
