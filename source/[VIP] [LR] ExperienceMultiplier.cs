using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Capabilities;
using CounterStrikeSharp.API.Modules.Admin;
using LevelsRanksApi;
namespace VIP_ExperienceMultiplier;

public class VipExperienceMultiplier : BasePlugin
{
    public override string ModuleAuthor => "Letaryat";
    public override string ModuleDescription => "Modified plugin CS2-VIP-LR-ExperienceMultiplier to multiply experience for C# LR when player has specific flag";
    public override string ModuleName => "[VIP-Plugin] Experience Multiplier";
    public override string ModuleVersion => "v1.0.0";


    private ExperienceMultiplier? _experienceMultiplier;

    private PluginCapability<ILevelsRanksApi> LevelsRanksCapability { get; } = new("levels_ranks");

    public override void OnAllPluginsLoaded(bool hotReload)
    {
        var levelsRanksApi = LevelsRanksCapability.Get();

    }

}

public class ExperienceMultiplier 
{
    private readonly ILevelsRanksApi _levelsRanksApi;


    public ExperienceMultiplier(ILevelsRanksApi levelsRanksApi)
    {
        _levelsRanksApi = levelsRanksApi;
    }

    public void OnPlayerSpawn(CCSPlayerController player)
    {
        if (AdminManager.PlayerInGroup(player, "@vip-plugin/vip"))
        {
        var steamId = player.SteamID.ToString();
        _levelsRanksApi.SetExperienceMultiplier(steamId, 1.5);
        }
        /*
        if (!PlayerHasFeature(player)) return;
        if (GetPlayerFeatureState(player) is not IVipCoreApi.FeatureState.Enabled) return;
        if (multiplier <= 0) return;
        *?
        _levelsRanksApi.SetExperienceMultiplier(steamId, multiplier);
        */
    }
}
