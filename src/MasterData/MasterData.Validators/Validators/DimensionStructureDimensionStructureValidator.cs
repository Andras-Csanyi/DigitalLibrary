// <copyright file="DimensionStructureDimensionStructureValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    public class DimensionStructureDimensionStructureValidator : AbstractValidator<DimensionStructureDimensionStructure>
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