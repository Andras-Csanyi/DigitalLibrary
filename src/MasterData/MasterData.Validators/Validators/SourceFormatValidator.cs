// <copyright file="SourceFormatValidator.cs" company="Andras Csanyi">
// Copyright (c) Andras Csanyi. All rights reserved.
//  Licensed under MIT.
// </copyright>

namespace DigitalLibrary.MasterData.Validators
{
    using System.Diagnostics.CodeAnalysis;

    using DigitalLibrary.MasterData.DomainModel;

    using FluentValidation;

    /// <summary>
    /// Validator for <see cref="SourceFormat"/> object.
    /// It contains multiple validators which can be utilized by using <see cref="SourceFormatValidatorRulesets"/>.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SourceFormatValidator : AbstractValidator<SourceFormat>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceFormatValidator"/> class.
        /// </summary>
        public SourceFormatValidator()
        {
            RuleSet(SourceFormatValidatorRulesets.Add, () =>
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
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            // RuleSet(SourceFormatValidatorRulesets.AddSourceFormat, () =>
            // {
            //     When(w => w.Name == null || w.Desc == null, () =>
            //     {
            //         RuleFor(e => e.Name).NotNull();
            //         RuleFor(e => e.Desc).NotNull();
            //     });
            //
            //     When(w => w.Name != null && w.Desc != null, () =>
            //     {
            //         RuleFor(p => p.Id).Equal(0);
            //         // RuleFor(p => p.ParentDimensionStructureId).Equal(0);
            //         RuleFor(p => p.Name).NotEmpty().NotEqual(" ");
            //         RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
            //         RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
            //         RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
            //         RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
            //     });
            // });
            RuleSet(SourceFormatValidatorRulesets.Update, () =>
            {
                When(w => w.Name == null || w.Desc == null, () =>
                {
                    RuleFor(e => e.Name).NotNull();
                    RuleFor(e => e.Desc).NotNull();
                });
                When(w => w.Name != null && w.Desc != null, () =>
                {
                    RuleFor(p => p.Id).GreaterThan(0);

                    // RuleFor(p => p.ParentDimensionStructureId).Equal(0);
                    RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Name).NotNull().NotEmpty().NotEqual(" ");
                    RuleFor(p => p.Desc.Length).GreaterThanOrEqualTo(3);
                    RuleFor(p => p.Desc).NotEmpty().NotEqual(" ");
                    RuleFor(p => p.IsActive).GreaterThanOrEqualTo(0).LessThanOrEqualTo(1);
                });
            });

            RuleSet(SourceFormatValidatorRulesets.Delete, () => { RuleFor(p => p.Id).NotEqual(0); });
            RuleSet(SourceFormatValidatorRulesets.GetById, () => { RuleFor(p => p.Id).GreaterThan(0); });
            RuleSet(SourceFormatValidatorRulesets.GetByName, () =>
            {
                RuleFor(p => p.Name).NotNull().NotEmpty();
                RuleFor(p => p.Name.Length).GreaterThanOrEqualTo(3);
            });
        }
    }
}