using MYSTER.Core;
using System.Linq;

namespace MYSTER.Services
{
    public class RegistryManager
    {
        public GameRegistry Registry { get; set; }

        public RegistryManager()
        {
            Registry = new GameRegistry();
        }

        public AssetRegistry GetCorrectRegistry(GameEnum game)
        {
            AssetRegistry reg;
            switch (game)
            {
                case GameEnum.Exile:
                    reg = Registry.Exile;
                    break;
                case GameEnum.Revelation:
                    reg = Registry.Revelation;
                    break;
                default:
                    reg = Registry.Exile;
                    break;
            }
            return reg;
        }

        public void AddNode(GameEnum game, Node node)
        {
            var reg = GetCorrectRegistry(game);
            reg.AddNode(node);
        }

        public void RemoveNode(GameEnum game, Node node)
        {
            var reg = GetCorrectRegistry(game);
            Node match = reg.Nodes.Where(x =>
                x.Scene == node.Scene &&
                x.Zone == x.Zone &&
                x.Number == node.Number).FirstOrDefault();
            reg.Nodes.Remove(match);
        }

        public AssetRegistry CreateFakeRegistry()
        {
            var registry = new AssetRegistry();
            var node01 = new Node();
            node01.Scene = "Amateria";
            node01.Zone = "TO";
            node01.Number = "010";

            var cubeMap = new CubeMapImageSet();
            cubeMap.Back.File = "0001.jpg";
            cubeMap.Bottom.File = "0002.jpg";
            cubeMap.Front.File = "0003.jpg";
            cubeMap.Left.File = "0004.jpg";
            cubeMap.Right.File = "0005.jpg";
            cubeMap.Top.File = "0006.jpg";
            node01.CubeMap = cubeMap;

            registry.Nodes.Add(node01);
            return registry;
        }
    }
}
