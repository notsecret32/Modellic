using Modellic.Abstracts;
using Modellic.Enums;
using System;

namespace Modellic.Events
{
    public class FixtureStepBuildStatusChangedEventArgs : EventArgs
    {
        private readonly FixtureStepBase _fixtureStep;

        private readonly FixtureStepBuildStatus _buildStatus;

        public FixtureStepBase FixtureStep => _fixtureStep;

        public FixtureStepBuildStatus BuildStatus => _buildStatus;

        public FixtureStepBuildStatusChangedEventArgs(
            FixtureStepBase fixtureStep, 
            FixtureStepBuildStatus buildStatus
        ) {
            _fixtureStep = fixtureStep;
            _buildStatus = buildStatus;
        }
    }
}
