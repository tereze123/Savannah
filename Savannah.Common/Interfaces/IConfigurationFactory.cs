namespace Savannah.Common
{
    public interface IConfigurationFactory
    {
        int GetFieldSizeFromConfigurationFile();
        int GetOffsetFromLeftSideFromConfigurationFile();
        int GetOffsetFromTopFromConfigurationFile();
    }
}