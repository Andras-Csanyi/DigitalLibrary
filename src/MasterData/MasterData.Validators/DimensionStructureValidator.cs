// <copyright file="DimensionStructureValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class DimensionStructureValidator : AbstractValidator<DimensionStructure>
    {
        public DimensionStructureValidator()
        {
            RuleSet(DimensionStructureValidatorRulesets.AddAsync, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });

                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).Equal(0);
                    RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Name.Trim().Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Trim().Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(DimensionStructureValidatorRulesets.Update, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });

                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).NotEqual(0);
                    RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Name.Trim().Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Trim().Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(DimensionStructureValidatorRulesets.Delete, () => { RuleFor(p => p.Id).GreaterThan(0); });
            RuleSet(DimensionStructureValidatorRulesets.GetById,
                () => { RuleFor(p => p.Id).NotEqual(0).GreaterThan(0); });
            RuleSet(DimensionStructureValidatorRulesets.Inactivate, () => { RuleFor(p => p.Id).NotEqual(0); });
        }
    }
}
