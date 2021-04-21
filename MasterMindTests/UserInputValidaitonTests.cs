using NUnit.Framework;
using System.Collections.Generic;

namespace MasterMind.Tests
{
    [TestFixture]
    public class UserInputValidaitonTests
    {
        [Test, TestCaseSource(typeof(UserInputTestCases))]
        public void IsUserInputValidTest(string input, bool expected)
        {
            bool actual = UserInputValidaiton.IsUserInputValid(input.ToCharArray());
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(GetInputEvaluationTestCases))]
        public void GetInputEvaluationTest(string input, string randomNum, string expected)
        {
            string actual = UserInputValidaiton.GetInputEvaluation(input.ToCharArray(), randomNum.ToCharArray());
            Assert.AreEqual(expected, actual);
        }


        public class GetInputEvaluationTestCases : List<TestCaseData>
        {
            public GetInputEvaluationTestCases()
            {
                base.AddRange(new[]
                {
                    new TestCaseData("1111", "1111", " +  +  +  + ").SetName("{m}_positive_same_digits"),
                    new TestCaseData("1234", "1234", " +  +  +  + ").SetName("{m}_positive"),
                     new TestCaseData("1234", "1111", " + ").SetName("{m}one_positove"),
                     new TestCaseData("1234", "5111", " - ").SetName("{m}_one_negative"),
                    new TestCaseData("1111", "2222", "").SetName("{m}_no_match"),
                    new TestCaseData("1234", "1553", " +  - ").SetName("{m}_one_negative_one_positive"),
                   });
            }
        }

        public class UserInputTestCases : List<TestCaseData>
        {
            public UserInputTestCases()
            {
                base.AddRange(new[]
                {
                    new TestCaseData("", true).SetName("{m}_positive_empty"),
                    new TestCaseData("abcd", false).SetName("{m}_negative_letters"),
                    new TestCaseData("1ab2", false).SetName("{m}_negative_numbers_letters"),
                    new TestCaseData("1234", true).SetName("{m}_positve"),
                    new TestCaseData("12345", false).SetName("{m}_negative_long"),
                    new TestCaseData("abcdef", false).SetName("{m}_negative_long_letters"),
                    new TestCaseData("ab", false).SetName("{m}_negative_short_letters"),
                    new TestCaseData("134", true).SetName("{m}_positve_short")

                   });
            }
        }
    }
}

