using ERAssetExtractor.Core;
using ERAssetExtractor.Services;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace ERAssetExtractor.App
{
    public class ERAssetExtractorApp2
    {
        WorkspaceModificationService workspaceModServ;
        RegistryManager registryManager;

        public ERAssetExtractorApp2(IUIContext context)
        {
            workspaceModServ = new WorkspaceModificationService(context);
            registryManager = new RegistryManager(context);
        }

        public Workspace GetWorkspace()
        {
            return workspaceModServ.Workspace;
        }

        public CubeMapImageSet GetCurrentSet() // hackiness
        {
            return workspaceModServ.currentSet;
        }
        public void SetCurrentSet(CubeMapImageSet imageSet) // hackiness
        {
            workspaceModServ.currentSet = imageSet;
        }

        public void SetWorkingDirectory(string path)
        {
            workspaceModServ.SetWorkingDirectory(path);
        }

        public void SortDataFiles()
        {
            workspaceModServ.SortDataFiles();
        }
    }
}
