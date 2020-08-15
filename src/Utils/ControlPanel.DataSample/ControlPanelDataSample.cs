// <copyright file="ControlPanelDataSample.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace DigitalLibrary.Utils.ControlPanel.DataSample
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using DigitalLibrary.ControlPanel.Ctx.Ctx;
    using DigitalLibrary.ControlPanel.DomainModel.Entities;

    [SuppressMessage("ReSharper", "CA1303")]
    [SuppressMessage("ReSharper", "CA1307")]
    public static class ControlPanelDataSample
    {
        private static void AddMenusToControlPanel(ControlPanelContext ctx)
        {
            Module controlPanel = ctx.Modules.FirstOrDefault(d => d.Name.Equals("Control Panel"));

            if (controlPanel != null)
            {
                Menu modulesListMenu = new Menu
                {
                    Name = "Modules",
                    Description = "Available modules in the system",
                    IsActive = 1,
                    MenuRoute = "modules",
                    ModuleId = controlPanel.Id,
                };
                ctx.Menus.Add(modulesListMenu);
                ctx.SaveChanges();

                Menu availableMenusList = new Menu
                {
                    Name = "Menus",
                    Description = "Available menus in the system",
                    IsActive = 1,
                    MenuRoute = "menus",
                    ModuleId = controlPanel.Id,
                };
                ctx.Menus.Add(availableMenusList);
                ctx.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("There is no controlpanel entity");
            }

            Module masterDataModule = ctx.Modules.FirstOrDefault(d => d.Name.Equals("Master Data"));

            if (masterDataModule != null)
            {
                Menu dimension = new Menu
                {
                    Name = "Dimension",
                    Description = "Dimensions in the system",
                    IsActive = 1,
                    MenuRoute = "dimension",
                    ModuleId = masterDataModule.Id,
                };
                ctx.Menus.Add(dimension);
                ctx.SaveChanges();

                Menu topDimensionStructure = new Menu
                {
                    Name = "Source formats",
                    Description = "Source formats description",
                    IsActive = 1,
                    MenuRoute = "sourceformats",
                    ModuleId = masterDataModule.Id,
                };
                ctx.Menus.Add(topDimensionStructure);
                ctx.SaveChanges();

                Menu dimensionStructure = new Menu
                {
                    Name = "Dimension structures",
                    Description = "Dimension structures",
                    IsActive = 1,
                    MenuRoute = "dimensionstructures",
                    ModuleId = masterDataModule.Id,
                };
                ctx.Menus.Add(dimensionStructure);
                ctx.SaveChanges();

                Menu documentBuilder = new Menu
                {
                    Name = "SourceFormat Builder",
                    Description = "SourceFormat Builder",
                    IsActive = 1,
                    MenuRoute = "sourceformatbuilder",
                    ModuleId = masterDataModule.Id,
                };
                ctx.Menus.Add(documentBuilder);
                ctx.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("There is no master data entity!");
            }
        }

        private static void AddMenusToModules(ControlPanelContext ctx)
        {
            AddMenusToControlPanel(ctx);
        }

        private static void AddModules(ControlPanelContext ctx)
        {
            Module teamManager = new Module
            {
                Name = "Team Manager",
                Description = "Module for managing teams",
                ModuleRoute = "teammanager",
                IsActive = 1,
            };
            ctx.Modules.Add(teamManager);
            ctx.SaveChanges();

            Module moneyTracker = new Module
            {
                Name = "Money Tracker",
                Description = "Module for tracking money",
                ModuleRoute = "money_tracker",
                IsActive = 1,
            };
            ctx.Modules.Add(moneyTracker);
            ctx.SaveChanges();

            Module masterData = new Module
            {
                Name = "Master Data",
                Description = "Module for managing Master Data",
                ModuleRoute = "masterdata",
                IsActive = 1,
            };
            ctx.Modules.Add(masterData);
            ctx.SaveChanges();

            Module controlPanelModule = new Module
            {
                Name = "Control Panel",
                Description = "Control Panel Module",
                ModuleRoute = "controlpanel",
                IsActive = 1,
            };
            ctx.Modules.Add(controlPanelModule);
            ctx.SaveChanges();
        }

        public static void Populate(ControlPanelContext ctx)
        {
            if (ctx != null)
            {
                AddModules(ctx);
                AddMenusToModules(ctx);
            }
        }
    }
}