using Exiled.API.Features;
using System;

namespace ScpSlSuicide
{
    public class SuicidePlugin : Plugin<SuicideConfig>
    {
        public override string Author => "zazarick";
        public override string Name => "Suicide";
        public override string Prefix => "suicide";
        public override Version RequiredExiledVersion => new Version(8, 6, 0);

        public static SuicidePlugin Instance { get; private set; }

        public override void OnEnabled()
        {
            Instance = this;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            base.OnDisabled();
            Instance = null;
        }
    }
}
