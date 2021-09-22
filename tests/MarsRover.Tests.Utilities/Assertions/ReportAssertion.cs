using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace MarsRover.Tests.Utilities.Assertions
{
    public class ReportAssertion: ReferenceTypeAssertions<string, ReportAssertion>
    {
        public ReportAssertion(string instance)
        {
            this.Subject = instance;
        }

        public AndConstraint<ReportAssertion> SignalsItsPositionAt(int x, int y)
        {
            Execute.Assertion.Given(() => Subject)
                .ForCondition(report => !string.IsNullOrEmpty(report))
                .ForCondition(report => report.Contains($"{x}:{y}:"))
            ;

            return new AndConstraint<ReportAssertion>(this);
        }

        protected override string Identifier => "report";
    }

    public static class ReportExtension
    {
        public static ReportAssertion Should(this string instance)
        {
            return new ReportAssertion(instance);
        }
    }
}
