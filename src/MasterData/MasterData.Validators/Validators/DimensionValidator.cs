// <copyright file="DimensionValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;
    using DigitalLibrary.MasterData.DomainModel;
    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class DimensionValidator : AbstractValidator<Dimension>
    {
        public DimensionValidator()
        {
            RuleSet(ValidatorRulesets.AddNewDimension, () =>
            {
                When(p => p.Name == null || p.Description == null, () =>
                {
                    RuleFor(p => p.Name).NotNull();
                    RuleFor(p => p.Description).NotNull();
                });

                When(p => p.Name != null && p.Description != null, () =>
                {
                    RuleFor(p => p.Id).Equal(0);
                    RuleFor(p => p.Name).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Description).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Description.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(ValidatorRulesets.UpdateDimension, () =>
            {
                When(p => p.Name == null || p.Description == null, () =>
                {
                    RuleFor(p => p.Name).NotNull();
                    RuleFor(p => p.Description).NotNull();
                });

                When(p => p.Name != null && p.Description != null, () =>
                {
                    RuleFor(p => p.Id).GreaterThan(0);
                    RuleFor(p => p.Name).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Description).NotEmpty().NotNull().NotEqual(" ");
                    RuleFor(p => p.Description.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(ValidatorRulesets.DeleteDimension, () => { RuleFor(p => p.Id).GreaterThan(0); });
        }
    }
}