using System;
using System.Linq;

using DigitalLibrary.ControlPanel.DomainModel.Entities;

namespace DigitalLibrary.Utils.ControlPanel.DataSample
{
    using DigitalLibrary.ControlPanel.Ctx;

    public static class ControlPanelDataSample
    {
        public static void Populate(ControlPanelContext ctx)
        {
            AddModules(ctx);
            AddMenusToModules(ctx);
        }

        private static void AddModules(ControlPanelContext ctx)
        {
            Module teamManager = new Module
            {
                Name = "Team Manager",
                Description = "Module for managing teams",
                ModuleRoute = "teammanager",
                IsActive = 1
            };
            ctx.Modules.Add(teamManager);
            ctx.SaveChanges();

            Module moneyTracker = new Module
            {
                Name = "Money Tracker",
                Description = "Module for tracking money",
                ModuleRoute = "money_tracker",
                IsActive = 1
            };
            ctx.Modules.Add(moneyTracker);
            ctx.SaveChanges();

            Module masterData = new Module
            {
                Name = "Master Data",
                Description = "Module for managing Master Data",
                ModuleRoute = "masterdata",
                IsActive = 1
            };
            ctx.Modules.Add(masterData);
            ctx.SaveChanges();

            Module controlPanelModule = new Module
            {
                Name = "Control Panel",
                Description = "Control Panel Module",
                ModuleRoute = "controlpanel",
                IsActive = 1
            };
            ctx.Modules.Add(controlPanelModule);
            ctx.SaveChanges();
        }

        private static void AddMenusToModules(ControlPanelContext ctx)
        {
            AddMenusToControlPanel(ctx);
        }

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
                    ModuleId = controlPanel.Id
                };
                ctx.Menus.Add(modulesListMenu);
                ctx.SaveChanges();

                Menu availableMenusList = new Menu
                {
                    Name = "Menus",
                    Description = "Available menus in the system",
                    IsActive = 1,
                    MenuRoute = "menus",
                    ModuleId = controlPanel.Id
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
                    ModuleId = masterDataModule.Id
                };
                ctx.Menus.Add(dimension);
                ctx.SaveChanges();

                Menu topDimensionStructure = new Menu
                {
                    Name = "Top dimension structures",
                    Description = "Top level dimension structures",
                    IsActive = 1,
                    MenuRoute = "topdimensionstructures",
                    ModuleId = masterDataModule.Id
                };
                ctx.Menus.Add(topDimensionStructure);
                ctx.SaveChanges();

                Menu dimensionStructure = new Menu
                {
                    Name = "Dimension structures",
                    Description = "Dimension structures",
                    IsActive = 1,
                    MenuRoute = "dimensionstructures",
                    ModuleId = masterDataModule.Id
                };
                ctx.Menus.Add(dimensionStructure);
                ctx.SaveChanges();
            }
            else
            {
                throw new NullReferenceException("There is no master data entity!");
            }
        }
    }
}