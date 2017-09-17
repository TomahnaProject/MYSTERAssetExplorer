using ERAssetExtractor.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace ERAssetExtractor.Services
{
    public class WorkspaceModificationService
    {
        public Workspace Workspace;
        public IUIContext uiContext;

        // temporary hackiness
        public CubeMapImageSet currentSet;

        public WorkspaceModificationService(IUIContext context)
        {
            uiContext = context;
            Workspace = new Workspace();
        }

        public void SetWorkingDirectory(string path)
        {
            if (!Directory.Exists(Path.GetDirectoryName(path)))
                uiContext.WriteToConsole(Color.Red, "The following path is invalid: \"" + path + "\"");
            Workspace.RootDir = Path.GetDirectoryName(path);
            SetSubDirectories();

            PrintListOfNodeFiles();
        }

        private void SetSubDirectories()
        {
            Workspace.SpriteDir = Path.Combine(Workspace.RootDir, "sprites");
            Workspace.NodeDir = Path.Combine(Workspace.RootDir, "nodes");
            Workspace.VideoDir = Path.Combine(Workspace.RootDir, "video");
            Workspace.PanoDir = Path.Combine(Workspace.RootDir, "panoramas");
            Workspace.OtherDir = Path.Combine(Workspace.RootDir, "other");
        }

        public void PrintListOfNodeFiles()
        {
            if (!Directory.Exists(Workspace.NodeDir))
                return;

            var files = Directory.EnumerateFiles(Workspace.NodeDir).ToList();
            for (var i = 0; i < files.Count; i++)
            {
                files[i] = Path.GetFileName(files[i]);
            }
            uiContext.ListFiles(files);
        }

        public void DirectoryCheckWorkspace()
        {
            if (!Directory.Exists(Workspace.SpriteDir))
                Directory.CreateDirectory(Workspace.SpriteDir);
            if (!Directory.Exists(Workspace.NodeDir))
                Directory.CreateDirectory(Workspace.NodeDir);
            if (!Directory.Exists(Workspace.VideoDir))
                Directory.CreateDirectory(Workspace.VideoDir);
            if (!Directory.Exists(Workspace.PanoDir))
                Directory.CreateDirectory(Workspace.PanoDir);
            if (!Directory.Exists(Workspace.OtherDir))
                Directory.CreateDirectory(Workspace.OtherDir);
        }

        public void SortDataFiles()
        {
            DirectoryCheckWorkspace();
            uiContext.WriteToConsole(Color.Gray, "Sorting Data Files...");

            var fileList = Directory.EnumerateFiles(Workspace.RootDir);

            string fileName;
            foreach (var file in fileList)
            {
                fileName = Path.GetFileName(file);
                if (file.Contains(".bik"))
                    File.Move(file, Path.Combine(Workspace.VideoDir, fileName));
                else if (!Utils.FileIsImage(fileName))
                    File.Move(file, Path.Combine(Workspace.OtherDir, fileName));
                else if (NodeFaceValidator.IsNodeImage(Path.Combine(Workspace.RootDir, fileName), NodeFaceValidator.NODE_FACE_SIZE))
                    File.Move(file, Path.Combine(Workspace.NodeDir, fileName));
                else
                    File.Move(file, Path.Combine(Workspace.SpriteDir, fileName));
                uiContext.WriteToConsole(Color.Gray, "Moved " + fileName);
            }

            if (!Directory.EnumerateFiles(Workspace.OtherDir).Any())
            {
                Directory.Delete(Workspace.OtherDir);
            }

            PrintListOfNodeFiles();
            uiContext.WriteToConsole(Color.LimeGreen, "Sorting Completed");
        }
    }
}
