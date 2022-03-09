dotnet-aspnet-codegenerator controller `
-name AccountController `
-m Account `
-dc MySqlContext `
--relativeFolderPath Controllers `
--useDefaultLayout `
--referenceScriptLibraries `
--restWithNoViews

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