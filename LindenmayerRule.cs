namespace Curves
{
    public class LindenmayerRule
    {
        public static LindenmayerRules[,] UseRule(LindenmayerRules rule)
        {
            LindenmayerRules[,] ruleSet = new LindenmayerRules[2, 2];
            if (rule == LindenmayerRules.A)
            {
                ruleSet[0, 0] = LindenmayerRules.A;
                ruleSet[0, 1] = LindenmayerRules.A;
                ruleSet[1, 0] = LindenmayerRules.D;
                ruleSet[1, 1] = LindenmayerRules.C;
            }
            else if (rule == LindenmayerRules.B)
            {
                ruleSet[0, 0] = LindenmayerRules.B;
                ruleSet[0, 1] = LindenmayerRules.C;
                ruleSet[1, 0] = LindenmayerRules.B;
                ruleSet[1, 1] = LindenmayerRules.A;
            }
            else if (rule == LindenmayerRules.C)
            {
                ruleSet[0, 0] = LindenmayerRules.D;
                ruleSet[0, 1] = LindenmayerRules.B;
                ruleSet[1, 0] = LindenmayerRules.C;
                ruleSet[1, 1] = LindenmayerRules.C;
            }
            else if (rule == LindenmayerRules.D)
            {
                ruleSet[0, 0] = LindenmayerRules.C;
                ruleSet[0, 1] = LindenmayerRules.D;
                ruleSet[1, 0] = LindenmayerRules.A;
                ruleSet[1, 1] = LindenmayerRules.D;
            }

            return ruleSet;
        }
    }
}
