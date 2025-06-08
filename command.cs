using Exiled.API.Features;
using PlayerRoles;
using CommandSystem;
using System;

namespace ScpSlSuicide
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class SuicideCommand : ICommand
    {
        public string Command { get { return "suicide"; } }
        public string[] Aliases { get { return new string[0]; } }
        public string Description { get { return "Позволяет кильнуться (самоубийство), запрещено для SCP."; } }

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            var commandSender = sender as CommandSender;
            if (commandSender == null)
            {
                response = "Команда доступна только игрокам.";
                return false;
            }

            Player player = Player.Get(commandSender);

            if (player == null || !player.IsAlive)
            {
                response = "Вы должны быть живы, чтобы использовать эту команду.";
                return false;
            }

            var config = SuicidePlugin.Instance?.Config;
            if (config == null || !config.EnableSuicide)
            {
                response = "Самоубийство отключено на этом сервере.";
                return false;
            }
            RoleTypeId role = player.Role.Type;
            if (role == RoleTypeId.Scp049 ||
                role == RoleTypeId.Scp0492 ||
                role == RoleTypeId.Scp079 ||
                role == RoleTypeId.Scp096 ||
                role == RoleTypeId.Scp106 ||
                role == RoleTypeId.Scp173 ||
                role == RoleTypeId.Scp939)
            {
                response = "SCP не могут использовать эту команду!";
                return false;
            }

            player.Kill(config.DeathReason);

            response = config.SuicideMessage;
            return true;
        }
    }
}
