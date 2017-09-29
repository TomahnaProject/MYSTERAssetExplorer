using MYSTERAssetExplorer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MYSTERAssetExplorer.Services
{
    public interface IFileIndexerService
    {
        IVirtualFolder IndexFile(string filePath);
    }
}
