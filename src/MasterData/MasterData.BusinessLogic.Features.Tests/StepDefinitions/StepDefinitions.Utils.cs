// <copyright file="SourceFormatFeature.Background.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.BusinessLogic.Features.Tests.StepDefinitions
{
    using TechTalk.SpecFlow;

    public partial class StepDefinitions
    {
        private TType GetValueFromScenarioContext<TType>(string key, ScenarioContext context)
            where TType : class
        {
            return context[key] as TType;
        }
    }
}