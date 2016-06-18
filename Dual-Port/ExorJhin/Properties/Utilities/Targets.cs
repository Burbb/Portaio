using System.Collections.Generic;
using System.Linq;
using ExorSDK.Utilities;
using LeagueSharp;
using LeagueSharp.SDK;
using EloBuddy;
using LeagueSharp.SDK.Core.Utils;
using EloBuddy.SDK;

namespace ExorSDK.Champions.Jhin
{
    /// <summary>
    ///     The targets class.
    /// </summary>
    internal class Targets
    {
        /// <summary>
        ///     The main hero target.
        /// </summary>
        public static AIHeroClient Target => TargetSelector.GetTarget(Vars.R.Range, DamageType.Physical);

        /// <summary>
        ///     The R targets.
        /// </summary>
        public static List<AIHeroClient> RTargets
            =>
                GameObjects.EnemyHeroes.Where(
                    t =>
                        t.LSIsValidTarget(Vars.R.Range) &&
                        GameObjects.Player.LSIsFacing(t) &&
                        !Invulnerable.Check(t, DamageType.True, false) &&
                        Vars.getCheckBoxItem(Vars.WhiteList2Menu, t.ChampionName.ToLower())).ToList();

        /// <summary>
        ///     The minions target.
        /// </summary>
        public static List<Obj_AI_Minion> Minions
            =>
                GameObjects.EnemyMinions.Where(
                    m =>
                        m.IsMinion() &&
                        m.LSIsValidTarget(Vars.W.Range)).ToList();

        /// <summary>
        ///     The jungle minion targets.
        /// </summary>
        public static List<Obj_AI_Minion> JungleMinions
            =>
                GameObjects.Jungle.Where(
                    m =>
                        m.LSIsValidTarget(Vars.Q.Range) &&
                        !GameObjects.JungleSmall.Contains(m)).ToList();
    }
}