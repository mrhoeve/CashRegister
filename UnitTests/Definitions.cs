using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class Definitions
    {
        // Testing passwords
        public const string TEST_PASSWORD_WITHOUTNUMERALS = "ABCDefgh";
        public const string TEST_PASSWORD_WITHOUTUPPERCASE = "abcd1234";
        public const string TEST_PASSWORD_WITHOUTLOWERCASE = "ABCD1234";
        public const string TEST_PASSWORD_TOOSHORT = "ABCdef1";
        public const string TEST_PASSWORD_VALID = "ABCdef12";
    }
}
