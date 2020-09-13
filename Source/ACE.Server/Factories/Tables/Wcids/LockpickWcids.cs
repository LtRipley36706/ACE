using ACE.Server.Factories.Entity;
using ACE.Server.Factories.Enum;

namespace ACE.Server.Factories.Tables.Wcids
{
    public static class LockpickWcids
    {
        private static readonly ChanceTable<WeenieClassName> T1_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.75f ),
            ( WeenieClassName.lockpickreliable, 0.25f ),
            ( WeenieClassName.lockpickgood,     0.00f ),
            ( WeenieClassName.lockpickexcell,   0.00f ),
            ( WeenieClassName.lockpicksuperb,   0.00f ),
            ( WeenieClassName.lockpickpeer,     0.00f ),
        };

        private static readonly ChanceTable<WeenieClassName> T2_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.25f ),
            ( WeenieClassName.lockpickreliable, 0.50f ),
            ( WeenieClassName.lockpickgood,     0.25f ),
            ( WeenieClassName.lockpickexcell,   0.00f ),
            ( WeenieClassName.lockpicksuperb,   0.00f ),
            ( WeenieClassName.lockpickpeer,     0.00f ),
        };

        private static readonly ChanceTable<WeenieClassName> T3_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.00f ),
            ( WeenieClassName.lockpickreliable, 0.25f ),
            ( WeenieClassName.lockpickgood,     0.50f ),
            ( WeenieClassName.lockpickexcell,   0.25f ),
            ( WeenieClassName.lockpicksuperb,   0.00f ),
            ( WeenieClassName.lockpickpeer,     0.00f ),
        };

        private static readonly ChanceTable<WeenieClassName> T4_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.00f ),
            ( WeenieClassName.lockpickreliable, 0.00f ),
            ( WeenieClassName.lockpickgood,     0.25f ),
            ( WeenieClassName.lockpickexcell,   0.50f ),
            ( WeenieClassName.lockpicksuperb,   0.25f ),
            ( WeenieClassName.lockpickpeer,     0.00f ),
        };

        private static readonly ChanceTable<WeenieClassName> T5_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.00f ),
            ( WeenieClassName.lockpickreliable, 0.00f ),
            ( WeenieClassName.lockpickgood,     0.00f ),
            ( WeenieClassName.lockpickexcell,   0.25f ),
            ( WeenieClassName.lockpicksuperb,   0.50f ),
            ( WeenieClassName.lockpickpeer,     0.25f ),
        };

        private static readonly ChanceTable<WeenieClassName> T6_Chances = new ChanceTable<WeenieClassName>()
        {
            ( WeenieClassName.lockpickplain,    0.00f ),
            ( WeenieClassName.lockpickreliable, 0.00f ),
            ( WeenieClassName.lockpickgood,     0.00f ),
            ( WeenieClassName.lockpickexcell,   0.00f ),
            ( WeenieClassName.lockpicksuperb,   0.25f ),
            ( WeenieClassName.lockpickpeer,     0.75f ),
        };
    }
}
