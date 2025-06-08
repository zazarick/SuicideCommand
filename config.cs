using Exiled.API.Interfaces;
using System.ComponentModel;

namespace ScpSlSuicide
{
    public class SuicideConfig : IConfig
    {
        [Description("Включить/отключить плагин")]
        public bool IsEnabled { get; set; } = true;

        [Description("Включить debug-вывод")]
        public bool Debug { get; set; } = false;

        [Description("Разрешить ли самоубийство (через команду .suicide)?")]
        public bool EnableSuicide { get; set; } = true;

        [Description("Сообщение игроку после самоубийства")]
        public string SuicideMessage { get; set; } = "Вы совершили самоубийство.";

        [Description("Причина, которая появляется в логах сервера при смерти (Kill reason)")]
        public string DeathReason { get; set; } = "Самоубийство через .suicide";
    }
}
