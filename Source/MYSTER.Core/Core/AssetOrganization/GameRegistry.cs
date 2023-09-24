namespace MYSTER.Core
{
    public class GameRegistry
    {
        public AssetRegistry Exile { get; set; }
        public AssetRegistry Revelation { get; set; }

        public GameRegistry()
        {
            Exile = new AssetRegistry();
            Revelation = new AssetRegistry();
        }
    }
}
