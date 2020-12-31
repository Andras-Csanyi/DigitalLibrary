// <copyright file="DimensionStructureDimensionStructureValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class DimensionStructureDimensionStructureValidator : AbstractValidator<DimensionStructureNode>
    {
        public DimensionStructureDimensionStructureValidator()
        {
            RuleSet(DimensionStructureDimensionStructureValidatorRulesets.Add, () =>
            {
                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.DimensionStructureId).GreaterThan(0);
            });
        }
    }
}