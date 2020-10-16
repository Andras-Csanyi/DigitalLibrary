// <copyright file="MasterDataDimensionValueValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class MasterDataDimensionValueValidator : AbstractValidator<DimensionValue>
    {
        public MasterDataDimensionValueValidator()
        {
            RuleSet(ValidatorRulesets.AddNewDimensionValue, () => { RuleFor(v => v.Id).Equals(0); });

            RuleSet(ValidatorRulesets.ModifyDimensionValue, () => { RuleFor(v => v.Id).NotEqual(0); });
        }
    }
}