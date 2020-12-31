// <copyright file="DimensionStructureQueryObjectValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.BusinessLogic.ViewModels;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class DimensionStructureQueryObjectValidator : AbstractValidator<DimensionStructureQueryObject>
    {
        public DimensionStructureQueryObjectValidator()
        {
            RuleSet(
                DimensionStructureQueryObjectValidatorRulesets.GetDimensionStructureByIdOperation,
                () => { RuleFor(r => r.GetDimensionsStructuredById).NotEqual(0); });
        }
    }
}