namespace SharpKeys.RuntimeComponent.API
{
    public interface IApplicationState
    {
        StringMapping StringMapping { get; }

        void AddStringMapping(StringMapping stringMapping);

        void DeleteAllStringMappings();

        IUserAction CreateAddStringMappingDialog(StringMapping stringMapping);

        void DeleteStringMapping();

        IUserAction CreateMessageBoxDialog(string text, string caption);

        void UpdateStringMapping(StringMapping stringMapping);

        void LoadRegistryBytes();

        void SaveRegistryBytes();

        void UpdateCurentRegistryBytes();

        bool UserAcceptsWarningOnDeleteAllMappings();

        IUserAction CreateEditStringMappingDialog(StringMapping stringMapping);
    }
}