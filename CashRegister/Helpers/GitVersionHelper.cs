using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Helpers
{
    public static class GitVersionHelper
    {
        public static String GetFullVersionInformation()
        {
            String gitVersion = $"Versie {GitVersionInformation.MajorMinorPatch}";
            if (GitVersionInformation.PreReleaseLabel.ToLower().Equals("beta") || GitVersionInformation.PreReleaseLabel.ToLower().Equals("alpha"))
            {
                gitVersion += $"-{GitVersionInformation.PreReleaseLabel}";
            }
            gitVersion += $" (commit {GitVersionInformation.ShortSha})";

            return gitVersion;
        }

        public static String GetBrancheName()
        {
            String branchename = "";
            if (!GitVersionInformation.BranchName.ToLower().Equals("develop") && !GitVersionInformation.BranchName.ToLower().Equals("master"))
            {
                branchename = $"Branche {GitVersionInformation.BranchName}";
            }

            return branchename;
        }
    }
}
