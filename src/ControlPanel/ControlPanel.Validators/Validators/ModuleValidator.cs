// <copyright file="ModuleValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.ControlPanel.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    using FluentValidation;

    [ExcludeFromCodeCoverage]
    public class ModuleValidator : AbstractValidator<Module>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ModuleValidator" /> class.
        /// </summary>
        public ModuleValidator()
        {
            RuleSet(ValidatorRulesets.AddNew, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");

                When(p => p.ModuleRoute == null, () => { RuleFor(p => p.ModuleRoute).NotNull(); });
                RuleFor(p => p.ModuleRoute).NotEmpty().NotEqual(" ");

                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");

                RuleFor(p => p.Id).Equal(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });

            RuleSet(ValidatorRulesets.Delete, () => { RuleFor(p => p.Id).NotEqual(0); });

            RuleSet(ValidatorRulesets.Modify, () =>
            {
                When(p => p.Name == null, () => { RuleFor(p => p.Name).NotNull(); });
                RuleFor(p => p.Name).NotEmpty().NotEqual(" ");

                When(p => p.ModuleRoute == null, () => { RuleFor(p => p.ModuleRoute).NotNull(); });
                RuleFor(p => p.ModuleRoute).NotEmpty().NotEqual(" ");

                When(p => p.Description == null, () => { RuleFor(p => p.Description).NotNull(); });
                RuleFor(p => p.Description).NotEmpty().NotEqual(" ");

                RuleFor(p => p.Id).NotEqual(0);
                RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            });
        }
    }
}