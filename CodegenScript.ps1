dotnet-aspnet-codegenerator controller `
-name DeviceController `
-m Device `
-dc MySqlContext `
--relativeFolderPath Controllers `
--useDefaultLayout `
--referenceScriptLibraries `
--restWithNoViews

dotnet-aspnet-codegenerator controller `
-name SensorDataController `
-m SensorData `
-dc MySqlContext `
--relativeFolderPath Controllers `
--useDefaultLayout `
--referenceScriptLibraries `
--restWithNoViews

dotnet-aspnet-codegenerator controller `
-name UserController `
-m User `
-dc MySqlContext `
--relativeFolderPath Controllers `
--useDefaultLayout `
--referenceScriptLibraries `
--restWithNoViews

dotnet-aspnet-codegenerator controller `
-name PlantController `
-m Plant `
-dc MySqlContext `
--relativeFolderPath Controllers `
--useDefaultLayout `
--referenceScriptLibraries `
--restWithNoViews


# New API endpoint
dotnet-aspnet-codegenerator controller `
-name SensorDetailsController `
-dc MySqlContext `
--relativeFolderPath Controllers `
--restWithNoViews