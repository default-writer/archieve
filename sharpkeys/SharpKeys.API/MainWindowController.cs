namespace SharpKeys.API
{
    public static class MainWindowController
    {
        public static void AddStringMapping(IApplicationState applicationState)
        {
            // max out the mapping at 104
            if (StringMappings.Count >= 104)
            {
                var notyfyDialog = applicationState.CreateMessageBoxDialog("The maximum number of mappings SharpKeys supports is 16.\n\nPlease delete an existing mapping before adding a new one!", "SharpKeys");
                notyfyDialog.Execute();
                return;
            }
            var stringMapping = StringMappings.Instance.Create();
            var dlg = applicationState.CreateAddStringMappingDialog(stringMapping);
            dlg.Execute();
            if (dlg.Succees)
            {
                StringMappings.Instance.Add(stringMapping);
                applicationState.AddStringMapping(stringMapping);
                applicationState.UpdateCurentRegistryBytes();
            }
        }

        public static void EditStringMapping(IApplicationState applicationState)
        {
            var stringMapping = applicationState.StringMapping;
            var dlg = applicationState.CreateEditStringMappingDialog(stringMapping);
            dlg.Execute();
            if (dlg.Succees)
            {
                // update the select mapping item in the list view
                applicationState.UpdateStringMapping(stringMapping);
                applicationState.UpdateCurentRegistryBytes();
            }
        }

        public static void DeleteAllStringMapping(IApplicationState applicationState)
        {
            // Since removing all is a big step, get a confirmation
            var userAccepts = applicationState.UserAcceptsWarningOnDeleteAllMappings();
            if (!userAccepts)
                return;
            StringMappings.Instance.Clear();
            applicationState.DeleteAllStringMappings();
            applicationState.UpdateCurentRegistryBytes();
        }

        public static void DeleteStringMapping(IApplicationState applicationState)
        {
            StringMappings.Instance.Remove(applicationState.StringMapping);
            applicationState.DeleteStringMapping();
            applicationState.UpdateCurentRegistryBytes();
        }

        public static void Load(IApplicationState applicationState)
        {
            applicationState.LoadRegistryBytes();
            foreach (var keymap in StringMappings.KeyMappings)
                applicationState.AddStringMapping(keymap);
        }

        public static void Save(IApplicationState applicationState)
        {
            applicationState.SaveRegistryBytes();
        }
    }
}