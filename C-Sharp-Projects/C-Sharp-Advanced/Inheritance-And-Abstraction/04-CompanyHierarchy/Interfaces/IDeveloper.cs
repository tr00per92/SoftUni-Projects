namespace _04_CompanyHierarchy
{
    public interface IDeveloper : IRegularEmployee
    {
        void AddProject(Project project);

        void RemoveProject(Project project);
    }
}